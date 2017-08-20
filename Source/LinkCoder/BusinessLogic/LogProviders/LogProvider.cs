using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BusinessLogic.LogProviders
{
    public class LogProvider
    {
        protected Logger logger;

        public LogProvider()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public virtual void ErrorListener(Action action, string errorMessage = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public virtual T ErrorListener<T>(Func<T> function, string errorMessage = null)
        {
            try
            {
                return function();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}
