//9*9단 출력 변수 없이 그냥 for문 돌려서 출력

for(int i = 2; i <= 9; i++)
{
    for(int j = 1; j <= 9; j++)
    {
        Console.WriteLine($"{i} * {j} = {i * j}");
    }
    Console.WriteLine();
}