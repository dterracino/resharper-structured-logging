﻿using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;

using ReSharper.Structured.Logging.Highlighting;

[assembly:
    RegisterConfigurableSeverity(ExceptionPassedAsTemplateArgumentWarning.SeverityId, null, HighlightingGroupIds.CompilerWarnings,
        ExceptionPassedAsTemplateArgumentWarning.Message, ExceptionPassedAsTemplateArgumentWarning.Message,
        Severity.WARNING)]

namespace ReSharper.Structured.Logging.Highlighting
{
    [ConfigurableSeverityHighlighting(
        SeverityId,
        CSharpLanguage.Name,
        OverlapResolve = OverlapResolveKind.WARNING,
        ToolTipFormatString = Message)]
    public class ExceptionPassedAsTemplateArgumentWarning : IHighlighting
    {
        public const string SeverityId = "ExceptionPassedAsTemplateArgumentProblem";

        public const string Message = "Exception should be passed to the exception argument";

        private readonly DocumentRange _documentRange;

        public ExceptionPassedAsTemplateArgumentWarning(DocumentRange documentRange)
        {
            _documentRange = documentRange;
        }

        public string ErrorStripeToolTip => ToolTip;

        public string ToolTip => Message;

        public DocumentRange CalculateRange()
        {
            return _documentRange;
        }

        public bool IsValid()
        {
            return _documentRange.IsValid();
        }
    }
}