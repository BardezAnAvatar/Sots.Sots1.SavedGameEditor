using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bardez.Project.ExceptionHandler
{
    public interface IExceptionLogger
    {
        void LogException(Exception Ex);
        //void LogException(String SystemInfo, String ExceptionDetails);
    }
}
