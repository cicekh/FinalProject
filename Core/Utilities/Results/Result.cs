using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        // sadece getter ı olan propertieler read only dir. Ve readonly özellikler Constructor da setlenebilirler.
        //Ama dışardan setlenebilirler. Bu şekilde dışardan erişime engellenir ve daha güzel bir design sağlanır.

        // constructer ın baselerle çalışması kendi içinde farklı yapılarla çalışmasına bir örnek (:this(success))
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
