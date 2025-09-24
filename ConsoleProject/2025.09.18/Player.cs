public enum PlayerClass : int
{
    None = 0,

    Warrior,
    Wizard,

}

public class Player : Character
{
    // 외부에서도 읽을 수 있음
    // 외부에서는 값을 바꿀 수 없고, 클래스 내부에서만 변경 가능
    public PlayerClass PlayerClass1 { get; private set; }
    
    
    public void InitPlayer(PlayerClass inPlayerClass , string inName , int inHp , int inAtk)
    {
        InitCharacter(inName, inHp, inAtk);
        PlayerClass1 = inPlayerClass;      


    }

    public override void PrintInfo()
    {
        base.PrintInfo();

        Console.WriteLine($"Class : {PlayerClass1}");
    }

}