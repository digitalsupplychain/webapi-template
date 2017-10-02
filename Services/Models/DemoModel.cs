using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class DemoModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Not long enough")]
        public string DemoString { get; set; }

        public bool DemoBool { get; set; }

        public DateTime DemoDate { get; set; }

        public DemoEntity ToEntity()
        {
            DemoEntity entity = new DemoEntity {
                Id = Id,
                DemoBool = DemoBool,
                DemoDate = DemoDate,
                DemoString = DemoString
            };

            return entity;
        }

    }
}