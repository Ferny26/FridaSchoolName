using System;
namespace FridaSchoolWeb.Models
{
    public class Subject
    {
        public int ID{get;set;}
        public string  Name {get; set;}
        public string Key{get; set;}
        public sbyte PracticeHours{get; set;}
        public sbyte TheoryHours{get; set;}  
        public int? TeacherID{get; set;}

        public Subject(){  
        }

        public sbyte GetTotalHours(){
            return (sbyte)(PracticeHours + TheoryHours);
        }

        public void GenerateKey(int counter){
            Random random = new Random();
            Key = "FK" + random.Next(10,99) + (100 + counter);
        }
    }
}