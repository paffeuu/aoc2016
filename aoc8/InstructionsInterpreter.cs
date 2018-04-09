namespace aoc8
{
    public class InstructionsInterpreter
    {
        private string[] _input;
        private int _counter;


        public InstructionsInterpreter(string[] input)
        {
            _input = input;
            _counter = 0;
        }

        public Instruction Interpret()
        {
            if (_counter == _input.Length) return null;
            var split = _input[_counter++].Split(' ');
            if (split[0].Equals("rect"))
                return PrepareRectInstruction(split);
            if (split[1].Equals("row"))
                return PrepareRotateInstruction(split, 0);
            if (split[1].Equals("column"))
                return PrepareRotateInstruction(split, 1);
            return null;
        }

        private static Instruction PrepareRectInstruction(string[] split)
        {
            var rectSizeSplit = split[1].Split('x');
            int.TryParse(rectSizeSplit[0], out var rectWidth);
            int.TryParse(rectSizeSplit[1], out var rectHeigth);
            return new RectInstruction(rectWidth, rectHeigth);
        }

        private static Instruction PrepareRotateInstruction(string[] split, int type)
        {
            int.TryParse(split[2].Split('=')[1], out var xy);
            int.TryParse(split[4], out var by);
            return new RotateInstruction(type, xy, by);
        }
        
    }
}