using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


class Menu
{
    private string menu_choice_check;
    private int menu_choice;

    public void Menu_list()
    {
        do
        {
            Console.WriteLine("  1. 회원 모드");
            Console.WriteLine("  2. 관리자 모드");
            Console.WriteLine("  3. exit");
            Console.Write("\n  ");

            menu_choice_check = Console.ReadLine();
            if (!(menu_choice_check.Equals("1") || menu_choice_check.Equals("2") || menu_choice_check.Equals("3")))
            {
                Console.WriteLine("  잘못입력하셨습니다.");
                Console.WriteLine("  다시 선택하여 주십시오.....");
                Thread.Sleep(500);
                continue;
            }

            menu_choice = int.Parse(menu_choice_check);
            if (menu_choice == 1)
            {
            }
            else if (menu_choice == 2)
            {
            }
            else if (menu_choice == 3)
                break;

        } while (true);
    }
}

//회원 관리 - 회원 등록, 수정, 삭제, 검색, 출력
//도서 관리 - 도서 등록, 찾기(저자, 도서명, 가격), 출력(전체), 삭제, 변경(전체)
//도서 대여 및 반납 - 도서대여 및 반남시간 정보 추가