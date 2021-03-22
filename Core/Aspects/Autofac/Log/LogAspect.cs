using Castle.DynamicProxy;
using Core.Constants;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Log
{
    public class LogAspect : MethodInterception
    {
        private Type _loggerType;
        private LoggerService _loggerService;
        public LogAspect(Type loggerType)
        {  // defensinn programming
            _loggerType = loggerType;
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception(Messages.WrongLoggerType);
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
           
        }

      

        protected override void OnBefore(IInvocation invocation)
        {
            //if (!_loggerService.IsInfoEnabled)
            //{
            //    return;
            //}
           
            // burada hata oluşmaması için try cache e alıyoruz. Eğer loglama önemli ise Exception ile durumu yazdırabilirsin.
            try
            {
                var logParameters = invocation.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = invocation.Arguments.GetValue(i)
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = invocation.Method.DeclaringType == null ? null : invocation.Method.DeclaringType.Name,
                    MethodName = invocation.Method.Name,
                    Parameters = logParameters,

                };
             
                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {
            }
        }
        protected override void OnException(IInvocation invocation, System.Exception e) {

        }
        protected override void OnSuccess(IInvocation invocation) { }
    }
}
