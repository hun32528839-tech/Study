int[,] bingo = new int[5, 5];
int number = 1;
int bingoCount = 1;

bool bingoVisit1 = false;
bool bingoVisit2 = false;
bool bingoVisit3 = false;
bool bingoVisit4 = false;
bool bingoVisit5 = false;
bool bingoVisit6 = false;
bool bingoVisit7 = false;
bool bingoVisit8 = false;
bool bingoVisit9 = false;
bool bingoVisit10 = false;
bool bingoVisit11 = false;
bool bingoVisit12 = false;

Random random = new Random();

for (int i = 0; i < bingo.GetLength(0); i++)
{
    for (int j = 0; j < bingo.GetLength(1); j++)
    {
        bingo[i, j] = number++;      
    }    
}

for (int i = 0; i < 30; i++)
{
    int one = random.Next(5);
    int two = random.Next(5);
    int three = random.Next(5);
    int four = random.Next(5);

    int temp = bingo[one, two];
    bingo[one, two] = bingo[three, four];
    bingo[three, four] = temp;
}

for (int i = 0; i < bingo.GetLength(0); i++)
{
    for (int j = 0; j < bingo.GetLength(1); j++)
    {
        Console.Write(bingo[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("빙고게임을 시작합니다");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("숫자를 입력하세요");
    string num = Console.ReadLine();

    if (int.TryParse(num , out int result) == false)
    {
        Console.WriteLine("잘못된 입력입니다");
        Console.WriteLine("다시 입력하세요");
        Console.WriteLine();
        Console.WriteLine("숫자를 입력하세요");      
        num = Console.ReadLine();
    }

    if (int.TryParse(num , out result))
    {
        if (result <= 0 || result > bingo.Length)
        {
            while (true)
            {
                Console.WriteLine("잘못된 숫자입니다");
                Console.WriteLine("다시 입력하세요");
                Console.WriteLine();
                Console.WriteLine("숫자를 입력하세요");         
                num = Console.ReadLine();
                
                if (int.TryParse(num , out result))
                {
                    if (result > 0 && result <= bingo.Length)
                    {
                        break;
                    }
                }                           
            }           
        }

        if (result > 0 && result <= bingo.Length)
        {
            for (int i = 0; i < bingo.GetLength(0); i++)
            {
                for (int j = 0; j < bingo.GetLength(1); j++)
                {
                    if (result == bingo[i, j])
                    {
                        bingo[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < bingo.GetLength(0); i++)
            {
                for (int j = 0; j < bingo.GetLength(1); j++)
                {
                    Console.Write(bingo[i, j] + " ");
                }
                Console.WriteLine();
            }
        
        
            if (bingo[0, 0] == 0 && bingo[0, 1] == 0 && bingo[0, 2] == 0 && bingo[0, 3] == 0 && bingo[0, 4] == 0)
            {
                if(bingoVisit1 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit1 = true;
                }                                    
            }

            if (bingo[1, 0] == 0 && bingo[1, 1] == 0 && bingo[1, 2] == 0 && bingo[1, 3] == 0 && bingo[1, 4] == 0)
            {
                if(bingoVisit2 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit2 = true;
                }
            }

            if (bingo[2, 0] == 0 && bingo[2, 1] == 0 && bingo[2, 2] == 0 && bingo[2, 3] == 0 && bingo[2, 4] == 0)
            {
                if(bingoVisit3 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit3 = true;
                }
            }

            if (bingo[3, 0] == 0 && bingo[3, 1] == 0 && bingo[3, 2] == 0 && bingo[3, 3] == 0 && bingo[3, 4] == 0)
            {
                if (bingoVisit4 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit4 = true;
                }
            }

            if (bingo[4, 0] == 0 && bingo[4, 1] == 0 && bingo[4, 2] == 0 && bingo[4, 3] == 0 && bingo[4, 4] == 0)
            {
                if (bingoVisit5 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit5 = true;
                }
            }

            if (bingo[0, 0] == 0 && bingo[1, 0] == 0 && bingo[2, 0] == 0 && bingo[3, 0] == 0 && bingo[4, 0] == 0)
            {
                if (bingoVisit6 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit6 = true;
                }
            }

            if (bingo[0, 1] == 0 && bingo[1, 1] == 0 && bingo[2, 1] == 0 && bingo[3, 1] == 0 && bingo[4, 1] == 0)
            {
                if (bingoVisit7 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit7 = true;
                }
            }

            if (bingo[0, 2] == 0 && bingo[1, 2] == 0 && bingo[2, 2] == 0 && bingo[3, 2] == 0 && bingo[4, 2] == 0)
            {
                if (bingoVisit8 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit8 = true;
                }
            }

            if (bingo[0, 3] == 0 && bingo[1, 3] == 0 && bingo[2, 3] == 0 && bingo[3, 3] == 0 && bingo[4, 3] == 0)
            {
                if (bingoVisit9 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit9 = true;
                }
            }

            if (bingo[0, 4] == 0 && bingo[1, 4] == 0 && bingo[2, 4] == 0 && bingo[3, 4] == 0 && bingo[4, 4] == 0)
            {
                if (bingoVisit10 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit10 = true;
                }
            }

            if (bingo[0, 0] == 0 && bingo[1, 1] == 0 && bingo[2, 2] == 0 && bingo[3, 3] == 0 && bingo[4, 4] == 0)
            {
                if (bingoVisit11 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit11 = true;
                }
            }

            if (bingo[0, 4] == 0 && bingo[1, 3] == 0 && bingo[2, 2] == 0 && bingo[3, 1] == 0 && bingo[4, 0] == 0)
            {
                if (bingoVisit12 == true)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"BingoCount : {bingoCount}빙고");
                    bingoCount++;
                    bingoVisit12 = true;
                }
            }        
        }       
    }
}



// 한 줄 완성되면 1빙고