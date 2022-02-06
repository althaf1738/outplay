using System.ComponentModel.DataAnnotations;


namespace Firstapi.PersonModels;
    public class Person{

        [Key]
        public int Id{get; set;}

        [Required]
        public string Name{get; set;}


        public int Age{get; set;}
        public string Dob{get;set;}
        public bool IsAdult{get;set;}
        
    }
