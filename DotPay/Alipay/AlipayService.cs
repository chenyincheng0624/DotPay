using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotCommon.Components;
using DotCommon.Extensions;
using DotCommon.SimulationRequest;
using DotPay.Alipay.Dto;
using DotPay.Alipay.Safe;
using DotPay.Enum;

namespace DotPay.Alipay
{
    public class AlipayService
    {
        private readonly SimulatRequestor _requestor;
        private readonly AlipayConfiguration _configuration;
        private readonly BaseAlipayConfig _config;

        public AlipayService()
        {
            _requestor = ContainerManager.Resolve<SimulatRequestor>();
            _configuration = AlipayConfiguration.Instance;
            _config = _configuration.Config;
        }

        /// <summary>支付宝创建即时到账订单(PC端)
        /// </summary>
        public string CreateDirectOrder(DirectOrderDto dto, out string tradeNo)
        {
            tradeNo = _configuration.CreateTradeNoHandler();
            var paramDict = new Dictionary<string, string>
            {
                {"service", _configuration.GetServiceName(AlipayServiceType.Website)},
                {"partner", _config.Partner},
                {"seller_id", _config.SellerId},
                {"payment_type", _config.PaymentType},
                {"notify_url", _config.NotifyUrl},
                {"return_url", _config.ReturnUrl},
                {"_input_charset", _config.InputCharset},
                {"anti_phishing_key", _config.AntiPhishingKey},
                {"exter_invoke_ip", _config.ExterInvokeIp},
                //下面为业务数据
                {"out_trade_no", tradeNo},
                {"subject", dto.Subject},
                {"total_fee", dto.Totalfee.ToString("F2")},
                {"body", dto.Body}
            };

            _requestor.Create("", "get")
                .SetParameters(paramDict)
                .SetUrlEncode(true, Encoding.UTF8)
                .BeginRequestAsync(5000);


            return "";
        }



        /// <summary>创建当前配置的签名
        /// </summary>
        private string BuildRequestMysign()
        {
            string mysign = "";
            if (_config.SignType == "RSA")
            {
                mysign= RSAFromPkcs8.sign("", _config.PrivateKey,_config.InputCharset);
            }
            if (_config.SignType == "MD5")
            {
                mysign = AlipayMD5.Sign("", _config.Key, _config.InputCharset);
            }

            return mysign;
        }

        private SortedDictionary<string, string> GetConfigParam()
        {
            var paramDict = new SortedDictionary<string, string>()
            {
                {"partner", _config.Partner},
                {"seller_id", _config.SellerId},
                {"payment_type", _config.PaymentType},
                {"notify_url", _config.NotifyUrl},
                {"return_url", _config.ReturnUrl},
                {"sign_type", _config.SignType},
                {"_input_charset", _config.InputCharset},
                {"anti_phishing_key", _config.AntiPhishingKey},
                {"exter_invoke_ip", _config.ExterInvokeIp},
            };
            return paramDict;
        }


    }
}
