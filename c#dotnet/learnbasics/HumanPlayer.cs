using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseGround
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer()
        {
        }

        public override MoveDirection MakeMove()
        {
            ConsoleKeyInfo info = Console.ReadKey();

            if (info.Key == ConsoleKey.LeftArrow) { return MoveDirection.Left; }
            if (info.Key == ConsoleKey.RightArrow) { return MoveDirection.Right; }
            if (info.Key == ConsoleKey.UpArrow) { return MoveDirection.Up; }
            if (info.Key == ConsoleKey.DownArrow) { return MoveDirection.Down; }

            return MoveDirection.None;
        }
    }
}
