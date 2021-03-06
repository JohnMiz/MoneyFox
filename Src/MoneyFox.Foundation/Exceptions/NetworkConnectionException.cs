﻿using System;

namespace MoneyFox.Foundation.Exceptions
{
    /// <summary>
    ///     This Exception is thrown when there was an issue with an internet connection.
    /// </summary>
    public class NetworkConnectionException : Exception
    {
        /// <summary>
        ///     Creates an network connection Exception
        /// </summary>
        public NetworkConnectionException()
        {
        }

        /// <summary>
        ///     Creates an network connection Exception
        /// </summary>
        /// <param name="message">Exception message to show to the user.</param>
        public NetworkConnectionException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Creates an network connection Exception
        /// </summary>
        /// <param name="message">Exception message to show to the user.</param>
        /// <param name="exception">Inner Exception of the backup exception.</param>
        public NetworkConnectionException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}