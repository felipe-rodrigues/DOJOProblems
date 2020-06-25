using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSolutions.Base
{
    public abstract class ExerciseBase<TInput,TOutput>
    {
        /// <summary>
        /// Campo destinado a definir o problema em poucas palavras:
        ///  Ex: Dado vetor ordenado em x espera-se o retorno y
        /// </summary>
        public string Description { get; }
        private IEnumerable<TestCase<TInput, TOutput>> TestCases;

        protected ExerciseBase()
        {
        }

        public abstract IEnumerable<TestCase<TInput, TOutput>> GetTestCases();
        public abstract TOutput Execute(TInput input);
        public abstract bool CompareTestCases(TOutput expected, TOutput founds);

        public void Run()
        {
            var testes = GetTestCases();

            var count = 0;
            foreach (var item in testes)
            {
                var initialTime = DateTime.Now;
                Console.WriteLine($"_[#] Iniciando teste {++count} em: {initialTime}");
                var result = Execute(item.Input);
                var finalTime = DateTime.Now;
                var differenteTime = finalTime - initialTime;

                if(CompareTestCases(item.ResultExpected, result))
                {
                    Console.WriteLine($"__[SUCESSO]  Em {differenteTime.TotalMilliseconds} milisegundos");
                }
                else
                {                    
                    Console.WriteLine($"__[ERROR] Experado: {item.ResultExpected.ToString()} encontrado: {result.ToString()} Em {differenteTime.TotalMilliseconds} milisegundos");
                }

            }
        }
    }
}
