﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ART.VehicleTracker.PL
{
    public partial class tblVehicle
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public Guid ColorId { get; set; }
        public Guid ModelId { get; set; }
        public string Vin { get; set; }
        public int Year { get; set; }

        public virtual tblColor Color { get; set; }
        public virtual tblMake Make { get; set; }
        public virtual tblModel Model { get; set; }
    }
}
