using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

StreamReader reader = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\Day8\\challenge.txt");

string? line;
string direction = "";
Hashtable nodeMapLeft = new Hashtable();
Hashtable nodeMapRight = new Hashtable();
List<string> startingPoints = new List<string>();


try
{
    line = reader.ReadLine();
    line = line + reader.ReadLine();
    direction = line;
    line = reader.ReadLine();

    while (line != null)
    {
        if (line != "")
        {
            string temp = RemoveSpecialCharacters(line);
            string[] tempArray = temp.Split(' ');
            nodeMapLeft.Add(tempArray[0], tempArray[2]);
            nodeMapRight.Add(tempArray[0], tempArray[3]);
        }
        line = reader.ReadLine();
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    reader.Close();
}

bool foundSolution = false;
string nextKey = "AAA";
int steps = 0;

while (foundSolution == false)
{
    for (int i = 0; i < direction.Length; i++)
    {
        if (direction.ElementAt(i) == 'L')
        {
            nextKey = (string)nodeMapLeft[nextKey];
        }
        else if (direction.ElementAt(i) == 'R')
        {
            nextKey = (string)nodeMapRight[nextKey];
        }
    }
    if (nextKey == "ZZZ") {
        foundSolution = true;
    }
    steps = steps + direction.Length;
}

Console.WriteLine("Number of steps is: " + steps);


string RemoveSpecialCharacters(string str)
{
    return Regex.Replace(str, "[^a-zA-Z0-9_. ]+", "", RegexOptions.Compiled);
}

class Node
{
    string left { get; set; }
    string right { get; set; }
    string self { get; set; }

    public Node(string left, string right, string self) : this(left, right)
    {
        this.self = self;
    }

    public Node(string left, string right)
    {
        this.left = left;
        this.right = right;
    }
}