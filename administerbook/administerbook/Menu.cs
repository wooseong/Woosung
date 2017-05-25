using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace administerbook
{
    class Menu
    {
        private string getMainMenuNumberCheck;
        private int getMainMenuNumber;

        public int MenuList()
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t\t\t Main Menu\n");
                Console.WriteLine("\t\t\t\t\t\t 1. Sign in");
                Console.WriteLine("\t\t\t\t\t\t 2. Sign out");
                //Console.WriteLine("\t\t\t\t\t\t 3. 아이비/비밀번호 찾기\n");
                Console.WriteLine("\t\t\t\t\t\t Esc. exit");
                Console.Write("\n\t\t\t\t\t\t");


                getMainMenuNumberCheck = Console.ReadLine(); //getMainMenuNumber에 입력 받아오기
               // if (getMainMenuNumberCheck. == ConsoleKey.Escape) // Esc키인지 확인 -> 프로그램 종료
                //{
                    //Console.Write("Esc");
                    //Console.Read();
                //    return 0;
              //  }
              //  else
              //  {
                    if (!(getMainMenuNumberCheck.Equals("1") || getMainMenuNumberCheck.Equals("2")))
                    {
                        Console.Write("\t\t\t\t\t\t 잘못된 입력입니다.");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        getMainMenuNumber = int.Parse(getMainMenuNumberCheck);
                        if (getMainMenuNumberCheck.Equals("1") ) // Login메뉴
                        {
                        }
                        else if ( getMainMenuNumberCheck.Equals("2") ) // 회원 가입 메뉴
                        {
                            Console.Write("2");
                            Thread.Sleep(1000);
                        }
                 //   }   
                }
            } while (true);
        }
    }
}

//회원 관리 - 회원 등록, 수정, 삭제, 검색, 출력
//도서 관리 - 도서 등록, 찾기(저자, 도서명, 가격), 출력(전체), 삭제, 변경(전체)
//도서 대여 및 반납 - 도서대여 및 반남시간 정보 추가