using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Collections;

Regex reg;
int numberRed = 12;
int numberGreen = 13;
int numberBlue = 14;

StreamReader reader = new StreamReader("challenge.txt");
string line;

int sum = 0;
int sumPower = 0;

try
{
    line = reader.ReadLine();
    while (line != null)
    {
        int temp = isGamePossible(line);  
        sum += temp;
        Console.WriteLine("running sum is: " + sum + " game number is: " + temp);   

        temp = gamePower(line);
        sumPower += temp;
        Console.WriteLine("running sumPower is: " + sumPower + " power is: " + temp);  

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

Console.WriteLine("Final sum is:" + sum);
Console.WriteLine("Final powersum is: " + sumPower);

/* string s = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

int i = isGamePossible(s); */

int isGamePossible(string s)
{
    int gameID = Int32.Parse(Regex.Match(s, @"(\d)").Value);
  
    string[] values = s.Split(':');
    gameID = Int32.Parse(values[0].Split(' ')[1]);
    values = values[1].Split(';',',');

    foreach(string value in values) {
        string[] temp = value.Split(' ');
        switch(temp[2]) {
            case "red":
                if (Int32.Parse(temp[1]) > numberRed) {return 0;}
                break;
            case "blue":
                if (Int32.Parse(temp[1]) > numberBlue) {return 0;}
                break;
            case "green":
                if (Int32.Parse(temp[1]) > numberGreen) {return 0;}
                break;
            default:
                break;
        }
    }    
    return gameID;
}

int gamePower(string s)
{
    int gameID = Int32.Parse(Regex.Match(s, @"(\d)").Value);  
    string[] values = s.Split(':');
    gameID = Int32.Parse(values[0].Split(' ')[1]);
    values = values[1].Split(';',',');
    int maxRed = 0;
    int maxBlue = 0;
    int maxGreen = 0;

    foreach(string value in values) {
        string[] temp = value.Split(' ');
        int number = Int32.Parse(temp[1]);
        switch(temp[2]) {
            case "red":
                if (number > maxRed) {
                    maxRed = number;
                }
                break;
            case "blue":
                if (number > maxBlue) {
                    maxBlue = number;
                }
                break;
            case "green":
                if (number > maxGreen) {
                    maxGreen = number;
                }
                break;
            default:
                break;
        }
    }    
    return maxRed*maxBlue*maxGreen;
}

    /* MatchCollection matches = Regex.Matches(s, @"\d\s(red|blue|green)");
    foreach (Match value in matches) {
        GroupCollection groups = value.Groups;
    } */
    //Console.WriteLine(Regex.Match(s, @"(s|Game)\s\d").Value);@"\d+(?=\s?(red|blue|green)?\b)"
    //string[] game = s.Split( ':', ';' );
    //string regResult = Regex.Match(game[0], @"\d+").Value;
    //int gameID = Int32.Parse(regResult);
    /* for (int i = 1; i < game.Length; i++) {
        string temp = game[i];
        regResult = Regex.Match(temp, @"\d+(?=\s?red?\b)").Value;
        int tempNumber = Int32.Parse(regResult);
        Console.WriteLine(tempNumber);
        if (tempNumber > numberRed) {
            return 0;
        } 
        regResult = Regex.Match(temp, @"\d+(?=\s?green?\b)").Value;
        tempNumber = Int32.Parse(regResult);
        if (tempNumber > numberGreen) {
            return 0;
        }        
        regResult = Regex.Match(temp, @"\d+(?=\s?blue?\b)").Value;
        tempNumber = Int32.Parse(regResult);
        if (tempNumber > numberBlue) {
            return 0;
        } 
    }*/ 
