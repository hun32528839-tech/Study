public static class ObjectFactory 
{
    public static Monster CreateMonster(MonsterType monsterType)
    {
        Monster monster = new Monster();

        switch(monsterType)
        {
            case MonsterType.Goblin:
                monster.InitMonster("Goblin", 30, 10, MonsterType.Goblin);
                
                break;
            case MonsterType.Skeleton:
                monster.InitMonster("Skeleton", 40, 15, MonsterType.Skeleton);
                
                break;
            case MonsterType.Orc:
                monster.InitMonster("Orc", 50, 20, MonsterType.Orc);
                
                break;
        }
        return monster;
    }
    public static Monster CreateRandomMonster()
    {
        Random random = new Random();

        MonsterType monsterType = (MonsterType)random.Next(1, (int)MonsterType.End);

        return CreateMonster(monsterType);
    }


}

// 이 클래스 왜 이렇게 사용하는지 질문 