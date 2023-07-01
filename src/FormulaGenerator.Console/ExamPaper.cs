using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaGenerator.Console
{
    internal class ExamPaper
    {
        public void SaveToImage(string path, bool isShowAnswer = true)
        {
            Font fontTitle = new("宋体", 24, FontStyle.Bold);
            Font fontText = new("宋体", 12);
            Random random = new();
            char[] operators = new char[] { '+', '-', '×', '÷' };
            float mmpi = 25.4f;
            int dpi = 150;
            using Bitmap a4 = new((int)(210 / mmpi * dpi), (int)(297 / mmpi * dpi));
            a4.SetResolution(dpi, dpi);
            using Graphics graphics = Graphics.FromImage(a4);
            graphics.Clear(Color.White);

            graphics.DrawString("一· 口算：", fontTitle, Brushes.Black, 0, 20);

            //Formula[] oralCalculations = Enumerable.Range(0, 60).Select(x => Formula.EasyDivided).ToArray();
            Formula[] oralCalculations = new Formula[] {
                Formula.PlusDot99,
                Formula.MinusDot99,
                Formula.Multiplied1,
                Formula.Multiplied2,
                Formula.Divided,
                (Formula)Formula.Random_10_50 + Formula.SimpleMultiplied,
                Formula.PlusDot99,
                Formula.MinusDot99,
                Formula.Multiplied1,
                Formula.Multiplied2,
                Formula.Divided,
                (Formula)Formula.Random_10_50 + Formula.SimpleMultiplied,
            };
            IEnumerable<Formula> duplicate1 = new Formula[] {
                Formula.MultipliedDot10,
                Formula.MultipliedDot100,
                Formula.MultipliedDot1000,
                Formula.MultipliedDot10000,
                Formula.DividedDot10,
                Formula.DividedDot100,
                Formula.DividedDot1000,
                Formula.DividedDot10000,
            };
            duplicate1 = duplicate1.OrderBy(x => Guid.NewGuid());
            oralCalculations = oralCalculations.Concat(duplicate1.Take(1)).OrderBy(x => Guid.NewGuid()).ToArray();

            for (int i = 0; i < 10; i++)
            {
                int x = i % 2;
                int y = i / 2;
                graphics.DrawString($"{string.Join("", Enumerable.Range(0, 2 - (i + 1).ToString().Length).Select(i => ' '))}{i + 1}: {oralCalculations[i]} =", fontText, Brushes.Black, x * (a4.Width / 2 - 50), 120 + y * 40);
            }

            graphics.DrawString("二· 竖式计算：", fontTitle, Brushes.Black, 0, 350);

            Formula[] verticalCalculations = new Formula[] {
                Formula.DividedDot99,
                Formula.Multiplied999,
            };
            verticalCalculations = verticalCalculations.OrderBy(x => Guid.NewGuid()).ToArray();

            for (int i = 0; i < verticalCalculations.Length; i++)
            {
                int x = i % 2;
                int y = i / 2;
                graphics.DrawString($"{string.Join("", Enumerable.Range(0, 2 - (i + 1).ToString().Length).Select(i => ' '))}{i + 1}: {verticalCalculations[i]} =", fontText, Brushes.Black, x * (a4.Width / 2 - 50), 450 + y * 140);
            }

            graphics.DrawString("三· 脱式计算（可以简便计算的要简便计算）：", fontTitle, Brushes.Black, 0, 780);

            IEnumerable<Formula> detachableCalculations = new Formula[] {
                Formula.Multiplied99 + (Formula)Formula.RandomFloat_30_100,
                (Formula)Formula.Random_30_100 * Formula.Plus99,
                Formula.Divided99 + (Formula)Formula.RandomFloat_30_100,
                (Formula)Formula.Random_30_100 * Formula.Minus99,
            };
            detachableCalculations = detachableCalculations.OrderBy(x => Guid.NewGuid());
            IEnumerable<Formula> easy = new Formula[] {
                Formula.EasyPlusNNN,
                Formula.EasyMinusNNN,
                Formula.EasyMultipliedNNN,
                Formula.EasyMultipliedNNNN,
                Formula.EasyMultipliedNN,
                Formula.EasyMultipliedNNxNN,
                Formula.EasyDivided
            };
            easy = easy.OrderBy(x => Guid.NewGuid());
            var all = detachableCalculations.Take(2).Concat(easy.Take(2)).OrderBy(x => Guid.NewGuid()).ToArray();

            for (int i = 0; i < all.Length; i++)
            {
                int x = i % 2;
                int y = i / 2;
                graphics.DrawString($"{string.Join("", Enumerable.Range(0, 2 - (i + 1).ToString().Length).Select(i => ' '))}{i + 1}: {all[i]}", fontText, Brushes.Black, x * (a4.Width / 2 - 50), 880 + y * 320);
            }

            if (isShowAnswer)
            {
                var answer1 = string.Join("|", oralCalculations.Take(5).Select(x => x.FormulaResult.ToString()));
                var answer1_ = string.Join("|", oralCalculations.Skip(5).Take(5).Select(x => x.FormulaResult.ToString()));
                var answer2 = string.Join("|", verticalCalculations.Select(x => x.FormulaResult.ToString()));
                var answer3 = string.Join("|", detachableCalculations.Select(x => x.FormulaResult.ToString()));
                graphics.DrawString($" 口算1-5:[{answer1}]\r\n 口算6-10:[{answer1_}]\r\n 竖式计算:[{answer2}]\r\n 脱式计算:[{answer3}]", fontText, Brushes.Black, 50, a4.Height - 140);
            }
            a4.Save(path);
        }
    }
}
