public enum ItemType : int
{
    None = 0,

    HpPotion,

    End
}
public class Item
{
    private ItemType itemType;
    private int itemValue;

    public ItemType GetItemType()
    {
        return itemType;
    }
    public int GetItemValue()
    {
        return itemValue;
    }

    public void Init(ItemType inItemType , int inItemValue)
    {
        itemType = inItemType;
        itemValue = inItemValue;
    }
}