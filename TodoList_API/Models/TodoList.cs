﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList_API.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string ContentTask { get; set; }
        public int IsDone { get; set; }
    }
}
