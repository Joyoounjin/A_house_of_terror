using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_house_of_terror
{
    public class Store
    {
        public static bool purchaseCompleted = false;

        public static void ShowStore()
        {

            Console.WriteLine("\n[보유 골드]\n");
            Console.Write($"{Player.playergold}G\n");
            Console.WriteLine("\n[아이템 목록]\n");

            ShowStoreProduct();

            Console.Write("\n1. 아이템 구매");
            Console.Write("\n0. 나가기");

            Console.Write("\n\n원하시는 행동을 입력해주세요: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    BuyProduct();
                    break;

                case "0":
                    Player.PlayerSelect();
                    break;

                default:
                    Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                    ShowStore();
                    break;
            }
        }
        public static void BuyProduct() // 1. 아이템 구매
        {
            bool purchaseCompleted = false;
            Console.WriteLine($"\n[보유 골드]\n");
            Console.WriteLine($"{Player.playergold}G");
            Console.WriteLine("\n[아이템 목록]\n");

            ShowStoreProduct();

            Console.Write("\n0. 나가기\n");

            Console.Write("\n구매하려는 상품의 번호를 입력해주세요: ");

            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.WriteLine("상점에서 나갑니다.");
                ShowStore(); 
            }

            if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= ItemDatabase.Items.Count)
                // TryParse 함수로 input이 정수이면 itemNumber 지연변수로 전환 
            {

                Item selectedItem = ItemDatabase.Items[itemNumber - 1]; 

                if (Player.playergold >= selectedItem.gold)
                {
                    Player.playergold -= selectedItem.gold; // 골드 차감
                    Item.InventoryItems.Add(selectedItem); // 아이템 인벤토리에 추가 
                    purchaseCompleted = true;
                    Console.WriteLine($"\n{selectedItem.name}을(를) 구매했습니다.");
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.\n");
                }

                BuyProduct();
            }

            else
            {
                Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                BuyProduct();
            }

        }
        public static void ShowStoreProduct() // 아이템 리스트 출력 
        {
            for (int i = 0; i < ItemDatabase.Items.Count; i++)
            {
                Item item = ItemDatabase.Items[i];
                string itemInfo = $"- {i + 1}. {item.name} | ";

                // 공격력이 0이 아닐 때만 출력
                if (item.attackPower != 0)
                {
                    itemInfo += $"공격력 + {item.attackPower} ";
                }

                // 방어력이 0이 아닐 때만 출력
                if (item.defense != 0)
                {
                    itemInfo += $"방어력 + {item.defense} ";
                }

                itemInfo += $"| {item.description}";


                if (purchaseCompleted = true)
                {
                    ItemDatabase.showGold = false;
                    itemInfo += " | [구매완료]";

                }
                else 
                {
                    itemInfo += $" | {item.gold}G";
                }


                Console.WriteLine(itemInfo);

                // 아이템 자체한테 출력해야 하는 값 

                //for (int i = 0; i < ItemDatabase.Items.Count; i++)
                //{
                //    Item item = ItemDatabase.Items[i];
                //    Console.WriteLine($"- {i + 1}. {item.name} | 공격력 + {item.attackPower} 방어력 + {item.defense} | {item.description} | {item.gold}G");
                //}
            }
        }
    }
}


