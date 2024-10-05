using System;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Введите математическое выражение (или 'exit' для выхода): ");
            string? input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            try
            {
                var result = CSharpScript.EvaluateAsync(input, ScriptOptions.Default
                    .WithReferences(AppDomain.CurrentDomain.GetAssemblies()) 
                    .WithImports("System", "System.Math")
                ).Result;

                Console.WriteLine("Результат: " + result);
            }
            catch (CompilationErrorException ex)
            {
                Console.WriteLine("Ошибка компиляции: " + string.Join(Environment.NewLine, ex.Diagnostics));
            }
        }
    }
}
