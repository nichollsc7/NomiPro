
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Nomipro.ModelDB
{

using System;
    using System.Collections.Generic;
    
public partial class Parafiscale
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Parafiscale()
    {

        this.ParaxEmples = new HashSet<ParaxEmple>();

    }


    public int ID_Parafiscales { get; set; }

    public string Nombre { get; set; }

    public Nullable<int> Valor { get; set; }

    public string Estado { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ParaxEmple> ParaxEmples { get; set; }

}

}
