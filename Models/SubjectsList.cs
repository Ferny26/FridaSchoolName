using System.Collections.Generic;
namespace FridaSchoolWeb.Models
{
    public class SubjectsList
    {
        public List<Subject> SubjectsAvaiable {get;set;}
        public List<Subject> SubjectsPerTeacher{get;set;}

        public SubjectsList(){
            
        }
    }
}