﻿// Copyright 2013 Serilog Contributors
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Microsoft.WindowsAzure.Storage;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.AzureTableStorage;

namespace Serilog
{
    /// <summary>
    /// Adds the WriteTo.AzureTableStorage() extension method to <see cref="LoggerConfiguration"/>.
    /// </summary>
    public static class LoggerConfigurationAzureTableStorageExtensions
    {
        /// <summary>
        /// Adds a sink that writes log events as records in the 'LogEventEntity' Azure Table Storage table in the given storage account.
        /// </summary>
        /// <param name="loggerConfiguration">The logger configuration.</param>
        /// <param name="storageAccount">The Cloud Storage Account to use to insert the log entries to.</param>
        /// <param name="restrictedToMinimumLevel">The minimum log event level required in order to write an event to the sink.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        /// <param name="storageTableName">Table name that log entries will be written to. Note: Optional, setting this may impact performance</param>
        /// <returns>Logger configuration, allowing configuration to continue.</returns>
        /// <exception cref="ArgumentNullException">A required parameter is null.</exception>
        public static LoggerConfiguration AzureTableStorage(
            this LoggerSinkConfiguration loggerConfiguration,
            CloudStorageAccount storageAccount,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
            IFormatProvider formatProvider = null,
            string storageTableName = null)
        {
            if (loggerConfiguration == null) throw new ArgumentNullException("loggerConfiguration");
            if (storageAccount == null) throw new ArgumentNullException("storageAccount");
            return loggerConfiguration.Sink(
                new AzureTableStorageSink(storageAccount, formatProvider, storageTableName),
                restrictedToMinimumLevel);
        }

    }
}
