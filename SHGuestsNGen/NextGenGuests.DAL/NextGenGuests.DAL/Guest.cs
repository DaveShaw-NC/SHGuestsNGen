//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NextGenGuests.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guest()
        {
            this.Visits1 = new HashSet<Visit>();
        }
    
        public int GuestID { get; set; }
        public string Roster { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public long SSN { get; set; }
        public string Gender { get; set; }
        public int Visits { get; set; }
        public System.DateTime LastVisitDate { get; set; }
        public byte[] g_Timestamp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits1 { get; set; }

        public override string ToString ( )
        {
            return $"ID: {GuestID.ToString ( )} {LastName}, {FirstName} {SSN:000-00-0000} {BirthDate.ToShortDateString ( )} ";
        }
    }
}
