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

        private string administratorMenuNumber; //관리자 메뉴에서, 1: 회원관리 2: 도서관리
        private string memberAdministratorMenuNumber; // 관리자의 회원관리 메뉴, 1:등록 2:수정 3:삭제 4:검색 5:출력
        private string memberEditNumber; //회원 수정 메뉴, 1:이름 2:ID 3:비밀번호

        private int memberCheck = 0; // 입력받은 정보와 같은 회원 있는지 확인하는 변수
        private string memberSearch; // 회원검색을 위한 변수

        public int MenuList()
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Main Menu\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 1. Sign in");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 2. Sign up");
                //Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 3. 아이비/비밀번호 찾기\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 0. exit");
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t ");

                getMainMenuNumber = Console.ReadLine(); //getMainMenuNumber에 입력 받아오기
                if (getMainMenuNumber.Equals("0")) // exit
                    break;
                else if (getMainMenuNumber.Equals("1")) // Login메뉴
                    SignIn();
                else if (getMainMenuNumber.Equals("2")) // 회원 가입 메뉴
                    SignUp();
                else
                {
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }

            } while (true);
            return 0;
        }


        public int SignIn() // login 페이지
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign in\n");
            Console.Write("\t\t\t\t\t\t\t\t\t I.D를 입력하세요 - ");
            id = Console.ReadLine();
            if (id.Equals("0")) return 1; // 0일 경우 Main Menu로 돌아가기 위해 return, 값은 무의미하다 
            Console.Write("\t\t\t\t\t\t\t\t\t password를 입력하세요 - ");
            password = Console.ReadLine();
            if (password.Equals("0")) return 1; // 0일 경우 Main Menu로 돌아가기 위해 return, 값은 무의미하다 

            if ((id.Equals("빵빵덕")) && (password.Equals("00")))
            {
                Console.Write("\t\t\t\t\t\t\t\t\t 관리자님 안녕하세요!");
                Thread.Sleep(1000);
                signInCheck = 2; // 관리자sign in이면 2
                Administrate(); // 0일 경우 Main Menu로 돌아가기 위해 return, 값은 무의미하다 

            }

            else
            {
                foreach (MemberInformation i in memberInformationList)
                    if ((i.ID.Equals(id)) && (i.Password.Equals(password)))
                    {
                        Console.Write("\t\t\t\t\t\t\t\t\t {0}님 안녕하세요!", i.Name);
                        Thread.Sleep(1000);
                        signInCheck = 1; // sign in이 되면 1, 안되면 0 유지
                    }
                if (signInCheck == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 사용자 입니다.");
                    Thread.Sleep(1000);
                }
            }
            signInCheck = 0;
            return 0; //Main Menu로 돌아가기 위해 return, 값은 무의미하다 
        }

        public int SignUp() // 회원가입 페이지
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t Name(본인의 이름을 입력하세요 2~30자 이내) - ");
                name = Console.ReadLine();
                if ((name.Length < 2) || (30 < name.Length)) // 글자 길이 제한
                {
                    if (name.Equals("0")) break; // 0일 경우 Main Menu로 돌아가기 위해 break
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
                }
                else break;
            } while (true);
            if (name.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 MainMenu로 돌아가기위해 return, 값은 무의미하다
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t I.D(원하는 아이디를 입력하세요 6~20자 이내) - ");
                id = Console.ReadLine();
                if ((id.Length < 6) || (20 < id.Length)) // id 길이 제한
                {
                    if (id.Equals("0")) break; // 0일 경우 Main Menu로 돌아가기 위해 break
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t Name(본인의 이름을 입력하세요 2~30자 이내) - {0}", name);
                }
                else
                {
                    foreach (MemberInformation i in memberInformationList)
                    {
                        if (i.ID.Equals(id))
                        {
                            Console.Write("\t\t\t\t\t\t\t\t 같은 ID가 존재합니다. 다시 입력하세요");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
                            Console.WriteLine("\t\t\t\t\t\t\t\t Name(본인의 이름을 입력하세요 2~30자 이내) - {0}", name);
                            memberCheck = 1; // 회원 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                            break;
                        }
                    }
                    if (memberCheck == 0)
                        break;
                    memberCheck = 0;
                }
            } while (true);
            if (id.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 MainMenu로 돌아가기위해 return, 값은 무의미하다
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t password(비밀번호를 입력하세요 8~16자 이내) - ");
                password = Console.ReadLine();
                if ((password.Length < 8) || (16 < password.Length)) // password 길이 제한
                {
                    if (password.Equals("0")) break; // 0일 경우 Main Menu로 돌아가기 위해 break
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t Name(본인의 이름을 입력하세요 2~30자 이내) - {0}", name);
                    Console.WriteLine("\t\t\t\t\t\t\t\t I.D(원하는 아이디를 입력하세요 6~20자 이내) - {0}", id);
                }
                else break;
            } while (true);

            if (password.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 MainMenu로 돌아가기위해 return, 값은 무의미하다
            else
            {
                memberInformationList.Add(new MemberInformation(name, id, password));
                memberNumber++;
            }
            return 0;// 메소드가 끝나고 MainMenu로 돌아가기위해 return, 값은 무의미하다
        }

        public void Administrate() // 관리자 메뉴
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 1. 회원관리");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 2. 도서관리");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 0. Logout");
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t ");

                administratorMenuNumber = Console.ReadLine(); //getMainMenuNumber에 입력 받아오기
                if (administratorMenuNumber.Equals("0")) // exit
                    break; // 0일 경우 뒤로 돌아가기 위해 
                else if (administratorMenuNumber.Equals("1")) // 회원관리메뉴
                {
                    memberAdministrate();
                }
                else if (administratorMenuNumber.Equals("2")) // 도서관리 메뉴
                {
                }
                else
                {
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
            while (true);
        }

        public void memberAdministrate() //관리자 메뉴에서 회원 관리
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 1. 회원 등록");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 2. 회원 정보수정");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 3. 회원 삭제");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 4. 회원 검색");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 5. 회원 전체출력");
                //Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 6. 연체자출력");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 0. 뒤로가기");
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t ");

                memberAdministratorMenuNumber = Console.ReadLine(); //getMainMenuNumber에 입력 받아오기
                if (memberAdministratorMenuNumber.Equals("0")) // exit
                    break; // 0일 경우 뒤로 돌아가기 위해
                else if (memberAdministratorMenuNumber.Equals("1")) // 회원등록
                    SignUp();
                else if (memberAdministratorMenuNumber.Equals("2")) // 회원수정
                    EditMember();
                else if (memberAdministratorMenuNumber.Equals("3")) // 회원삭제
                {
                    DeleteMember();
                }
                else if (memberAdministratorMenuNumber.Equals("4")) // 회원검색
                    SearchMember();
                else if (memberAdministratorMenuNumber.Equals("5")) // 회원전체출력
                {
                    Console.Clear();
                    Console.Write("\n\n\n\n\n\n\n");
                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                    Console.WriteLine("\t\t\t\t\t이름\t\t\t\t\t  ID\t\t\t\t        비밀번호");
                    foreach (MemberInformation i in memberInformationList)
                        Console.WriteLine("\t\t\t{0,20}\t\t\t{1,20}\t\t\t{2,20}", i.Name, i.ID, i.Password);
                    Console.Write("\t\t\t");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
            while (true);
        }

        public void EditMember() // 회원 수정
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 1. 이름 수정");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 2. ID 수정");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 3. 비밀번호 수정");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 0. 뒤로가기");
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t ");

                memberEditNumber = Console.ReadLine(); //getMainMenuNumber에 입력 받아오기
                if (memberEditNumber.Equals("0")) // exit
                    break; // 0일 경우 뒤로 돌아가기 위해 
                else if (memberEditNumber.Equals("1")) // 이름수정
                {
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 이름 수정\n");
                    Console.Write("\t\t\t\t\t\t\t\t\t I.D를 입력하세요 - ");
                    id = Console.ReadLine();
                    if (id.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 
                    Console.Write("\t\t\t\t\t\t\t\t\t password를 입력하세요 - ");
                    password = Console.ReadLine();
                    if (password.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해
                    foreach (MemberInformation i in memberInformationList)
                        if ((i.ID.Equals(id)) && (i.Password.Equals(password)))
                        {
                            memberCheck = 1; // 회원 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                            do
                            {
                                Console.Write("\t\t\t\t\t\t\t\t Name(바꾸실 이름을 입력하세요 2~30자 이내) - ");
                                name = Console.ReadLine();
                                if ((name.Length < 2) || (30 < name.Length)) // 글자 길이 제한
                                {
                                    if (name.Equals("0")) break; // 0일 경우 Main Menu로 돌아가기 위해 break
                                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 이름 수정\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t I.D를 입력하세요 - {0}", id);
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t password를 입력하세요 - {0}", password);
                                }
                                else break;
                            } while (true);
                            i.Name = name;
                        }
                    if (memberCheck == 0) // 회원 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 사용자 입니다.");
                        Thread.Sleep(1000);
                    }
                    memberCheck = 0;
                }
                else if (memberEditNumber.Equals("2")) // ID 수정
                {
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t I.D 수정\n");
                    Console.Write("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - ");
                    name = Console.ReadLine();
                    if (name.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 
                    Console.Write("\t\t\t\t\t\t\t\t\t password를 입력하세요 - ");
                    password = Console.ReadLine();
                    if (password.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해
                    foreach (MemberInformation i in memberInformationList)
                        if ((i.Name.Equals(name)) && (i.Password.Equals(password)))
                        {
                            memberCheck = 1; // 회원 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                            do
                            {
                                Console.Write("\t\t\t\t\t\t\t\t ID(바꾸실 ID을 입력하세요 6~20자 이내) - ");
                                id = Console.ReadLine();
                                if ((id.Length < 6) || (20 < id.Length)) // 글자 길이 제한
                                {
                                    if (id.Equals("0")) break; // 0일 경우 Main Menu로 돌아가기 위해 break
                                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t I.D 수정\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - {0}", name);
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t password를 입력하세요 - {0}", password);
                                }
                                else
                                {
                                    foreach (MemberInformation j in memberInformationList)
                                    {
                                        if (j.ID.Equals(id))
                                        {
                                            Console.Write("\t\t\t\t\t\t\t\t 같은 ID가 존재합니다. 다시 입력하세요");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                                            Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t I.D 수정\n");
                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - {0}", name);
                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t password를 입력하세요 - {0}", password);
                                            memberCheck = 2; // 같은 아이디 찾으면이 되면 재입력을 위해 2, 못 찾으면 1 유지
                                            break;
                                        }
                                    }
                                    if (memberCheck == 1)
                                        break;
                                    memberCheck = 0;
                                }
                            } while (true);
                            i.ID = id;
                        }
                    if (memberCheck == 0) // 회원 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 사용자 입니다.");
                        Thread.Sleep(1000);
                    }
                    memberCheck = 0;
                }
                else if (memberEditNumber.Equals("3")) // 비밀번호 수정
                {
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 비밀번호 수정\n");
                    Console.Write("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - ");
                    name = Console.ReadLine();
                    if (name.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 
                    Console.Write("\t\t\t\t\t\t\t\t\t I.D를 입력하세요 - ");
                    id = Console.ReadLine();
                    if (password.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해
                    foreach (MemberInformation i in memberInformationList)
                        if ((i.Name.Equals(name)) && (i.ID.Equals(id)))
                        {
                            memberCheck = 1; // 회원 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                            do
                            {
                                Console.Write("\t\t\t\t\t\t\t\t Password(바꾸실 비밀번호을 입력하세요 8~16자 이내) - ");
                                password = Console.ReadLine();
                                if ((password.Length < 8) || (16 < password.Length)) // 글자 길이 제한
                                {
                                    if (password.Equals("0")) break; // 0일 경우 Main Menu로 돌아가기 위해 break
                                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 비밀번호 수정\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - {0}", name);
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t I.D를 입력하세요 - {0}", id);
                                }
                                else break;
                            } while (true);
                            i.Password = password;
                        }
                    if (memberCheck == 0) // 회원 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 사용자 입니다.");
                        Thread.Sleep(1000);
                    }
                    memberCheck = 0;
                }
                else
                {
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
            while (true);
        }
        public int DeleteMember() // 회원 삭제
        {
                Console.Clear();
                Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 회원 삭제\n");
                Console.Write("\t\t\t\t\t\t\t\t\t I.D를 입력하세요 - ");
                id = Console.ReadLine();
                if (id.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값은 무의미
                Console.Write("\t\t\t\t\t\t\t\t\t password를 입력하세요 - ");
                password = Console.ReadLine();
                if (password.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값은 무의미

            if ((id.Equals("빵빵덕")) && (password.Equals("00")))
                {
                    Console.Write("\t\t\t\t\t\t\t\t\t 관리자의 ID는 삭제되지 않습니다.");
                    Thread.Sleep(1000);
                }
                else
                {
                    for( int k = 0; k < memberNumber; k++)
                        if ((memberInformationList[k].ID.Equals(id)) && (memberInformationList[k].Password.Equals(password)))
                        {
                            memberInformationList.Remove(memberInformationList[k]);
                            memberNumber--;
                            memberCheck = 1; // 존재하는 회원 정보일 떄 1, 아닐 경우 0 유지
                            break;
                        }
                    if (memberCheck == 0)
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 사용자 입니다.");
                        Thread.Sleep(1000);
                    }
                }
            return 0;
        }
        public int SearchMember() // 회원 검색
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
            Console.Write("\n\n\n\n\n\n\n  ");
            memberSearch = Console.ReadLine();
            if (memberSearch.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값은 무의미
            Console.Clear();
            Console.Write("\n\n\n\n\n\n\n");
            Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
            Console.WriteLine("\t\t\t\t\t이름\t\t\t\t\t  ID\t\t\t\t        비밀번호");
            foreach (MemberInformation i in memberInformationList)
            {
                if ((i.ID.Equals(memberSearch)) || (i.Name.Equals(memberSearch)))
                    Console.WriteLine("\t\t\t{0,20}\t\t\t{1,20}\t\t\t{2,20}", i.Name, i.ID, i.Password);
            }
            Console.Write("\t\t\t");
            Console.ReadLine();
            return 0; // 끝나서 나기 위한 return ,값은 무의미
        }
    }
}

//회원 관리 - 회원 등록, 수정, 삭제, 검색, 출력
//도서 관리 - 도서 등록, 찾기(저자, 도서명, 가격), 출력(전체), 삭제, 변경(전체)
//도서 대여 및 반납 - 도서대여 및 반남시간 정보 추가