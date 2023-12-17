using System.Globalization;
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

int[] countArray = new int[lineList.Count];
int iter = 0;

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
    countArray[iter] = count;
    iter++;
}

int[] resultArray = new int[lineList.Count];
int[] newCountArray = new int[lineList.Count];
Array.Fill(newCountArray, 1);

for (int i = 0; i<lineList.Count(); i++) {
    int j = 1;
    while ((i+j) <lineList.Count() && j<countArray[i]+1) {
        newCountArray[i+j] =   newCountArray[i+j] + newCountArray[i];
        j++;
    }
}
sum = newCountArray.Sum();

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