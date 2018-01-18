using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsTest
{
    public class BaseTest
    {
        protected Logger logger = new Logger();
        
        protected void LogStep(object step)
        {
            logger.LogStep(step);
        }

        public static class MultiAssert
        {
            public static bool NotFailed = true;

            public static void SoftAssert(params Action[] assertions)
            {
                var errors = new List<Exception>();

                foreach(var assertion in assertions)
                    try
                    {
                        assertion();
                    }
                    catch(Exception E)
                    {
                        errors.Add(E);
                    }

                if (errors.Any())
                {
                    foreach (Exception E in errors)
                        new Logger().LogAssertFail(E.Message);
                    NotFailed = false;
                }
            }
        }
    }
}
