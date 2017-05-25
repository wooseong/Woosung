using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BookVO
{
    private string name;
    private string writer;
    private string price;
    private bool someoneBorrow=false;
    private string borrowTime;

    public BookVO(string name, string writer, string price)
    {
        this.name = name;
        this.writer = writer;
        this.price = price;
    }
    public string Name
    {
        get
        { return name; }
        set { name = value; }
    }
    public string Writer
    {
        get
        { return writer; }
        set { writer = value; }
    }
    public string Price
    {
        get
        { return price; }
        set { price = value; }
    }
    public bool SomeoneBorrrow
    {
        get { return someoneBorrow; }
        set { someoneBorrow = value; }
    }
    public string BorrowTime
    {
        get { return borrowTime; }
        set { borrowTime = value; }
    }
}

//도서 관리 - 도서 등록, 찾기(저자, 도서명, 가격), 출력(전체), 삭제, 변경(전체)
//도서 대여 및 반납 - 도서대여 및 반남시간 정보 추가