// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Diagnostics;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.DurableTask
{
    /// <summary>
    /// Trigger attribute used for durable orchestrator functions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [DebuggerDisplay("{Orchestration}")]
#if !FUNCTIONS_V1
#pragma warning disable CS0618 // Type or member is obsolete
    [Binding(TriggerHandlesReturnValue = true)]
#pragma warning restore CS0618 // Type or member is obsolete
#else
    [Binding]
#endif
    public sealed class OrchestrationTriggerAttribute : Attribute
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
            Version = DEFAULTVERSION;
        }

        /// <summary>
        /// Creates an instance of Microsoft.Azure.WebJobs.Extensions.DurableTask.OrchestrationTriggerAttribute with specified version.
        /// </summary>
        public OrchestrationTriggerAttribute(string version)
        {
            Version = version;
        }

        /// <summary>
        /// Gets or sets the name of the orchestrator function.
        /// </summary>
        /// <remarks>
        /// If not specified, the function name is used as the name of the orchestration.
        /// </remarks>
        /// <value>
        /// The name of the orchestrator function or <c>null</c> to use the function name.
        /// </value>
#pragma warning disable CS0618 // Type or member is obsolete
        [AutoResolve]
#pragma warning restore CS0618 // Type or member is obsolete
        public string Orchestration { get; set; }

        /// <summary>
        /// Gets or sets the version of the orchestrator function.
        /// </summary>
        /// <remarks>
        /// If not specified, the function version will default to "1.0.0".
        /// </remarks>
        /// <value>
        /// The version of the orchestrator function or <c>null</c> to use the default version "1.0.0".
        /// </value>
#pragma warning disable CS0618 // Type or member is obsolete
        [AutoResolve]
#pragma warning restore CS0618 // Type or member is obsolete
        public string Version { get; set; }
    }
}
