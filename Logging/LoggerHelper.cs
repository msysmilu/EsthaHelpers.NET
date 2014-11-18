using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsthaHelpers.Logging
{
    public class LoggerHelper
    {
        public static Logger log
        {
            get
            {
                return LogManager.GetCurrentClassLogger();
            }
        }
		
		        /*
                logger.Trace("Trace: The chatter of people on the street");
                logger.Debug("Debug: Where are you going and why?");
                logger.Info("Info: What bus station you're at.");
                logger.Warn("Warn: You're playing on the phone and not looking up for your bus");
                logger.Error("Error: You get on the wrong bus.");
                logger.Fatal("Fatal: You are run over by the bus.");
                */
    }
}