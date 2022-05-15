using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MMKiwi.XmlSerializerSG;
[Generator]
public class XmlSerializerSourceGenerator : IIncrementalGenerator
{
    internal const string AutoAttribute = "MMKiwi.AsyncXmlSerializer.AutoXmlSerializeAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {

        IncrementalValuesProvider<ClassDeclarationSyntax> classDeclarations = context.SyntaxProvider.CreateSyntaxProvider(
        predicate: static (s, _) => IsSyntaxTargetForGeneration(s),
        transform: static (ctx, _) => GetSemanticTargetForGeneration(ctx)).Where(static m => m is not null)!;


        IncrementalValueProvider<(Compilation, ImmutableArray<ClassDeclarationSyntax>)> compilationAndClasses
            = context.CompilationProvider.Combine(classDeclarations.Collect());

        context.RegisterSourceOutput(compilationAndClasses,
            static (spc, source) => Execute(source.Item1, source.Item2, spc));
    }

    static bool IsSyntaxTargetForGeneration(SyntaxNode node) =>
        (node is ClassDeclarationSyntax c && c.AttributeLists.Count > 0) ||
         node is PropertyDeclarationSyntax p && p.Parent is ClassDeclarationSyntax pc && pc.AttributeLists.Count > 0;
    

    static ClassDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        // we know the node is a MethodDeclarationSyntax thanks to IsSyntaxTargetForGeneration
        ClassDeclarationSyntax xmlClass;
        if (context.Node is PropertyDeclarationSyntax childProp &&
            childProp.Parent is ClassDeclarationSyntax parentClass)
            xmlClass = parentClass;
        else if (context.Node is ClassDeclarationSyntax classSyntax)
            xmlClass = classSyntax;
        else return null;

        // loop through all the attributes on the method
        foreach (AttributeListSyntax attributeListSyntax in xmlClass.AttributeLists)
        {
            foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
            {
                if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                {
                    // weird, we couldn't get the symbol, ignore it
                    continue;
                }

                INamedTypeSymbol attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                string fullName = attributeContainingTypeSymbol.ToDisplayString();

                // Is the attribute the [LoggerMessage] attribute?
                if (fullName == AutoAttribute)
                {
                    // return the parent class of the method
                    return xmlClass;
                }
            }
        }

        // we didn't find the attribute we were looking for
        return null;
    }

    private static void Execute(Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes, SourceProductionContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            Debugger.Launch();
        }
#endif
        if (classes.IsDefaultOrEmpty)
        {
            // nothing to do yet
            return;
        }

        IEnumerable<ClassDeclarationSyntax> distinctClasses = classes.Distinct();

        AutoXmlParser p = new(compilation, context.ReportDiagnostic, context.CancellationToken);

        foreach (ClassDeclarationSyntax xmlClass in distinctClasses)
        {
            (string name, string result) = p.Emit(xmlClass, context.CancellationToken);
            context.AddSource($"{name}.g.cs", SourceText.From(result, Encoding.UTF8));
        }
            

        /*var p = new Parser(compilation, context.ReportDiagnostic, context.CancellationToken);

        IReadOnlyList<LoggerClass> logClasses = p.GetLogClasses(distinctClasses);
        if (logClasses.Count > 0)
        {
            var e = new Emitter();
            string result = e.Emit(logClasses, context.CancellationToken);

            context.AddSource("LoggerMessage.g.cs", SourceText.From(result, Encoding.UTF8));
        }*/
    }

}