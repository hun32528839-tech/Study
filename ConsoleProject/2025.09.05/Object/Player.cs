public enum PlayerClass : int
{
    None = 0,

    Warrior,
    Wizard,

    End
}

public class Player : Character
{
    protected PlayerClass playerClass;
    protected List<Item> items;

    public void InitPlayer(string inName , int inHp , int inAtk , PlayerClass inPlayerClass)
    {
        InitCharacter(inName, inHp, inAtk);

        playerClass = inPlayerClass;

        items = new List<Item>();
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"PlayerClass : {playerClass}");
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void PrintItem()
    {
        for(int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i}번 : {items[i].GetItemType()} {items[i].GetItemValue()}");
        }
    }

    public bool UseItem(int index)
    {
        if(index < 0 || index >= items.Count)
        {
            return false;
        }

        if(GetHp() <= 0)
        {
            return false;
        }

        switch(items[index].GetItemType())
        {
            case ItemType.None:
            case ItemType.End:
                return false;
            case ItemType.HpPotion:
                {
                    hp += items[index].GetItemValue();
                    Console.WriteLine($"포션을 먹었습니다. Hp : {hp}");
                }               
                break;
        }
        items.RemoveAt(index);

        return true;
    }

    

}