using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.MISPOS
{
    public class MisPosResponse
    {
        public MisPosResponse()
        {

        }
        public MisPosResponse(string code, string error)
        {
            返回码 = code;
            错误说明 = error;
        }
        /// <summary>
        /// 00 表示成功，其它表示失败
        /// </summary>
        [Length(2)]
        [Index(1)]
        public string 返回码 { get; set; }

        /// <summary>
        /// 银行卡应用返回银行行号
        ///有硬件pos通,支付宝返回[0ZFB]，微信返回[WXZF]，云闪付返回[YLSM]
        ///其他返回空格
        /// </summary>
        [Length(4)]
        [Index(2)]
        public string 银行行号 { get; set; }

        /// <summary>
        /// 银行卡应用返回前六后四屏蔽后卡号，其他应用空格填充
        /// </summary>
        [Length(20)]
        [Index(3)]
        public string 卡号 { get; set; }

        /// <summary>
        /// 原交易凭证号，部分应用撤销和查询交易使用
        /// </summary>
        [Length(6)]
        [Index(4)]
        public string 凭证号 { get; set; }

        /// <summary>
        /// 持卡人实付金额，无硬件pos通B扫C撤销交易返回原交易金额
        /// </summary>
        [Length(12)]
        [Index(5)]
        public string 实付金额 { get; set; }

        /// <summary>
        /// 中文解释
        /// </summary>
        [Length(40)]
        [Index(6)]
        public string 错误说明 { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Length(15)]
        [Index(7)]
        public string 商户号 { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [Length(8)]
        [Index(8)]
        public string 终端号 { get; set; }

        /// <summary>
        /// 查询交易返回原交易批次号
        /// </summary>
        [Length(6)]
        [Index(9)]
        public string 批次号 { get; set; }

        /// <summary>
        /// 查询交易返回原交易日期
        /// MMDD
        /// </summary>
        [Length(4)]
        [Index(10)]
        public string 交易日期 { get; set; }

        /// <summary>
        /// 查询交易返回原交易时间
        /// hhmmss
        /// </summary>
        [Length(6)]
        [Index(12)]
        public string 交易时间 { get; set; }

        /// <summary>
        /// 查询交易返回原交易参考号
        /// </summary>
        [Length(12)]
        [Index(13)]
        public string 交易参考号 { get; set; }

        /// <summary>
        /// 预授权与担保类交易返回，其他交易空格填充
        /// </summary>
        [Length(6)]
        [Index(14)]
        public string 授权号 { get; set; }

        /// <summary>
        /// 空格填充
        /// MMDD
        /// </summary>
        [Length(4)]
        [Index(15)]
        public string 清算日期 { get; set; }

        /// <summary>
        /// 空格填充
        /// </summary>
        [Length(3)]
        [Index(16)]
        public string LRC校验 { get; set; }

        /// <summary>
        /// 优惠金额=原金额-实付金额
        /// </summary>
        [Length(12)]
        [Index(17)]
        public string 优惠金额 { get; set; }

        /// <summary>
        /// 00贷记  01借记  02准贷记
        /// </summary>
        [Length(2)]
        [Index(18)]
        public string 卡类型 { get; set; }

        /// <summary>
        /// 第三方优惠说明
        /// </summary>
        [Length(200)]
        [Index(19)]
        public string 第三方优惠说明 { get; set; }

        /// <summary>
        /// 第三方平台
        /// </summary>
        [Length(50)]
        [Index(20)]
        public string 第三方平台 { get; set; }

        /// <summary>
        /// 消费返回
        /// </summary>
        [Length(50)]
        [Index(21)]
        public string 银商订单号 { get; set; }

        /// <summary>
        /// 空格填充
        /// </summary>
        [Length(50)]
        [Index(22)]
        public string ERP订单号 { get; set; }

        /// <summary>
        /// 支付方式  0：支付宝 1：微信  2：银联钱包  3：其他
        /// </summary>
        [Length(1)]
        [Index(23)]
        public string 支付方式 { get; set; }

        /// <summary>
        /// 查询交易返回
        /// 0：成功
        /// 1：超时
        /// 2：已撤销
        /// 3：已退货
        /// 4：已冲正
        /// 5：失败
        /// 其他：未知错误
        /// </summary>
        [Length(1)]
        [Index(24)]
        public string 查询结果状态 { get; set; }

        /// <summary>
        /// 查询交易返回原交易状态描述
        /// </summary>
        [Length(50)]
        [Index(25)]
        public string 查询结果描述 { get; set; }
        #region C扫B  B扫C
        /// <summary>
        /// 账单二维码
        /// </summary>
        [Length(200)]
        [Index(26)]
        public string 无硬件C扫B二维码 { get; set; }

        /// <summary>
        /// 账单时间YYYYMMDD
        /// </summary>
        [Length(8)]
        [Index(27)]
        public string 无硬件C扫B账单时间 { get; set; }

        /// <summary>
        /// 账单状态
        /// </summary>
        [Length(20)]
        [Index(28)]
        public string 无硬件C扫B订单状态 { get; set; }
        #endregion
    }
}
