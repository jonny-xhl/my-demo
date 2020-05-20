using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Jonny.AllDemo.MISPOS
{
    public class PosinfDLL
    {
        #region MIS-POS DLL引用

        /// <summary>
        /// 无界面接口(DLL/OCX)函数说明
        /// 交易执行函数
        /// </summary>
        /// <returns></returns>
        [DllImport("posinf.dll")]
        private static extern int bankall(byte[] request, byte[] response);

        /// <summary>
        /// 有界面接口(EXE/DLL)函数说明
        /// </summary>
        /// <returns></returns>
        [DllImport("bankpos.dll")]
        private static extern int mispos(byte[] request, byte[] response);
        #endregion

        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void Consume00(MisPosRequest request, ref MisPosResponse response)
        {
#if DEBUG
            var res = "000308621483******9012    000003000000000001交易成功                                898500080620629000000040000030422173915173915040319      042200000000000000000                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ";
            response = GetObject<MisPosResponse>(Encoding.Default.GetBytes(res));
#endif
        }

        /// <summary>
        /// 消费撤销
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void Cancel01(MisPosRequest request, ref MisPosResponse response)
        {

        }

        /// <summary>
        /// 退货
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void Refund02(MisPosRequest request, ref MisPosResponse response)
        {

        }

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void CheckBalances03(MisPosRequest request, ref MisPosResponse response)
        {

        }

        /// <summary>
        /// 重打印
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void RePrint04(MisPosRequest request, ref MisPosResponse response)
        {

        }

        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public void Sign05(MisPosRequest request, ref MisPosResponse response)
        {

        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void SettleAccounts06(MisPosRequest request, ref MisPosResponse response)
        {

        }

        /// <summary>
        /// 根据MIS-POS返回字符串获取返回对象        
        /// </summary>
        /// <remarks>切记一定要注意LengthAttribute特性</remarks>
        /// <param name="response"></param>
        /// <returns></returns>
        public T GetObject<T>(byte[] response) where T : class, new()
        {
            int offset = 0;
            var t = new T();
            var type = t.GetType();
            var properties = type.GetProperties()
                .OrderBy(p => funOrderProperty);
            LengthAttribute lengthAttribute;
            foreach (var item in properties)
            {
                //字符串长度
                lengthAttribute = item.GetCustomAttributes(typeof(LengthAttribute), false).FirstOrDefault() as LengthAttribute;
                //出现一个属性未知长度的时候直接返回空
                if (lengthAttribute != null)
                {
                    item.SetValue(t, Encoding.Default.GetString(response, offset, lengthAttribute.Len), null);
                    offset += lengthAttribute.Len;
                }
                else
                {
                    return new T();
                }
            }
            return t;
        }
        private Func<PropertyInfo, int> funOrderProperty = (p) =>
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
