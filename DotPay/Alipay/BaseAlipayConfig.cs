using System.Web;

namespace DotPay.Alipay
{
    public abstract class BaseAlipayConfig
    {
        /// <summary>支付宝最新提交的地址
        /// </summary>
        public string GatewayNew = "https://mapi.alipay.com/gateway.do";

        //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        /// <summary>合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        /// </summary>
        public abstract string Partner { get; protected set; }

        /// <summary>收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号
        /// </summary>
        public abstract string SellerId { get; protected set; }

        /// <summary>卖家支付宝账号别名
        /// 当签约账号就是收款账号时，请务必使用参数seller_id，即seller_id的值与partner的值相同。三个参数的优先级别是：seller_id>seller_account_name>seller_email。
        /// </summary>
        public virtual string SellerAccountName { get; protected set; }

        /// <summary>MD5密钥，安全检验码，由数字和字母组成的32位字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        /// </summary>
        public virtual string Key { get; protected set; } = "";

        /// <summary>签名方式
        /// </summary>
        public virtual string SignType { get; protected set; } = "MD5";

        /// <summary>商户的私钥,原始格式，RSA公私钥生成：https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.nBDxfy&treeId=58&articleId=103242&docType=1   
        /// 只有SignType=RSA的时候,才需要
        /// </summary>
        public virtual string PrivateKey { get; protected set; } = "";

        /// <summary>支付宝的公钥，查看地址：https://b.alipay.com/order/pidAndKey.htm 
        /// 只有SignType=RSA的时候,才需要
        /// </summary>
        public virtual string AlipayPublicKey { get; protected set; } = "";



        /// <summary> 服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问
        /// </summary>
        public virtual string NotifyUrl { get; protected set; } =
            " http://商户网关地址/create_direct_pay_by_user-CSHARP-UTF-8/NotifyUrl.aspx";

        /// <summary>页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        /// </summary>
        public virtual string ReturnUrl { get; protected set; } =
            "http://商户网关地址/create_direct_pay_by_user-CSHARP-UTF-8/ReturnUrl.aspx";


        /// <summary>调试用，创建TXT日志文件夹路径，见AlipayCore.cs类中的LogResult(string sWord)打印方法。
        /// </summary>
        public virtual string LogPath { get; protected set; } = HttpRuntime.AppDomainAppPath + "log\\";

        /// <summary>字符编码格式 目前支持 gbk 或 utf-8
        /// </summary>
        public virtual string InputCharset { get; protected set; } = "utf-8";

        // 支付类型 ，无需修改
        public string PaymentType = "1";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


        //↓↓↓↓↓↓↓↓↓↓请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        //防钓鱼时间戳  若要使用请调用类文件submit中的Query_timestamp函数
        public virtual string AntiPhishingKey { get; set; } = "";

        //客户端的IP地址 非局域网的外网IP地址，如：221.0.0.1
        public virtual string ExterInvokeIp { get; set; } = "";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    }
}
