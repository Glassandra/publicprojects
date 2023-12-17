long[,] training = {{7, 15, 30}, {9, 40, 200}};
long[,] challenge = {{60, 94, 78, 82}, {475, 2138, 1015, 1650}};
long[,] challenge2 = {{60947882},{475213810151650}};

long[,] input = challenge2;

long length = input.Length/2;

long result = 1;

for(long i = 0; i < length; i++) {
    long count = 0;
    for(long j = 0; j<input[0,i]; j++) {
        if ( (input[0,i]*j - (j*j)) > input[1,i]) {
            count++;
        }
    }
    result = result * count;
}

Console.WriteLine("Result: " + result);