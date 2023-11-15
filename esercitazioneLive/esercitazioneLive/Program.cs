

Console.WriteLine("inserisci numero elementi");
string? numeroInput = Console.ReadLine();

int outParsed;
bool parsed = int.TryParse(numeroInput, out outParsed);
if (!parsed)
{
    Console.WriteLine("invalid input");
    return;
}

Console.WriteLine($"inserisci {outParsed} input");
List<string?> inputList = new() { };

for (int i = 0; i< outParsed; i++)
{
    string? elemento = Console.ReadLine();

    inputList.Add(elemento);
    
}
string? elements = string.Join(", ", inputList);

/*foreach (string? elemento in inputList)
{
    //Console.WriteLine(elemento);
    elements += elemento + ", ";
   
}*/

Console.WriteLine($"hai inserito i seguenti valori: {elements}.");


