using System;
using System.Collections.Generic;
using System.Text;

namespace tts.extends.common
{
    public class ServiceBase
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string ServerIp { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
    }

    public class Config
    {
        public List<StartServicesConfig> Services { get; set; }
    }


    /// <summary>
    /// 本地服务启动后监听端口
    /// </summary>
    public class StartServicesConfig : ServiceBase
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务显示名称
        /// </summary>
        public string ServiceDisplayName { get; set; }
        /// <summary>
        /// 服务描述
        /// </summary>
        public string ServiceDescription { get; set; }
    }
}
