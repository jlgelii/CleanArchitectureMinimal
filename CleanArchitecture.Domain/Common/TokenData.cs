﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public class TokenData
    {
        public int UserId { get; set; }



        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
