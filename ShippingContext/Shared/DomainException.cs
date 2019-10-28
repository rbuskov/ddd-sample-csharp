﻿using System;

namespace ShippingContext.Shared
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {}
    }
}