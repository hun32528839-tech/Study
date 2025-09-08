public enum MonsterType : int
{
    None = 0,

    Goblin,
    Skeleton,
    Orc,

    End
}

public class Monster : Character
{
    protected MonsterType monsterType;

    public void InitMonster(string inName , int inHp , int inAtk , MonsterType inMonsterType)
    {
        InitCharacter(inName, inHp, inAtk);

        monsterType = inMonsterType;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();

        Console.WriteLine($"MonsterType : {monsterType}");
    }
}
