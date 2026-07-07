using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class Request
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RequestedDate { get; set; }

        public Int64 MyProperty { get; set; }


    }
}
