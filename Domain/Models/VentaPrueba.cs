﻿    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class VentaPrueba
    {
        public string ClienteId { get; set; }
        public double TotalPagar { get; set; }

    }
}
