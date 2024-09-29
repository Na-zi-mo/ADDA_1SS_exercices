using System.Text.RegularExpressions;

namespace regex
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //string pattern = "\\d{4}";
            //string chaineDeTest = "Je suis né en 1934.";

            //var regexp = new Regex(pattern);


            //if (regexp.IsMatch(chaineDeTest))
            //{
            //    Console.WriteLine("Trouvé!");
            //}
            //else
            //{
            //    Console.WriteLine("Pas trouvé!");
            //}

            //pattern = "\\d{4}";
            //regexp = new Regex(pattern);
            //chaineDeTest = "Je suis né en 1934 ou 1938... j'm'en souviens plus!";

            //var matches = regexp.Matches(chaineDeTest);

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine("*************");
            //    Console.WriteLine(match.Value);
            //    Console.WriteLine(match.Index);
            //}


            //string pattern = "(\\d{1,3})\\.\\d{0,2}%";
            //string chaineDeTest = "J'ai eu 99.99% et 10.34% dans mes examens!";

            //var regexp = new Regex(pattern);

            //var matches = regexp.Matches(chaineDeTest);

            //foreach (Match match in matches)
            //{
            //    foreach (Group item in match.Groups)
            //    {
            //        Console.WriteLine("*************");
            //        Console.WriteLine(item.Value);
            //        Console.WriteLine(item.Index);
            //    }
            //}




            //string pattern = "(\\d{1,3})\\.\\d{0,2}%";
            //string chaineDeTest = "J'ai eu 99.99% et 10.34% dans mes examens!";

            //var regexp = new Regex(pattern);

            //string nvlleChaine = regexp.Replace(chaineDeTest, "0%");

            //Console.WriteLine(nvlleChaine);



            //static string MethodeDeRemplacement(Match match)
            //{
            //    return match.Groups["1"].Value + match.Groups["3"].Value;
            //}

            //string pattern = "(\\d{1,3})(\\.\\d{0,2})(%)";
            //string chaineDeTest = "J'ai eu 99.99% et 10.34% dans mes examens!";

            //var regexp = new Regex(pattern);

            //string nvlleChaine = regexp.Replace(chaineDeTest, MethodeDeRemplacement);

            //Console.WriteLine(nvlleChaine);



            //string pattern = "[A-Z]{4}\\s[0-9]{4}\\s[0-9]{4}";
            //string chaineDeTest = "ABCD 3445 3456";

            //Console.WriteLine(Ramq("ABCD 3445 3456"));

            //var regexp = new Regex(pattern);


            //if (regexp.IsMatch(chaineDeTest))
            //{
            //    Console.WriteLine("Trouvé!");
            //}
            //else
            //{
            //    Console.WriteLine("Pas trouvé!");
            //}


            //string pattern = "(.+)\\.pdf";
            //string chaineDeTest = "Fichier_abc.pdf";

            //Console.WriteLine(ExtraireNomFichierPdf("Fichier_abc.jpg"));
            //Console.WriteLine(ExtraireNomFichierPdf("Fichier_mon_devoir.pdf"));
            //Console.WriteLine(ExtraireNomFichierPdf("Fichier_2198289.pdf"));

            //var regexp = new Regex(pattern);

            //var matches = regexp.Matches(chaineDeTest);

            //foreach (Match match in matches)
            //{
            //    foreach (Group item in match.Groups)
            //    {
            //        Console.WriteLine("*************");
            //        Console.WriteLine(item.Value);
            //        Console.WriteLine(item.Index);
            //    }
            //}

            //static string MethodeDeRemplacement(Match match)
            //{
            //    return $"({match.Groups["1"].Value}) " + match.Groups["2"].Value;
            //}

            //string pattern = "(\\d{3})-(\\d{3}-\\d{4})";
            //string chaineDeTest = "819-539-6401";

            //var regexp = new Regex(pattern);

            //string nvlleChaine = regexp.Replace(chaineDeTest, MethodeDeRemplacement);

            //Console.WriteLine(nvlleChaine);

            Console.WriteLine(Ramq("ABCD 3445 3456"));

            Console.WriteLine(ExtraireNomFichierPdf("Fichier_abc.jpg"));
            Console.WriteLine(ExtraireNomFichierPdf("Fichier_mon_devoir.pdf"));
            Console.WriteLine(ExtraireNomFichierPdf("Fichier_2198289.pdf"));

            Console.WriteLine(UniformiserNoTel("819-539-6401"));

        }
        public static bool Ramq(string num)
        {
            string pattern = "[A-Z]{4}\\s[0-9]{4}\\s[0-9]{4}";
            var regexp = new Regex(pattern);


           return regexp.IsMatch(num);
        }

        public static string ExtraireNomFichierPdf(string fichier)
        {
            string pattern = "(.+)\\.pdf";
            var regexp = new Regex(pattern);

            var matches = regexp.Matches(fichier);

            if (matches.Count > 0 && matches[0].Groups.Count > 1)
            {
                return matches[0].Groups[1].Value ?? "";
            }
            else
            {
                return "";
            }
        }

        static string MethodeDeRemplacement(Match match)
        {
            return $"({match.Groups["1"].Value}) " + match.Groups["2"].Value;
        }

        public static string UniformiserNoTel(string numero)
        {
            string pattern = "(\\d{3})-(\\d{3}-\\d{4})";

            var regexp = new Regex(pattern);

            string nvlleChaine = regexp.Replace(numero, MethodeDeRemplacement);

            return nvlleChaine;
        }
    }
}
