using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Reflection;

namespace EsthaHelpers.Cfg
{
    public class Cfg
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

        public static string LOCATION_OF_IDK_DATA
        {
            get
            {
                //try { return Int32.Parse(GetConfig("LOCATION_OF_IDK_DATA")); }
                try { return GetConfig("LOCATION_OF_IDK_DATA"); }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    return ""; 
                }
            }
        }        
    }

}