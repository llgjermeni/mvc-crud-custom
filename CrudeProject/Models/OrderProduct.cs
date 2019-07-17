using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudeProject.Models
{
    public class OrderProduct
    {
        public int OrderProductID { get; set; }
        public int OrderID { get; set; }
        public FabricTypeID FabricTypeID { get; set; }
        public CoverTypeID CoverTypeID { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }

    public enum CoverTypeID
    {
        _1,
        _2,
        _3,
        _4,
        _5
    }

    public enum FabricTypeID
    {
        _6,
        _7,
        _8,
        _9,
        _10
    }
}

/*
 * [OrderId] [int] NOT NULL,
	[CoverTypeId] [int] NULL,
	[FabricTypeId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
*/