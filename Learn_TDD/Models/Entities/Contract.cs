using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learn_TDD.Models.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string Snils { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }
}