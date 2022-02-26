﻿using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Analyzer.CodeFixes
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(WhiteSpacesStringsCodeFixProvider)), Shared]
    public class WhiteSpacesStringsCodeFixProvider : CodeFixProvider
    {
        private const string title = "Remove whitespaces";

        public sealed override ImmutableArray<string> FixableDiagnosticIds
        {
            get { return ImmutableArray.Create(WhitespacesStringsAnalyzer.DiagnosticId); }
        }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<NamespaceDeclarationSyntax>().First();

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: title,
                    createChangedDocument: c => RemoveSpacesAsync(context.Document, diagnostic, root),
                    equivalenceKey: title),
                    diagnostic);
        }

        Task<Document> RemoveSpacesAsync(Document document, Diagnostic diagnostic, SyntaxNode root)
        {
            var trivia = root.FindTrivia(diagnostic.Location.SourceSpan.Start);
            var newRoot = root.ReplaceTrivia(trivia, SyntaxFactory.EndOfLine(string.Empty));
            return Task.FromResult(document.WithSyntaxRoot(newRoot));
        }
    }
}
