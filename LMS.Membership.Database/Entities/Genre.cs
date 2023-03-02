﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Membership.Database.Entities
{
    public class Genre : IEntity
    {
        public Genre()
        {
            Films = new HashSet<Film>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}