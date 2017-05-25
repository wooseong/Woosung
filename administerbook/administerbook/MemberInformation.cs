using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administerbook
{
    class MemberInformation
    {
        private string name;
        private string id;
        private string password;
        private List<BookVO> borrow = new List<BookVO>();
        private int borrowCount=0;

       public MemberInformation(string name, string id, string password)
        {
            this.name = name;
            this.id = id;
            this.password = password;
            /*Name = name;
            ID = id;
            Password = password;*/
        }
        public string Name
        {
            get
            { return name; }
            set { name = value; }
        }
        public string ID
        {
            get
            { return id; }
            set { id = value; }
        }
        public string Password
        {
            get
            { return password; }
            set { password = value; }
        }
        public List<BookVO> Borrow
        {
            get
            { return borrow; }
            set { borrow = value; }

        }
        public int BorrowCount
        {
            get { return borrowCount; }
            set { borrowCount = value; }
        }
    }
}
