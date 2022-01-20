using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTestLibrary.Models
{
    /// <summary>
    /// Represents one person.
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// The unique identifier for the customer.
        /// </summary>
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsClosed { get; set; }
        public DateTime CreatedDate { get; set; }


        public List<RequestModel> Requests { get; set; } = new List<RequestModel>();
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }, {Company} ";
            }
        }

    }
}
