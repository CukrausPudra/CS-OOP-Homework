﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kurmiai
{
    class Kurmiai
    {
        int x, y;

        public Kurmiai(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int max = 500;
            const string duom = "..\\..\\duom.txt";
            int n, m;
            char[,] plokstuma = new char[max, max];
            int kurmiuSkaicius = 0;
            List<int> plotai = new List<int>();

            skaitymas(duom, out n, out m, plokstuma);

            /*
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(plokstuma[i,j]);
                }
                Console.WriteLine("");
            }*/

            int x = 0, y = 0, plotas = 0;

            rasti(plokstuma, n, m, ref x, ref y);

            while (x != -1)
            {
                rastiKita(plokstuma, n, m, x, y, ref plotas);
                plotai.Add(plotas);
                kurmiuSkaicius++;
                Console.WriteLine("");
                plotas = 0;
                rasti(plokstuma, n, m, ref x, ref y);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(plokstuma[i, j]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Kurmiu skaicius: {0}", kurmiuSkaicius);
            foreach (var pl in plotai)
            {
                Console.WriteLine("{0}", pl);
            }
            Console.WriteLine("Programa baige darba");
        }

        static void rastiKita(char[,] plokstuma, int n, int m, int x, int y, ref int plotas)
        {
            plotas += 5;

            plokstuma[x, y] = 'z';
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (plokstuma[i,j] == 'u')
                    {
                        Console.Write(plokstuma[i, j]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }

            if (y + 1 <= m && plokstuma[x, y + 1] == 'u')
            {
                Console.WriteLine("d");
                rastiKita(plokstuma, n, m, x, y + 1, ref plotas);
            }

            if (y - 1 >= 0 && plokstuma[x, y - 1] == 'u')
            {
                Console.WriteLine("a");
                rastiKita(plokstuma, n, m, x, y - 1, ref plotas);
            }

            if (x + 1 <= n && plokstuma[x + 1, y] == 'u')
            {
                Console.WriteLine("s");
                rastiKita(plokstuma, n, m, x + 1, y, ref plotas);
            }

            if (x - 1 >= 0 && plokstuma[x - 1, y] == 'u')
            {
                Console.WriteLine("w");
                rastiKita(plokstuma, n, m, x - 1, y, ref plotas);
            }
        }

        static void skaitymas(string duom, out int n, out int m, char[,] plokstuma)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] skaidymas;
                line = reader.ReadLine();
                skaidymas = line.Split(' ');
                n = int.Parse(skaidymas[0]);
                m = int.Parse(skaidymas[1]);

                if (n >= 5 && n <= 500 && m <= 500 && m >= 5)
                {
                    for (int i = 0; i < n; i++)
                    {
                        line = reader.ReadLine();
                        for (int j = 0; j < m; j++)
                        {
                            plokstuma[i, j] = line[j];
                        }
                    }
                }
            }
        }

        static void rasti(char[,] plokstuma, int n, int m, ref int x, ref int y)
        {
            x = -1;
            y = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (plokstuma[i, j] == 'u')
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }

                if (x != -1)
                {
                    break;
                }
            }
        }
    }
}


