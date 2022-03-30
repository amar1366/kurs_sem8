using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Manager.Professors
{
    public class PRequest
    {
        public Guid pNomber 
        { 
            get; 
            set; 
        }

        public string surname 
        { 
            get; 
            set; 
        }

        public string name 
        { 
            get; 
            set; 
        }

        public string middlename 
        { 
            get; 
            set; 
        }

        public DateTime MyDay { get; private set; }
        public string  birthday 
        {
            get
            {
                return MyDay.ToShortDateString();
            }
            set
            {
                MyDay = DateTime.Parse(value);
            }
        }
    }
}
