using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_house_of_terror
{
    public class Item // 인벤토리 아이템 데이터베이스 저장
    {
        public string name;
        public int attackPower;
        public int defense;
        public string description;
        public int gold;
        public bool isEquipped = false;
        public Item(string name, int attackPower, int defense, string description, int gold) // 초기화 
        {
            this.name = name;
            this.attackPower = attackPower;
            this.defense = defense;
            this.description = description;
            this.gold = gold;
            this.isEquipped = false;
        }

        public static List<Item> InventoryItems = new List<Item>();  // 인벤토리 아이템을 구분해서 목록을 하나로 저장 
    }

    public class ItemDatabase()
    {
        public static Item item1 = new Item("수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000);
        public static Item item2 = new Item("무쇠 갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000);
        public static Item item3 = new Item("스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3000);
        public static Item item4 = new Item("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 1000);
        public static Item item5 = new Item("청동 도끼", 5, 0, "어디선가 사용됐던 도끼입니다.", 2000);
        public static Item item6 = new Item("스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3000);

        public static List<Item> Items = new List<Item>() // 아이템의 모든 목록을 하나로 저장 
        {
        item1, item2, item3, item4, item5, item6
        };

        public static bool showGold = false;
    }
}



