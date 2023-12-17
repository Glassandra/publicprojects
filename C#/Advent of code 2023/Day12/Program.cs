using System.IO;

string? line;
string path = @"C:\Users\cassa\Documents\Projects\C#\AdventCode\Day12\challenge.txt";

int length = File.ReadAllLines(path).Length;

string[] input = new string[length];

using (StreamReader reader = File.OpenText(path)) {
    int index = 0;
    while ((line = reader.ReadLine()) != null) {
        input[index] = line;
        index++;
    }
}

