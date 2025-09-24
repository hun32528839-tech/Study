public enum MonsterType : int
{
    None = 0,

    Goblin,
    Skeleton,
    Orc,
}

public class Monster : Character
{
    public MonsterType MonsterType1 { get; private set; }

    public void InitMonster(MonsterType inMonsterType , string inName , int inHp , int inAtk)
    {
        InitCharacter(inName, inHp, inAtk);
        MonsterType1 = inMonsterType;        
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"MonsterType : {MonsterType1}");
    }
}