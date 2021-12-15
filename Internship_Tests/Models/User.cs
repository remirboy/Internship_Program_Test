using System;
namespace Internship_Tests.Models
{
    public class User
    {

        private string password;
        private string firstName;
        private string lastName;
        private string email;
        private bool isSuperUser;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }


        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public bool IsSuperUser
        {
            get
            {
                return isSuperUser;
            }
            set
            {
                isSuperUser = value;
            }
        }


        public User(string firstName, string lastName, string email, string password, bool isSuperUser)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            IsSuperUser = isSuperUser;
        }

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User() { }
    }
}
