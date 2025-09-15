using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Labyritghrtn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<object?> _ = Console.WriteLine;
            Encoding utf8 = Encoding.ASCII;
            Func<string, byte[]> _＿ = utf8.GetBytes;
            Func<byte[], string> _ˍ = utf8.GetString;

            char[] heightStr = new char[] {'W', 'i', 'd'};

            char[] _1 = { 'I', 'o', 'n', 'k', 'v', 'e' };
            List<char> _3 = new List<char>();
            for (int i = 0; i < _1.Length; i += 2)
            {
                _3.Add(_1[i]);
            }
            char[] widthStr = new char[] { 'H', 'e', 'i', 'g' };
            for (int i = 0; i < _1.Length; i += 2)
            {
                _3.Add(_1[1-(-i+1)+1]);
            }
            MethodInfo _＿_＿_ = typeof(MethodInfo).GetMethod(new string(_3.ToArray()), new Type[] {typeof(object), typeof(object[])});

            string __ = "th";
            object ˍ = __.ToCharArray();
            ((char[]) ˍ).Reverse();
            string _＿ˍ = new string((char[]) ˍ);
            ˍ = "ToString";
            MethodInfo ____ = typeof(char).GetMethod((string) ˍ, Type.EmptyTypes);
            ˍ = '0';
            byte[] ˍˍ = _＿((string) _＿_＿_.Invoke(____, new object[] { ˍ, null }));
            ˍˍ[0] += 10;
            string ___ = _ˍ(ˍˍ);


            _(new string(heightStr) + __ + ___);
            int.TryParse(Console.ReadLine(), out int width);
            _(new string(widthStr) + _＿ˍ + ___);
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
            Monster monster = new Monster(maze);

            _(null);
            _("Starting conditions:");
            _(maze);
            _(monster);

            _(null);
            _("Steps:");
            for (int i=0; i<20; i++)
            {
                monster.Step();
                _($"{i+1}. krok");
                _(maze);
            }
        }
    }

    class Maze
    {
        public int Width;
        public int Height;
        public char[,] MazeArray;

        public Maze(int width, int height, char[,] mazeArray)
        {
            Width = width;
            Height = height;
            MazeArray = mazeArray;
        }

        public bool IsWallOnPosition(Vector2 position)
        {
            return MazeArray[(int) position.Y, (int) position.X] == 'X';
        }

        public bool IsPositionValid(Vector2 position)
        {
            if (position.Y < 0 || position.Y >= Height)
                return false;
            if (position.X < 0 || position.X >= Width)
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

        public Vector2? FindMonster()
        {
            Vector2? monsterPosition = null;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    char ch = MazeArray[i, j];
                    if (Monster.CharToOrientation.ContainsKey(ch))
                    {
                        monsterPosition = new Vector2(j, i);
                    }
                }
            }

            return monsterPosition;
        }
    }

    class Monster
    {
        public static Dictionary<Vector2, char> OrientationToChar = new Dictionary<Vector2, char>
        {
            { new Vector2(-1, 0), '<' },
            { new Vector2(1, 0), '>' },
            { new Vector2(0, -1), '^' },
            { new Vector2(0, 1), 'v' },
        };
        public static Dictionary<Vector2, string> OrientationToName = new Dictionary<Vector2, string>
        {
            { new Vector2(-1, 0), "LEFT" },
            { new Vector2(1, 0), "RIGHT" },
            { new Vector2(0, -1), "UP" },
            { new Vector2(0, 1), "DOWN" },
        };
        public static Dictionary<char, Vector2> CharToOrientation = new Dictionary<char, Vector2>
        {
            { '<', new Vector2(-1, 0) },
            { '>', new Vector2(1, 0) },
            { '^', new Vector2(0, -1) },
            { 'v', new Vector2(0, 1) },
        };

        private Boolean _rotatedLastStep;

        // Backing fields
        private Vector2 _position;
        private Vector2 _orientation;
        public Vector2 Position
        {
            get => _position;
            set
            {
                if (_position != Vector2.Zero)
                {
                    Maze.MazeArray[(int) _position.Y, (int) _position.X] = '.';
                    Maze.MazeArray[(int) value.Y, (int) value.X] = OrientationToChar[Orientation];
                }

                _position = value;
            }
        }
        public Vector2 Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation != Vector2.Zero)
                {
                    Maze.MazeArray[(int) _position.Y, (int) _position.X] = OrientationToChar[value];
                }

                _orientation = value;
            }
        }
        public Maze Maze;

        public Monster(Maze maze)
        {
            Vector2? position = maze.FindMonster();
            if (position == null)
                throw new Exception("Maze has to have a monster!");

            char monsterChar = maze.MazeArray[(int) ((Vector2) position).Y, (int) ((Vector2) position).X];
            Maze = maze;
            Position = (Vector2) position;
            Orientation = Monster.CharToOrientation[monsterChar];
        }

        public void Step()
        {
            Vector2 nextPosition = Position + Orientation;

            // Rotate right
            Vector2 rightOrientation = new Vector2(-Orientation.Y, Orientation.X);
            Vector2 rightPosition = Position + rightOrientation;

            // Move forward if valid
            if (
                (Maze.IsPositionValid(nextPosition) && !Maze.IsWallOnPosition(nextPosition))
                && (_rotatedLastStep || (Maze.IsPositionValid(rightPosition) && Maze.IsWallOnPosition(rightPosition)))
                )
            {
                _rotatedLastStep = false;
                Position = nextPosition;
                return;
            }

            _rotatedLastStep = true;

            // Rotate right if it will lead to a valid step forward next Step()
            if (Maze.IsPositionValid(rightPosition) && !Maze.IsWallOnPosition(rightPosition))
            {
                Orientation = rightOrientation;
                return;
            }

            // Rotate left otherwise
            Orientation = new Vector2(Orientation.Y, -Orientation.X);
        }

        public override string ToString()
        {
            return $"Monster Object at {Position} looking {Monster.OrientationToName[Orientation]}";
        }
    }
}
