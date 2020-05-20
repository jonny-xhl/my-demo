using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Jonny.AllDemo.MISPOS
{
    public class MisPosRequest
    {
        /// <summary>
        /// 00-银行卡
        ///01-有硬件POS通
        ///02-无硬件POS通
        /// </summary>
        [Length(2)]
        [Index(1)]
        public string 应用类型 { get; set; }

        /// <summary>
        /// 不足8位时右补空格
        /// </summary>
        [Length(8)]
        [Index(2)]
        public string POS机号 { get; set; }

        /// <summary>
        /// 不足8位时右补空格
        /// </summary>
        [Length(8)]
        [Index(3)]
        public string POS员工号 { get; set; }

        /// <summary>
        /// =====================================
        /// 银行卡
        /// 00－消费              01－撤消
        /// 02－退货              03－查余
        /// 04－重打印            05－签到
        /// 06－结算              07－重打结算单
        /// 21－预授权            23－预授权完成
        /// 25－预授权撤销        26－预授权完成撤销
        /// 30－营销联盟银行卡积分消费
        /// 31－银联钱包优惠券消费 
        /// 32－银联钱包积分消费
        /// 33－银联钱包积分撤销
        /// 34－银联钱包优惠券撤销
        /// 35－银联钱包优惠券退货
        /// 36－银联钱包积分退货
        /// =====================================
        /// 有硬件POS通B扫C
        /// 00－消费              01－撤消
        /// 02－退货              03－结果查询
        /// 04－重打印            05－签到
        /// 06－结算              07－重打结算单
        /// =====================================
        /// 无硬件POS通
        /// 00－B2C消费          01－B2C撤消
        /// 02－B2C退货          04－B2C结果查询
        /// 05－B2C签到          06－B2C结算
        /// 31－B2C担保          32－B2C快速担保撤销
        /// 33－B2C快速担保完成   
        /// 10－C2B获取二维码    11－C2B交易查询
        /// 12－C2B关闭订单      13－C2B退货
        /// 14－C2B申请担保二维码
        /// 15－C2B查询担保交易状态
        /// 16－C2B担保撤销      17－C2B担保完成
        /// 注：
        /// ERP系统开发查询接口尽可能避免长款，且结果查询交易必须同时判断[返回码] 和[查询结果状态]；
        /// </summary>
        [Length(2)]
        [Index(4)]
        public string 交易类型标志 { get; set; }

        /// <summary>
        /// 无小数点"."，单位为分，不足时12位左补0
        /// </summary>
        [Length(12)]
        [PadingLeft]
        [Index(5)]
        public string 金额 { get; set; }

        /// <summary>
        /// 部分应用退货及预授权类交易使用YYYYMMDD
        /// </summary>
        [Length(8)]
        [Index(6)]
        public string 原交易日期 { get; set; }

        /// <summary>
        /// 部分应用退货交易使用，其他空格填充
        /// </summary>
        [Length(12)]
        [Index(7)]
        public string 原交易参考号 { get; set; }

        /// <summary>
        /// 部分应用撤销交易使用，其他空格填充
        /// </summary>
        [Length(6)]
        [Index(8)]
        public string 原凭证号 { get; set; }

        /// <summary>
        /// 3位随机数字
        /// </summary>
        [Length(3)]
        [Index(9)]
        public string LRC校验 { get; set; }

        /// <summary>
        /// 消费时支付串码，右补空格
        /// </summary>
        [Length(50)]
        [Index(10)]
        public string 串码 { get; set; }

        /// <summary>
        ///         银商后台生成。
        ///部分应用撤销，退货和查询时使用，右补空格
        /// </summary>
        [Length(50)]
        [Index(11)]
        public string 银商订单号 { get; set; }

        /// <summary>
        /// ERP系统生成唯一标识，可用于对账。
        ///部分应用查询时【银商订单号】和【ERP订单号】必须传入一个，两者皆传入则以ERP订单号为准。比如YYYYMMDDhhmmss+随机数
        /// </summary>
        [Length(50)]
        [Index(12)]
        public string ERP订单号 { get; set; }

        /// <summary>
        /// 二维码ID(C2B关闭二维码)
        /// </summary>
        [Length(32)]
        [Index(13)]
        public string 无硬件C扫B二维码ID { get; set; }

        /// <summary>
        /// ERP传入APPIDKEY加密后的密文
        /// 银行卡交易没有该参数
        /// </summary>
        //[Length(300)]
        //[Index(14)]
        //public string 无硬件APPIDKEY { get; set; }

        public override string ToString()
        {
            var type = GetType();
            var properties = type.GetProperties(System.Reflection.BindingFlags.Public)
                .OrderBy(p => funOrderProperty);
            LengthAttribute lengthAttribute;
            PadingLeftAttribute padingLeftAttribute;
            StringBuilder builder = new StringBuilder();
            foreach (var item in properties)
            {
                //字符串长度
                lengthAttribute = item.GetCustomAttributes(typeof(LengthAttribute), false).FirstOrDefault() as LengthAttribute;
                //出现一个属性未知长度的时候直接返回空
                if (lengthAttribute == null)
                {
                    return string.Empty;
                }
                //为空默认为右填充
                padingLeftAttribute = item.GetCustomAttributes(typeof(PadingLeftAttribute), false).FirstOrDefault() as PadingLeftAttribute;
                var value = item.GetValue(this, null) == null ? "" : item.GetValue(this, null).ToString();
                if (padingLeftAttribute == null)
                {
                    builder.Append(value.PadRight(lengthAttribute.Len, ' '));
                }
                else
                {
                    builder.Append(value.PadLeft(lengthAttribute.Len, ' '));
                }
            }
            return builder.ToString();
        }
        Func<PropertyInfo, int> funOrderProperty = (p) =>
        {
            var indexAttr = p.GetCustomAttributes(typeof(IndexAttribute), false).FirstOrDefault() as IndexAttribute;
            if (indexAttr == null)
            {
                return 1;
            }
            return indexAttr.Index;
        };

    }
}
