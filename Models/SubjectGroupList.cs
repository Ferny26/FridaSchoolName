using System.Collections.Generic;
namespace FridaSchoolWeb.Models
{
    public class SubjectsGroupList
    {
        public Group Group {get; set;}
        public List<Subject> SubjectsAvaiable {get;set;}
        public List<Subject> SubjectsPerGroup{get;set;}

        public SubjectsGroupList(){
            SubjectsAvaiable = new List<Subject>();
            SubjectsPerGroup = new List<Subject>();
        }
    }
}