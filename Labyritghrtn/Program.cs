using System.Drawing;
using System.Numerics;
using System.Text;

namespace Labyritghrtn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Width:");
            int.TryParse(Console.ReadLine(), out int width);
            Console.WriteLine("Height:");
            int.TryParse(Console.ReadLine(), out int height);

            if (width <= 0 || height <= 0)
                throw new Exception("Invalid width or height!");

            char[,] mazeArray = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                string? mazeLine = Console.ReadLine();
                if (mazeLine == null)
                    throw new Exception("Invalid maze input!");

                for (int j = 0; j < width; j++)
                    mazeArray[i, j] = mazeLine[j];
            }

            Maze maze = new Maze(width, height, mazeArray);
            Console.WriteLine(maze);
        }
    }

    class Maze
    {
        int Width;
        int Height;
        char[,] MazeArray;

        private Dictionary<Vector2, char> rotationToChar = new Dictionary<Vector2, char>
        {
            { new Vector2(-1, 0), '<' },
            { new Vector2(1, 0), '>' },
            { new Vector2(0, -1), '^' },
            { new Vector2(0, 1), 'v' },
        };
        private Dictionary<char, Vector2> chatToRotation = new Dictionary<char, Vector2>
        {
            { '<', new Vector2(-1, 0) },
            { '>', new Vector2(1, 0) },
            { '^', new Vector2(0, -1) },
            { 'v', new Vector2(0, 1) },
        };

        private Vector2 monsterPosition;
        private Vector2 monsterRotation;

        public Maze(int width, int height, char[,] mazeArray)
        {
            Width = width;
            Height = height;
            MazeArray = mazeArray;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    char ch = MazeArray[i, j];
                    if (chatToRotation.ContainsKey(ch))
                    {
                        monsterPosition = new Vector2(j, i);
                        monsterRotation = chatToRotation[ch];
                    }
                }
            }
        }

        public bool IsPositionValid(int y, int x)
        {
            if (y < 0 || y >= Height)
                return false;
            if (x < 0 || x >= Width)
                return false;

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    sb.Append(MazeArray[i, j]);

                if (i < Width - 1)
                    sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}
