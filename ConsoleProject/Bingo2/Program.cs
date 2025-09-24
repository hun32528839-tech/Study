int[,] bingo = new int[5, 5];

Random random = new Random();
int num = 1;

for(int y = 0; y < bingo.GetLength(0); y++)
{
    for(int x = 0; x < bingo.GetLength(1); x++)
    {
        bingo[y, x] = num++;
    }   
}


for(int i = 0; i < 50; i++)
{
    int one = random.Next(5);
    int two = random.Next(5);
    int three = random.Next(5);
    int four = random.Next(5);


    int temp = bingo[one,two];
    bingo[one , two] = bingo[three, four];
    bingo[three , four] = temp;
}


while(true)
{
    for (int y = 0; y < bingo.GetLength(0); y++)
    {
        for (int x = 0; x < bingo.GetLength(1); x++)
        {
            Console.Write($"{bingo[y, x]} ");
        }
        Console.WriteLine();
    }

    Console.WriteLine("====================================================================");

    Console.WriteLine("숫자를 입력하세요");

    string input = Console.ReadLine();

    if(int.TryParse(input , out int result) == false)
    {
        Console.WriteLine("잘못된 입력입니다");
    }

    if(int.TryParse(input, out result))
    {
        for(int y = 0; y < bingo.GetLength(0); y++)
        {
            for(int x = 0; x < bingo.GetLength(1); x++)
            {
                if(result == bingo[y,x])
                {
                    bingo[y, x] = 0;
                }
            }
        }
    }

    int bingoCount = 0;
    for(int y = 0; y < 5; y++)
    {
        bool horizontalLineBingo = true;
        for(int x = 0; x < 5; x++)
        {
            if (bingo[y,x] != 0)
            {
                horizontalLineBingo = false;
            }
        }
        if(horizontalLineBingo)
        {
            bingoCount++;            
        }
    }

    for(int x = 0; x < 5; x++)
    {
        bool verticalLineBingo = true;
        for(int y = 0; y < 5; y++)
        {
            if (bingo[y,x] != 0)
            {
                verticalLineBingo = false;
            }
        }
        if(verticalLineBingo)
        {
            bingoCount++;
        }
    }

    bool diagonalLineBingo1 = true;
    for (int x = 0; x < 5; x++)
    {     
        if (bingo[x,x] != 0)
        {
            diagonalLineBingo1 = false;
        }
    }
    if (diagonalLineBingo1)
    {
        bingoCount++;
    }

    bool diagonalLineBingo2 = true;
    for(int x = 0; x < 5; x++)
    {
        if (bingo[x , 4 - x] != 0)
        {
            diagonalLineBingo2 = false;
        }
    }
    if(diagonalLineBingo2)
    {
        bingoCount++;
    }

    Console.WriteLine($"BingoCount : {bingoCount}");

    if(bingoCount == 12)
    {
        break;
    }
}
