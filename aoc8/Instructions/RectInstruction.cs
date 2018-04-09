namespace aoc8
{
    public class RectInstruction : Instruction
    {
        public int RectWidth { get; }
        public int RectHeight { get; }

        public RectInstruction(int rectWidth, int rectHeight)
        {
            RectHeight = rectHeight;
            RectWidth = rectWidth;
        }
    }
}