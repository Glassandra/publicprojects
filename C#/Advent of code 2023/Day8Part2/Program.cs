using System.Collections;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

StreamReader reader = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\Day8Part2\\challenge.txt");

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
            if (tempArray[0].ElementAt(2) == 'A')
            {
                startingPoints.Add(tempArray[0]);
            }
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

Queue<string> queue = new Queue<string>(startingPoints);
int steps = 0;

while (queue.Count > 0)
{
    int nodesInCurrentStep = queue.Count;
    bool allEndWithZ = true;

    for (int i = 0; i < nodesInCurrentStep; i++)
    {
        string currentNode = queue.Dequeue();
        allEndWithZ &= currentNode.EndsWith("Z");

        if (!currentNode.EndsWith("Z"))
        {
            string nextNode = steps % 2 == 0 ? (string)nodeMapLeft[currentNode] : (string)nodeMapRight[currentNode];
            queue.Enqueue(nextNode);
        }
    }

    if (allEndWithZ)
    {
        break;
    }

    steps++;
}

Console.WriteLine("Number of steps is: " + steps);


string RemoveSpecialCharacters(string str)
{
    return Regex.Replace(str, "[^a-zA-Z0-9_. ]+", "", RegexOptions.Compiled);
}

int findLCMArray(int[] array) {
    int current = findLCM(array[0], array[1]);
    for (int i = 2; i<array.Length; i++) {
        current = findLCM(current, array[i]);
    }
    return current;
}

int findLCM(int a, int b) {
    int x = a;
    int y = b;
    while (a != b) 
    {
        if (a>b) {
            a = a-b;
        }
        else {
            b = b-a;
        }
    }
    int lcm = (x*y)/a;

    return lcm;
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

