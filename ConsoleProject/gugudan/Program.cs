//9*9 변수에 초기화 후 변수의 값 출력

int[,] gugudan = new int[8, 9];

for(int i = 0; i < gugudan.GetLength(0); i++) // 단의 개수 
{    
    for(int j = 0; j < gugudan.GetLength(1); j++) // 1 ~ 9 까지의 개수
    {
        gugudan[i, j] = (i + 2) * (j + 1);
        Console.WriteLine($"{i + 2} * {j + 1} = {gugudan[i, j]}");        
    }
    Console.WriteLine();
    
}
    


