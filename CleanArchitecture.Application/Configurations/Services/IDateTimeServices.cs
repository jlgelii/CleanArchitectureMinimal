﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Configurations.Services
{
    public interface IDateTimeServices
    {
        DateTime Now { get; }
    }
}
