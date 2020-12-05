using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long Age { get; set; }
    }
}