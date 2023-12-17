using System.IO;
using System;
using System.Text;

string[] units = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

string line;
int sum = 0;
int temp = 0;
/* 
string test = "hellotwo134five";
Console.WriteLine(extractInt(test)); */

try {
    string path = @"C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\DayOnePartTwo\\challenge.txt";
    StreamReader reader = new StreamReader(path, Encoding.UTF8);
    line = reader.ReadLine();
    while (line != null) {
        temp = extractInt(line);
        sum += temp;
        Console.WriteLine("\t\tRunning total is: " + sum + " This line sums to: " + temp);
        line = reader.ReadLine();
    }
    reader.Close();
    Console.WriteLine("Total is: " + sum);
}
catch(Exception e) {
    Console.WriteLine("Exception: " + e.Message);
}

/* int extractIntOld(string s) {
    string temp = "";
    foreach(char c in s) {
        if (Char.IsNumber(c)) {
            temp += c;
        }
    }
    string result = "" +  temp.ElementAt(0) + temp.ElementAt(temp.Length-1);
    return int.Parse(result);
} */

int extractInt(string s) {
    string temp = "";
    for(int i = 0; i< units.Length; i++) {
        int number;
        string temporal;
        while(s.Contains(units[i])) {
            number = s.IndexOf(units[i]);
            temporal = s.Replace(units[i], "" + units[i].ElementAt(0) +(i+1) + units[i].ElementAt(units[i].Length-1));
            s = temporal;
        }
    }
    Console.Write(" New line is: " + s);
    foreach(char c in s) {
        if (Char.IsNumber(c)) {
            temp += c;
        }
    }
    string result = "" +  temp.ElementAt(0) + temp.ElementAt(temp.Length-1);
    return int.Parse(result);
}


/* string ReplaceAt(string input, int index, char newChar)
{
    if (input == null)
    {
        throw new ArgumentNullException("input");
    }
    char[] chars = input.ToCharArray();
    chars[index] = newChar;
    return new string(chars);
}
 */