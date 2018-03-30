//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelAgency.BusinessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Content
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Content()
        {
            this.ContentImages = new HashSet<ContentImage>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> Panel { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<int> NumberPeople { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public System.DateTime Created_Date { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentImage> ContentImages { get; set; }
    }
}
