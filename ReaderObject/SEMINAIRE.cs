//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReaderObject
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEMINAIRE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEMINAIRE()
        {
            this.INSCRIT = new HashSet<INSCRIT>();
        }
    
        public string CODESEMI { get; set; }
        public string CODECOURS { get; set; }
        public System.DateTime DATEDEBUTSEM { get; set; }
    
        public virtual COURS COURS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INSCRIT> INSCRIT { get; set; }
    }
}
