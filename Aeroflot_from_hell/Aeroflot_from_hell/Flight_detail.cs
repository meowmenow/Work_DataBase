//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aeroflot_from_hell
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flight_detail
    {
        public int id { get; set; }
        public string Flight { get; set; }
        public string Destination { get; set; }
        public Nullable<System.DateTime> Departure_time { get; set; }
        public System.DateTime Arrival_time { get; set; }
        public string Available_seets { get; set; }
        public string Aircraft_type { get; set; }
        public string Capacity { get; set; }
    }
}