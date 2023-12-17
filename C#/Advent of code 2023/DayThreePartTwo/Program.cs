using System.IO;

StreamReader reader = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\DayThreePartTwo\\challenge.txt");
string? line;
List<string> partData = new List<string>();

try
{
    line = reader.ReadLine();
    while (line != null)
    {
        partData.Add(line);
        line = reader.ReadLine();
    }
}
catch (Exception e)
{
    Console.WriteLine("Error: " + e.Message);
}
reader.Close();

int width = partData.First().Length;
int height = partData.Count;
List<DataObject> listStars = new List<DataObject>();


string[,] data = new string[height + 2, width + 2];

Console.WriteLine("Width: " + width + " Height: " + height);

for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
        if (partData.ElementAt(i).ElementAt(j) != '.')
        {
            data[i + 1, j + 1] = "" + partData.ElementAt(i).ElementAt(j);
        }
    }
}

int[,] comparison = new int[height + 2, width + 2];
DataObject[,] comparisonData = new DataObject[height + 2, width + 2];
int temp;

for (int i = 1; i < height + 1; i++)
{
    for (int j = 1; j < width + 1; j++)
    {
        int check = 0;
        if ((Int32.TryParse(data[i, j], out temp)))
        {
            DataObject tempData = new DataObject("*");
            for (int k = -1; k < 2; k++)
            {
                for (int l = -1; l < 2; l++)
                {
                    if (data[i + k, j + l] == "*")
                    {
                        if (check == 0)
                        {
                            check = 1;
                            tempData.coupled.Add(new coord(i + k, j + l));
                            comparison[i + k, j + l] = 2;
                        }
                        else
                        {
                            comparison[i + k, j + l] = 2;
                            tempData.coupled.Add(new coord(i + k, j + l));
                        }
                    }
                }
            }
            comparisonData[i, j] = tempData;
        }
        comparison[i, j] = check;
    }
}
List<DataObject> result = new List<DataObject>();

int iter = 1;

for (int i = 1; i < height + 2; i++)
{
    iter = 1;
    while (iter < width + 2)
    {
        if (Int32.TryParse(data[i, iter], out temp))
        {
            DataObject tempData = new DataObject("");            
            bool hasAdded = false;
            while (Int32.TryParse(data[i, iter], out temp))
            {
                tempData.text += data[i, iter];
                if (comparison[i, iter] == 1)
                {
                    foreach (coord cor in comparisonData[i, iter].coupled)
                    {
                        if (hasAdded == false)
                        {
                            tempData.coupled.Add(cor);
                            hasAdded = true;
                        }
                        else
                        {
                            foreach (coord cortemp in tempData.coupled)
                            {
                                if ((cor.x != cortemp.x) && (cor.y != cortemp.y))
                                {
                                    tempData.coupled.Add(cor);
                                }
                            }
                        }
                        //if ( iter != cor.x || i != cor.y){
                        //}
                    }
                }
                iter++;
            }
            result.Add(tempData);
        }
        iter++;
    }
    //Console.WriteLine(i);.Except(tempData.coupled)tempData.coupled.AddRange(comparisonData[i,iter].coupled.Except(tempData.coupled));
}

int sum = 0;

for (int i = 1; i < height + 1; i++)
{
    for (int j = 1; j < width + 1; j++)
    {
        if (comparison[i, j] == 2)
        {
            List<DataObject> tempDat = new List<DataObject>();
            int tempSum = 1;
            foreach (DataObject dat in result)
            {
                foreach (coord cor in dat.coupled)
                {
                    if (cor.x == j && cor.y == i)
                    {
                        tempDat.Add(dat);
                        tempSum = tempSum * int.Parse(dat.text);
                    }
                }
            }
            if (tempDat.Count == 2)
            {
                sum += tempSum;
            }
        }
    }
}

Console.WriteLine("sum is: " + sum);
// && (comparison[i,iter] == 1 || comparison[i,iter+1] == 1|| comparison[i,iter+2] == 1))

class DataObject
{
    public string text { get; set; }
    public List<coord> coupled { get; set; } = new List<coord>();

    public DataObject(string text, int y, int x)
    {
        this.text = text;
        coupled.Add(new coord(y, x));
    }

    public DataObject(string text)
    {
        this.text = text;
    }

}

class coord
{
    public int x { get; set; }
    public int y { get; set; }

    public coord(int y, int x)
    {
        this.x = x;
        this.y = y;
    }
}
