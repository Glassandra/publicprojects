using System.IO;

StreamReader reader = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\DayFour\\challenge.txt");

string? line;
List<string> lineList = new List<string>();

try
{
    line = reader.ReadLine();
    while (line != null)
    {
        lineList.Add(line);
        line = reader.ReadLine();
    }

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
reader.Close();

int sum = 0;

foreach (string str in lineList)
{
    string[] tempString = str.Split(':', '|');
    string[] winningNumbers = tempString[1].Trim().Split(' ');
    string[] ownNumbers = tempString[2].Trim().Split(' ');
    var intersect = winningNumbers.Intersect(ownNumbers);
    int count = 0;
    foreach(string resultString in intersect) {
        if (resultString != "") {
            count++;
        }
    }
    if (count > 1)
    {
        sum = sum + power(2, count - 1);
    }
    else if (count == 1)
    {
        sum++;
    }
}

Console.WriteLine("Sum is: " + sum);


int power(int x, int y)
{
    int result = 1;
    if (y == 0)
    {
        result = 0;
    }
    else if (y == 1)
    {
        result = x;
    }
    else
    {
        for (int i = 0; i < y; i++)
        {
            result = result * x;
        }
    }
    return result;
}