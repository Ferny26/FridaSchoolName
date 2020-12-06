using System.Collections.Generic;
namespace FridaSchoolWeb.Models
{
    public class SubjectsList
    {
        public List<Subject> SubjectsAvaiable {get;set;}
        public List<Subject> SubjectsPerTeacher{get;set;}

        public SubjectsList(){
            SubjectsAvaiable = new List<Subject>();
            SubjectsPerTeacher = new List<Subject>();
        }
    }
}