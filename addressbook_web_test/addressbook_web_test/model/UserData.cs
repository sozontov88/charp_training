﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTest
{
   public class UserData :IComparable<UserData>,IEquatable<UserData>
    {
     
        public UserData(string firstname,string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
    
        public string Middlename { get; set; }
     
        public string Lastname { get; set; }
      
        public string Nickname { get; set; }
      
        public string Title { get; set; }
    
        public string Company { get; set; }
     
        public string Address { get; set; }
      
        public string Home { get; set; }
      
        public string Mobile { get; set; }
      
        public string Work { get; set; }
   
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
     
        public string Id { get; set; }
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