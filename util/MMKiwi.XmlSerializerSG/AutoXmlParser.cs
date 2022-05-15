using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Text;

namespace MMKiwi.XmlSerializerSG;

internal class AutoXmlParser
{
    public AutoXmlParser(Compilation compilation, Action<Diagnostic> reportDiagnostic, CancellationToken cancellationToken)
    {
        Compilation = compilation;
        ReportDiagnostic = reportDiagnostic;
        CancellationToken = cancellationToken;
    }

    public Compilation Compilation { get; }
    public Action<Diagnostic> ReportDiagnostic { get; }
    public CancellationToken CancellationToken { get; }

    public (string, string) Emit(ClassDeclarationSyntax cds, CancellationToken cancellationToken)
    {
        StringBuilder outputFile = new();
        var name = cds.GetFullName();
        outputFile.Append($$"""
            public partial class {{name}} : {{XmlSerializerSourceGenerator.AutoAttribute}} {
                public async Task ReadXmlAsync(XmlReader reader) => throw new NotImplementedException;
                public async Task WriteXmlAsync(XmlWriter writer) => throw new NotImplementedException;
            }
            """);
        
        var properties = cds.Members.Where(m => m is PropertyDeclarationSyntax).Cast<PropertyDeclarationSyntax>();
        foreach(var property in properties)
        {

        }
        return (name, "");
    }
}
