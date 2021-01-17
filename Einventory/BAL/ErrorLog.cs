using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace BAL
{
    public class ErrorLog
    {

       public void DoBalErrorLogging(Exception ex)
        {
            try
            {
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
            }
            catch (Exception)
            {

            }

        }

    }
}
