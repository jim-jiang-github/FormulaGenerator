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
        public void SaveToImage(string path)
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

            Formula[] oralCalculations = new Formula[] {
                Formula.Plus,
                Formula.Minus,
                Formula.Multiplied,
                Formula.SimpleDivided,
                (Formula)Formula.Random_10_50 + Formula.SimpleMultiplied,
                (Formula)Formula.Random_10_50 + Formula.SimpleMultiplied };
            oralCalculations = oralCalculations.OrderBy(x => Guid.NewGuid()).ToArray();

            for (int i = 0; i < oralCalculations.Length; i++)
            {
                int x = i % 2;
                int y = i / 2;
                graphics.DrawString($"{string.Join("", Enumerable.Range(0, 2 - (i + 1).ToString().Length).Select(i => ' '))}{i + 1}: {oralCalculations[i]} =", fontText, Brushes.Black, x * (a4.Width / 2 - 50), 120 + y * 80);
            }

            graphics.DrawString("二· 竖式计算：", fontTitle, Brushes.Black, 0, 350);

            Formula[] verticalCalculations = new Formula[] {
                Formula.Multiplied,
                Formula.Multiplied1,
                Formula.Multiplied2,
                Formula.Divided };
            verticalCalculations = verticalCalculations.OrderBy(x => Guid.NewGuid()).ToArray();

            for (int i = 0; i < verticalCalculations.Length; i++)
            {
                int x = i % 2;
                int y = i / 2;
                graphics.DrawString($"{string.Join("", Enumerable.Range(0, 2 - (i + 1).ToString().Length).Select(i => ' '))}{i + 1}: {verticalCalculations[i]} =", fontText, Brushes.Black, x * (a4.Width / 2 - 50), 450 + y * 280);
            }

            graphics.DrawString("三· 脱式计算：", fontTitle, Brushes.Black, 0, 1050);

            Formula[] detachableCalculations = new Formula[] {
                Formula.Multiplied + (Formula)Formula.Random_10_100,
                (Formula)Formula.Random_3_10 * Formula.Plus};
            detachableCalculations = detachableCalculations.OrderBy(x => Guid.NewGuid()).ToArray();

            for (int i = 0; i < detachableCalculations.Length; i++)
            {
                int x = i % 2;
                int y = i / 2;
                graphics.DrawString($"{string.Join("", Enumerable.Range(0, 2 - (i + 1).ToString().Length).Select(i => ' '))}{i + 1}: {detachableCalculations[i]} =", fontText, Brushes.Black, x * (a4.Width / 2 - 50), 1150 + y * 280);
            }
            a4.Save(path);
        }
    }
}
