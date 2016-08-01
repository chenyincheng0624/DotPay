using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPay.Alipay.Dto
{
    public class DirectOrderDto
    {
        ///// <summary>商户订单号，商户网站订单系统中唯一订单号(不可空)
        ///// </summary>
        //public string TradeNo { get; set; }
        /// <summary>订单名称(不可空)
        /// </summary>
        public string Subject { get; set; }

        /// <summary>总金额(不可空)
        /// </summary>
        public decimal Totalfee { get; set; }

        /// <summary>商品描述(可空)
        /// </summary>
        public string Body { get; set; }

        public DirectOrderDto(string subject, decimal totalFee, string body = "")
        {
            Subject = subject;
            Totalfee = totalFee;
            Body = body;
        }

    }
}
