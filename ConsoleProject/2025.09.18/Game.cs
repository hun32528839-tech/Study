public class Game
{
    
    public void Init()
    {
        Console.WriteLine("직업을 선택하세요");
        Console.WriteLine("1. Warrior 2. Wizard");
        string playerClassInput = Console.ReadLine();

        if(int.TryParse(playerClassInput , out int result))
        {
            if(result == (int)PlayerClass.Warrior)
            {
                Console.WriteLine("Warrior를 선택하셨습니다");

                Player myPlayer = PlayerFactory.GetPlayer(PlayerClass.Warrior);
             
                Console.WriteLine($"Class : {myPlayer.PlayerClass1} Hp : {myPlayer.Hp} Atk : {myPlayer.Atk}");
            }
        }


    }

    
}