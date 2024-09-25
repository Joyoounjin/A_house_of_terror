using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_house_of_terror
{
    public class Inventory
    {
        public static Item equippedItem = null;
        public static int attackIncrease = 0;
        public static int defenseIncrease = 0;

        public static void ShowInventory() // 상태창 기능
        {

            Console.WriteLine("\n\n===== 인벤토리 =====\n");
            Console.WriteLine("\n보유 중인 아이템을 관리할 수 있습니다.\n");

            Console.WriteLine("\n[아이템 목록]\n");

            ShowInventoryItem();

            Console.WriteLine("\n\n===================\n\n");

            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.Write("\n원하시는 행동을 입력해주세요: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ManageEquipment();
                    break;

                case "0":
                    Player.PlayerSelect();
                    break;

                default:
                    Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                    ShowInventory();
                    break;
            }
        }

        public static void ShowInventoryItem()
        {
            // 인벤토리에 아이템이 없으면
            if (Item.InventoryItems.Count == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다. \n");
            }

            for (int i = 0; i < Item.InventoryItems.Count; i++)
            {
                string itemInfo = $"- {i + 1}.";

                if (Item.InventoryItems[i].isEquipped)
                {
                    itemInfo += " [E] ";
                }

                itemInfo += $"{Item.InventoryItems[i].name}";

                // 공격력과 방어력 속성을 추가 (0이 아닌 경우만)
                if (Item.InventoryItems[i].attackPower != 0)
                {
                    itemInfo += $"| 공격력 +{Item.InventoryItems[i].attackPower} ";
                }
                if (Item.InventoryItems[i].defense != 0)
                {
                    itemInfo += $"| 방어력 +{Item.InventoryItems[i].defense} ";
                }

                // 아이템의 설명을 마지막에 추가
                itemInfo += $"| {Item.InventoryItems[i].description}";
                Console.WriteLine(itemInfo);
            }
        }
        public static void ManageEquipment()
        {
            Console.WriteLine("\n\n===== 인벤토리 - 장착관리 =====\n");
            Console.WriteLine("\n[아이템 목록]\n");

            ShowInventoryItem();

            Console.WriteLine("\n0. 나가기\n");

            Console.Write("장착하고 싶은 아이템의 번호를 입력해주세요.: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= Item.InventoryItems.Count)
            {
                Item selectedItem = Item.InventoryItems[itemNumber - 1];

                if (selectedItem.isEquipped)
                {
                    // 장착 해제
                    Player.attackPower -= selectedItem.attackPower;
                    Player.defense -= selectedItem.defense;
                    equippedItem.isEquipped = false;
                    Console.WriteLine($"{selectedItem.name}을(를) 해제했습니다.");
                    ManageEquipment();

                }
                else
                {
                    // 기존에 장착한 아이템이 있으면 해제
                    if (equippedItem != null)
                    {
                        Player.attackPower -= equippedItem.attackPower;
                        Player.defense -= equippedItem.defense;
                        selectedItem.isEquipped = false;
                        Console.WriteLine($"{equippedItem.name}을(를) 해제했습니다.");
                    }

                    // 새 아이템 장착
                    Player.attackPower += selectedItem.attackPower;
                    Player.defense += selectedItem.defense;

                    attackIncrease = selectedItem.attackPower;
                    defenseIncrease = selectedItem.defense;

                    selectedItem.isEquipped = true;
                    equippedItem = selectedItem;
                    Console.WriteLine($"{selectedItem.name}을(를) 장착했습니다.");
                    ManageEquipment();
                }

             
            }

            else if (input == "0")
            {
                Console.WriteLine("장착 관리를 종료합니다.");
                ShowInventory();
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. 다시 시도해주세요.");
                ManageEquipment(); 
            }

            ManageEquipment();
        }  
    }
}

