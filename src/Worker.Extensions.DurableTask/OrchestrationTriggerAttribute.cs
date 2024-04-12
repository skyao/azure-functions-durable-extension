// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

namespace Microsoft.Azure.Functions.Worker;

/// <summary>
/// Trigger attribute used for durable orchestrator functions.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
[DebuggerDisplay("{Orchestration}")]
public sealed class OrchestrationTriggerAttribute : TriggerBindingAttribute
{
        /// <summary>
        /// default version of the orchestrator function if not specified.
        /// </summary>
        public const string DEFAULTVERSION = "1.0.0";

        /// <summary>
        /// Creates an instance of Microsoft.Azure.WebJobs.Extensions.DurableTask.OrchestrationTriggerAttribute.
        /// </summary>
        public OrchestrationTriggerAttribute()
        {
            this.Version = DEFAULTVERSION;
        }

        /// <summary>
        /// Creates an instance of Microsoft.Azure.WebJobs.Extensions.DurableTask.OrchestrationTriggerAttribute with specified version.
        /// </summary>
        public OrchestrationTriggerAttribute(string version)
        {
            this.Version = version;
        }

    /// <summary>
    /// Gets or sets the name of the orchestrator function.
    /// </summary>
    /// <remarks>
    /// If not specified, the function name is used as the name of the orchestration.
    /// This property supports binding parameters.
    /// </remarks>
    /// <value>
    /// The name of the orchestrator function or <c>null</c> to use the function name.
    /// </value>
    public string? Orchestration { get; set; }

    /// <summary>
    /// Gets or sets the version of the orchestrator function.
    /// </summary>
    /// <remarks>
    /// If not specified, the function version will default to "1.0.0".
    /// </remarks>
    /// <value>
    /// The version of the orchestrator function or <c>null</c> to use the default version "1.0.0".
    /// </value>
    public string Version { get; set; }
}
