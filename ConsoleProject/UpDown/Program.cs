Random random = new Random();
int computer = random.Next(1, 101);

while (true)
{
    Console.WriteLine($"Computer : ???");

    Console.WriteLine("Player Input");
    string player = Console.ReadLine();

    if (int.TryParse(player , out int result) == false)
    {
        Console.WriteLine("잘못된 입력입니다");
    }

    if (int.TryParse(player, out result))
    {
        if (result <= 0 && result >= 101)
        {
            Console.WriteLine("범위를 벗어났습니다");
        }

        if (result == computer)
        {
            Console.WriteLine($"Computer : {computer}");
            Console.WriteLine("정답입니다");
            break;
        }
        else if (result < computer)
        {
            Console.WriteLine("업");
        }
        else if(result > computer)
        {
            Console.WriteLine("다운");
        }
    }
   
}