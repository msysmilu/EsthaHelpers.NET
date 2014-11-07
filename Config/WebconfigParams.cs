using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Reflection;

namespace Estha.Config
{
    public class ConfigHelper
    {
        private static Configuration GetConfig()
        {
            Configuration cf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            return cf;
        }

        private static string GetConfig(string key)
        {
            return GetConfig().AppSettings.Settings[key].Value;
        }

        // ============== PARTICULAR ============= 
        // see descriptions in web.config at:
		//	<configuration>
		//	  <appSettings>
		//		<!-- The time before a working person is considered idle -->
		//		<add key="SAMPLE_VARIABLE" value="301"/>
		//	  </appSettings>
		//	</configuration>
        
        public static int SAMPLE_VARIABLE
        {
            get
            {
                try { return Int32.Parse(GetConfig("SAMPLE_VARIABLE")); }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 301; //2h default value;
                }
            }
        }        
    }

}