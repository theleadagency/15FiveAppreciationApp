using System;
using System.Collections.Generic;

namespace AppreciationApp.Core.Models
{
    public class Appreciation
    {
        public Person NameOfSubmitter { get; set; }
        public List<Person> AppreciatedPeople { get; set; }
        public string Message { get; set; }
        public DateTime Submitted { get; set; }
    }
}
