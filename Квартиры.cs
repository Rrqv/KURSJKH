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
    
    public partial class Квартиры
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Квартиры()
        {
            this.Жалобы = new HashSet<Жалобы>();
            this.Жильцы = new HashSet<Жильцы>();
            this.Заявки = new HashSet<Заявки>();
            this.Счета = new HashSet<Счета>();
        }
    
        public int id { get; set; }
        public string номер_квартиры { get; set; }
        public string адрес { get; set; }
        public Nullable<decimal> площадь { get; set; }
        public string тип_жилища { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Жалобы> Жалобы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Жильцы> Жильцы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заявки> Заявки { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Счета> Счета { get; set; }
    }
}
