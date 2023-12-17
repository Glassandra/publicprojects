using System.IO;

StreamReader reader = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\DayFive\\challenge.txt");
string? line;
Int64[] seeds = new Int64[3];
List<string> allMapsString = new List<string>();

try{
    line = reader.ReadLine();
    string[] tempString = line.Split(' ');
    tempString = tempString.Skip(1).ToArray();
    seeds = Array.ConvertAll(tempString, s => Int64.Parse(s));
    line = reader.ReadLine();
    while (line !=null) {
        allMapsString.Add(line);
        line = reader.ReadLine();
    }

}
catch (Exception e) {
    Console.WriteLine("Error is: " + e.Message);
}
finally {
    reader.Close();
}

List<numberSpan>[] mapsSeed = new List<numberSpan>[7];

Int64 index = -1;
foreach(string str in allMapsString) {
    if (str == "" || str == null) {
        index++;
        mapsSeed[index] = new List<numberSpan>();
    }
    else if (Int64.TryParse(str.Split(' ')[0], out Int64 var)) {
        Int64[] tempArray = Array.ConvertAll(str.Split(' '), s => Int64.Parse(s));
        mapsSeed[index].Add(new numberSpan(tempArray));
    }
}

List<Int64> lowestValue = new List<Int64>();

foreach (Int64 currentSeed in seeds) {
    Int64 iterSeed = currentSeed;
    for(Int64 i = 0; i<mapsSeed.Length; i++) {
        foreach(numberSpan num in mapsSeed[i]) {
            if (iterSeed >= num.span[1] && iterSeed < num.span[1] + num.span[2]) {
                iterSeed = Math.Abs(iterSeed - num.span[1] + num.span[0]);
                break;
            }
        }
        //Console.WriteLine($"Current iteration is {i} and current seed is {iterSeed}");
    }
    lowestValue.Add(iterSeed);
}


Console.WriteLine("Final resultat is: " + lowestValue.AsQueryable().Min());

class numberSpan {
    public Int64[] span {get;set;} = new Int64[3];

    public numberSpan(Int64[] array) {
        for (Int64 i = 0; i<3; i++) {
            span[i] = array[i];
        }
    }
    public numberSpan() {

    }
}