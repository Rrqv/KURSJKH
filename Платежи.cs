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
    
    public partial class Платежи
    {
        public int id { get; set; }
        public Nullable<int> номер_счета { get; set; }
        public Nullable<System.DateTime> дата_платежа { get; set; }
        public Nullable<decimal> сумма { get; set; }
    
        public virtual Счета Счета { get; set; }
    }
}
