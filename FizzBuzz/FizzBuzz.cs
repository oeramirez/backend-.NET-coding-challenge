using System;
using System.Collections.Generic;
using System.Collections.Immutable;

/**
 *
 * Given is the following FizzBuzz application which counts from 1 to 100 and outputs either the corresponding
 * number or the corresponding text if one of the following rules apply.
 * Rules:
 *  - dividable by 3 without a remainder -> Fizz
 *  - dividable by 5 without a remainder -> Buzz
 *  - dividable by 3 and 5 without a remainder -> FizzBuzz
 *
 * ACCEPTANCE CRITERIA:
 * Please refactor this code so that it can be easily extended in the future with other rules, such as
 * "if it is dividable by 7 without a remainder output Bar"
 * "if multiplied by 10 is larger than 100 output Foo"
 *
 */

namespace FizzBuzz
{
    /// <summary>
    /// A flexible FizzBuzz Engine that prints the FizzBuzz sequence according to specified rules.
    /// The rules are executed in order and able to look at the previous rules' results to make a decision.
    /// </summary>
    public sealed class FizzBuzzEngine
    {
        /// <summary>
        /// Default rules for FizzBuzz.
        /// - dividable by 3 without a remainder -> Fizz
        /// - dividable by 5 without a remainder -> Buzz
        /// - dividable by 3 and 5 without a remainder -> FizzBuzz
        /// </summary>
        public static readonly IImmutableList<Func<int, string, string>> DefaultRules = new List<Func<int, string, string>>
        {
            (i, _) => i % 3 == 0 ? "Fizz" : string.Empty,
            (i, _) => i % 5 == 0 ? "Buzz" : string.Empty,
            (i, prev) => string.IsNullOrEmpty(prev) ? i.ToString() : string.Empty
        }.ToImmutableList();
        
        private readonly IImmutableList<Func<int, string, string>> rules;

        /// <summary>
        /// Create a new instance of FizzBuzzEngine with DefaultRules.
        /// </summary>
        public FizzBuzzEngine() : this(DefaultRules)
        {}

        /// <summary>
        /// Create a new instance of FizzBuzzEngine with specified rules.
        /// </summary>
        /// <remarks>
        /// The rules are applied in the same order they are specified,
        /// so if you want to output "FizzBuzz" you need to add the rule
        /// for "Fizz" before the rule for "Buzz".
        /// </remarks>
        public FizzBuzzEngine(IImmutableList<Func<int, string, string>> rules) => this.rules = rules;

        public void Run(int limit = 100)
        {
            for (int i = 1; i <= limit; i++)
            {
                string output = "";
                foreach (var rule in rules)
                {
                    output += rule(i, output);
                }
                
                Console.WriteLine("{0}: {1}", i, output);
            }
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            FizzBuzzEngine engine = new FizzBuzzEngine();
            engine.Run();
        }
    }
}
