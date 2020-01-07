using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BE
{
    //status family
    public enum status
    {
        Single, Marrid, Divprcee, Widower
    }
    //class of user

    public class User
    {
        public String Name { get; set; }
        private double height;
        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0) //When the height is less than 0

                    throw new Exception("the hieght is negative");
                else
                    height = value;
            }
        }
        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)//When the weight is less than 0
                    throw new Exception("the weight is negative");
                else
                    weight = value;
            }
        }
        public DateTime Date
        { get; set; }
        public status familyStatus { get; set; }
        private String phone;
        public String Phone
        {
            get { return phone; }
            set
            {
                if (value.Length != 10)//when the length is not equal to 10
                    throw new Exception("invalid phone number");
                else phone = value;
            }
        }
        [Key]
        private String id;
        public String Id
        {
            get { return id; }
            set
            {
                if (value.ToString().Length != 9)//when the length is not equal to 9
                    throw new Exception("invalid id");
                else
                    id = value;
            }
        }
        public String Password { get; set; }
        public String email;
        public String Email
        {
            get { return email; }
            set
            {
                //when the mail address invalid
                if (!Regex.IsMatch(value, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                    throw new Exception("invalid email address");
                else
                    email = value;
            }
        }
    }
}
