using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }

        [Required(ErrorMessage ="Last Name is required.")]
        public string BowlerLastName { get; set; }

        [Required(ErrorMessage ="First name is required.")]
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }

        [Required(ErrorMessage ="Please enter valid address.")]
        public string BowlerAddress { get; set; }

        [Required(ErrorMessage ="Enter valid city.")]
        public string BowlerCity { get; set; }

        [Required(ErrorMessage ="Enter valid state.")]
        public string BowlerState { get; set; }

        [Required(ErrorMessage ="Valid zip code required.")]
        public string BowlerZip { get; set; }

        [Required(ErrorMessage ="Please enter valid phone number.")]
        public string BowlerPhoneNumber { get; set; }

        [Required]
        public int TeamID { get; set;}


    }
}
