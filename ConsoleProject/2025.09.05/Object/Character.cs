public class Character
{
    protected string name;
    protected int hp;
    protected int atk;

    public void InitCharacter(string inName , int inHp , int inAtk)
    {
        name = inName;
        hp = inHp;
        atk = inAtk;
    }

    public int GetHp()
    {
        return hp;
    }
    public int GetAtk()
    {
        return atk;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name : {name}");
        Console.WriteLine($"Hp : {hp}");
        Console.WriteLine($"Atk : {atk}");
    }

    public void AttackDamage(int inDamage)
    {
        hp -= inDamage;
    }
}
