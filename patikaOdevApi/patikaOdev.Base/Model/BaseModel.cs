﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patikaOdevApi.Base;

public class BaseModel
{
    public int ID { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

}
