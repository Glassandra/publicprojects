using System.IO;

string? line;
string path = @"C:\Users\cassa\Documents\Projects\C#\AdventCode\Day11\challenge.txt";

int length = File.ReadAllLines(path).Length;

string[] input = new string[length];

using (StreamReader reader = File.OpenText(path)) {
    int index = 0;
    while ((line = reader.ReadLine()) != null) {
        input[index] = line;
        index++;
    }
}

Tuple<String[], List<int>> dataResult =  expandSpace(input);
string[] data = dataResult.Item1;
List<int> expanded = dataResult.Item2;
List<long> distances = getDistances(data, expanded);
long sum = distances.Sum();

Console.WriteLine("Sum is: " + sum);

List<long> getDistances(string[] data, List<int> expanded) {
    List<long> distances = new List<long>();
    List<(long, long)> hashCoordinates = new List<(long, long)>();

    // Get coordinates of all '#' characters
    for (int i = 0; i < data.Length; i++) {
        for (int j = 0; j < data[i].Length; j++) {
            if (data[i][j] == '#') {
                /* int expandedWidth = 0;
                int expandedHeight = 0;
                foreach (int index in expanded) {
                    
                    if (i > index) {
                        expandedHeight++;
                    }
                    if (j > -index) {
                        expandedWidth++;
                    }
                } */                
                long x = i + 999999*data.Take(i).Count(row => row.Contains('e'));
                long y = j + 999999*data[i].Take(j).Count(c => c == 'f');
                hashCoordinates.Add((x, y));
            }
        }
    }

    // Calculate distances
    for (int i = 0; i < hashCoordinates.Count; i++) {
        for (int j = i + 1; j < hashCoordinates.Count; j++) {           
            long distance = Math.Abs(hashCoordinates[i].Item1 - hashCoordinates[j].Item1) +
                                Math.Abs(hashCoordinates[i].Item2 - hashCoordinates[j].Item2);
            distances.Add(distance);
        }
    }

    return distances;
}

Tuple<string[], List<int>> expandSpace(string[] data) {
    List<int> expanded = new List<int>();
    for (int i = 0; i < data.Length; i++) {
        if (data[i].All(c => c == '.' || c == 'e')) {
            data[i] = data[i].Replace('.', 'e');
            expanded.Add(i);
        }
    }

    for (int j = 0; j < data[0].Length; j++) {
        if (data.All(row => row[j] == '.' || row[j] == 'e')) {
            for (int i = 0; i < data.Length; i++) {
                data[i] = data[i].Substring(0, j) + 'f' + data[i].Substring(j + 1);                
            }
            expanded.Add(-j);
        }
    }
    return Tuple.Create(data, expanded);
}