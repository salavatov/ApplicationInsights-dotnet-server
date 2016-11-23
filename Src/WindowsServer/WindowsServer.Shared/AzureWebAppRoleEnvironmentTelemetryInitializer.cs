﻿namespace Microsoft.ApplicationInsights.WindowsServer
{
    using System;
    using System.Threading;

    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.ApplicationInsights.Extensibility.Implementation;
    using Microsoft.ApplicationInsights.WindowsServer.Implementation;
   
    /// <summary>
    /// A telemetry initializer that will gather Azure Web App Role Environment context information.
    /// </summary>
    public class AzureWebAppRoleEnvironmentTelemetryInitializer : ITelemetryInitializer
    {
        /// <summary>Azure Web App name corresponding to the resource name.</summary>
        private const string WebAppNameEnvironmentVariable = "WEBSITE_SITE_NAME";

        /// <summary>Azure Web App Instance Id representing the VM. Each instance will have different id.</summary>
        private const string WebAppInstanceNameEnvironmentVariable = "WEBSITE_INSTANCE_ID";

        private string roleInstanceName;
        private string roleName;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureWebAppRoleEnvironmentTelemetryInitializer" /> class.
        /// </summary>
        public AzureWebAppRoleEnvironmentTelemetryInitializer()
        {
            WindowsServerEventSource.Log.TelemetryInitializerLoaded(this.GetType().FullName);
        }

        /// <summary>
        /// Initializes <see cref="ITelemetry" /> device context.
        /// </summary>
        /// <param name="telemetry">The telemetry to initialize.</param>
        public void Initialize(ITelemetry telemetry)
        {
            if (string.IsNullOrEmpty(telemetry.Context.Cloud.RoleName))
            {
                string name = LazyInitializer.EnsureInitialized(ref this.roleName, this.GetRoleName);
                telemetry.Context.Cloud.RoleName = name;
            }

            if (string.IsNullOrEmpty(telemetry.Context.Cloud.RoleInstance))
            {
                string name = LazyInitializer.EnsureInitialized(ref this.roleInstanceName, this.GetRoleInstanceName);
                telemetry.Context.Cloud.RoleInstance = name;
            }

            if (string.IsNullOrEmpty(telemetry.Context.GetInternalContext().NodeName))
            {
                string name = LazyInitializer.EnsureInitialized(ref this.roleInstanceName, this.GetRoleInstanceName);
                telemetry.Context.GetInternalContext().NodeName = name;
            }
        }

        private string GetRoleName()
        {
            return Environment.GetEnvironmentVariable(WebAppNameEnvironmentVariable) ?? string.Empty;
        }

        private string GetRoleInstanceName()
        {
            return Environment.GetEnvironmentVariable(WebAppInstanceNameEnvironmentVariable) ?? string.Empty;
        }
    }
}
