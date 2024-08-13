using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class DrawingProgram
    {
        private static float _x, _y;
        private static IGraphics _graphics;

        public static void Initialization(IGraphics newGraphics)
        {
            _graphics = newGraphics;
            _graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var x = (float)(_x + length * Math.Cos(angle));
            var y = (float)(_y + length * Math.Sin(angle));
            _graphics?.DrawLine(pen, _x, _y, x, y);
            _x = x;
            _y = y;
        }

        public static void Change(double length, double angle)
        {
            _x = (float)(_x + length * Math.Cos(angle));
            _y = (float)(_y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        private const float Ratio1 = 0.375f;
        private const float Ratio2 = 0.04f;

        public static void Draw(int width, int height, double rotationAngle, IGraphics graphics)
        {
            DrawingProgram.Initialization(graphics);

            var size = Math.Min(width, height);

            const double pi = Math.PI;
            const double halfPi = pi / 2;
            const double quoterPi = pi / 4;
            var brushColor = Brushes.Yellow;

            var diagonalLength = Math.Sqrt(2) * (size * Ratio1 + size * Ratio2) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(quoterPi + pi)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(quoterPi + pi)) + height / 2f;

            DrawingProgram.SetPosition(x0, y0);

            //Рисуем 1-ую сторону
            DrawSide(brushColor, size, 0, quoterPi, pi, halfPi);
            DrawChange(size, -pi, 3 * quoterPi);

            //Рисуем 2-ую сторону
            DrawSide(brushColor, size, -halfPi, -halfPi + quoterPi, halfPi, 0);
            DrawChange(size, -halfPi - pi, quoterPi);

            //Рисуем 3-ю сторону
            DrawSide(brushColor, size, pi, pi + quoterPi, pi + pi, pi + halfPi);
            DrawChange(size, 0, pi + 3 * quoterPi);

            //Рисуем 4-ую сторону
            DrawSide(brushColor, size, halfPi, halfPi + quoterPi, halfPi + pi, pi);
            DrawChange(size, -halfPi, pi + quoterPi);
        }

        private static void DrawSide(IBrush brush, double size, double angle1, double angle2, double angle3,
            double angle4)
        {
            var length1 = size * Ratio1;
            var length2 = size * Ratio2;
            DrawingProgram.MakeIt(new Pen(brush), length1, angle1);
            DrawingProgram.MakeIt(new Pen(brush), length2 * Math.Sqrt(2), angle2);
            DrawingProgram.MakeIt(new Pen(brush), length1, angle3);
            DrawingProgram.MakeIt(new Pen(brush), length1 - length2, angle4);
        }

        private static void DrawChange(double size, double angle1, double angle2)
        {
            DrawingProgram.Change(size * Ratio2, angle1);
            DrawingProgram.Change(size * Ratio2 * Math.Sqrt(2), angle2);
        }
    }
}