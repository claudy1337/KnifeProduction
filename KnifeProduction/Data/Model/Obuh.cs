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
    
    public partial class Obuh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Obuh()
        {
            this.Blade = new HashSet<Blade>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public byte[] Image { get; set; }
        public Nullable<int> Count { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blade> Blade { get; set; }
    }
}
