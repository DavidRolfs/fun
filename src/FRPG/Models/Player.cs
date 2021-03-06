﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRPG.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageToByte { get; set; }
        public string Bio { get; set; }
        public int Age { get; set; }
        public int Charm { get; set; }
        public int Intellect { get; set; }
        public int Wealth { get; set; }
        public int Physique { get; set; }
        public int Experience { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}