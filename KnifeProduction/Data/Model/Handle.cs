//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnifeProduction.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Handle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Handle()
        {
            this.Knives = new HashSet<Knives>();
        }
    
        public int id { get; set; }
        public Nullable<int> idBackrest { get; set; }
        public Nullable<int> idClip { get; set; }
    
        public virtual Backrest Backrest { get; set; }
        public virtual Clip Clip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Knives> Knives { get; set; }
    }
}
