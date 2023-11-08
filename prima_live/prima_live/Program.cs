Console.WriteLine("inseri due numeri per la somma");

String primoInput = Console.ReadLine();
String secondoInput = Console.ReadLine();

bool primo = int.TryParse(primoInput, out int result1);
bool secondo = int.TryParse(secondoInput, out int result2);

int somma = result1 + result2;
if (primo != true || secondo != true)
{
    Console.WriteLine("inserimento non valido");

}
else
{
    Console.WriteLine($"la somma di {result1} + {result2} è {somma}");
}