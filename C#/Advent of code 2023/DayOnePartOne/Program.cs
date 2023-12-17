using System.IO;

string line;
int sum = 0;
int temp = 0;

try {
    StreamReader reader = new StreamReader("challenge.txt");
    line = reader.ReadLine();
    while (line != null) {
        temp = extractInt(line);
        sum += temp;
        Console.WriteLine("Running total is: " + sum + " This line sums to: " + temp);
        line = reader.ReadLine();
    }
    reader.Close();
    Console.WriteLine("Total is: " + sum);
}
catch(Exception e) {
    Console.WriteLine("Exception: " + e.Message);
}

int extractInt(string s) {
    string temp = "";
    foreach(char c in s) {
        if (Char.IsNumber(c)) {
            temp += c;
        }
    }
    string result = "" +  temp.ElementAt(0) + temp.ElementAt(temp.Length-1);
    return int.Parse(result);
}