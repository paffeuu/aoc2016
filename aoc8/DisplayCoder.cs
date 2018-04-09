using System;
using System.Text;

namespace aoc8
{
    public class DisplayCoder
    {
        private readonly int _width;
        private readonly int _height;
        public bool[,] Pixels { get; private set; }
        private readonly InstructionsInterpreter _interpreter;

        public DisplayCoder(InstructionsInterpreter interpreter, int width, int height)
        {
            _interpreter = interpreter;
            _width = width;
            _height = height;
            Pixels = new bool[width,height];
        }

        public void Code()
        {
            Instruction instruction;
            while ((instruction = _interpreter.Interpret()) != null)
            {
                switch (instruction)
                {
                    case RectInstruction _:
                        var rectInstruction = (RectInstruction) instruction;
                        Rect(rectInstruction.RectWidth, rectInstruction.RectHeight);
                        break;
                    case RotateInstruction _:
                        var rotateInstruction = (RotateInstruction) instruction;
                        switch (rotateInstruction.Type)
                        {
                            case 0:
                                RotateRow(rotateInstruction.Xy, rotateInstruction.By);
                                break;
                            case 1:
                                RotateColumn(rotateInstruction.Xy, rotateInstruction.By);
                                break;
                        }
                        break;
                }
            }
        }

        public string Display()
        {
            var stringBuilder = new StringBuilder();
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                    stringBuilder.Append(Pixels[x, y] ? "#" : ".");
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }
        
        public int CountOnPixels()
        {
            var counter = 0;
            foreach (var pixel in Pixels)
                if (pixel)
                    counter++;
            return counter;
        }

        private void Rect(int rectWidth, int rectHeight)
        {
            for (var x = 0; x < rectWidth; x++)
            for (var y = 0; y < rectHeight; y++)
                Pixels[x, y] = true;
        }

        private void RotateRow(int y, int by)
        {
            var tempA = (bool[,])Pixels.Clone();
            var tempB = (bool[,])tempA.Clone();
            for (var i = 0; i < by; i++)
            {
                for (var x = 0; x < _width; x++)
                    tempB[(x + 1) % _width, y] = tempA[x % _width, y];
                tempA = (bool[,]) tempB.Clone();
            }
            Pixels = (bool[,])tempA.Clone();
        }

        private void RotateColumn(int x, int by)
        {
            var tempA = (bool[,])Pixels.Clone();
            var tempB = (bool[,])tempA.Clone();
            for (var i = 0; i < by; i++)
            {
                for (var y = 0; y < _height; y++)
                    tempB[x, (y + 1) % _height] = tempA[x, y % _width];
                tempA = (bool[,]) tempB.Clone();
            }
            Pixels = (bool[,]) tempB.Clone();
        }
    }
}