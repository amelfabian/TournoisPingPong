using System;

namespace CoucheMetier
{
    static public class AccesConsole
    {
        
       static public void CreerEcran(String s)
        {
            Console.Clear();
            Console.WriteLine(s);
            Console.WriteLine(new String('-', s.Length) + "\n");
        }

        static public string SaisirChaine(string s)
        {
            Console.Write(s);
            return Console.In.ReadLine();
        }

        static public DateTime SaisirDate(string s)
        {
            Console.Write(s);
            return Convert.ToDateTime(Console.In.ReadLine());

        }

        static public int SaisirInt(string s)
        {
            Console.Write(s);
            return Convert.ToInt32(Console.In.ReadLine());
        }

        static public double SaisirDouble(string s)
        {
            Console.Write(s);
            return Convert.ToDouble(Console.In.ReadLine());
        }

        static public void Attendre()
        {
            Console.Write("\nPressez une touche pour continuer...");
            Console.ReadKey();
            Console.WriteLine("\n");
        }
    }
}