using System.ComponentModel.DataAnnotations;

namespace CrudeProject.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "City Name")]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }
        public ShippingID ShippingID { get; set; }
        public OrderStatusID OrderStatusID { get; set; }
    }

    public enum ShippingID
    {
        _1 ,
        _2 ,
        _3 ,
        _4,
        _5
    }
    public enum OrderStatusID
    {
        _6,
        _7,
        _8,
        _9,
        _10
    }
}

/*
 [OrderId] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](100) NULL,
	[SchoolName] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[ContacPhone] [nvarchar](20) NULL,
	[ShippingId] [int] NULL,
	[OrderStatusID] [int] NULL,
*/