using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTestLibrary.Models
{
    public class HydrantPressureModel
    {
        public int HydrantId { get; set; }
        public DateTime solveTime { get; set; }
        public double Pressure { get; set; }
        public double DecimalHour
        {
            get
            {
                return Math.Round((double)solveTime.Hour + (double)solveTime.Minute / 60,0);
            }
        }
    }
}
