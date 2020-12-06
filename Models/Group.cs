using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace FridaSchoolWeb.Models
{
    public class Group 
    {
        public int ID{get; set;}
        public string Name{get; set;}
        public bool Period{get; set;}
        public DateTime StartDate{get; set;}
        public DateTime EndDate{get; set;}
        public Group (){
        }

        public void StablishDates (){
            StartDate = _validationPeriod(DateTime.Now);
            EndDate = Period == true ? _validationPeriod(DateTime.Now.AddMonths(4)) :  _validationPeriod(DateTime.Now.AddMonths(6)); 
        }

        private DateTime _validationPeriod(DateTime date){
            DateTime ResultDate = date.DayOfWeek == DayOfWeek.Saturday ? date.AddDays(-1) : 
            date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date; 
            return ResultDate;
        }

    }
}