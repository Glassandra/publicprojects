using System.IO;
using System.IO.Compression;

StreamReader reader = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\Day10\\challenge.txt");
string? line;
List<string> input = new List<string>();
int width = 0;
int height = 0;

try
{
    line = reader.ReadLine();
    width = line.Length;
    while (line != null)
    {
        input.Add(line);
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

height = input.Count;
int[] startingPosition = new int[2];

char[,] map = new char[height, width];
int index = 0;
foreach(string str in input) {
    for (int i = 0; i < width; i++) {
        map[index,i] = str.ElementAt(i);
        if (str.ElementAt(i) == 'S') {
            startingPosition = new int[2]{i, index};
        }
    }
    index++;
}

bool done = false;
int steps = 0;
int[] currentPosition = startingPosition;
int[] viablePositions = new int[] {0,-1,1,0};
int[] oldPosition = new int[] {-1,-1};

while (!done) {
    if (currentPosition[0] + viablePositions[0] != oldPosition[0] | currentPosition[1] + viablePositions[1] != oldPosition[1])
    {
        oldPosition = currentPosition;
        currentPosition = new int[] {viablePositions[0]+currentPosition[0], viablePositions[1]+currentPosition[1]};
    }   else if (currentPosition[0] + viablePositions[2] != oldPosition[0] | currentPosition[1] + viablePositions[3] != oldPosition[1]) { 
        oldPosition = currentPosition;
        currentPosition = new int[] {viablePositions[2]+currentPosition[0], viablePositions[3]+currentPosition[1]};
    }
    viablePositions = getViablePositions(currentPosition); 
    if (map[currentPosition[1],currentPosition[0]] == 'S') {
        done = !done;
        break;
    }    
    steps++;
}


Console.WriteLine("Steps: " + steps);
Console.WriteLine("Furthest distance: " + (steps+1)/2);

int[] getViablePositions(int[] currentPosition) {
    char cha = map[currentPosition[1],currentPosition[0]];
    int[] viablePositions = new int[4];
    switch(cha) {
        case '|':
            viablePositions = new int[] {0,1,0,-1};
            break;
        case '-':
            viablePositions = new int[] {1,0,-1,0};
            break;        
        case 'L':
            viablePositions = new int[] {0,-1,1,0};
            break;            
        case 'J':
            viablePositions = new int[] {0,-1,-1,0};
            break;            
        case '7':
            viablePositions = new int[] {-1,0,0,1};
            break;            
        case 'F':
            viablePositions = new int[] {1,0,0,1};
            break;            
        case '.':

            break;            
        case 'S':

            break;
        default:
            break;
    }
    return viablePositions;

}