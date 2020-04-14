using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3.BLL
{
    class Parser
    {
        static public Dictionary<double, double> Parse(string values)
        {
            string[] expressions = FirsltyParse(values);

            var result = GetValues(expressions);

            return result;
        }

        static private string[] FirsltyParse(string values)
        {
            string[] expressions = values.Split('\n');
            string[] result = new string[expressions.Length - 2];
            for(int i = 1; i < expressions.Length - 1; i++)
            {
                result[i - 1] = expressions[i];
            }
            return result;
        }

        static private Dictionary<double, double> GetValues(string[] expressions)
        {
            List<(string key, string value)> parsedValues = GetParsedValues(expressions);

            Dictionary<double, double> result = new Dictionary<double, double>();
            foreach (var expr in parsedValues)
            {
                var key = double.Parse(expr.key);
                var value = double.Parse(expr.value);

                result.Add(key, value);
            }
            return result;
        }

        static private List<(string, string)> GetParsedValues(string [] expressions)
        {
            List<(string key, string value)> parsedExpressions = new List<(string, string)>();
            for (int i = 0; i < expressions.Length; i++)
            {
                var pair = expressions[i].Split(':');
                parsedExpressions.Add((pair[0], pair[1]));
            }
            return parsedExpressions;
        }
    }
}
