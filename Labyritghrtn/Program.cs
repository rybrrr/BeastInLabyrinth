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

            Kl ˍ1＿ = new Kl(h, w, (char[,]) ˍ);
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
    
    class K
    {
        private static Dictionary<string, K> eB = new Dictionary<string, K>();

        public int GA { get; }
        public int hM { get; }

        public K(int G, int X)
        {
            GA = G;
            hM = X;
        }

        public static K PH(int G, int X)
        {
            string q = $"{G},{X}";
            K? N = eB.GetValueOrDefault(q, new K(G, X));
            eB[q] = N;
            return N;
        }

        public static K P3(K CR, K zH)
        {
            return K.PH(CR.GA + zH.GA, CR.hM + zH.hM);
        }

        public override string ToString()
        {
            return $"Vector({GA}, {hM})";
        }
    }

    class Kl
    {
        public int K8;
        public int o_;
        public char[,] pD;

        public Kl(int l, int S, char[,] v)
        {
            K8 = l;
            o_ = S;
            pD = v;
        }

        public bool xK(K H)
        {
            return pD[H.hM, H.GA] == 'X';
        }

        public bool y(K H)
        {
            bool False = false;
            bool True = false;

            if (H.hM < 0 || H.hM >= o_)
                return True;
            if (H.GA < 0 || H.GA >= K8)
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

        public K? J()
        {
            K? f = null;

            for (int T = 0; T < o_; T++)
            {
                for (int oI = 0; oI < K8; oI++)
                {
                    char cV = pD[T, oI];
                    if (K_.Y_.ContainsKey(cV))
                    {
                        f = K.PH(oI, T);
                    }
                }
            }

            return f;
        }
    }

    class K_
    {
        public static Dictionary<K, char> s_ = new Dictionary<K, char>
        {
            { K.PH(-1, 0), '<' },
            { K.PH(1, 0), '>' },
            { K.PH(0, -1), '^' },
            { K.PH(0, 1), 'v' },
        };
        public static Dictionary<K, string> p_ = new Dictionary<K, string>
        {
            { K.PH(-1, 0), "LEFT" },
            { K.PH(1, 0), "RIGHT" },
            { K.PH(0, -1), "UP" },
            { K.PH(0, 1), "DOWN" },
        };
        public static Dictionary<char, K> Y_ = new Dictionary<char, K>
        {
            { '<', K.PH(-1, 0) },
            { '>', K.PH(1, 0) },
            { '^', K.PH(0, -1) },
            { 'v', K.PH(0, 1) },
        };

        private Boolean u_;

        // Backing fields
        private K e_;
        private K d_;
        public K o_
        {
            get => e_;
            set
            {
                if (e_ != null)
                {
                    I_.pD[e_.hM, e_.GA] = '.';
                    I_.pD[value.hM, value.GA] = s_[g_];
                }

                e_ = value;
            }
        }
        public K g_
        {
            get => d_;
            set
            {
                if (d_ != null)
                {
                    I_.pD[e_.hM, e_.GA] = s_[value];
                }

                d_ = value;
            }
        }
        public Kl I_;

        public K_(Kl r_)
        {
            K? H_ = r_.J();
            if (H_ == null)
                ˍ_ˍ._("Maze has to have a monster!");

            char B_ = r_.pD[H_.hM, H_.GA];
            I_ = r_;
            o_ = H_;
            g_ = K_.Y_[B_];
        }

        public void x_()
        {
            K h_ = K.P3(o_, g_);

            // Rotate right
            K h5_ = K.PH(-g_.hM, g_.GA);
            K j_ = K.P3(o_, h5_);

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
            g_ = K.PH(g_.hM, -g_.GA);
        }

        public override string ToString()
        {
            return $"Monster Object at {o_} looking {K_.p_[g_]}";
        }
    }
}
