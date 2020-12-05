using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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