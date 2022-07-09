using Microsoft.Maui.Graphics.Skia;

namespace FormulaGenerator.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Photos>();

            // Create a bitmap in memory and draw on its Canvas
            SkiaBitmapExportContext bmp = new(600, 400, 1.0f);
            ICanvas canvas = bmp.Canvas;

            // Draw a big blue rectangle with a dark border
            Rect backgroundRectangle = new(0, 0, bmp.Width, bmp.Height);
            canvas.FillColor = Color.FromArgb("#003366");
            canvas.FillRectangle(backgroundRectangle);
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 20;
            canvas.DrawRectangle(backgroundRectangle);

            // Draw circles randomly around the image
            for (int i = 0; i < 100; i++)
            {
                float x = Random.Shared.Next(bmp.Width);
                float y = Random.Shared.Next(bmp.Height);
                float r = Random.Shared.Next(5, 50);

                Color randomColor = Color.FromRgb(
                    red: Random.Shared.Next(255),
                    green: Random.Shared.Next(255),
                    blue: Random.Shared.Next(255));

                canvas.StrokeSize = r / 3;
                canvas.StrokeColor = randomColor.WithAlpha(.3f);
                canvas.DrawCircle(x, y, r);
            }

            // Measure a string
            string myText = "Hello, Maui.Graphics!";
            Microsoft.Maui.Graphics.Font myFont = new Microsoft.Maui.Graphics.Font("Impact");
            float myFontSize = 48;
            canvas.Font = myFont;
            SizeF textSize = canvas.GetStringSize(myText, myFont, myFontSize);

            // Draw a rectangle to hold the string
            Point point = new(
                x: (bmp.Width - textSize.Width) / 2,
                y: (bmp.Height - textSize.Height) / 2);
            Rect myTextRectangle = new(point, textSize);
            canvas.FillColor = Colors.Black.WithAlpha(.5f);
            canvas.FillRectangle(myTextRectangle);
            canvas.StrokeSize = 2;
            canvas.StrokeColor = Colors.Yellow;
            canvas.DrawRectangle(myTextRectangle);

            // Daw the string itself
            canvas.FontSize = myFontSize * .9f; // smaller than the rectangle
            canvas.FontColor = Colors.White;
            canvas.DrawString(myText, myTextRectangle,
                HorizontalAlignment.Center, VerticalAlignment.Center, TextFlow.OverflowBounds);

            // Save the image as a PNG file
            var picDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var picPath = Path.Combine(picDir, "console2.png");
            bmp.WriteToFile(picPath);
        }
    }
}