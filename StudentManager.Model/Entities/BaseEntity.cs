﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
