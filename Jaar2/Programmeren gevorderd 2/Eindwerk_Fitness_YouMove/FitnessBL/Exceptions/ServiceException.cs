﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string? message)
            : base(message) { }

        public ServiceException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
