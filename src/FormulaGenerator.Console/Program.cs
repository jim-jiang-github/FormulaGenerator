using FormulaGenerator;
using FormulaGenerator.Console;
using System.Drawing;

Console.Write("Enter exam papers count：");
var read = Console.ReadLine();
if (int.TryParse(read, out int count))
{
    Console.Write("Need display answer(yes/no)：");
    var needShowAnswer = Console.ReadLine();
    var isShowAnswer = true;
    if (needShowAnswer == "no")
    {
        isShowAnswer = false;
    }
    ExamPaper examPaper = new ExamPaper();
    var rootDir = "ExamPapers";
    if (Directory.Exists(rootDir))
    {
        Directory.Delete(rootDir, true);
    }
    Directory.CreateDirectory(rootDir);
    for (int i = 0; i < count; i++)
    {
        examPaper.SaveToImage(Path.Combine("ExamPapers", $"{i}.png"), isShowAnswer);
    }
}