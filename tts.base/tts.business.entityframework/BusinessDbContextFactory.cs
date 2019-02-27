using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using tts.extends.common;

namespace tts.business.entityframework
{
    public class BusinessDbContextFactory : IDesignTimeDbContextFactory<BusinessDbContext>
    {
        private const string ConnectionStringKey = "Default";

        public BusinessDbContext CreateDbContext(string[] args)
        {
            return new BusinessDbContext(BuildOptions());
        }

        /// <summary>
        /// ABP提供的示例代码是读取Web项目的配置文件
        /// 个人感觉不是很合适，采用共用配置文件的方式，似乎更好；
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
                return configuration.GetConnectionString(ConnectionStringKey);
            }
        }

        public static DbContextOptions<BusinessDbContext> BuildOptions()
        {
            var builder = new DbContextOptionsBuilder<BusinessDbContext>();
            builder.UseMySql(ConnectionString);
            return builder.Options;
        }
    }
}
