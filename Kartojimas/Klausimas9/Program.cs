﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Klausimas9
{
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";

        static void Main(string[] args)
        {
            if (File.Exists(rez))
                File.Delete(rez);
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            string skyrikliai = " !?.,<>/?;:'\"\\|{[}]()";
            int ind1;
            int ind2;
            string eil1;
            string eil2;
            Skaityti(duom, skyrikliai, out ind1, out ind2, out eil1, out eil2);
            Console.WriteLine(ind1 + " " + ind2);
            Console.WriteLine(eil1 + "\n" + eil2);
            if (ind1 > ind2)
            {
                int temp = ind1;
                ind1 = ind2;
                ind2 = temp;
                string pagalb = eil1;
                eil1 = eil2;
                eil2 = pagalb;
            }
            Console.WriteLine(ind1 + " " + ind2);
            Console.WriteLine(eil1 + "\n" + eil2);
            if (ind1 != -1 && ind2 != -1 && eil1 != "" && eil2 != "" && ind1 != ind2)
            {
                Sukeisti(duom, rez, ind1, ind2, eil1, eil2);
            }
            else
            {
                Console.WriteLine("Klaida");
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Sukeisti(string duom, string rez, int ind1, int ind2, string eil1, string eil2)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                using (StreamWriter writer = new StreamWriter(rez))
                {
                    string line;
                    for (int i = 0; (i < ind1) && ((line = reader.ReadLine()) != null); i++)
                    {
                        writer.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    writer.WriteLine(eil2);
                    for (int i = ind1 + 1; (i < ind2) && ((line = reader.ReadLine()) != null); i++)
                    {
                        writer.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    writer.WriteLine(eil1);
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }

                }
            }
        }

        static string SurastiAntrąPagalDydįSuBalse(string eil, string skyrikliai)
        {
            // string antrasIlgiausias1 = eil.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(x => TuriBalse(x) == true).OrderByDescending(x => x.Length).Skip(1).FirstOrDefault();
            string[] words = eil.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> tinkami = new List<string>();

            foreach (string word in words)
            {
                if (TuriBalse(word))
                {
                    tinkami.Add(word);
                }
            }


            string ilgiausias = "";
            string antrasIlgiausias = "";
            if (tinkami.Count >= 2)
            {
                ilgiausias = tinkami[0];
                antrasIlgiausias = tinkami[1];
                if (antrasIlgiausias.Length > ilgiausias.Length)
                {
                    string temp = ilgiausias;
                    ilgiausias = antrasIlgiausias;
                    antrasIlgiausias = temp;
                }

                for (int i = 2; i < tinkami.Count; i++)
                {
                    string temp = tinkami[i];
                    if (temp.Length > ilgiausias.Length && temp.Length > antrasIlgiausias.Length)
                    {
                        string pag = ilgiausias;
                        ilgiausias = temp;
                        antrasIlgiausias = pag;
                    }
                    else if (temp.Length < ilgiausias.Length && temp.Length > antrasIlgiausias.Length)
                    {
                        antrasIlgiausias = temp;
                    }
                }
            }

            // Console.WriteLine(antrasIlgiausias);
            // Console.WriteLine(antrasIlgiausias1);
            
            return antrasIlgiausias;
        }

        static bool TuriBalse(string word)
        {
            string balses = "eyuioaEYUIOA";
            for (int i = 0; i < word.Length; i++)
            {
                if (balses.Contains(word[word.Length - 1]))
                {
                    return true;
                }
            }

            return false;
        }

        static bool TuriPriebalse(string word)
        {
            string priebalses = "qwrtpsdfghjklzxcvbnmQWRTPSDFGHJKLZXCVBNM";
            for (int i = 0; i < word.Length; i++)
            {
                if (priebalses.Contains(word[word.Length - 1]))
                {
                    return true;
                }
            }

            return false;
        }

        static string SurastiSuPriebalse(string eil, string skyrikliai)
        {
            string[] words = eil.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> tinkami = new List<string>();

            foreach (string word in words)
            {
                if (TuriPriebalse(word))
                {
                    tinkami.Add(word);
                }
            }

            string trumpiausias = "";

            if (tinkami.Count >= 1)
            {
                trumpiausias = tinkami[0];

                for (int i = 1; i < tinkami.Count; i++)
                {
                    string temp = tinkami[i];
                    if (temp.Length < trumpiausias.Length)
                    {
                        trumpiausias = temp;
                    }
                }
            }

            return trumpiausias;
        }

        static void Skaityti(string duom, string skyrikliai, out int balse, out int prieb, out string eil1, out string eil2)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                int i = 0;
                string ilgiausiasSuBalse = "";
                string trumpiausiasSuPriebalse = "";
                eil1 = "";
                eil2 = "";
                balse = -1;
                prieb = -1;
                while ((line = reader.ReadLine()) != null)
                {
                    string temp1 = SurastiAntrąPagalDydįSuBalse(line, skyrikliai);
                    string temp2 = SurastiSuPriebalse(line, skyrikliai);
                    if (temp1 != "")
                    {
                        if (temp1.Length > ilgiausiasSuBalse.Length || ilgiausiasSuBalse == "")
                        {
                            ilgiausiasSuBalse = temp1;
                            balse = i;
                            eil1 = line;
                        }
                    }
                    if (temp2 != "")
                    {
                        if (temp2.Length < trumpiausiasSuPriebalse.Length || trumpiausiasSuPriebalse == "")
                        {
                            trumpiausiasSuPriebalse = temp1;
                            prieb = i;
                            eil2 = line;
                        }
                    }
                    i++;
                }
            }
        }
    }
}
