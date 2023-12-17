using System.IO;
using System.Collections.Generic;
using System.Collections;

StreamReader reader = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\Day7\\challenge.txt");
string? line;
List<string> input = new List<string>();

try
{
    line = reader.ReadLine();
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

int[][] cards = new int[input.Count][];

int index = 0;
foreach (string str in input)
{
    int[] array = new int[7];     
    array[6] = Int32.Parse(str.Split(' ')[1]);
    array[0] = 0;
    for (int i = 0; i < 5; i++)
    {   
        char let = str[i];
        switch (let)
        {
            case 'A':
                array[i + 1] = 14;
                break;
            case 'K':
                array[i + 1] = 13;
                break;
            case 'Q':
                array[i + 1] = 12;
                break;
            case 'J':
                array[i + 1] = 1;
                break;
            case 'T':
                array[i + 1] = 10;
                break;
            default:
                array[i + 1] = Int32.Parse(let.ToString());
                break;
        }
    }


    getType(array);
    cards[index] = array;
    index++;
}

sortCards(cards);
sortCards(cards);
sortCards(cards);

int sum = 0;

for (int i = 0; i < cards.Length; i++ ) {
    sum = sum + (cards[i][6] * (i+1));
}

Console.WriteLine(sum);

StreamWriter writer = new StreamWriter("output.txt");
try {
    for (int i = 0; i < cards.Length; i++) {
        string temp = "";
        for (int j = 0; j < cards[i].Length; j++) {
            temp = temp + " " + cards[i][j];
        }
        writer.WriteLine(temp);
    }
}
catch (Exception e) {
    Console.WriteLine(e.Message);
}
finally {
    writer.Close();
}


void getType(int[] array)
{
    IDictionary<int, int> numbers = new Dictionary<int, int>();
    for (int i = 1; i < array.Length-1; i++)
    {
        if (numbers.ContainsKey(array[i]))
        {
            numbers[array[i]] = numbers[array[i]] + 1;
        }
        else
        {
            numbers.Add(array[i], 1);
        }
    }
    //five of a kind
    if (numbers.Values.Any(x => x == 5))
    {
        array[0] = 6;
    }   //four of a kind
    else if (numbers.Values.Any(x => x == 4))
    {
        array[0] = 5;
    }   // full house
    else if (numbers.Values.Any(x => x == 3) && numbers.Values.Any(x => x == 2))
    {
        array[0] = 4;
    }   // three of a kind
    else if (numbers.Values.Any(x => x == 3))
    {
        array[0] = 3;
    }   // two pair
    else if (numbers.Values.Count(x => x == 2) == 2)
    {
        array[0] = 2;
    }   // one one pair
    else if (numbers.Values.Any(x => x == 2))
    {
        array[0] = 1;
    } // high card
    
    if (numbers.ContainsKey(1)) {
        int temporary = numbers[1];
        if ( array[0] == 5) {
            array[0] = 6;
        } 
        else if ( array[0] == 4 ) {
            if (temporary == 1) {
                array[0] = 5;
            } else {
                array[0] = 6;
            }
        }
        else if ( array[0] == 3){
            array[0] = 5;
        }
        else if ( array[0] == 2) {
            if ( temporary == 1) {
                array[0] = 4;
            }
            else {
                array[0] = 5;
            }
        }
        else if (array[0] == 1) {
            array[0] = 3;
        }
        else if (array[0] == 0) {
            array[0] = 1;
        }
        
    }
}

void sortCards(int[][] array)
{

    for (int i = 1; i < array.Length; i++)
    {
        int j = i;
        int k = 0;
        bool check = false;
        while (j > 0 ) // && array[j-1][0] > array[j][0]
        {
            while (k < 7)
            {
                if (array[j-1][k] > array[j][k])
                {
                    check = true;
                    break;
                }
                else if (array[j-1][k] < array[j][k]) {
                    break;
                }
                k++;
            }
            if (check == false) {
                break;
            }
            int[] temp = array[j];
            array[j] = array[j-1];
            array[j-1] = temp;
            j--;
            k = 0;

            check = false;
        }
    }
}