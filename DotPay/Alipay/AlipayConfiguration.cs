using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotPay.Enum;

namespace DotPay.Alipay
{
    public class AlipayConfiguration
    {
        #region Singleton

        private static volatile AlipayConfiguration _instance = null;
        private static readonly object LockObject = new object();

        private AlipayConfiguration()
        {
        }

        public static AlipayConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (LockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new AlipayConfiguration();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        /// <summary>用来生成唯一交易号的操作,引用项目可以指定操作,也可以不指定,使用默认的编号生成器
        /// </summary>
        public Func<string> CreateTradeNoHandler;


        /// <summary>支付宝服务枚举和名称对应关系
        /// </summary>
        private readonly Dictionary<AlipayServiceType, string> _serviceDict = new Dictionary<AlipayServiceType, string>()
        {
            {AlipayServiceType.Website, "create_direct_pay_by_user"},
            {AlipayServiceType.Wap, "alipay.wap.create.direct.pay.by.user"},
            {AlipayServiceType.App, ""}
        };

        public BaseAlipayConfig Config { get; private set; }

        /// <summary>设置支付宝支付时候的基本配置
        /// </summary>
        public AlipayConfiguration UseConfig(BaseAlipayConfig config)
        {
            Config = config;
            return this;
        }

        /// <summary>设置生成交易订单号的操作
        /// </summary>
        public AlipayConfiguration SetCreateNo(Func<string> createNoHandler)
        {
            CreateTradeNoHandler = createNoHandler;
            return this;
        }
        /// <summary>获取支付宝支付的服务名称
        /// </summary>
        public string GetServiceName(AlipayServiceType serviceType)
        {
            var serviceName = "";
            _serviceDict.TryGetValue(serviceType, out serviceName);
            return serviceName;
        }



    }
}
