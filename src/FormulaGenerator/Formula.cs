using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaGenerator
{
    public class Formula
    {
        public enum MathSymbol
        {
            Plus,
            Minus,
            Multiplied,
            Divided,
            Unknow
        }

        private static Random random = new Random();
        public static int Random_0_10 => random.Next(0, 10);
        public static int Random_3_10 => random.Next(3, 10);
        public static int Random_10_100 => random.Next(10, 100);
        public static int Random_30_100 => random.Next(30, 100);
        public static int Random_NN0 => Random_30_100 * 10;
        public static int Random_N0N => Random_3_10 * 100 + Random_3_10;
        public static int Random_10_50 => random.Next(10, 50);
        public static int Random_50_100 => random.Next(50, 100);
        public static int Random_3_100 => random.Next(3, 100);

        public static Formula Plus => (Formula)Random_10_100 + (Formula)Random_10_100;
        public static Formula Minus => (Formula)Random_50_100 - (Formula)Random_10_50;
        public static Formula Multiplied => (Formula)Random_30_100 * (Formula)Random_30_100;
        public static Formula Multiplied1 => (Formula)Random_NN0 * (Formula)Random_3_10;
        public static Formula Multiplied2 => (Formula)Random_N0N * (Formula)Random_3_10;
        public static Formula SimpleMultiplied => (Formula)Random_3_10 * (Formula)Random_3_10;
        public static Formula Divided => (Formula)Random_50_100 / (Formula)Random_3_10;
        public static Formula SimpleDivided => (Formula)Random_3_10 / (Formula)Random_3_10;
        public static Formula SimpleRandomMathSymbol(Formula formula1, Formula formula2)
        {
            var randomNum = random.Next(0, 4);
            return randomNum switch
            {
                0 => formula1 + formula2,
                1 => formula1 - formula2,
                2 => formula1 * formula2,
                3 => formula1 / formula2,
                _ => formula1 + formula2,
            };
        }

        public int Value { get; }
        public Formula? Formula1 { get; }
        public MathSymbol? Symbol { get; }
        public Formula? Formula2 { get; }
        public int FormulaResult
        {
            get
            {
                if (Symbol == null || Formula1 == null || Formula2 == null)
                {
                    return Value;
                }
                return Symbol switch
                {
                    MathSymbol.Plus => Formula1.FormulaResult + Formula2.FormulaResult,
                    MathSymbol.Minus => Formula1.FormulaResult - Formula2.FormulaResult,
                    MathSymbol.Multiplied => Formula1.FormulaResult * Formula2.FormulaResult,
                    MathSymbol.Divided => Formula1.FormulaResult / Formula2.FormulaResult,
                    _ => Value,
                };
            }
        }

        public Formula(int value)
        {
            Value = value;
        }
        public Formula(int value1, MathSymbol symbol, int value2) : this((Formula)value1, symbol, (Formula)value2)
        {
        }
        public Formula(Formula formula1, MathSymbol symbol, Formula formula2)
        {
            Formula1 = formula1;
            Symbol = symbol;
            Formula2 = formula2;
        }
        public Formula(int value1, int value2)
        {
            Formula1 = (Formula)(value1 * value2);
            Symbol = MathSymbol.Divided;
            Formula2 = (Formula)value2;
        }

        public string WithBrackets()
        {
            if (Symbol == null || Formula1 == null || Formula2 == null)
            {
                return Value.ToString();
            }
            var result = Symbol switch
            {
                MathSymbol.Plus => $"({Formula1} + {Formula2})",
                MathSymbol.Minus => $"({Formula1} - {Formula2})",
                MathSymbol.Multiplied => $"{Formula1} × {Formula2}",
                MathSymbol.Divided => $"{Formula1} ÷ {Formula2}",
                _ => ToString()
            };
            return result;
        }

        public override string ToString()
        {
            if (Symbol == null || Formula1 == null || Formula2 == null)
            {
                return Value.ToString();
            }
            return Symbol switch
            {
                MathSymbol.Plus => $"{Formula1} + {Formula2}",
                MathSymbol.Minus => $"{Formula1} - {Formula2}",
                MathSymbol.Multiplied => $"{Formula1.WithBrackets()} × {Formula2.WithBrackets()}",
                MathSymbol.Divided => $"{Formula1.WithBrackets()} ÷ {Formula2.WithBrackets()}",
                _ => ToString()
            };
        }

        public static explicit operator int(Formula fcormula)
        {
            return fcormula.FormulaResult;
        }

        public static explicit operator Formula(int value)
        {
            return new Formula(value);
        }

        public static Formula operator +(Formula formula1, Formula formula2)
        {
            return new Formula(formula1, MathSymbol.Plus, formula2);
        }
        public static Formula operator -(Formula formula1, Formula formula2)
        {
            return new Formula(formula1, MathSymbol.Minus, formula2);
        }
        public static Formula operator *(Formula formula1, Formula formula2)
        {
            return new Formula(formula1, MathSymbol.Multiplied, formula2);
        }
        public static Formula operator /(Formula formula1, Formula formula2)
        {
            return new Formula((Formula)((int)formula1 * (int)formula2), MathSymbol.Divided, formula2);
        }
    }
}
