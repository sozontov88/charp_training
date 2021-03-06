﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTest
{
    [Table(Name = "addressbook")]
   public class UserData :IComparable<UserData>,IEquatable<UserData>
    {
        private string allphones;
        private string allemails;

        public UserData(string firstname,string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
     public UserData(){}

          public string Allemails
        {
            get
            {
                if (allemails != null)
                    return allemails;

                else
                {
                    return (CleanEmail(Email) + CleanEmail(Email2) + CleanEmail(Email3)).Trim();
                       
                }
            }

            set { allemails = value; }
        }
        public static List<UserData> GetAll()
        {
            using (AddressBookDb db = new AddressBookDb())
            {
                return (from c in db.User.Where(x=>x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
        public string CleanEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }

            return email + "\r\n";
        }

        public string Allphone {
            get {
                if (allphones!=null)
                    return allphones;
                else
                {
                    return CleanUp(Home) + CleanUp( Mobile) + CleanUp(WorkPhone).Trim();
                }
                }
            set { allphones = value; }
        }

        public string CleanUp(string phone)
        {
            if(phone==null||phone =="")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") +"\r\n";
        }

        [Column(Name = "id"),PrimaryKey]
        public string Id { get; set; }
        public string PhoneProperty { get; set; }
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "id")]
        public int Value { get; set; }
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
      
        public string Nickname { get; set; }
      
        public string Title { get; set; }
    
        public string Company { get; set; }
     
        public string Address { get; set; }
      
        public string Home { get; set; }
      
        public string Mobile { get; set; }
      
        public string WorkPhone { get; set; }
   
        public string Fax { get; set; }
     
        public string Email { get; set; }
      
        public string Email2 { get; set; }
      
        public string Email3 { get; set; }
      
        public string Homepage { get; set; }
      
        public string Bday { get; set; }
       
        public string Bmonth { get; set; }
       
        public string Byear { get; set; }
      
        public string Address2 { get; set; }
       
        public string Phone2 { get; set; }
      
        public string Notes { get; set; }
       
      

        public int CompareTo(UserData other)
        {
            if(Object.ReferenceEquals(other,null))
            {
              return 1;
            }
            if(Lastname.CompareTo(other.Lastname)==0 && Firstname.CompareTo(other.Firstname)==0)
            {
                return 0;
            }

            return Firstname.CompareTo(other.Firstname);
        }

        public bool Equals(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
              return false;
            }
             if(Object.ReferenceEquals(this,other))
            {
                return true;
            }
            return Firstname == other.Firstname&&Lastname==other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode()+Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "name = " + Firstname + " " + Lastname;
        }
    }
}
