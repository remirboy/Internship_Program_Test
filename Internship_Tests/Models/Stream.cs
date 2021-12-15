using System;
namespace Internship_Tests.Models
{
    public class Stream
    {
        private string name;
        private string description;
        private int interns;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }


        public int Interns
        {
            get
            {
                return interns;
            }
            set
            {
                interns = value;
            }
        }

        public Stream() {   }

        public Stream(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Stream(string name, string description, int interns)
        {
            Name = name;
            Description = description;
            Interns = interns;
        }

        public Stream(string name)
        {
            Name = name;
        }


        public Stream(int interns)
        {
            Interns = interns;
        }

        public override string ToString()
        {
            return base.ToString() + ": " + name.ToString()+description.ToString();
        }

    }
}
