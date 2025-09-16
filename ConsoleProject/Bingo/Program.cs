int[,] bingo = new int[5, 5];
int number = 1;

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

            int bingoCount = 0;
            for (int y = 0; y < 5; ++y)
            {
                bool bLineBingo = true;
                for (int x = 0; x < 5; ++x)
                {
                    if (bingo[y, x] != 0)
                    {
                        bLineBingo = false;
                    }
                }
                if (bLineBingo)
                {
                    bingoCount++;
                }
            }

            for (int x = 0; x < 5; ++x)
            {
                bool bLineBingo = true;
                for (int y = 0; y < 5; ++y)
                {
                    if (bingo[y, x] != 0)
                    {
                        bLineBingo = false;
                    }
                }
                if (bLineBingo)
                {
                    bingoCount++;
                }
            }

            for (int x = 0; x < 5; ++x)
            {
                bool bLineBingo = true;
                if (bingo[x, x] != 0)
                {
                    bLineBingo = false;
                }
                if (bLineBingo)
                {
                    bingoCount++;
                }
            }

          
            for (int i = 0; i < 5; ++i)
            {
                bool bLineBingo = true;
                if (bingo[i, 4 - i] != 0)
                {
                    bLineBingo = false;
                }
                if (bLineBingo)
                {
                    bingoCount++;
                }
            }

            Console.WriteLine($"Bingo : {bingoCount}");
            
        }       
    }
}



// 한 줄 완성되면 1빙고