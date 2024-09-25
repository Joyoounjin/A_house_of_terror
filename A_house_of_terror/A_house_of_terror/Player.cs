using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_house_of_terror
{
    public class Player
    {
        public static string playerName = "younjin";

        public static int playerLv = 01;
        public static string playerJob;
        public static int attackPower = 10;
        public static int defense = 5;
        public static int hp = 100;
        public static int playergold = 1500;

    
        public static void ShowStatus()  // 상태창 기능, 매개 변수로 inventory 불러옴 
        {

            Console.WriteLine("\n===== 상태창 =====");

            Console.WriteLine($"이름: {playerName}");
            Console.WriteLine($"레벨: {playerLv}");
            Console.WriteLine($"직업: {playerJob}");

            if (Inventory.attackIncrease > 0)
            {
                Console.WriteLine($"공격력: {Player.attackPower} (+{Inventory.attackIncrease})");
            }
            else
            {
                Console.WriteLine($"공격력: {Player.attackPower}");
            }

            if (Inventory.defenseIncrease > 0)
            {
                Console.WriteLine($"방어력: {Player.defense} (+{Inventory.defenseIncrease})");
            }
            else
            {
                Console.WriteLine($"방어력: {Player.defense}");
            }

            Console.WriteLine($"체력: {hp}");
            Console.WriteLine($"Gold: {playergold}G");

            Console.WriteLine("===================\n");

            Console.WriteLine("\n0. 나가기\n"); // 구현 필요 (어떻게?)

            Console.Write("원하시는 행동을 입력해주세요: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Player.PlayerSelect();
                    break;

                default:
                    Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                    PlayerSelect();
                    break;
            }
        }

        public static void PlayerSelect()
        {
            Console.WriteLine("\n저택에 오신 손님을 환영합니다.");
            Console.WriteLine("이곳에서 시련에 도전하기전 활동을 할 수 있습니다.");

            Console.Write("\n1. 상태창");
            Console.Write("\n2. 인벤토리");
            Console.Write("\n3. 상점");

            Console.Write("\n\n원하시는 행동을 입력해주세요: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Player.ShowStatus();
                    break;
                case "2":
                    Inventory.ShowInventory();
                    break;
                case "3":
                    Store.ShowStore();
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                    PlayerSelect();
                    break;
            }
        }

    }
}
