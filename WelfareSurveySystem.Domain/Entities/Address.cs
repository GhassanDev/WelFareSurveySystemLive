using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelfareSurveySystem.Domain.Entities
{
    public class Address

    {
        public int AddressId { get; set; }
        //We want to make Region and City drowbdown
        public string Region { get; set; }
        public string City { get; set; }
        public string Village { get; set; }
    }
}
