using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public abstract class User
    {
        public User ()
        {

        }
        //Jednoznacne identifikacne cislo(UCO,...)
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //telefon, e-mail,...
        public string Contact { get; set; }
    }
}
