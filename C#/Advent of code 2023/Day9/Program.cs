using System.Collections;
using System.IO;

StreamReader reader  = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\Day9\\challenge.txt");

string? line;

List<int[]> input = new List<int[]>();

try {
    line = reader.ReadLine();
    
    while (line != null) {
    input.Add(Array.ConvertAll(line.Split(' '), s => int.Parse(s)));
    line = reader.ReadLine();
    }
}
catch (Exception e) {
    Console.WriteLine(e.Message);
}
finally {
    reader.Close();
    reader.Dispose();
}

int sum = 0;
int sumbefore = 0;

foreach (int[] array in input) {

    bool bottomFound = false;
    int[][] tempMatrix = new int[20][];
    int index = 1;
    tempMatrix[0] = array;

    while (!bottomFound) {        
        int count = 0;
        int[] tempArray = new int[tempMatrix[index-1].Length-1];
        for (int i = 1; i < tempMatrix[index-1].Length; i++) {
            tempArray[i-1] = tempMatrix[index-1][i]-tempMatrix[index-1][i-1];
            if (tempArray[i-1] == 0) {
                count++;
            }
        }
        tempMatrix[index] = tempArray;
        if (count == tempArray.Length) {
            bottomFound = true;
            break;
        }
        index++;
    }
    int result = 0;
    int resultbefore = 0;
    for (int i = index-1; i >= 0; i--) {
        result = result + tempMatrix[i][tempMatrix[i].Length-1];
        resultbefore =  tempMatrix[i][0] - resultbefore;
    }

    sum = sum + result;
    sumbefore = sumbefore + resultbefore;
}

Console.WriteLine("Extrapolation after is:" + sum);
Console.WriteLine("Extrapolation before is: " + sumbefore);