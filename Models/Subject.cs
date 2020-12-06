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

        public Subject(){  
        }

        public Subject (String[] information, short asignatureCounter){
            Name = information[0];
            TheoryHours = sbyte.Parse(information[1]);
            PracticeHours = sbyte.Parse(information[2]); 
            _getKey(asignatureCounter);
        }

        public sbyte GetTotalHours(){
            return (sbyte)(PracticeHours + TheoryHours);
        }



        private void _getKey(short counter){
            Random random = new Random();
            Key = "FK" + random.Next(10,99) + (100 + counter);
        }
    }
}