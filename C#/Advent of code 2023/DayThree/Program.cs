using System.IO;

StreamReader reader = new StreamReader("C:\\Users\\cassa\\Documents\\Projects\\C#\\AdventCode\\DayThree\\challenge.txt");
string? line;
List<string> partData = new List<string>();

try {
    line = reader.ReadLine();
    while (line != null) {
        partData.Add(line);
        line = reader.ReadLine();
    }
}
catch(Exception e){
    Console.WriteLine("Error: " + e.Message);
}
reader.Close();

int width = partData.First().Length;
int height = partData.Count;


string[,] data = new string[width+2,height+2];

Console.WriteLine("Width: " + width + " Height: " + height);

for (int i = 0; i<height; i++ ) {
    for ( int j = 0; j<height; j++) {        
        if (partData.ElementAt(i).ElementAt(j) != '.') {
            data[i+1,j+1] = "" + partData.ElementAt(i).ElementAt(j);
        }
    }
}

int[,] comparison = new int[width+2,height+2];
int temp;

for (int i = 1; i<height+1; i++ ) {
    for ( int j = 1; j<height+1; j++) { 
        int check = 0;
        if (Int32.TryParse(data[i,j], out temp)) {
            for(int k=-1; k<2; k++) {
                for( int l=-1; l<2; l++) {
                    if (data[i+k, j+l] != null && !(Int32.TryParse(data[i+k,j+l], out temp))) {
                        check = 1;
                    }
                }
            }
        }
        comparison[i,j] = check;          
    }
}
/* 
for (int i = 0; i< height; i++) {
    for (int j = 0; j < width; j++) {
        if (partData.ElementAt(i).ElementAt(j) != '.') {
            data[i+1,j+1] = "" + partData.ElementAt(i).ElementAt(j);
        }
    }
}


for(int i = 1; i < height-1; i++) {
    for (int j = 1; j< height-1; j++) {
        int check = 0;
        if (Int32.TryParse(data[i,j], out temp)) {
            for(int k=-1; k<2; k++) {
                for( int l=-1; l<2; l++) {
                    if (data[i+k, j+l] != null || !(Int32.TryParse(data[i+k,j+l], out temp))) {
                        check = 1;
                    }
                }
            }
        }
        comparison[i,j] = check;
    }
}
 */
List<string> result = new List<string>();

int iter = 1;

for (int i = 1; i<height+1; i++) {
    iter=1;
    while (iter<width+1) {
        if (Int32.TryParse(data[i,iter], out temp)) { 
            string str = "";
            int count = 0;
            while (Int32.TryParse(data[i,iter], out temp)) {
                str += data[i,iter];
                if (comparison[i,iter] == 1) {
                    count = 1;
                }
                iter++;
            }
            if ( count == 1) {
                result.Add(str);
            }            
        }
        iter++;
    }
    //Console.WriteLine(i);
}

int sum = 0;

foreach (string s in result) {
    sum += Int32.Parse(s);
}

Console.WriteLine("sum is: " + sum);
// && (comparison[i,iter] == 1 || comparison[i,iter+1] == 1|| comparison[i,iter+2] == 1))