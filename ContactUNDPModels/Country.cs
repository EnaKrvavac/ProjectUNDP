using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUNDPModels
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Name is required")]
        [StringLength(ContactManagerConstants.MAX_COUNTRY_NAME_LENGTH)]
        public string CountryName { get; set; }
    }
}
