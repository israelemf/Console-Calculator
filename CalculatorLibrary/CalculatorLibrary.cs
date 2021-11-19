using System;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operações");
            writer.WriteStartArray();
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Operador 1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operador 2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operação");

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Adição");
                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtração");
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiplicação");
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        writer.WriteValue("Divisão");
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            writer.WritePropertyName("Resultado");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}

