﻿namespace Microsoft.ApplicationInsights.Web.Implementation
{
    using System;
    using System.Diagnostics.CodeAnalysis;
#if NET45
    using System.Diagnostics.Tracing;
#endif
    
    /// <summary>
    /// ETW EventSource tracing class.
    /// </summary>
    [EventSource(Name = "Microsoft-ApplicationInsights-Extensibility-Web")]
    [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "appDomainName is required")]
    internal sealed class WebEventSource : EventSource
    {
        /// <summary>
        /// Instance of the PlatformEventSource class.
        /// </summary>
        public static readonly WebEventSource Log = new WebEventSource();

        private WebEventSource()
        {
            this.ApplicationName = this.GetApplicationName();
        }

        public string ApplicationName { [NonEvent]get; [NonEvent]private set; }

        public bool IsVerboseEnabled 
        { 
            [NonEvent] 
             get 
             { 
                 return Log.IsEnabled(EventLevel.Verbose, (EventKeywords)(-1)); 
             } 
         }

        [Event(
            1,
            Message = "ApplicationInsightsHttpModule failed at initialization with exception: {0}",
            Level = EventLevel.Error)]
        public void WebModuleInitializationExceptionEvent(string excMessage, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                1,
                excMessage ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            2,
            Message = "ApplicationInsightsHttpModule failed at {0} with exception: {1}",
            Level = EventLevel.Warning)]
        public void TraceCallbackFailure(string callbackName, string excMessage, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                2,
                callbackName ?? string.Empty,
                excMessage ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            3,
            Message = "[msg=WebModuleCallback];[callback={0}];[uri={1}];",
            Level = EventLevel.Verbose)]
        public void WebModuleCallback(string callback, string uri, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                3,
                callback ?? string.Empty,
                uri ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            4,
            Message = "[msg=HanderFailure];[exception={0}];",
            Level = EventLevel.Error)]
        public void HanderFailure(string exception, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                4,
                exception ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            5,
            Message = "[msg=UserHostNotCollectedWarning];[exception={0}];",
            Level = EventLevel.Warning)]
        public void UserHostNotCollectedWarning(string exception, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                5,
                exception ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            8,
            Message = "[msg=RequestTelemetryCreated];",
            Level = EventLevel.Verbose)]
        public void WebTelemetryModuleRequestTelemetryCreated(string appDomainName = "Incorrect")
        {
            this.WriteEvent(8, this.ApplicationName);
        }

        [Event(
            9,
            Message = "[msg=HttpRequestNotAvailable];[msg={0}];[stack={1}];",
            Level = EventLevel.Warning)]
        public void HttpRequestNotAvailable(string message, string stack, string appDomainName = "Incorrect")
        {
            this.WriteEvent(9, message, stack, this.ApplicationName);
        }

        [Event(
            10,
            Keywords = Keywords.VerboseFailure,
            Message = "[msg=WebSessionTrackingSessionCookieIsNotSecifiedInRequest];",
            Level = EventLevel.Verbose)]
        public void WebSessionTrackingSessionCookieIsNotSecifiedInRequest(string appDomainName = "Incorrect")
        {
            this.WriteEvent(10, this.ApplicationName);
        }

        [Event(
            11,
            Message = "[msg=WebSessionTrackingSessionCookieIsEmptyWarning];",
            Level = EventLevel.Warning)]
        public void WebSessionTrackingSessionCookieIsEmptyWarning(string appDomainName = "Incorrect")
        {
            this.WriteEvent(11, this.ApplicationName);
        }

        [Event(
            12,
            Message = "[msg=WebUserTrackingUserCookieNotAvailable];",
            Level = EventLevel.Verbose)]
        public void WebUserTrackingUserCookieNotAvailable(string appDomainName = "Incorrect")
        {
            this.WriteEvent(12, this.ApplicationName);
        }

        [Event(
            13,
            Message = "[msg=WebUserTrackingUserCookieIsEmpty];",
            Level = EventLevel.Warning)]
        public void WebUserTrackingUserCookieIsEmpty(string appDomainName = "Incorrect")
        {
            this.WriteEvent(13, this.ApplicationName);
        }

        [Event(
            14,
            Message = "[msg=WebUserTrackingUserCookieIsIncomplete];[cookieValue={0}];",
            Level = EventLevel.Warning)]
        public void WebUserTrackingUserCookieIsIncomplete(
            string cookieValue, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                14,
                cookieValue ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            16,
            Message = "WebTelemetryInitializerLoaded at {0}",
            Level = EventLevel.Verbose)]
        public void WebTelemetryInitializerLoaded(
            string typeName,
            string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                16,
                typeName ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            17,
            Message = "[msg=WebTelemetryInitializerNotExecutedOnNullHttpContext]",
            Level = EventLevel.Verbose)]
        public void WebTelemetryInitializerNotExecutedOnNullHttpContext(
            string appDomainName = "Incorrect")
        {
            this.WriteEvent(17, this.ApplicationName);
        }

        [Event(
            18,
            Message = "TelemetryInitializer {0} failed to initialize telemetry item {1}",
            Level = EventLevel.Error)]
        public void WebTelemetryInitializerFailure(
            string typeName,
            string exception,
            string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                18,
                typeName ?? string.Empty,
                exception ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            19,
            Message = "[msg=WebSetLocationIdSkiped];[headerName={0}];",
            Level = EventLevel.Verbose)]
        public void WebLocationIdHeaderFound(string headerName, string appDomainName = "Incorrect")
        {
            this.WriteEvent(19, headerName ?? "NULL", this.ApplicationName);
        }

        [Event(
            20,
            Message = "[msg=WebSetLocationIdSet];[ip={0}];",
            Level = EventLevel.Verbose)]
        public void WebLocationIdSet(string ip, string appDomainName = "Incorrect")
        {
            this.WriteEvent(20, ip ?? "NULL", this.ApplicationName);
        }

        [Event(
            21,
            Message = "[msg=WebUriFormatException];",
            Level = EventLevel.Warning)]
        public void WebUriFormatException(string appDomainName = "Incorrect")
        {
            this.WriteEvent(21, this.ApplicationName);
        }

        [Event(
            26,
            Message = "[msg=AuthIdTrackingCookieNotAvailable];",
            Level = EventLevel.Verbose)]
        public void AuthIdTrackingCookieNotAvailable(string appDomainName = "Incorrect")
        {
            this.WriteEvent(26, this.ApplicationName);
        }

        [Event(
            27,
            Message = "[msg=AuthIdTrackingCookieIsEmpty];",
            Level = EventLevel.Warning)]
        public void AuthIdTrackingCookieIsEmpty(string appDomainName = "Incorrect")
        {
            this.WriteEvent(27, this.ApplicationName);
        }

        [Event(
            28,
            Message = "[msg=ThreadAbortWarning];",
            Level = EventLevel.Warning)]
        public void ThreadAbortWarning(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                28,
                this.ApplicationName);
        }

        [Event(
            29,
            Message = "[msg=WebRequestFilteredOutByUserAgent];",
            Level = EventLevel.Verbose)]
        public void WebRequestFilteredOutByUserAgent(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                29,
                this.ApplicationName);
        }

        [Event(
            30,
            Message = "[msg=WebRequestFilteredOutByRequestHandler];",
            Level = EventLevel.Verbose)]
        public void WebRequestFilteredOutByRequestHandler(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                30,
                this.ApplicationName);
        }

        [Event(
            31,
            Keywords = Keywords.UserActionable,
            Message = "SyntheticUserAgentTelemetryInitializer failed to parse regular expression {0} with exception: {1}",
            Level = EventLevel.Warning)]
        public void SyntheticUserAgentTelemetryInitializerRegularExpressionParsingException(string pattern, string exception, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                31,
                pattern,
                exception,
                this.ApplicationName);
        }

        [Event(
            32,
            Message = "FlagCheckFailure {0}.",
            Level = EventLevel.Error)]
        public void FlagCheckFailure(string excMessage, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                32,
                excMessage ?? string.Empty,
                this.ApplicationName);
        }

        [Event(
            33,
            Message = "RequestFiltered",
            Level = EventLevel.Verbose)]
        public void RequestFiltered(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                33,
                this.ApplicationName);
        }

        [Event(
            34,
            Message = "[msg=NoHttpContext];",
            Level = EventLevel.Warning)]
        public void NoHttpContextWarning(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                34,
                this.ApplicationName);
        }

        [Event(
            35,
            Message = "Failed to hook onto AddOnSendingHeaders event. Exception {0}",
            Level = EventLevel.Warning)]
        public void HookAddOnSendingHeadersFailedWarning(string exception, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                35,
                exception,
                this.ApplicationName);
        }

        [Event(
            36,
            Message = "Failed to add target instrumentation key hash as a response header. Exception {0}",
            Level = EventLevel.Warning)]
        public void AddTargetHeaderFailedWarning(string exception, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                36,
                exception,
                this.ApplicationName);
        }

        [Event(
            37,
            Message = "Initialize has not been called on this module yet.",
            Level = EventLevel.Error)]
        public void InitializeHasNotBeenCalledOnModuleYetError(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                37,
                this.ApplicationName);
        }

        [Event(
            38,
            Message = "Initialize has not been called on this module yet.",
            Level = EventLevel.Verbose)]
        public void InitializeHasNotBeenCalledOnModuleYetVerbose(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                38,
                this.ApplicationName);
        }

        [Event(
            39,
            Message = "RequestTrackingTelemetryModule ChildRequestTrackingSuppressionModule Method: '{0}' Unknown Exception: {1}",
            Level = EventLevel.Error)]
        public void ChildRequestUnknownException(string methodName, string exceptionMessage, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                39,
                methodName,
                exceptionMessage,
                this.ApplicationName);
        }

        [Event(
            40,
            Message = "RequestTrackingTelemetryModule: Request was not logged. Set EventLevel Verbose for more details.",
            Level = EventLevel.Informational)]
        public void RequestTrackingTelemetryModuleRequestWasNotLoggedInformational(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                40,
                this.ApplicationName);
        }

        [Event(
            41,
            Message = "RequestTrackingTelemetryModule: Request was not logged. Request Id: '{0}' Reason: {1}",
            Level = EventLevel.Verbose)]
        public void RequestTrackingTelemetryModuleRequestWasNotLoggedVerbose(string requestId, string reason, string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                41,
                requestId,
                reason,
                this.ApplicationName);
        }

        [Event(42,
            Keywords = Keywords.Diagnostics,
            Message = "Injection started.",
            Level = EventLevel.Verbose)]
        public void InjectionStarted(string appDomainName = "Incorrect")
        {
            this.WriteEvent(42, this.ApplicationName);
        }

        [Event(43,
            Keywords = Keywords.Diagnostics,
            Message = "{0} Injection failed. Error message: {1}",
            Level = EventLevel.Informational)]
        public void InjectionFailed(string component, string error, string appDomainName = "Incorrect")
        {
            this.WriteEvent(43, component ?? string.Empty, error ?? string.Empty, this.ApplicationName);
        }

        [Event(44,
            Keywords = Keywords.Diagnostics,
            Message = "Version '{0}' of component '{1}' is not supported",
            Level = EventLevel.Verbose)]
        public void InjectionVersionNotSupported(string version, string component, string appDomainName = "Incorrect")
        {
            this.WriteEvent(44, version ?? string.Empty, component ?? string.Empty, this.ApplicationName);
        }

        [Event(
            45,
            Keywords = Keywords.Diagnostics,
            Message = "Unknown exception. Error message: {0}.",
            Level = EventLevel.Error)]
        public void InjectionUnknownError(string error, string appDomainName = "Incorrect")
        {
            this.WriteEvent(45, error ?? string.Empty, this.ApplicationName);
        }

        [Event(
            46,
            Keywords = Keywords.Diagnostics,
            Message = "Another exception filter or logger is already injected. Type: '{0}', component: '{1}'",
            Level = EventLevel.Verbose)]
        public void InjectionSkipped(string type, string component, string appDomainName = "Incorrect")
        {
            this.WriteEvent(46, type ?? string.Empty, component ?? string.Empty, this.ApplicationName);
        }

        [Event(47,
            Keywords = Keywords.Diagnostics,
            Message = "Injection completed.",
            Level = EventLevel.Verbose)]
        public void InjectionCompleted(string appDomainName = "Incorrect")
        {
            this.WriteEvent(47, this.ApplicationName);
        }

        [Event(48,
            Keywords = Keywords.Diagnostics,
            Message = "Activity is null for event = '{0}'",
            Level = EventLevel.Error)]
        public void ActivityIsNull(string diagnosticsSourceEventName, string appDomainName = "Incorrect")
        {
            this.WriteEvent(48, diagnosticsSourceEventName, this.ApplicationName);
        }

        [Event(49,
            Keywords = Keywords.Diagnostics | Keywords.UserActionable,
            Message = ".NET 4.7.1 is not installed, correlation for HTTP requests with body is not possible",
            Level = EventLevel.Error)]
        public void CorrelationIssueIsDetectedForRequestWithBody(string appDomainName = "Incorrect")
        {
            this.WriteEvent(
                49,
                this.ApplicationName);
        }

        [NonEvent]
        private string GetApplicationName()
        {
            string name;
            try
            {
                name = AppDomain.CurrentDomain.FriendlyName;
            }
            catch (Exception exp)
            {
                name = "Undefined " + exp.Message;
            }

            return name;
        }

        /// <summary>
        /// Keywords for the PlatformEventSource. Those keywords should match keywords in Core.
        /// </summary>
        public sealed class Keywords
        {
            /// <summary>
            /// Key word for user actionable events.
            /// </summary>
            public const EventKeywords UserActionable = (EventKeywords)0x1;

            /// <summary>
            /// Diagnostics tracing keyword.
            /// </summary>
            public const EventKeywords Diagnostics = (EventKeywords)0x2;

            /// <summary>
            /// Keyword for errors that trace at Verbose level.
            /// </summary>
            public const EventKeywords VerboseFailure = (EventKeywords)0x4;
        }
    }
}
