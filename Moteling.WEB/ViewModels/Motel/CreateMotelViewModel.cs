using System.ComponentModel.DataAnnotations;

namespace Moteling.WEB.ViewModels.Motel
{
    public class CreateMotelViewModel
    {
        [Required]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 7)]
        public string PhoneNumber { get; set; }

        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Page { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Description { get; set; }

        [Required]
        [StringLength(800, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Address { get; set; }

        //public virtual MotelAddressViewModel Address { get; set; }
    }
}
