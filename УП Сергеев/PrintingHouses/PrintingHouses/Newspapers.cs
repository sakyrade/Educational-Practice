//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrintingHousesApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Newspapers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Newspapers()
        {
            this.PrintingNewspapers = new HashSet<PrintingNewspapers>();
        }
    
        public string NewspaperName { get; set; }
        public string NewspaperIndex { get; set; }
        public string EditorSecondName { get; set; }
        public string EditorFirstName { get; set; }
        public string EditorLastName { get; set; }
        public double SubPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrintingNewspapers> PrintingNewspapers { get; set; }
    }
}
