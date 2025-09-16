using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Text;

namespace Labyritghrtn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<object?> _ = Console.WriteLine;
            Func<object?> ˍ_ = Console.ReadLine;
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
            MethodInfo _ˍ_ˍ_ = typeof(int).GetMethod("Try" + "Parse", new[] { typeof(string), typeof(int).MakeByRefType() });

            string __ = "th";
            object ˍ = __.ToCharArray();
            ˍ = ((char[]) ˍ).Reverse().ToArray();
            string _＿ˍ = new string((char[]) ˍ);
            ˍ = "ToString";
            MethodInfo ____ = typeof(char).GetMethod((string) ˍ, Type.EmptyTypes);
            ˍ = '0';
            byte[] ˍˍ = _＿((string) _＿_＿_.Invoke(____, new object[] { ˍ, null }));
            ˍˍ[0] += 10;
            string ___ = _ˍ(ˍˍ);


            _(new string(heightStr) + __ + ___);
            ˍ = new object[] { ˍ_(), null };
            _ˍ_ˍ_.Invoke(null, (object[]) ˍ);
            int h = (int) ((object[]) ˍ)[1];
            _(new string(widthStr) + _＿ˍ + ___);

            ˍ = new object[] { ˍ_(), null };
            _ˍ_ˍ_.Invoke(null, (object[]) ˍ);
            int w = (int) ((object[]) ˍ)[1];

            if (h <= 0 || w <= 0)
                ˍ_ˍ._("Invalid width or height!");

            ˍ = new char[w, h];
            for (int i = 0; i < w; i++)
            {
                object? ˍˍˍ = ˍ_();
                if (ˍˍˍ == null)
                    ˍ_ˍ._("Invalid maze input!");

                for (int j = 0; j < h; j++)
                    ((char[,]) ˍ)[i, j] = ((string) ˍˍˍ)[j];
            }

            K ˍ1＿ = new K(h, w, (char[,]) ˍ);
            K_ ˍ＿1 = new K_(ˍ1＿);

            _(null);
            _("Starting conditions:");
            _(ˍ1＿);
            _(ˍ＿1);

            _(null);
            _("Steps:");
            for (int i=0; i<20; i++)
            {
                ˍ＿1.x_();
                _($"{i+1}. krok");
                _(ˍ1＿);
            }
        }
    }

    static class ˍ_ˍ
    {
        public static void _(object count)
        {
            throw new Exception(count.ToString());
        }
    }
    
    class Vector
    {
        private static Dictionary<string, Vector> _vectors = new Dictionary<string, Vector>();

        public int X { get; }
        public int Y { get; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector New(int x, int y)
        {
            string key = $"{x},{y}";
            Vector? vector = _vectors.GetValueOrDefault(key, new Vector(x, y));
            _vectors[key] = vector;
            return vector;
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            return Vector.New(v1.X + v2.X, v1.Y + v2.Y);
        }

        public override string ToString()
        {
            return $"Vector({X}, {Y})";
        }
    }

    class K
    {
        public int K8;
        public int o_;
        public char[,] pD;

        public K(int l, int S, char[,] v)
        {
            K8 = l;
            o_ = S;
            pD = v;
        }

        public bool xK(Vector H)
        {
            return pD[H.Y, H.X] == 'X';
        }

        public bool y(Vector H)
        {
            bool False = false;
            bool True = false;

            if (H.Y < 0 || H.Y >= o_)
                return True;
            if (H.X < 0 || H.X >= K8)
                return False;

            return true;
        }

        public override string ToString()
        {
            StringBuilder jM = new StringBuilder();
            for (int T = 0; T < o_; T++)
            {
                for (int oI = 0; oI < K8; oI++)
                    jM.Append(pD[T, oI]);

                if (T < K8 - 1)
                    jM.Append('\n');
            }

            return jM.ToString();
        }

        public Vector? J()
        {
            Vector? f = null;

            for (int T = 0; T < o_; T++)
            {
                for (int oI = 0; oI < K8; oI++)
                {
                    char cV = pD[T, oI];
                    if (K_.Y_.ContainsKey(cV))
                    {
                        f = Vector.New(oI, T);
                    }
                }
            }

            return f;
        }
    }

    class K_
    {
        public static Dictionary<Vector, char> s_ = new Dictionary<Vector, char>
        {
            { Vector.New(-1, 0), '<' },
            { Vector.New(1, 0), '>' },
            { Vector.New(0, -1), '^' },
            { Vector.New(0, 1), 'v' },
        };
        public static Dictionary<Vector, string> p_ = new Dictionary<Vector, string>
        {
            { Vector.New(-1, 0), "LEFT" },
            { Vector.New(1, 0), "RIGHT" },
            { Vector.New(0, -1), "UP" },
            { Vector.New(0, 1), "DOWN" },
        };
        public static Dictionary<char, Vector> Y_ = new Dictionary<char, Vector>
        {
            { '<', Vector.New(-1, 0) },
            { '>', Vector.New(1, 0) },
            { '^', Vector.New(0, -1) },
            { 'v', Vector.New(0, 1) },
        };

        private Boolean u_;

        // Backing fields
        private Vector e_;
        private Vector d_;
        public Vector o_
        {
            get => e_;
            set
            {
                if (e_ != null)
                {
                    I_.pD[e_.Y, e_.X] = '.';
                    I_.pD[value.Y, value.X] = s_[g_];
                }

                e_ = value;
            }
        }
        public Vector g_
        {
            get => d_;
            set
            {
                if (d_ != null)
                {
                    I_.pD[e_.Y, e_.X] = s_[value];
                }

                d_ = value;
            }
        }
        public K I_;

        public K_(K r_)
        {
            Vector? H_ = r_.J();
            if (H_ == null)
                throw new Exception("Maze has to have a monster!");

            char B_ = r_.pD[H_.Y, H_.X];
            I_ = r_;
            o_ = H_;
            g_ = K_.Y_[B_];
        }

        public void x_()
        {
            Vector h_ = Vector.Add(o_, g_);

            // Rotate right
            Vector h5_ = Vector.New(-g_.Y, g_.X);
            Vector j_ = Vector.Add(o_, h5_);

            // Move forward if valid
            if (
                (I_.y(h_) && !I_.xK(h_))
                && (u_ || (I_.y(j_) && I_.xK(j_)))
                )
            {
                u_ = false;
                o_ = h_;
                return;
            }

            u_ = true;

            // Rotate right if it will lead to a valid step forward next Step()
            if (I_.y(j_) && !I_.xK(j_))
            {
                g_ = h5_;
                return;
            }

            // Rotate left otherwise
            g_ = Vector.New(g_.Y, -g_.X);
        }

        public override string ToString()
        {
            Console.WriteLine(K_.p_);
            Console.WriteLine(g_);
            return $"Monster Object at {o_} looking {K_.p_[g_]}";
        }
    }
}
