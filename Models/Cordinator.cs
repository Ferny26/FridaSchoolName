using System;
using System.Collections.Generic;


namespace FridaSchoolWeb.Models
{
    public class Cordinator: Teacher
    {
        public Cordinator(){
        }
        public Cordinator (string[] information) : base(information){}


        public override sbyte GetHours()
        {
            return CordinatorHours;
        }
    }
}