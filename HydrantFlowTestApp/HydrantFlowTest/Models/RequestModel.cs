using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTestLibrary.Models
{
    public class RequestModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CloseDate { get; set; }   // Made this nullable
        public string CustomerNotes { get; set; }
        public string WwNotes { get; set; }
        public bool IsClosed { get; set; }
        //public int IsClosedInt { get; set; }
        public int FlowTestId { get; set; }

        // todo No longer used
        public string RequestRecord
        {
            
            get
            {
                return $"{ Id },  { RequestDate.Date.ToShortDateString() },  { Title }";
            }

        }
        public string RequestDateOnly
        {
            get
            {
                return RequestDate.Date.ToShortDateString();
            }
        }

        public int  DaysOpen
        {
            get
            {
                if (IsClosed == true)
                {
                    return System.DateTime.Now.Subtract(RequestDate).Days;
                }
                else
                {
                    try
                    {
                        return CloseDate.Value.Subtract(RequestDate).Days;
                    }
                    catch
                    {
                        return System.DateTime.Now.Subtract(RequestDate).Days;
                    }
                   
                }
                
            }
        }
    }
}
