using System;

namespace TreeStructure
{
    internal enum TreeDirection
    {
        Left,
        Right,
        Center
    }

    public class Tree
    {
        public int Depth { get; private set; }
        public int Value { get; private set; }
        public Tree Parent { get; private set; }
        public Tree LeftBranch { get; private set; }
        public Tree RightBranch { get; private set; }
        private TreeDirection Direction { get; set; }

        /// <summary>
        /// If input integer is lower than current branch value it goes to the right branch till finds empty value to be entered. Otherwise it goes to the left branch.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void BinaryEnter(int value)
        {
            if (Parent == null)
                Direction = TreeDirection.Center;

            if (Value == 0)
            {
                Value = value; return;
            }

            if (value > Value && RightBranch != null)
            {
                RightBranch.BinaryEnter(value);
            }
            else if (value > Value)
            {
                RightBranch = new Tree(); RightBranch.Parent = this; RightBranch.BinaryEnter(value); RightBranch.Direction = TreeDirection.Right;
            }

            if (value < Value && LeftBranch != null)
            {
                LeftBranch.BinaryEnter(value);
            }
            else if (value < Value)
            {
                LeftBranch = new Tree(); LeftBranch.Parent = this; LeftBranch.BinaryEnter(value); LeftBranch.Direction = TreeDirection.Left;
            }
            CalculateDepth();
        }
        private void CalculateDepth()
        {
            double approximateDepth = Math.Log2(ToArray().Length);

            Depth = (int)approximateDepth;

            if (approximateDepth > Depth)
                Depth++;
        }
        public Tree TryFind(int value)
        {
            if (Value == value)
                return this;

            if (Value > value && LeftBranch != null)
            {
                return LeftBranch.TryFind(value);
            }
            else if (Value < value && RightBranch != null)
            {
                return RightBranch.TryFind(value);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Deletes branch (With all children branches) the value of which is equal to input integer.
        /// </summary>
        /// <param name="value"></param>
        public void Delete(int value)
        {
            if (Parent == null && Value == value)
            {
                Value = 0; RightBranch = null; LeftBranch = null; return;
            }

            if (Value == value)
            {
                if (Parent.LeftBranch != null)
                    if(Parent.LeftBranch.Value == value)
                        Parent.LeftBranch = null;
                    

                if (Parent.RightBranch != null)
                    if(Parent.RightBranch.Value == value)
                    Parent.RightBranch = null;
                return;
            }

            if (value > Value && RightBranch != null)
            {
                RightBranch.Delete(value);
            }
            else if (value < Value && LeftBranch != null)
            {
                LeftBranch.Delete(value);
            }

            CalculateDepth();
        }
        public int[] ToArray()
        {
            int[] array = new int[100000];

            array[0] = 0;

            array[1] = Value;

            for (int i = 2; i < array.Length; i++)
                array[i] = 0;

            RightTree(array, 3); LeftTree(array, 2);

            int correctArrayLenght = 0;

            for (int i = array.Length - 1; i != 0; i--)
            {
                if (array[i] != 0)
                {
                    correctArrayLenght = i; break;
                }

            }

            int[] toReturnArray = new int[correctArrayLenght + 1];

            for (int i = 0; i < toReturnArray.Length; i++)
            {
                toReturnArray[i] = array[i];
            }

            return toReturnArray;
        }
        private void LeftTree(int[] array, int count)
        {
            Tree tree = this; int checkCode = 0;

            while (tree.LeftBranch != null)
            {
                tree = tree.LeftBranch;

                if (Parent == null && checkCode == 0)
                {
                    array[count] = tree.Value; checkCode = 1;
                }
                else
                {
                    array[count * 2] = tree.Value;
                }

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == tree.Value)
                    {
                        count = i; i = array.Length;
                    }
                }

                tree.RightTree(array, count);

            }
        }
        private void RightTree(int[] array, int count)
        {
            Tree tree = this; int checkCode = 0;

            while (tree.RightBranch != null)
            {
                tree = tree.RightBranch;

                if (Parent == null && checkCode == 0)
                {
                    array[count] = tree.Value; checkCode = 1;
                }
                else
                {
                    array[count * 2 + 1] = tree.Value;
                }

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == tree.Value)
                    {
                        count = i; i = array.Length;
                    }
                }

                tree.LeftTree(array, count);

            }
        }
        public void Print()
        {
            Print("", TreeDirection.Center, true, false);
        }
        private void PrintValue(string value, TreeDirection direction)
        {
            switch (direction)
            {
                case TreeDirection.Left:
                    PrintLeftValue(value);
                    break;
                case TreeDirection.Right:
                    PrintRightValue(value);
                    break;
                case TreeDirection.Center:
                    Console.WriteLine(value);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void PrintLeftValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("L:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintRightValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void Print(string indent, TreeDirection direction, bool last, bool empty)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }

            var stringValue = empty ? "-" : Value.ToString();
            PrintValue(stringValue, direction);

            if (!empty && (LeftBranch != null || RightBranch != null))
            {
                if (LeftBranch != null)
                    LeftBranch.Print(indent, TreeDirection.Left, false, false);
                else
                    Print(indent, TreeDirection.Left, false, true);

                if (RightBranch != null)
                    RightBranch.Print(indent, TreeDirection.Right, true, false);
                else
                    Print(indent, TreeDirection.Right, true, true);
            }
        }
    }
}
