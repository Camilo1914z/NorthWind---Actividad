using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.POCOEntities
{
    public class Order
    {
    public int Id { get; set; }
    public string CustomerId { get; set;}
    public DateTime CustomerDate { get; set;}
    public string shipCity { get; set;}
    public string shipCountry { get; set;}
    public string shipPostalCode { get; set;}
    }
}
