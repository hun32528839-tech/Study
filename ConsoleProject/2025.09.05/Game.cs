public enum GameInput : int
{
    None = 0,

    Battle,
    Runaway,

}
public class Game
{
    Character character = new Character();
    Player player = new Player();
    Monster monster = new Monster();
    GameConfig gameConfig = new GameConfig();
    Random random = new Random();
    Item item = new Item();

    string playerName = "";

    public void Init() // 플레이어 이름과 클래스를 정하는 초기화 함수
    {
        Console.Write("이름을 입력하세요 : ");
        playerName = Console.ReadLine();
        Console.WriteLine("==================================");

        while (true)
        {                      
            Console.WriteLine("클래스 선택하세요");
            Console.WriteLine("1.전사 2.마법사");
            Console.WriteLine("==================================");
            string playerClassInput = Console.ReadLine();

            if (int.TryParse(playerClassInput , out int result) == false) // 문자열로 잘못 받았을때
            {
                Console.WriteLine("잘못된 선택입니다");
                Console.WriteLine("다시 선택하세요");
                Console.WriteLine("==================================");
            }

            if (int.TryParse(playerClassInput, out int classInput))
            {
                if (classInput == (int)PlayerClass.Warrior)
                {
                    Console.WriteLine($"{PlayerClass.Warrior}를 선택하셨습니다");
                    Console.WriteLine("===================================");
                    Console.WriteLine("캐릭터 정보");
                    player.InitPlayer(playerName, 100, 30, PlayerClass.Warrior);
                    player.PrintInfo();
                    Console.WriteLine();
                    break;
                }
                else if (classInput == (int)PlayerClass.Wizard)
                {
                    Console.WriteLine($"{PlayerClass.Wizard}를 선택하셨습니다");
                    Console.WriteLine("===================================");
                    Console.WriteLine("캐릭터 정보");
                    player.InitPlayer(playerName, 100, 20, PlayerClass.Wizard);
                    player.PrintInfo();
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 선택입니다");
                    Console.WriteLine("다시 선택하세요");
                    Console.WriteLine("==================================");
                }
            }
        }       
    }

    public void Run() // 게임 시작 함수
    {
        Console.WriteLine($"{playerName} 걸어가는 중...");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine("      .");
        }
        Console.WriteLine("몬스터가 나타났다");
        Console.WriteLine();

        Monster monsterInfo = ObjectFactory.CreateRandomMonster();

        Console.WriteLine("몬스터 정보");
        Console.WriteLine("================================");
        monsterInfo.PrintInfo();
        Console.WriteLine("================================");
        Console.WriteLine();

        // hp를 0 밑으로 안 떨어지게 표시 할려면??? (△)
        // Item class를 만들고, Monster가 Item을 드랍하고, Player에 체력이 떨어진다면 HpPotion을 먹고, HpPotion에 회복량은 랜덤으로
       
        while (true)
        {
            int hpPotionRandomValue = random.Next(GameConfig.hpPotionMinValue, GameConfig.hpPotionMaxValue);
            Console.WriteLine("1.공격 2.도망");

            string playerInput = Console.ReadLine();

            if (int.TryParse(playerInput, out int result) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine("다시 선택하세요.");
                Console.WriteLine("=================================");
            }

            if (int.TryParse(playerInput, out int input))
            {
                if (input == (int)GameInput.Battle)
                {                  
                    Console.WriteLine();
                    Console.WriteLine($"{playerName} 공격!!");
                    monsterInfo.AttackDamage(player.GetAtk());
                    if (monsterInfo.GetHp() <= 0 && monsterInfo.GetHp() <= player.GetAtk())
                    {
                        Console.WriteLine("몬스터 Hp가 0 남았습니다.");
                        Console.WriteLine("몬스터를 잡았습니다.");
                        
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"몬스터 Hp {monsterInfo.GetHp()} 남았습니다.");
                    }
                   
                                      
                    Console.WriteLine();
                    Console.WriteLine("Monster 공격!!");
                    player.AttackDamage(monsterInfo.GetAtk());
                    Console.WriteLine($"{playerName}에 Hp가 {player.GetHp()} 남았습니다.");

                }
             
                else if (input == (int)GameInput.Runaway)
                {
                    if (gameConfig.PlayerRunawayChance() <= 3)
                    {
                        Console.WriteLine("도망에 실패하셨습니다.");
                        Console.WriteLine("전투에 돌입합니다.");

                        Console.WriteLine();

                        Console.WriteLine("1.공격");

                        playerInput = Console.ReadLine();

                        if (int.TryParse(playerInput, out result) == false)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.WriteLine("다시 선택하세요.");
                            Console.WriteLine("=================================");
                        }

                        Console.WriteLine();

                        Console.WriteLine($"{playerName} 공격!!");
                        monsterInfo.AttackDamage(player.GetAtk());
                        //Console.WriteLine($"몬스터 Hp {monsterInfo.GetHp()}이 남았습니다. ");

                        if (monsterInfo.GetHp() <= 0)
                        {
                            Console.WriteLine("몬스터를 잡았습니다.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("도망에 성공하셨습니다.");
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine();
                }
            }

        }                      
    }
}
