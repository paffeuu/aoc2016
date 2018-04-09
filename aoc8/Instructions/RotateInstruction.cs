namespace aoc8
{
    public class RotateInstruction : Instruction
    {
        public int Type { get; }
        public int Xy { get; }
        public int By { get; }

        public RotateInstruction(int type, int xy, int by)
        {
            Type = type;
            Xy = xy;
            By = by;
        }
    }
}