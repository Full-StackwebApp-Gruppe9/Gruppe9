using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models;

    public class PollenResponse
    {
        public int ID { get; set; } //Primary Key
        public int DateInfoId { get; set; }
        public int PlantInfoId { get; set; }

}
