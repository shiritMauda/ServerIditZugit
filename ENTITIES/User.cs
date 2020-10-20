using DocumentFormat.OpenXml.Office2010.Excel;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES
{
    public class User
    {
        public int id;
        public string firstName;
        public string lastName;
        public string password;
        public string email;


        //constructor
        public User() { }
        public User(int _id, string _password, string _firstName, string _lastName, string _email)
        {
            id = _id;
            firstName = _firstName;
            lastName = _lastName;
            password = _password;
            email = _email;

        }
    }
}
