using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Exception_Class : Exception
    {
        public Exception_Class(string message) : base(message) { }

        public class RightForm : Exception_Class
        {
            public RightForm()
            : base("Please enter a 4-digit PIN!") { }


        }

        public class RightPIN : Exception_Class
        {
            public RightPIN()
            : base("Wrong PIN!") { }
        }
        public class RightRange : Exception_Class
        {
            public RightRange()
            : base("Option range must be amoung 1 and 5!") { }
        }
        public class RightAmount : Exception_Class
        {
            public RightAmount()
            : base("Withdrawing must not be over than current balance!") { }
        }
        public class RightAmount2 : Exception_Class
        {
            public RightAmount2()
            : base("Depositing must not be negative number!") { }
        }

    }
}
