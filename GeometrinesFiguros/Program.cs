﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GeometrinesFiguros
{
    class Taskas
    {
        public double x { get; set; }
        public double y { get; set; }

        public Taskas(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Figura
    {
        private string name;
        private List<Taskas> kampai;
        private List<double> krastines;

        public Figura(string name)
        {
            this.name = name;
            kampai = new List<Taskas>();
        }

        public void PridetiKampu(Taskas kampas)
        {
            kampai.Add(kampas);
        }

        public void UzpildytiKrastines()
        {
            for (int i = 0; i < kampai.Count; i++)
            {
                if (i == kampai.Count)
                    krastines.Add(AtstumasTarpDviejuTasku(kampai[i].x, kampai[i].y, kampai[0].x, kampai[0].y));
                else
                    krastines.Add(AtstumasTarpDviejuTasku(kampai[i].x, kampai[i].y, kampai[i + 1].x, kampai[i + 1].y));
            }
        }

        public void SpausdintiKrastines()
        {
            foreach (double krastine in krastines)
            {
                Console.WriteLine(krastine);
            }
        }

        public double GrazintiKrastine(int n) { return krastines[n]; }

        public bool ArLygiakrasteFigura()
        {
            if (krastines.All(x => x == krastines[0]))
                return true;

            return false;
        }

        public Taskas GautiKampus(int n) { return kampai[n]; }

        public string Spausdinti()
        {
            string x = "Vardas: " + name + " Kampai: ";
            foreach (var kampas in kampai)
            {
                x += kampas.x + " " + kampas.y + " ";
            }

            return x;
        }

        public string GautiVarda() { return name; }

        public int KiekKampu()
        {
            return kampai.Count();
        }

        public double KoksPlotas()
        {
            double plotas = 0;
            for (int i = 0; i < kampai.Count; i++)
            {
                if (i == kampai.Count - 1)
                    plotas += kampai[i].x * kampai[0].y - kampai[i].y * kampai[0].x;
                else plotas += kampai[i].x * kampai[i + 1].y - kampai[i].y * kampai[i + 1].x;
            }
            return Math.Round(Math.Abs(plotas / 2), 2);
        }

        public double KoksPerimetras()
        {
            double perimetras = 0;
            for (int i = 0; i < kampai.Count; i++)
            {
                if (i == kampai.Count - 1)
                    perimetras += Math.Sqrt(Math.Pow(kampai[i].x - kampai[0].x, 2) + Math.Pow(kampai[i].y - kampai[0].y, 2));
                else
                    perimetras += Math.Sqrt(Math.Pow(kampai[i + 1].x - kampai[i].x, 2) + Math.Pow(kampai[i + 1].y - kampai[i].y, 2));
            }
            return Math.Round(perimetras, 2);
        }

        public bool ArStatusisTrikampus()
        {
            if (kampai.Count == 3)
            {
                if ((Math.Pow(AtstumasTarpDviejuTasku(kampai[0].x, kampai[0].y, kampai[1].x, kampai[1].y), 2) + Math.Pow(AtstumasTarpDviejuTasku(kampai[1].x, kampai[1].y, kampai[2].x, kampai[2].y), 2) == Math.Pow(AtstumasTarpDviejuTasku(kampai[2].x, kampai[2].y, kampai[0].x, kampai[0].y), 2))
                    || (Math.Pow(AtstumasTarpDviejuTasku(kampai[0].x, kampai[0].y, kampai[1].x, kampai[1].y), 2) + Math.Pow(AtstumasTarpDviejuTasku(kampai[2].x, kampai[2].y, kampai[0].x, kampai[0].y), 2) == Math.Pow(AtstumasTarpDviejuTasku(kampai[1].x, kampai[1].y, kampai[2].x, kampai[2].y), 2))
                    || (Math.Pow(AtstumasTarpDviejuTasku(kampai[1].x, kampai[1].y, kampai[2].x, kampai[2].y), 2) + Math.Pow(AtstumasTarpDviejuTasku(kampai[2].x, kampai[2].y, kampai[0].x, kampai[0].y), 2) == Math.Pow(AtstumasTarpDviejuTasku(kampai[0].x, kampai[0].y, kampai[1].x, kampai[1].y), 2)))
                    return true;
            }
            return false;
        }

        public double AtstumasTarpDviejuTasku(double x1, double y1, double x2, double y2)
        {
            double atstumas = Math.Pow((Math.Pow(x1 + x2, 2)) + (Math.Pow(y1 + y2, 2)), 0.5);
            return atstumas;
        }

        public void IlgiausiaTrikampioKrastine(double x1, double y1, double x2, double y2, double x3, double y3, out double x, out double y, out double ilgiausia)
        {
            ilgiausia = 0;
            x = 0;
            y = 0;

            if (AtstumasTarpDviejuTasku(x1, y1, x2, y2) > AtstumasTarpDviejuTasku(x2, y2, x3, y3) && AtstumasTarpDviejuTasku(x1, y1, x2, y2) > AtstumasTarpDviejuTasku(x3, y3, x1, y1))
            {
                ilgiausia = AtstumasTarpDviejuTasku(x1, y1, x2, y2);
                KrastinesVidurioTaskoKoordinates(x1, y1, x2, y2, out x, out y);
            }
            else if (AtstumasTarpDviejuTasku(x2, y2, x3, y3) > AtstumasTarpDviejuTasku(x1, y1, x2, y2) && AtstumasTarpDviejuTasku(x2, y2, x3, y3) > AtstumasTarpDviejuTasku(x3, y3, x1, y1))
            {
                ilgiausia = AtstumasTarpDviejuTasku(x2, y2, x3, y3);
                KrastinesVidurioTaskoKoordinates(x2, y2, x3, y3, out x, out y);

            }
            else if (AtstumasTarpDviejuTasku(x3, y3, x1, y1) > AtstumasTarpDviejuTasku(x1, y1, x2, y2) && AtstumasTarpDviejuTasku(x3, y3, x1, y1) > AtstumasTarpDviejuTasku(x2, y2, x3, y3))
            {
                ilgiausia = AtstumasTarpDviejuTasku(x3, y3, x1, y1);
                KrastinesVidurioTaskoKoordinates(x3, y3, x1, y1, out x, out y);

            }
        }

        public void KrastinesVidurioTaskoKoordinates(double x1, double y1, double x2, double y2, out double x, out double y)
        {
            x = (x1 + x2) / 2;
            y = (y1 + y2) / 2;
        }

        public bool ArKvadratas()
        {
            if (kampai.Count == 4)
            {
                if (AtstumasTarpDviejuTasku(kampai[0].x, kampai[0].y, kampai[1].x, kampai[1].y) == AtstumasTarpDviejuTasku(kampai[1].x, kampai[1].y, kampai[2].x, kampai[2].y) 
                    && AtstumasTarpDviejuTasku(kampai[1].x, kampai[1].y, kampai[2].x, kampai[2].y) == AtstumasTarpDviejuTasku(kampai[2].x, kampai[2].y, kampai[3].x, kampai[3].y)
                    && AtstumasTarpDviejuTasku(kampai[2].x, kampai[2].y, kampai[3].x, kampai[3].y) == AtstumasTarpDviejuTasku(kampai[3].x, kampai[3].y, kampai[0].x, kampai[0].y))
                {
                    double x1 = kampai[0].x, y1 = kampai[0].y, x2 = kampai[1].x, y2 = kampai[1].y, x3 = kampai[2].x, y3 = kampai[2].y, x4 = kampai[3].x, y4 = kampai[3].y;
                    if (AtstumasTarpDviejuTasku(x1, y1, x3, y3) == AtstumasTarpDviejuTasku(x2, y2, x4, y4))
                        return true;
                }
            }
            return false;
        }
    }

    class Apskritimas
    {
        private string name;
        private double cx, cy, spindulys;

        public Apskritimas(string name, double x, double y, double spind)
        {
            this.name = name;
            cx = x;
            cy = y;
            spindulys = spind;
        }

        public string Spausdinti()
        {
            string x = "Vardas: " + name + "; centro koordinates: " + cx + "; " + cy + "; spindulys: " + spindulys;
            return x;
        }

        public double KoksPlotas()
        {
            double plotas = 0;
            plotas = Math.PI * Math.Pow(spindulys, 2);
            return Math.Round(plotas, 2);
        }

        public double KoksPerimetras()
        {
            double perimetras = 0;
            perimetras = 2 * spindulys * Math.PI;
            return Math.Round(perimetras, 2);
        }

        public double KoksX() { return cx; }

        public double KoksY() { return cy; }

        public double KoksSpind() { return spindulys; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const int maxduom = 500;
            const string duom = "...\\...\\DuomU2.txt";
            const string rez = "...\\...\\rez.txt";
            if (File.Exists(rez))
                File.Delete(rez);

            const string meniu = "|-------------------------------------------------------------------------------------|\r\n" +
                                 "|          Meniu           |  Taškai  |             Veiksmas                          |\r\n" +
                                 "|-------------------------------------------------------------------------------------|\r\n" +
                                 "| KokiuIrKiek              |     4    | Rasti kokių ir kiek yra figūrų.               |\r\n" +
                                 "|-------------------------------------------------------------------------------------|\r\n" +
                                 "| MaxPerimetras            |     8    | Rasti didžiausią perimetrą turinčios          |\r\n" +
                                 "|                          |          | figūros vardą ir perimetrą.                   |\r\n" +
                                 "|-------------------------------------------------------------------------------------|\r\n" +
                                 "| MaxPlotas                |     8    | Rasti didžiausią plotą turinčios figūros      |\r\n" +
                                 "|                          |          | vardą ir plotą.                               |\r\n" +
                                 "|-------------------------------------------------------------------------------------|\r\n" +
                                 "| KiekStacTrikampiu        |    10    | Rasti stačiųjų trikampių, įbrėžtų į           |\r\n" +
                                 "|                          |          | apskritimus, kiekį (Tikslumas: 0.000001).     |\r\n" +
                                 "|-------------------------------------------------------------------------------------|\r\n" +
                                 "| KiekKvadratu             |    10    | Rasti kvadratų, apibrėžtų apie apskritimus,   |\r\n" +
                                 "|                          |          | kiekį (Tikslumas: 0.000001).                  |\r\n" +
                                 "|-------------------------------------------------------------------------------------|\r\n" +
                                 "| InfoFiguruGrupe          |    12    | Pateikti informaciją apie pageidaujamą        |\r\n" +
                                 "|                          |          | figūrų grupę atskirose eilutėse tokia seka:   |\r\n" +
                                 "|                          |          | (nurodoma grupės kampų skaičius,              |\r\n" +
                                 "|                          |          | pvz.: 5; apskritimams - 0 ):                  |\r\n" +
                                 "|                          |          | -> figūrų kiekis;                             |\r\n" +
                                 "|                          |          | -> kiek yra lygiakraščių figūrų               |\r\n" +
                                 "|                          |          |    (Tikslumas: 0.000001)                      |\r\n" +
                                 "|                          |          |    (apskritimams: figūrų kiekis);             |\r\n" +
                                 "|                          |          | -> bendras figūrų perimetras                  |\r\n" +
                                 "|                          |          |    (apskritimams: bendras apskritimų ilgis);  |\r\n" +
                                 "|                          |          | -> bendras figūrų plotas                      |\r\n" +
                                 "|                          |          |    (apskritimams: bendras apskritimų plotas). |\r\n" +
                                 "|-------------------------------------------------------------------------------------|";

            int n, na;
            Figura[] figuros = new Figura[maxduom];
            Apskritimas[] apskritimai = new Apskritimas[maxduom];
            Dictionary<string, int> kiekirkokiu = new Dictionary<string, int>();
            kiekirkokiu.Add("Trikampiu", 0);
            kiekirkokiu.Add("Keturkampiu", 0);
            kiekirkokiu.Add("Penkiakampiu", 0);
            kiekirkokiu.Add("Sesiakampiu", 0);
            kiekirkokiu.Add("Septynkampiu", 0);
            kiekirkokiu.Add("Astuonkampiu", 0);
            kiekirkokiu.Add("Devynkampiu", 0);
            kiekirkokiu.Add("Desimtkampiu", 0);
            kiekirkokiu.Add("Apskritimu", 0);


            Skaitymas(duom, figuros, apskritimai, out n, out na);
            Spausdinimas(rez, figuros, n, apskritimai, na, "Pradiniai duomenys: ");

            Console.WriteLine(meniu + "\n");
            PridetiTeksto(rez, meniu + "\n");
            string x = "tuscias";

            while (x != "0")
            {
                Console.Write("Iveskite savo pasirinkima, arba 0, jei norite nutraukti: ");
                PridetiTeksto(rez, "Iveskite savo pasirinkima, arba 0, jei norite nutraukti: ");
                x = Console.ReadLine();
                switch (x)
                {
                    case "KokiuIrKiek":
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        Console.WriteLine("KokiuIrKiek");
                        PridetiTeksto(rez, "KokiuIrKiek");
                        KiekIrKokiu(figuros, n, apskritimai, na, kiekirkokiu);
                        SpausdintiKiekIrKokiu(rez, kiekirkokiu);
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        break;
                    case "MaxPerimetras":
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        Console.WriteLine("MaxPerimetras");
                        PridetiTeksto(rez, "MaxPerimetras");
                        double maxF, maxA;
                        maxF = DidziausiasPerimetrasFiguros(figuros, n);
                        maxA = DidziausiasPerimetrasApskritimo(apskritimai, na);
                        if (maxF == maxA)
                            SpausdintiDidziausioPerimetroFiguras(rez, maxF, figuros, apskritimai, n, na, "Didžiausio perimetro figūros: ");
                        else if (maxF > maxA)
                            SpausdintiDidziausioPerimetroFiguras(rez, maxF, figuros, apskritimai, n, na, "Didžiausio perimetro figūros: ");
                        else if (maxA > maxF)
                            SpausdintiDidziausioPerimetroFiguras(rez, maxA, figuros, apskritimai, n, na, "Didžiausio perimetro figūros: ");
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        break;
                    case "MaxPlotas":
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        Console.WriteLine("MaxPlotas");
                        PridetiTeksto(rez, "MaxPlotas");
                        double maxFP, maxAP;
                        maxFP = DidziausiasPlotasFiguros(figuros, n);
                        maxAP = DidziausiasPlotasApskritimo(apskritimai, na);
                        if (maxFP == maxAP)
                            SpausdintiDidziausioPlotoFiguras(rez, maxFP, figuros, apskritimai, n, na, "Didžiausio ploto figūros: ");
                        else if (maxFP > maxAP)
                            SpausdintiDidziausioPlotoFiguras(rez, maxFP, figuros, apskritimai, n, na, "Didžiausio ploto figūros: ");
                        else if (maxAP > maxFP)
                            SpausdintiDidziausioPlotoFiguras(rez, maxAP, figuros, apskritimai, n, na, "Didžiausio ploto figūros: ");
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        break;
                    case "KiekStacTrikampiu":
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        Console.WriteLine("KiekStacTrikampiu");
                        PridetiTeksto(rez, "KiekStacTrikampiu");
                        int kiekis = 0;
                        kiekis = KiekIbreztuStaciujuTrikampiu(figuros, n, apskritimai, na);
                        if (kiekis > 0)
                        {
                            Console.WriteLine("Į apskritimus įbrėžtų stačiųjų trikampių kiekis yra: {0}", kiekis);
                            string z = String.Format("Į apskritimus įbrėžtų stačiųjų trikampių kiekis yra: {0}", kiekis);
                            PridetiTeksto(rez, z);
                        }
                        else
                        {
                            Console.WriteLine("Į apskritimus įbrėžtų stačiųjų trikampių nėra");
                            PridetiTeksto(rez, "Į apskritimus įbrėžtų stačiųjų trikampių nėra");
                        }
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        break;
                    case "KiekKvadratu":
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        Console.WriteLine("KiekKvadratu");
                        PridetiTeksto(rez, "KiekKvadratu");
                        int kiek = 0;
                        kiek = KiekIbreztuStaciujuTrikampiu(figuros, n, apskritimai, na);
                        if (kiek > 0)
                        {
                            Console.WriteLine("Apie apskritimus apibrėžtų kvadratų kiekis yra: {0}", kiek);
                            string c = String.Format("Apie apskritimus apibrėžtų kvadratų kiekis yra: {0}", kiek);
                            PridetiTeksto(rez, c);
                        }
                        else
                        {
                            Console.WriteLine("Apie apskritimus apibrėžtų kvadratų nėra");
                            PridetiTeksto(rez, "Apie apskritimus apibrėžtų kvadratų nėra");
                        }
                        Console.WriteLine();
                        PridetiTeksto(rez, "");
                        break;
                    case "InfoFiguruGrupe":

                        break;
                    default:
                        if (x != "0")
                        {
                            Console.WriteLine();
                            PridetiTeksto(rez, "");
                            Console.WriteLine(x);
                            PridetiTeksto(rez, x);
                            Console.WriteLine("Netinkamas pasirinkimas");
                            PridetiTeksto(rez, "Netinkamas pasirinkimas");
                            Console.WriteLine();
                            PridetiTeksto(rez, "");
                        }
                        break;
                }
            }
            Console.WriteLine();
            PridetiTeksto(rez, "");
            Console.WriteLine("0");
            PridetiTeksto(rez, "0");
            Console.WriteLine("Programa baigė darbą!");
            PridetiTeksto(rez, "Programa baigė darbą!");
            Console.WriteLine();
            PridetiTeksto(rez, "");
        }

        static int KiekApibreztuKvadratu(Figura[] figuros, int n, Apskritimas[] apskritimai, int na)
        {
            int kiekis = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (figuros[j].ArKvadratas())
                    {
                        if (apskritimai[i].KoksSpind() / 2 == figuros[j].AtstumasTarpDviejuTasku(figuros[j].GautiKampus(0).x, figuros[j].GautiKampus(0).y, figuros[j].GautiKampus(1).x, figuros[j].GautiKampus(1).y))
                            kiekis++;
                    }
                }
            }

            return kiekis;
        }

        static int KiekIbreztuStaciujuTrikampiu(Figura[] figuros, int n, Apskritimas[] apskritimai, int na)
        {
            int kiekis = 0;

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (figuros[j].ArStatusisTrikampus())
                    {
                        double ilgiausia, x, y;
                        figuros[j].IlgiausiaTrikampioKrastine(figuros[j].GautiKampus(0).x, figuros[j].GautiKampus(0).y, figuros[j].GautiKampus(1).x, figuros[j].GautiKampus(1).y, figuros[j].GautiKampus(2).x, figuros[j].GautiKampus(2).y, out x, out y, out ilgiausia);
                        if (x == apskritimai[i].KoksX() && y == apskritimai[i].KoksY() && apskritimai[i].KoksSpind() == ilgiausia / 2)
                            kiekis++;
                    }
                }
            }

            return kiekis;
        }

        static double DidziausiasPerimetrasFiguros(Figura[] figuros, int n)
        {
            double didzP = figuros[0].KoksPerimetras();
            for (int i = 1; i < n; i++)
            {
                if (figuros[i].KoksPerimetras() > didzP)
                    didzP = figuros[i].KoksPerimetras();
            }

            return didzP;
        }

        static double DidziausiasPlotasFiguros(Figura[] figuros, int n)
        {
            double didzP = figuros[0].KoksPlotas();
            for (int i = 1; i < n; i++)
            {
                if (figuros[i].KoksPlotas() > didzP)
                    didzP = figuros[i].KoksPlotas();
            }

            return didzP;
        }

        static double DidziausiasPerimetrasApskritimo(Apskritimas[] figuros, int n)
        {
            double didzP = figuros[0].KoksPerimetras();
            for (int i = 1; i < n; i++)
            {
                if (figuros[i].KoksPerimetras() > didzP)
                    didzP = figuros[i].KoksPerimetras();
            }

            return didzP;
        }

        static double DidziausiasPlotasApskritimo(Apskritimas[] figuros, int n)
        {
            double didzP = figuros[0].KoksPlotas();
            for (int i = 1; i < n; i++)
            {
                if (figuros[i].KoksPlotas() > didzP)
                    didzP = figuros[i].KoksPlotas();
            }

            return didzP;
        }

        static void SpausdintiDidziausioPerimetroFiguras(string rez, double didzP, Figura[] A, Apskritimas[] B, int n, int na, string x)
        {
            using (var fr = File.AppendText(rez))
            {
                Console.WriteLine(x);
                fr.WriteLine(x);
                for (int i = 0; i < n; i++)
                {
                    if (A[i].KoksPerimetras() == didzP)
                    {
                        Console.WriteLine("{0} Perimetras: {1}", A[i].Spausdinti(), A[i].KoksPerimetras());
                        fr.WriteLine("{0} Perimetras: {1}", A[i].Spausdinti(), A[i].KoksPerimetras());
                    }
                }

                for (int i = 0; i < na; i++)
                {
                    if (B[i].KoksPerimetras() == didzP)
                    {
                        Console.WriteLine("{0} Perimetras: {1}", B[i].Spausdinti(), B[i].KoksPerimetras());
                        fr.WriteLine("{0} Perimetras: {1}", B[i].Spausdinti(), B[i].KoksPerimetras());
                    }
                }
            }
        }

        static void SpausdintiDidziausioPlotoFiguras(string rez, double didzP, Figura[] A, Apskritimas[] B, int n, int na, string x)
        {
            using (var fr = File.AppendText(rez))
            {
                Console.WriteLine(x);
                fr.WriteLine(x);
                for (int i = 0; i < n; i++)
                {
                    if (A[i].KoksPlotas() == didzP)
                    {
                        Console.WriteLine("{0} Plotas: {1}", A[i].Spausdinti(), A[i].KoksPlotas());
                        fr.WriteLine("{0} Plotas: {1}", A[i].Spausdinti(), A[i].KoksPlotas());
                    }
                }

                for (int i = 0; i < na; i++)
                {
                    if (B[i].KoksPlotas() == didzP)
                    {
                        Console.WriteLine("{0} Plotas: {1}", B[i].Spausdinti(), B[i].KoksPlotas());
                        fr.WriteLine("{0} Plotas: {1}", B[i].Spausdinti(), B[i].KoksPlotas());
                    }
                }
            }
        }

        static void KiekIrKokiu(Figura[] figuros, int n, Apskritimas[] apskritimai, int na, Dictionary<string, int> kiekirkokiu)
        {
            for (int i = 0; i < n; i++)
            {
                switch (figuros[i].KiekKampu())
                {
                    case 3:
                        kiekirkokiu["Trikampiu"] += 1;
                        break;
                    case 4:
                        kiekirkokiu["Keturkampiu"] += 1;
                        break;
                    case 5:
                        kiekirkokiu["Penkiakampiu"] += 1;
                        break;
                    case 6:
                        kiekirkokiu["Sesiakampiu"] += 1;
                        break;
                    case 7:
                        kiekirkokiu["Septynkampiu"] += 1;
                        break;
                    case 8:
                        kiekirkokiu["Astuonkampiu"] += 1;
                        break;
                    case 9:
                        kiekirkokiu["Devynkampiu"] += 1;
                        break;
                    case 10:
                        kiekirkokiu["Desimtkampiu"] += 1;
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < na; i++)
            {
                kiekirkokiu["Apskritimu"] += 1;
            }
        }

        static void SpausdintiKiekIrKokiu(string rez, Dictionary<string, int> kiekirkokiu)
        {
            using (var fr = File.AppendText(rez))
            {
                foreach (KeyValuePair<string, int> pora in kiekirkokiu)
                {
                    if (pora.Value > 0)
                    {
                        Console.WriteLine("{0}: {1}", pora.Key, pora.Value);
                        fr.WriteLine("{0}: {1}", pora.Key, pora.Value);
                    }
                }
            }
        }

        static void Skaitymas(string duom, Figura[] figuros, Apskritimas[] apskritimai, out int n, out int na)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string eilute;
                string[] skaidymas;

                string name;
                int iterator1 = 0;
                int iterator2 = 0;

                while ((eilute = reader.ReadLine()) != null)
                {
                    skaidymas = eilute.Split(' ');
                    name = skaidymas[0];
                    if (skaidymas.Count() > 4)
                    {
                        figuros[iterator1] = new Figura(name);
                        for (int i = 1; i < skaidymas.Length; i = i + 2)
                        {
                            Taskas k = new Taskas(double.Parse(skaidymas[i]), double.Parse(skaidymas[i + 1]));
                            figuros[iterator1].PridetiKampu(k);
                        }
                        iterator1++;
                    }
                    else
                    {
                        apskritimai[iterator2] = new Apskritimas(name, double.Parse(skaidymas[1]), double.Parse(skaidymas[2]), double.Parse(skaidymas[3]));
                        iterator2++;
                    }
                }
                n = iterator1;
                na = iterator2;
            }
        }

        static void PridetiTeksto(string rez, string x)
        {
            using (var prideti = File.AppendText(rez))
            {
                prideti.WriteLine(x);
            }
        }

        static void Spausdinimas(string rez, Figura[] figuros, int n, Apskritimas[] apskritimai, int na, string x)
        {
            using (var prideti = File.AppendText(rez))
            {
                prideti.WriteLine(x);
                Console.WriteLine(x);
                if (n > 0)
                {
                    prideti.WriteLine("--------------------------------------------------------------------------------------");
                    Console.WriteLine("--------------------------------------------------------------------------------------");
                    for (int i = 0; i < n; i++)
                    {
                        prideti.WriteLine(figuros[i].Spausdinti());
                        Console.WriteLine(figuros[i].Spausdinti());
                    }
                }
                else
                {
                    prideti.WriteLine("Figuru sarasas tuscias\n");
                    Console.WriteLine("Figuru sarasas tuscias\n");
                }

                if (na > 0)
                {
                    for (int i = 0; i < na; i++)
                    {
                        prideti.WriteLine(apskritimai[i].Spausdinti());
                        Console.WriteLine(apskritimai[i].Spausdinti());
                    }
                    prideti.WriteLine("--------------------------------------------------------------------------------------\n");
                    Console.WriteLine("--------------------------------------------------------------------------------------\n");
                }
                else
                {
                    prideti.WriteLine("Apskritimu sarasas tuscias\n");
                    Console.WriteLine("Apskritimu sarasas tuscias\n");
                }
            }
        }
    }
}