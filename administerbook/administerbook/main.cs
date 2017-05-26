using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administerbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Console.SetWindowSize(180,40);
            menu.MenuList();
            
        }
    }
}

//회원 관리 - 회원 등록, 수정, 삭제, 검색, 출력
//도서 관리 - 도서 등록, 찾기(저자, 도서명, 가격), 출력(전체), 삭제, 변경(전체)
//도서 대여 및 반납 - 도서대여 및 반남시간 정보 추가
