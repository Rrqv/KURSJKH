//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ЖКХ
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meter()
        {
            this.MeterReadings = new HashSet<MeterReading>();
        }
    
        public int MeterID { get; set; }
        public int ApartmentID { get; set; }
        public string MeterType { get; set; }
        public System.DateTime InstallationDate { get; set; }
    
        public virtual Apartment Apartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeterReading> MeterReadings { get; set; }
    }
}
