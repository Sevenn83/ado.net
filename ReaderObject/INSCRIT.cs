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
    
    public partial class INSCRIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INSCRIT()
        {
            this.PARTICIPER = new HashSet<PARTICIPER>();
        }
    
        public decimal NUMEMP { get; set; }
        public string CODESEMI { get; set; }
        public System.DateTime DATEINSCRIT { get; set; }
    
        public virtual EMPLOYE EMPLOYE { get; set; }
        public virtual SEMINAIRE SEMINAIRE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARTICIPER> PARTICIPER { get; set; }
    }
}