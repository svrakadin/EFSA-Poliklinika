using ConsoleAppEFSA.Models;

namespace ConsoleAppEFSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Student din = new Student();
            din.FirstName = "Din";
            din.LastName = "Svraka";
            din.Age = 25;

            Student aida = new Student();
            aida.FirstName = "Aida";
            aida.Age = 31;

            Console.WriteLine($"Student: {din.FirstName} {din.LastName}, Age: {din.Age}");
            Console.WriteLine($"Student: {aida.FirstName} {aida.LastName}, Age: {aida.Age}");

            Console.WriteLine("----------------------");

            Console.WriteLine("Unesite ime studenta: ");
            string userInputFirstName = Console.ReadLine();

            Console.WriteLine("Unesite prezime studenta: ");
            string userInputLastName = Console.ReadLine();

            Console.WriteLine("Informacije o studentu su: ");
            Console.WriteLine($"Ime: {userInputFirstName}");
            Console.WriteLine($"Prezime: {userInputLastName}");

            Console.WriteLine("----------------------");

            Console.WriteLine("Unesite prvi broj: ");
            int num1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Unesite prvi broj: ");
            int num2 = Int32.Parse(Console.ReadLine());

            int sum = num1 + num2;
            int razlika = num1 - num2;
            int proizvod = num2 * num1;
            double kolicnik = (double)num1 / num2;

            Console.WriteLine($"Rezultat sabiranja je: {sum}");
            Console.WriteLine($"Rezultat oduzimanja je: {razlika}");
            Console.WriteLine($"Rezultat mnozenja je: {proizvod}");
            Console.WriteLine($"Rezultat dijeljenja je: {kolicnik}");
        }
    }
}
