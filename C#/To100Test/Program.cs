using System;

/* 
Challenge according to "https://rosettacode.org/wiki/Sum_to_100".
Program to insert the symbols "+","-","" into the sequence 123456789 to calculate the sums.
For an example -1+2-3+4+5+6+78+9 = 100.

To complete the challenge there are 4 parts:
Part 1 is finding and printing the sequences that sum up to 100
Part 2 is finding the number with the highest amount of solutions in the positive number line
Part 3 is finding the lowest number that has no viable solution
The bonus part is finding the highest 10 sums.

For ease of treating each part I start by finding all symbol sequences in a list using generateArrays(). The next step is finding all the sums corresponding
index in the symbol list using calculateSums(). Since the highest number of possible sequences is 2*3^8 = 13122, I feel confident that the size of the lists 
doesnt cause problem with memory.
These two lists are then used to complete each challenge. To help there are a couple of functions to print out values of lists, compare number and so forth.

 */

//initialization of the challenge
string[] challenge = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
string[] operators = { "+", "-", "" };
const int n = 9;

//viableSolutions is the list that contains all possible combinations of symbols, in the form of string arrays
// with 9 possible index, each keeping on symbol
List<string[]> viableSolutions = new List<string[]>();

string[] symbolArray = new string[n];
generateArrays(symbolArray, 0);

//sums keeps all the sums of the possible combinations, each index here will correspond to the same index on viableSolutions.
List<int> sums = calculateSums();

// each of these calls the functions completing each task.
firstPart();
secondPart();
thirdPart();
generateBonusArrays(sums);

void firstPart()
{
    int number = 100;
    List<string[]> result = findNumber(sums, number);
    printList(result, number);
}

void secondPart()
{
    Console.WriteLine();
    int maxValueList = 0;
    int highestCount = 0;
    for (int i = 1; i < 10000; i++) //10000 is there to make testing faster, the actual highest number must be 123456789, which we could put in instead
    {
        int sum = findNumber(sums, i).Count;
        if (sum > maxValueList)
        {
            maxValueList = sum;
            highestCount = i;
        }
    }
    Console.WriteLine("Sum with max solutions is: " + highestCount + " where the number of solutions is " + maxValueList);
}

void thirdPart()
{
    Console.WriteLine();
    int i = 0;
    do
    {
        if (findNumber(sums, i).Count == 0)
        {
            break;
        }
        i++;
    } while (true);
    Console.WriteLine("Lowest sum that cant be expressed is: " + i);
}

void generateBonusArrays(List<int> array)
{
    Console.WriteLine();
    var result = array.OrderByDescending(x => x).Take(10);
    Console.WriteLine("10 highest values are: ");
    foreach (int element in result)
    {
        Console.WriteLine(element);
    }
}

//using recursion to fill viableSolutions
void generateArrays(string[] array, int i)
{
    string[] temp = new string[n];
    for (int k = 0; k < n; k++)
    { // this part is here to avoid the list containing 13122 of the same memory locations
        temp[k] = array[k];
    }
    if (i == n)
    {
        viableSolutions.Add(temp);
        return;
    }
    else if (i == 0)
    {
        temp[0] = "";
        generateArrays(temp, i + 1);
        temp[0] = "-";
        generateArrays(temp, i + 1);
    }
    else
    {
        for (int j = 0; j < 3; j++)
        {
            temp[i] = operators[j];
            generateArrays(temp, i + 1);
        }
    }
}

//prints the solutions and sums, used mostly for part1
void printList(List<string[]> list, int number)
{
    string output = "";
    Console.WriteLine();
    foreach (string[] element in list)
    {
        if (element[0] == "-")
        {
            output = "-1";
        }
        else
        {
            output = "1";
        }
        for (int i = 1; i < n; i++)
        {
            output = output + element[i] + challenge[i];
        }
        Console.WriteLine($"{number} = {output}");
    }
}

//calculate each sum
int calculateArray(String[] array)
{
    int sum = 0;
    string test = "";
    for (int i = 0; i < n; i++)
    {
        switch (array[i])
        {
            case "+":
                if (i == 0)
                {
                    test = "1";
                }
                else
                {
                    sum = sum + Int32.Parse(test);
                    test = challenge[i];
                }
                break;
            case "-":
                if (i == 0)
                {
                    test = "-1";
                }
                else
                {
                    sum = sum + Int32.Parse(test);
                    test = "-" + challenge[i];
                }
                break;
            case "":
                test = test + challenge[i];
                break;

        }
    }
    if (test != null)
    {
        sum = sum + Int32.Parse(test);
        test = "";
    }
    return sum;
}

List<int> calculateSums()
{
    List<int> result = new List<int>();
    foreach (String[] element in viableSolutions)
    {
        result.Add(calculateArray(element));
    }
    return result;
}

List<String[]> findNumber(List<int> sums, int number)
{
    List<String[]> result = new List<string[]>();
    for (int i = 0; i < sums.Count(); i++)
    {
        if (sums[i] == number)
        {
            result.Add(viableSolutions.ElementAt(i));
        }
    }
    return result;
}