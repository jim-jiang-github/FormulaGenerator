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
        public static int Random_100x1_2 => random.Next(1, 2) * 100;
        public static int Random_100x1_5 => random.Next(1, 5) * 100;
        public static int Random_100x3_6 => random.Next(3, 6) * 100;
        public static int Random_100x1_9 => random.Next(1, 10) * 100;
        public static int Random_100x2_5 => random.Next(2, 6) * 100;
        public static int Random_100x2_10 => random.Next(2, 11) * 100;
        public static int Random_8x2_9 => random.Next(2, 10) * 8;
        public static int Random_4x2_9 => random.Next(2, 10) * 4;
        public static int Random_0_2 => random.Next(0, 2);
        public static int Random_1_3 => random.Next(1, 3);
        public static int Random_2_4 => random.Next(2, 4);
        public static int Random_2_5 => random.Next(2, 5);
        public static int Random_2_8 => random.Next(2, 8);
        public static int Random_2_10 => random.Next(2, 10);
        public static int Random_3_9 => random.Next(3, 9);
        public static int Random_3_10 => random.Next(3, 10);
        public static int Random_4_9 => random.Next(4, 9);
        public static int Random_10_30 => random.Next(10, 30);
        public static int Random_10_100 => random.Next(10, 100);
        public static int Random_10_20 => random.Next(10, 20);
        public static int Random_10_50 => random.Next(10, 50);
        public static int Random_20_60 => random.Next(20, 60);
        public static int Random_20_100 => random.Next(20, 100);
        public static int Random_30_100 => random.Next(30, 100);
        public static int Random_30_80 => random.Next(30, 80);
        public static int Random_50_100 => random.Next(50, 100);
        public static int Random_50_90 => random.Next(50, 91);
        public static int Random_50_500 => random.Next(50, 500);
        public static int Random_100_500 => random.Next(100, 500);
        public static int Random_100_300 => random.Next(100, 300);
        public static int Random_100_1000 => random.Next(100, 1000);
        public static int Random_200_300 => random.Next(200, 300);
        public static int Random_300_600 => random.Next(300, 600);
        public static int Random_300_1000 => random.Next(300, 1000);
        public static decimal RandomFloat_0_10 => (random.Next(10, 100) / (decimal)10);
        public static decimal RandomFloat_2_50 => (random.Next(20, 500) / (decimal)10);
        public static decimal RandomFloat_3_10 => (random.Next(30, 100) / (decimal)10);
        public static decimal RandomFloat_10_100 => (random.Next(100, 1000) / (decimal)10);
        public static decimal RandomFloat_30_100 => (random.Next(300, 1000) / (decimal)10);
        public static decimal RandomFloat_300_1000 => (random.Next(3000, 10000) / (decimal)10);
        public static decimal RandomFloat_3000_10000 => (random.Next(30000, 100000) / (decimal)10);
        public static decimal RandomFloat_30000_100000 => (random.Next(300000, 1000000) / (decimal)10);
        public static decimal RandomFloat_10_50 => (random.Next(100, 500) / (decimal)10);
        public static decimal RandomFloat_50_100 => (random.Next(500, 1000) / (decimal)10);

        public static int Random_NN0 => Random_30_100 * 10;
        public static int Random_N0N => Random_3_10 * 100 + Random_3_10;
        public static int Random_3_100 => random.Next(3, 100);

        public static Formula Plus99 => (Formula)Random_10_100 + (Formula)Random_10_100;
        public static Formula Plus999 => (Formula)Random_10_100 + (Formula)Random_100_1000;
        public static Formula PlusDot99 => (Formula)RandomFloat_10_100 + (Formula)RandomFloat_10_100;

        public static Formula Minus99 => (Formula)Random_50_100 - (Formula)Random_10_50;
        public static Formula MinusDot99 => (Formula)RandomFloat_50_100 - (Formula)RandomFloat_10_50;

        public static Formula SimpleMultiplied => (Formula)Random_3_10 * (Formula)Random_3_10;
        public static Formula Multiplied1 => (Formula)Random_NN0 * (Formula)Random_3_10;
        public static Formula Multiplied2 => (Formula)Random_N0N * (Formula)Random_3_10;
        public static Formula MultipliedDot10 => (Formula)(RandomFloat_30_100) * (Formula)(10);
        public static Formula MultipliedDot100 => (Formula)(RandomFloat_30_100) * (Formula)(100);
        public static Formula MultipliedDot1000 => (Formula)(RandomFloat_30_100) * (Formula)(1000);
        public static Formula MultipliedDot10000 => (Formula)(RandomFloat_30_100) * (Formula)(10000);
        public static Formula DividedDot10 => (Formula)(RandomFloat_30_100) / (Formula)(10);
        public static Formula DividedDot100 => (Formula)(RandomFloat_300_1000) / (Formula)(100);
        public static Formula DividedDot1000 => (Formula)(RandomFloat_3000_10000) / (Formula)(1000);
        public static Formula DividedDot10000 => (Formula)(RandomFloat_30000_100000) / (Formula)(10000);
        public static Formula Divided => GetDivided(Random_10_30, Random_2_5);

        public static Formula DividedDot => GetDivided(Random_3_10, RandomFloat_3_10);

        public static Formula Divided99 => GetDivided(Random_10_30, Random_10_30);
        public static Formula DividedDot99 => GetDividedInt(() => Random_20_100, () => RandomFloat_2_50);
        public static Formula Multiplied99 => (Formula)Random_30_100 * (Formula)Random_30_100;
        public static Formula Multiplied999 => (Formula)Random_100_500 * (Formula)Random_30_100;
        //public static Formula Multiplied500 => (Formula)Random_50_500 * (Formula)Random_50_500;
        //public static Formula Divided500 => GetDivided(Random_30_100, RandomFloat_3_10);

        public static Formula GetDividedInt(Func<int> divF, Func<decimal> vF)
        {
            int div = divF.Invoke();
            decimal v = vF.Invoke();
            while (div * v % 1 != 0 || div * v > 999 || div * v <= 210)
            {
                div = divF.Invoke();
                v = vF.Invoke();
            }
            return GetDivided(div, v);
        }
        public static Formula GetDivided(int div, decimal v)
        {
            return (Formula)(div * v) / (Formula)div;
        }

        public static Formula EasyPlusNNN
        {
            get
            {
                List<Formula> formulas = new List<Formula>();
                formulas.Add((Formula)Random_200_300);
                var x = Random_10_100;
                formulas.Add((Formula)x);
                formulas.Add((Formula)(Random_100x1_5 - x));
                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                var flag = Random_0_2;
                int i = 0;
                var formula = formulas.Aggregate((x1, x2) =>
                {
                    if (i++ == flag)
                    {
                        return (Formula)x1 - (Formula)Random_10_100 + x2;
                    }
                    else
                    {
                        return (Formula)x1 + x2;
                    }
                });
                return formula;
            }
        }

        public static Formula EasyMinusNNN
        {
            get
            {
                var n = Random_100x1_2;
                var x = Random_10_100;
                Formula f1 = (Formula)(Random_100_300 + n) + (Formula)Random_10_100 - (Formula)x - (Formula)(n - x);
                Formula f2 = (Formula)(Random_100_300 + n) - (Formula)x + (Formula)Random_10_100 - (Formula)(n - x);
                Formula f3 = (Formula)(Random_100_300 + n) - (Formula)x - (Formula)(n - x) + (Formula)Random_10_100;
                Formula f4 = (Formula)(Random_100_300 + n) - (Formula)Random_10_100 - (Formula)x - (Formula)(n - x);
                Formula f5 = (Formula)(Random_100_300 + n) - (Formula)x - (Formula)Random_10_100 - (Formula)(n - x);
                Formula f6 = (Formula)(Random_100_300 + n) - (Formula)x - (Formula)(n - x) - (Formula)Random_10_100;
                List<Formula> formulas = new List<Formula>();

                formulas.Add(f1);
                formulas.Add(f2);
                formulas.Add(f3);
                formulas.Add(f4);
                formulas.Add(f5);
                formulas.Add(f6);

                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                return formulas.First();
            }
        }

        public static Formula EasyMultipliedNNN
        {
            get
            {
                var fs1 = GetTwoFormulaPlus(Random_8x2_9);
                var a1 = fs1[0];
                var b1 = fs1[1];
                Formula f1 = (Formula)125 * (Formula)a1 + (Formula)125 * (Formula)b1;
                Formula f2 = (Formula)25 * (Formula)a1 + (Formula)25 * (Formula)b1;
                var fs2 = GetTwoFormulaPlus(Random_4x2_9);
                var a2 = fs1[0];
                var b2 = fs1[1];
                Formula f3 = (Formula)125 * (Formula)a2 + (Formula)125 * (Formula)b2;
                Formula f4 = (Formula)25 * (Formula)a2 + (Formula)25 * (Formula)b2;

                var fs3 = GetTwoFormulaPlus(Random_8x2_9);
                var a3 = fs3[0];
                var b3 = fs3[1];
                Formula f5 = (Formula)125 * (Formula)a3 - (Formula)125 * (Formula)b3;
                Formula f6 = (Formula)25 * (Formula)a3 - (Formula)25 * (Formula)b3;
                var fs4 = GetTwoFormulaPlus(Random_4x2_9);
                var a4 = fs4[0];
                var b4 = fs4[1];
                Formula f7 = (Formula)125 * (Formula)a4 - (Formula)125 * (Formula)b4;
                Formula f8 = (Formula)25 * (Formula)a4 - (Formula)25 * (Formula)b4;
                List<Formula> formulas = new List<Formula>();

                formulas.Add(f1);
                formulas.Add(f2);
                formulas.Add(f3);
                formulas.Add(f4);
                formulas.Add(f5);
                formulas.Add(f6);
                formulas.Add(f7);
                formulas.Add(f8);
                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                return formulas.First();
            }
        }

        public static Formula EasyMultipliedNNxNN
        {
            get
            {
                var n = Random_50_100;
                var fs5 = GetTwoFormulaPlus(Random_100x2_10);
                var a5 = fs5[0];
                var b5 = fs5[1];
                Formula f9 = (Formula)n * (Formula)a5 + (Formula)n * (Formula)b5;
                var fs6 = GetTwoFormulaMinus(Random_100x2_5);
                var a6 = fs6[0];
                var b6 = fs6[1];
                Formula f10 = (Formula)n * (Formula)a6 - (Formula)n * (Formula)b6;
                List<Formula> formulas = new List<Formula>();
                formulas.Add(f9);
                formulas.Add(f10);
                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                return formulas.First();
            }
        }

        public static Formula EasyDivided
        {
            get
            {
                var c = Random_2_10;
                var b = c * Random_2_10;
                var a = b * 10;
                Formula f1 = (Formula)c * (Formula)b;
                Formula f2 = (Formula)a / (Formula)f1;
                return f2;
            }
        }

        public static Formula[] GetTwoFormulaPlus(int value)
        {
            var v1 = random.Next(value / 4, value * 3 / 4);
            var v2 = value - v1;
            return new[] { (Formula)v1, (Formula)v2 };
        }

        public static Formula[] GetTwoFormulaMinus(int value)
        {
            var v2 = random.Next(value / 4, value * 3 / 4);
            var v1 = value + v2;
            return new[] { (Formula)v1, (Formula)v2 };
        }

        public static Formula EasyMultipliedNNNN
        {
            get
            {
                var n1 = Random_50_100;
                var a1 = Random_30_80;
                var b1 = 100 - a1;
                var c1 = 100 + b1;
                Formula f1 = (Formula)n1 * (Formula)a1 + (Formula)n1 * (Formula)b1;
                Formula f2 = (Formula)n1 * (Formula)c1 - (Formula)n1 * (Formula)b1;
                var n2 = Random_100x1_9;
                var a2 = Random_2_4;
                var b2 = n2 - a2;
                var c2 = n2 + a2;
                Formula f3 = (Formula)b2 * (Formula)Random_10_100;
                Formula f4 = (Formula)c2 * (Formula)Random_10_100;
                List<Formula> formulas = new List<Formula>();

                formulas.Add(f1);
                formulas.Add(f2);
                formulas.Add(f3);
                formulas.Add(f4);
                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                return formulas.First();
            }
        }

        public static Formula EasyMultipliedNN
        {
            get
            {
                var n1 = 8 * Random_3_9;
                List<Formula> formulas = new List<Formula>();
                formulas.Add((Formula)125);
                formulas.Add((Formula)n1);
                formulas.Add((Formula)Random_3_10);
                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                Formula f1 = formulas.Aggregate((x1, x2) => (Formula)x1 * (Formula)x2);

                formulas.Clear();
                formulas.Add((Formula)25);
                formulas.Add((Formula)n1);
                formulas.Add((Formula)Random_3_10);
                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                Formula f2 = formulas.Aggregate((x1, x2) => (Formula)x1 * (Formula)x2);

                var n2 = 4 * Random_3_9;
                formulas.Clear();
                formulas.Add((Formula)25);
                formulas.Add((Formula)n2);
                formulas.Add((Formula)Random_3_10);
                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                Formula f3 = formulas.Aggregate((x1, x2) => (Formula)x1 * (Formula)x2);

                formulas.Clear();
                formulas.Add((Formula)125);
                formulas.Add((Formula)n2);
                formulas.Add((Formula)Random_3_10);
                formulas = formulas.OrderBy(x => Guid.NewGuid()).ToList();
                Formula f4 = formulas.Aggregate((x1, x2) => (Formula)x1 * (Formula)x2);

                List<Formula> formulas1 = new List<Formula>();
                formulas1.Add(f1);
                formulas1.Add(f2);
                formulas1.Add(f3);
                formulas1.Add(f4);
                formulas1 = formulas1.OrderBy(x => Guid.NewGuid()).ToList();
                return formulas1.First();
            }
        }

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

        public decimal Value { get; }
        public Formula? Formula1 { get; }
        public MathSymbol? Symbol { get; }
        public Formula? Formula2 { get; }
        public decimal FormulaResult
        {
            get
            {
                if (Symbol == null || Formula1 == null || Formula2 == null)
                {
                    return Value;
                }
                if (Symbol == MathSymbol.Divided)
                {
                    var r1 = Formula1.FormulaResult;
                    var r2 = Formula2.FormulaResult;
                    var value = r1 / r2;
                    return value;
                }
                return Symbol switch
                {
                    MathSymbol.Plus => Formula1.FormulaResult + Formula2.FormulaResult,
                    MathSymbol.Minus => Formula1.FormulaResult - Formula2.FormulaResult,
                    MathSymbol.Multiplied => Formula1.FormulaResult * Formula2.FormulaResult,
                    _ => Value,
                };
            }
        }

        public Formula(decimal value)
        {
            Value = value;
        }
        public Formula(decimal value1, MathSymbol symbol, decimal value2) : this((Formula)value1, symbol, (Formula)value2)
        {
        }
        public Formula(Formula formula1, MathSymbol symbol, Formula formula2)
        {
            Formula1 = formula1;
            Symbol = symbol;
            Formula2 = formula2;
        }
        public Formula(decimal value1, decimal value2)
        {
            Formula1 = (Formula)(value1 * value2);
            Symbol = MathSymbol.Divided;
            Formula2 = (Formula)value2;
        }

        public string WithBrackets()
        {
            if (Symbol == null || Formula1 == null || Formula2 == null)
            {
                if (Value % 1 == 0)
                {
                    return ((int)Value).ToString();
                }
                else
                {
                    return Value.ToString();
                }
            }
            var result = Symbol switch
            {
                MathSymbol.Plus => $"({Formula1} + {Formula2})",
                MathSymbol.Minus => $"({Formula1} - {Formula2})",
                MathSymbol.Multiplied => $"({Formula1} × {Formula2})",
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
            var value = Symbol switch
            {
                MathSymbol.Plus => $"{Formula1} + {Formula2}",
                MathSymbol.Minus => $"{Formula1} - {Formula2}",
                MathSymbol.Multiplied => $"{Formula1} × {Formula2.WithBrackets()}",
                MathSymbol.Divided => $"{Formula1.WithBrackets()} ÷ {Formula2.WithBrackets()}",
                _ => ToString()
            };
            return value;
        }

        public static explicit operator decimal(Formula fcormula)
        {
            return fcormula.FormulaResult;
        }

        public static explicit operator Formula(decimal value)
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
            return new Formula(formula1, MathSymbol.Divided, formula2);
        }
    }
}
