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
    
    public partial class Счета
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Счета()
        {
            this.Платежи = new HashSet<Платежи>();
        }
    
        public int id { get; set; }
        public Nullable<int> номер_квартиры { get; set; }
        public Nullable<System.DateTime> месяц { get; set; }
        public Nullable<decimal> сумма { get; set; }
    
        public virtual Квартиры Квартиры { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Платежи> Платежи { get; set; }
    }
}
