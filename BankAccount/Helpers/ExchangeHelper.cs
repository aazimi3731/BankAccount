// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeHelper.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using BankAccount.DTO;
using BankAccount.Models;
using BankAccount.Repositories;

namespace BankAccount.Helpers
{
    public class ExchangeHelper
    {
        /// <summary>
        /// Currency exchange helper.
        /// </summary>
        public static Dictionary<string, decimal> CurrencyExchange()
        {
            Dictionary<string, decimal> exchange = new Dictionary<string, decimal>();
            exchange.Add("CAD", (decimal) 1.00);
            exchange.Add("MXN", (decimal) 0.10);
            exchange.Add("USD", (decimal) 2.00);

            return exchange;
        }
    }
}
