using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace A_house_of_terror
{
    public class GoRoom
    {

        public static void StartGame() // 인트로 
        {
            Console.ForegroundColor = ConsoleColor.Red; // 전경색
            Console.BackgroundColor = ConsoleColor.White; // 배경색
            Console.WriteLine("\n<A_house_of_terror>");
            Console.ResetColor(); // 초기값으로 설정

            Console.WriteLine("\n······");
            Console.WriteLine("······");
            Console.WriteLine("······");

            Console.WriteLine("\n당신은 눈을 뜬다.");
            Console.WriteLine("당신은 적당히 부드럽고 푹신한 침대에 누워있다. 결박된 곳은 없었다. 머리가 조금 멍했지만 컨디션도 나쁘지 않았다.");

            bool continueGame = true;

            while (continueGame)
            {
                Console.WriteLine("\n1. 창문의 커튼을 젖힌다.");
                Console.WriteLine("2. 방문을 연다.");

                Console.Write("\n원하시는 행동을 입력해주세요: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("\n당신은 커튼을 젖혔다.");
                        Console.WriteLine("창문 밖은 오직 검정색이다. 無를 연상하지만 벽으로 막혀있다는 생각이 현실적이다. 아무리 애써도 창문은 열리거나 깨지지 않는다.");
                        continueGame = false; // 안 돌아가짐 
                        break;

                    case "2":
                        Console.WriteLine("\n당신은 방문을 열었다.");
                        Console.WriteLine("어두운 복도 끝에서 무언가가 랜턴을 들고 이쪽을 향해 걸어온다.");

                        Console.WriteLine("\n메이드였다.");

                        Console.WriteLine("\n【■■】 일어나셨군요. ");
                        Console.WriteLine("【■■】 손님은 '어디까지' 기억하고 계십니까? ");

                        GoRoom.ChadSelect();
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다. 1 또는 2를 입력해주세요.");
                        StartGame();
                        break;
                }
            }
        }

        public static void ChadSelect() // 직업 선택 
        {
            Console.WriteLine("\n당신은 자신을 떠올렸다.");

            Console.WriteLine("\n1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 보안관");

            Console.Write("\n당신의 직업을 선택해주세요: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Player.playerJob = "전사";
                    Console.WriteLine("\n당신은 제국의 용맹한 전사였다. 마물을 퇴치하기 위해 길을 떠난 시점부터 기억이 흐릿하다.");
                    break;
                case "2":
                    Player.playerJob = "마법사";
                    Console.WriteLine("\n당신은 제국의 떠돌이 마법사였다. 제국의 축제를 보기 위해 황궁의 지붕에 올라간 시점부터 기억이 흐릿하다.");
                    break;
                case "3":
                    Player.playerJob = "보안관";
                    Console.WriteLine("\n당신은 제국의 냉철한 보안관이었다. 사건을 조사하기 위해 빈민가에 도착한 시점부터 기억이 흐릿하다.");
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                    ChadSelect();
                    break;
            }

            Console.WriteLine("\n*상태창 기능이 활성화 되었습니다.");
            GoRoom.ItemStore();

        }

        public static void ItemStore()
        {
            Console.WriteLine($"\n【■■】 제국의 {Player.playerJob} 님. 저희 저택에는 각층마다 시련이 존재합니다.");
            Console.WriteLine("【■■】 모든 시련을 해결할 경우 저택의 출구가 개방되며, 필요한 아이템은 상점에서 구매할 수 있습니다. ");

            Console.WriteLine("\n*인벤토리 기능이 활성화 되었습니다.");
            Console.WriteLine("\n*상점 기능이 활성화 되었습니다.");

            Player.PlayerSelect();
        }
    }

}