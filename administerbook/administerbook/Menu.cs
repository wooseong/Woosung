using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace administerbook
{
    class Menu
    {
        private string getMainMenuNumber;// Menu에서 실행할 번호 입력 받는 변수

        private string name; // 이름 받는 변수 받을때 잠시 사용
        private string id;// id 받는 변수 받을때 잠시 사용
        private string password;// password 받는 변수 받을때 잠시 사용

        List<MemberInformation> memberInformationList = new List<MemberInformation>();// 회원의 정보를 저장하는 list
        private int memberNumber = 0;//회원명 수

        private int signInCheck = 0; // sign in이 제대로 되었는지 체크하는 변수

        public int MenuList()
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t\t\t Main Menu\n");
                Console.WriteLine("\t\t\t\t\t\t 1. Sign in");
                Console.WriteLine("\t\t\t\t\t\t 2. Sign up");
                //Console.WriteLine("\t\t\t\t\t\t 3. 아이비/비밀번호 찾기\n");
                Console.WriteLine("\t\t\t\t\t\t 0. exit");
                Console.Write("\n\t\t\t\t\t\t ");

                getMainMenuNumber = Console.ReadLine(); //getMainMenuNumber에 입력 받아오기
                if (getMainMenuNumber.Equals("0")) // exit
                { break; }
                else if (getMainMenuNumber.Equals("1")) // Login메뉴
                {
                    SignIn();
                }
                else if (getMainMenuNumber.Equals("2")) // 회원 가입 메뉴
                {
                    SignUp();
                }
                else
                {
                    Console.Write("\t\t\t\t\t\t 잘못된 입력입니다.");
                    Thread.Sleep(500);
                }

                //}
            } while (true);
            return 0;
        }


        public void SignIn()
        {
            Console.Clear();
            Console.Write("\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t Sign in\n");
            Console.Write("\t\t\t\t I.D를 입력하세요 - ");
            id = Console.ReadLine();
            Console.Write("\t\t\t\t password를 입력하세요 - ");
            password = Console.ReadLine();
            if ((id.Equals("빵빵덕")) && (password.Equals("00")))
            {
                Console.Write("\t\t\t\t 관리자님 안녕하세요!");
                Thread.Sleep(500);
                signInCheck = 2; // 관리자sign in이면 2
            }
            else
            {
                foreach (MemberInformation i in memberInformationList)
                    if ((i.ID.Equals(id)) && (i.Password.Equals(password)))
                    {
                        Console.Write("\t\t\t\t {0}님 안녕하세요!", i.Name);
                        Thread.Sleep(500);
                        signInCheck = 1; // sign in이 되면 1, 안되면 0 유지
                    }
            }
            if(signInCheck == 0)
            {
                Console.WriteLine("\t\t\t\t 등록되지 않은 사용자 입니다.");
                Thread.Sleep(500);
            }
        }


        public int SignUp()
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t(0입력시 Main Menu로 돌아갑니다.)\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t Sign up\n");
            do
            {
                Console.Write("\t\t\t\t Name(본인의 이름을 입력하세요 2~30자 이내) - ");
                name = Console.ReadLine();
                if ((name.Length < 2) || (30 < name.Length)) // 글자 길이 제한
                {
                    if (name.Equals("0")) break;
                    Console.Write("\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t(0입력시 Main Menu로 돌아갑니다.)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t Sign up\n");
                }
                else break;
            } while (true);
            if (name.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 MainMenu로 돌아가기위해 return, 값은 무의미하다
            do
            {
                Console.Write("\t\t\t\t I.D(원하는 아이디를 입력하세요 6~20자 이내) - ");
                id = Console.ReadLine();
                if ((id.Length < 6) || (20 < id.Length)) // id 길이 제한
                {
                    if (id.Equals("0")) break;
                    Console.Write("\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t(0입력시 Main Menu로 돌아갑니다.)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t Sign up\n");
                    Console.WriteLine("\t\t\t\t Name(본인의 이름을 입력하세요 2~30자 이내) - {0}", name);
                }
                else break;
            } while (true);
            if (id.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 MainMenu로 돌아가기위해 return, 값은 무의미하다
            do
            {
                Console.Write("\t\t\t\t password(비밀번호를 입력하세요 8~16자 이내) - ");
                password = Console.ReadLine();
                if ((password.Length < 8) || (16 < password.Length)) // password 길이 제한
                {
                    if (password.Equals("0")) break;
                    Console.Write("\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t(0입력시 Main Menu로 돌아갑니다.)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t Sign up\n");
                    Console.WriteLine("\t\t\t\t Name(본인의 이름을 입력하세요 2~30자 이내) - {0}", name);
                    Console.WriteLine("\t\t\t\t I.D(원하는 아이디를 입력하세요 6~20자 이내) - {0}", id);
                }
                else break;
            } while (true);

            if (password.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 MainMenu로 돌아가기위해 return, 값은 무의미하다
            else {
                memberInformationList.Add(new MemberInformation(name, id, password));
                memberNumber++;
                return 0;// 메소드가 끝나고 MainMenu로 돌아가기위해 return, 값은 무의미하다
            }
        }
    }
}

//회원 관리 - 회원 등록, 수정, 삭제, 검색, 출력
//도서 관리 - 도서 등록, 찾기(저자, 도서명, 가격), 출력(전체), 삭제, 변경(전체)
//도서 대여 및 반납 - 도서대여 및 반남시간 정보 추가