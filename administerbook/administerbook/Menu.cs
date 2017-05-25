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
        private string writer;// id 받는 변수 받을때 잠시 사용
        private string price;// password 받는 변수 받을때 잠시 사용
        private int priceResult;//price문자열 숫자로 변환하는 변수

        List<MemberInformation> memberInformationList = new List<MemberInformation>();// 회원의 정보를 저장하는 list
        List<BookVO> bookInformationList = new List<BookVO>();// 책의 정보를 저장하는 list
        private int memberNumber = 0;//회원명 수
        private int bookNumber = 0;//책 수량

        private int signInCheck = 0; // sign in이 제대로 되었는지 체크하는 변수
        private string administratorMenuNumber; //관리자 메뉴에서, 1: 회원관리 2: 도서관리

        private string memberAdministratorMenuNumber; // 관리자의 회원관리 메뉴, 1:등록 2:수정 3:삭제 4:검색 5:출력
        private string memberEditNumber; //회원 수정 메뉴, 1:이름 2:ID 3:비밀번호
        private string bookAdministratorMenuNumber; // 관리자의 도서관리 메뉴, 1:등록 2:수정 3:삭제 4:검색 5:출력
        private string bookEditNumber; //도서 수정 메뉴, 1:이름 2:저자 3:가격

        private int memberCheck = 0; // 입력받은 정보와 같은 회원 있는지 확인하는 변수
        private string memberSearch; // 회원검색을 위한 변수
        private int bookCheck = 0; // 입력받은 정보와 같은 책 있는지 확인하는 변수
        private string bookSearch; // 책검색을 위한 변수

        private string memberMenuNumber; // 회원의 메뉴, 1:검색 2:대출 3:반납 4:목록


        public int MenuList()
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Main_Menu\n");
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
            if (id.Equals("0")) return 1; // 0일 경우 뒤로 돌아가기 위해 return, 값은 무의미하다 
            Console.Write("\t\t\t\t\t\t\t\t\t password를 입력하세요 - ");
            password = Console.ReadLine();
            if (password.Equals("0")) return 1; // 0일 경우 뒤로 돌아가기 위해 return, 값은 무의미하다 

            if ((id.Equals("빵빵덕")) && (password.Equals("00")))
            {
                Console.Write("\t\t\t\t\t\t\t\t\t 관리자님 안녕하세요!");
                Thread.Sleep(1000);
                signInCheck = 2; // 관리자sign in이면 2
                Administrate(); // 0일 경우 뒤로 돌아가기 위해 return, 값은 무의미하다 

            }
            else
            {
                foreach (MemberInformation i in memberInformationList)
                    if ((i.ID.Equals(id)) && (i.Password.Equals(password)))
                    {
                        Console.Write("\t\t\t\t\t\t\t\t\t {0}님 안녕하세요!", i.Name);
                        Thread.Sleep(1000);
                        signInCheck = 1; // sign in이 되면 1, 안되면 0 유지
                        Member(i);
                    }
                if (signInCheck == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 사용자 입니다.");
                    Thread.Sleep(1000);
                }
            }
            signInCheck = 0;
            return 0; //뒤로 돌아가기 위해 return, 값은 무의미하다 
        }
        public int SignUp() // 회원가입 페이지
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t Name(본인의 이름을 입력하세요 2~20자 이내) - ");
                name = Console.ReadLine();
                if ((name.Length < 2) || (30 < name.Length)) // 글자 길이 제한
                {
                    if (name.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
                }
                else break;
            } while (true);
            if (name.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 뒤로 돌아가기위해 return, 값은 무의미하다
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t I.D(원하는 아이디를 입력하세요 6~20자 이내) - ");
                id = Console.ReadLine();
                if ((id.Length < 6) || (20 < id.Length)) // id 길이 제한
                {
                    if (id.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t Name(본인의 이름을 입력하세요 2~20자 이내) - {0}", name);
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
                            Console.WriteLine("\t\t\t\t\t\t\t\t Name(본인의 이름을 입력하세요 2~20자 이내) - {0}", name);
                            memberCheck = 1; // 회원 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                            break;
                        }
                    }
                    if (memberCheck == 0)
                        break;
                    memberCheck = 0;
                }
            } while (true);
            if (id.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 뒤로 돌아가기위해 return, 값은 무의미하다
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t password(비밀번호를 입력하세요 8~16자 이내) - ");
                password = Console.ReadLine();
                if ((password.Length < 8) || (16 < password.Length)) // password 길이 제한
                {
                    if (password.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t Sign up\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t Name(본인의 이름을 입력하세요 2~20자 이내) - {0}", name);
                    Console.WriteLine("\t\t\t\t\t\t\t\t I.D(원하는 아이디를 입력하세요 6~20자 이내) - {0}", id);
                }
                else break;
            } while (true);

            if (password.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 뒤로 돌아가기위해 return, 값은 무의미하다
            else
            {
                memberInformationList.Add(new MemberInformation(name, id, password));
                memberNumber++;
            }
            return 0;// 메소드가 끝나고 뒤로 돌아가기위해 return, 값은 무의미하다
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

                administratorMenuNumber = Console.ReadLine();
                if (administratorMenuNumber.Equals("0")) // exit
                    break; // 0일 경우 뒤로 돌아가기 위해 
                else if (administratorMenuNumber.Equals("1")) // 회원관리메뉴
                {
                    MemberAdministrate();
                }
                else if (administratorMenuNumber.Equals("2")) // 도서관리 메뉴
                {
                    BookAdministrate();
                }
                else
                {
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
            while (true);
        }

        public void MemberAdministrate() //관리자 메뉴에서 회원 관리
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

                memberAdministratorMenuNumber = Console.ReadLine();
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

                memberEditNumber = Console.ReadLine();
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
                                Console.Write("\t\t\t\t\t\t\t\t Name(바꾸실 이름을 입력하세요 2~20자 이내) - ");
                                name = Console.ReadLine();
                                if ((name.Length < 2) || (30 < name.Length)) // 글자 길이 제한
                                {
                                    if (name.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
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
                                    if (id.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
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
                                    if (password.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
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
                for (int k = 0; k < memberNumber; k++)
                    if ((memberInformationList[k].ID.Equals(id)) && (memberInformationList[k].Password.Equals(password)))
                    {
                        memberCheck = 1; // 존재하는 회원 정보일 떄 1, 아닐 경우 0 유지
                        if (memberInformationList[k].BorrowCount != 0)
                        {
                            Console.WriteLine("대출 중인 책이 있어서 회원 삭제가 되지 않습니다.");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            memberInformationList.Remove(memberInformationList[k]);
                            memberNumber--;
                            break;
                        }
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
            Console.Write("\n\n\n\n\n\n\n\t\t\t\t\t\t");
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

        public void BookAdministrate() // 관리자 메뉴에서 도서 관리
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 1. 도서 등록");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 2. 도서 정보수정");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 3. 도서 삭제");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 4. 도서 검색");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 5. 도서 전체출력");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 0. 뒤로가기");
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t ");

                bookAdministratorMenuNumber = Console.ReadLine();
                if (bookAdministratorMenuNumber.Equals("0")) // exit
                    break; // 0일 경우 뒤로 돌아가기 위해
                else if (bookAdministratorMenuNumber.Equals("1")) // 도서등록
                    BookSignUp();
                else if (bookAdministratorMenuNumber.Equals("2")) // 도서수정
                    EditBook();
                else if (bookAdministratorMenuNumber.Equals("3")) // 도서삭제
                {
                    DeleteBook();
                }
                else if (bookAdministratorMenuNumber.Equals("4")) // 도서검색
                    SearchBook();
                else if (bookAdministratorMenuNumber.Equals("5")) // 도서전체출력
                {
                    Console.Clear();
                    Console.Write("\n\n\n\n\n\n\n");
                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                    Console.WriteLine("\t\t\t\t\t이름\t\t\t\t\t저자\t\t\t\t\t    가격\t\t대출 여부(False = 대출 가능, True = 대출 불가)");
                    foreach (BookVO i in bookInformationList)
                        Console.WriteLine("\t\t\t{0,20}\t\t\t{1,20}\t\t\t{2,20}\t\t{3}", i.Name, i.Writer, i.Price, i.SomeoneBorrrow);
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
        public int BookSignUp() // 도서 등록
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 도서 등록\n");
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t Name(책 이름을 입력하세요 1~20자 이내) - ");
                name = Console.ReadLine();
                if ((name.Length < 1) || (20 < name.Length)) // 글자 길이 제한
                {
                    if (name.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 도서 등록\n");
                }
                else break;
            } while (true);
            if (name.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 뒤로 돌아가기위해 return, 값은 무의미하다
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t Writer(저자를 입력하세요 1~20자 이내) - ");
                writer = Console.ReadLine();
                if ((writer.Length < 1) || (20 < writer.Length)) // writer 길이 제한
                {
                    if (writer.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 도서 등록\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t Name(책 이름을 입력하세요 1~20자 이내) - {0}", name);
                }
                else break;
            } while (true);
            if (writer.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 뒤로 돌아가기위해 return, 값은 무의미하다
            do
            {
                Console.Write("\t\t\t\t\t\t\t\t price(가격을 입력하세요) - ");
                price = Console.ReadLine();
                if (price.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                else if (!(Int32.TryParse(price, out int priceResult))) // price 길이 제한
                {
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 도서 등록\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t Name(책 이름을 입력하세요 1~20자 이내) - {0}", name);
                    Console.WriteLine("\t\t\t\t\t\t\t\t Writer(저자를 입력하세요 1~20자 이내) - {0}", writer);
                }
                else break;
            } while (true);

            if (price.Equals("0")) return 0; // 조건이 참일 경우 중도에 멈추고 뒤로 돌아가기위해 return, 값은 무의미하다
            else
            {
                bookInformationList.Add(new BookVO(name, writer, price));
                bookNumber++;
            }
            return 0;// 메소드가 끝나고 뒤로 돌아가기위해 return, 값은 무의미하다
        }
        public void EditBook() // 도서 수정
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 1. 이름 수정");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 2. writer 수정");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 3. 가격 수정");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 0. 뒤로가기");
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t ");

                bookEditNumber = Console.ReadLine(); //getMainMenuNumber에 입력 받아오기
                if (bookEditNumber.Equals("0")) // exit
                    break; // 0일 경우 뒤로 돌아가기 위해 
                else if (bookEditNumber.Equals("1")) // 이름수정
                {
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 이름 수정\n");
                    Console.Write("\t\t\t\t\t\t\t\t\t writer를 입력하세요 - ");
                    writer = Console.ReadLine();
                    if (writer.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 
                    Console.Write("\t\t\t\t\t\t\t\t\t price를 입력하세요 - ");
                    price = Console.ReadLine();
                    if (price.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해
                    foreach (BookVO i in bookInformationList)
                        if ((i.Writer.Equals(writer)) && (i.Price.Equals(price)))
                        {
                            bookCheck = 1; // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                            do
                            {
                                Console.Write("\t\t\t\t\t\t\t\t Name(바꾸실 이름을 입력하세요 1~20자 이내) - ");
                                name = Console.ReadLine();
                                if ((name.Length < 1) || (20 < name.Length)) // 글자 길이 제한
                                {
                                    if (name.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 이름 수정\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t writer를 입력하세요 - {0}", writer);
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t price를 입력하세요 - {0}", price);
                                }
                                else break;
                            } while (true);
                            i.Name = name;
                        }
                    if (bookCheck == 0) // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 도서 입니다.");
                        Thread.Sleep(1000);
                    }
                    bookCheck = 0;
                }
                else if (bookEditNumber.Equals("2")) // writer 수정
                {
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t writer 수정\n");
                    Console.Write("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - ");
                    name = Console.ReadLine();
                    if (name.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 
                    Console.Write("\t\t\t\t\t\t\t\t\t price를 입력하세요 - ");
                    price = Console.ReadLine();
                    if (price.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해
                    foreach (BookVO i in bookInformationList)
                        if ((i.Name.Equals(name)) && (i.Price.Equals(price)))
                        {
                            bookCheck = 1; // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                            do
                            {
                                Console.Write("\t\t\t\t\t\t\t\t writer(바꾸실 writer을 입력하세요 1~20자 이내) - ");
                                writer = Console.ReadLine();
                                if (writer.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                                else if ((writer.Length < 1) || (20 < writer.Length)) // 글자 길이 제한
                                {
                                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t writer 수정\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - {0}", name);
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t price를 입력하세요 - {0}", price);
                                }
                                else break;
                            } while (true);
                            i.Writer = writer;
                        }
                    if (bookCheck == 0) // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 도서 입니다.");
                        Thread.Sleep(1000);
                    }
                    bookCheck = 0;
                }
                else if (bookEditNumber.Equals("3")) // 가격 수정
                {
                    Console.Clear();
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 가격 수정\n");
                    Console.Write("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - ");
                    name = Console.ReadLine();
                    if (name.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 
                    Console.Write("\t\t\t\t\t\t\t\t\t writer를 입력하세요 - ");
                    writer = Console.ReadLine();
                    if (price.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해
                    foreach (BookVO i in bookInformationList)
                        if ((i.Name.Equals(name)) && (i.Writer.Equals(writer)))
                        {
                            bookCheck = 1; // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                            do
                            {
                                Console.Write("\t\t\t\t\t\t\t\t price(바꾸실 가격을 입력하세요) - ");
                                price = Console.ReadLine();
                                if (price.Equals("0")) break; // 0일 경우 뒤로 돌아가기 위해 break
                                else if (!(Int32.TryParse(price, out int priceResult))) // price 길이 제한
                                {
                                    Console.Write("\t\t\t\t\t\t\t\t\t\t 제대로 입력하세요");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
                                    Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 가격 수정\n");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t 이름를 입력하세요 - {0}", name);
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t writer를 입력하세요 - {0}", writer);
                                }
                                else break;
                            } while (true);
                            i.Price = price;
                        }
                    if (bookCheck == 0) // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 도서 입니다.");
                        Thread.Sleep(1000);
                    }
                    bookCheck = 0;
                }
                else
                {
                    Console.Write("\t\t\t\t\t\t\t\t\t\t 잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
            while (true);
        }
        public int DeleteBook() // 도서 삭제
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.WriteLine("★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★관리자 페이지★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 도서 삭제\n");
            Console.Write("\t\t\t\t\t\t\t\t\t 도서명를 입력하세요 - ");
            name = Console.ReadLine();
            if (name.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값은 무의미
            Console.Write("\t\t\t\t\t\t\t\t\t writer를 입력하세요 - ");
            writer = Console.ReadLine();
            if (name.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값은 무의미
            for (int k = 0; k < bookNumber; k++)
                if ((bookInformationList[k].Name.Equals(name)) && (bookInformationList[k].Writer.Equals(writer)))
                {
                    bookInformationList.Remove(bookInformationList[k]);
                    bookNumber--;
                    bookCheck = 1; // 존재하는 도서 정보일 떄 1, 아닐 경우 0 유지
                    break;
                }
            if (bookCheck == 0)
            {
                Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 도서 입니다.");
                Thread.Sleep(1000);
            }
            return 0;
        }
        public int SearchBook() // 도서 검색
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.Write("\n\n\n\n\n\n\n\t\t\t\t\t\t");
            bookSearch = Console.ReadLine();
            if (bookSearch.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값은 무의미
            Console.Clear();
            Console.Write("\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t이름\t\t\t\t\t저자\t\t\t\t\t    가격\t\t대출 여부(False = 대출 가능, True = 대출 불가)");
            foreach (BookVO i in bookInformationList)
            {
                if ((i.Name.Equals(bookSearch)) || (i.Writer.Equals(bookSearch)))
                    Console.WriteLine("\t\t\t{0,20}\t\t\t{1,20}\t\t\t{2,20}\t\t{3}", i.Name, i.Writer, i.Price, i.SomeoneBorrrow);
            }
            Console.Write("\t\t\t");
            Console.ReadLine();
            return 0; // 끝나서 나기 위한 return ,값은 무의미
        }

        public void Member(MemberInformation person) // 회원 메뉴
        {
            do
            {
                Console.Clear();
                Console.Write("\n\n\n\n\n\n\n");
                Console.WriteLine("-------------------------------------------------------------------------------------{0}님 페이지-------------------------------------------------------------------------------------\n", person.Name);
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 1. 도서 검색");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 2. 도서 대출");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 3. 도서 반납");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 4. 도서 목록");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 0. Logout");
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t ");

                memberMenuNumber = Console.ReadLine();
                if (memberMenuNumber.Equals("0")) // 뒤로가기
                    break; // 0일 경우 뒤로 돌아가기 위해 
                else if (memberMenuNumber.Equals("1")) // 도서 검색
                {
                    SearchBook();
                    do
                    {
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t 2. 도서 대출");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t 0. 뒤로가기");
                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t ");
                        memberMenuNumber = Console.ReadLine();
                        if (memberMenuNumber.Equals("0")) // 뒤로가기
                            break; // 0일 경우 뒤로 돌아가기 위해 
                        else if (memberMenuNumber.Equals("2")) // 도서 대출
                        {
                            BookBorrow(person);
                            break;
                        }
                        else
                        {
                            Console.Write("\t\t\t\t\t\t\t\t\t\t 잘못된 입력입니다.");
                            Thread.Sleep(1000);
                        }
                    } while (true);
                }
                else if (memberMenuNumber.Equals("2")) // 도서 대출
                    BookBorrow(person);
                else if (memberMenuNumber.Equals("3")) // 도서 반납
                    BookReturn(person);
                else if (memberMenuNumber.Equals("4")) // 도서 목록
                {
                    Console.Clear();
                    Console.Write("\n\n\n\n\n\n\n");
                    Console.WriteLine("-------------------------------------------------------------------------------------{0}님 페이지-------------------------------------------------------------------------------------\n", person.Name);
                    Console.WriteLine("\t\t\t\t\t이름\t\t\t\t\t저자\t\t\t\t\t    가격\t\t대여한 날짜 시간");
                    foreach (BookVO i in person.Borrow)
                        Console.WriteLine("\t\t\t{0,20}\t\t\t{1,20}\t\t\t{2,20}\t\t{3}", i.Name, i.Writer, i.Price, i.BorrowTime);
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
        public int BookBorrow(MemberInformation person) // 도서 대출
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.Write("\n\n\n\n\n\n\n");
            Console.Write("\t\t\t\t\t\t\t\t\t 도서명를 입력하세요 - ");
            name = Console.ReadLine();
            if (name.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값 무의미
            Console.Write("\t\t\t\t\t\t\t\t\t writer를 입력하세요 - ");
            writer = Console.ReadLine();
            if (price.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값 무의미
            foreach (BookVO i in bookInformationList)
                if ((i.Name.Equals(name)) && (i.Writer.Equals(writer)))
                {
                    bookCheck = 1; // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
                    if (i.SomeoneBorrrow) Console.WriteLine("\t\t\t\t\t\t\t\t\t 이미 누군가 대출 중인 도서입니다.");
                    else
                    {
                        person.Borrow.Add(new BookVO(i.Name, i.Writer, i.Price));
                        (person.BorrowCount)++;
                        i.SomeoneBorrrow = true;
                        i.BorrowTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t 책 {0} 이 대출 되셨습니다.", i.Name);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t {0}", i.BorrowTime);
                        Console.Write("\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t");
                        Console.ReadLine();
                    }
                }
            if (bookCheck == 0) // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
            {
                Console.WriteLine("\t\t\t\t\t\t\t\t\t 등록되지 않은 도서 입니다.");
                Thread.Sleep(1000);
            }
            bookCheck = 0;
            return 0;
        }
        public int BookReturn(MemberInformation person) // 도서 반납
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(0입력 시 뒤로가기)\n\n\n\n\n");
            Console.Write("\n\n\n\n\n\n\n");
            Console.Write("\t\t\t\t\t\t\t\t\t 도서명를 입력하세요 - ");
            name = Console.ReadLine();
            if (name.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값 무의미
            Console.Write("\t\t\t\t\t\t\t\t\t writer를 입력하세요 - ");
            writer = Console.ReadLine();
            if (price.Equals("0")) return 0; // 0일 경우 뒤로 돌아가기 위해 , 값 무의미
            for (int k = 0; k < person.BorrowCount; k++)
            {
                if ((person.Borrow[k].Name.Equals(name)) && (person.Borrow[k].Writer.Equals(writer)))
                {
                    bookCheck = 1; // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지

                    Console.WriteLine("\t\t\t\t\t\t\t\t\t 책 {0} 이 반납 되셨습니다.", person.Borrow[k].Name);
                    person.Borrow.RemoveAt(k);
                    person.Borrow[k].SomeoneBorrrow = false;
                    person.Borrow[k].BorrowTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    (person.BorrowCount)--;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t {0}", person.Borrow[k].BorrowTime);
                    Console.Write("\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t");
                    Console.ReadLine();
                    break;

                }
            }
            if (bookCheck == 0) // 도서 정보를 찾으면이 되면 1, 못 찾으면 0 유지
            {
                Console.WriteLine("\t\t\t\t\t\t\t\t\t 대출 목록에 없는 도서 입니다.");
                Thread.Sleep(1000);
            }
            bookCheck = 0;
            return 0;
        }
    }
}

//회원 관리 - 회원 등록, 수정, 삭제, 검색, 출력
//도서 관리 - 도서 등록, 찾기(저자, 도서명, 가격), 출력(전체), 삭제, 변경(전체)
//도서 대여 및 반납 - 도서대여 및 반남시간 정보 추가