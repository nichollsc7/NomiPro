
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
    
public partial class Nomina
{

    public int ID_Nomina { get; set; }

    public Nullable<int> ID_EmpleN { get; set; }

    public Nullable<int> ID_CargoN { get; set; }

    public Nullable<int> ID_Control_PagoN { get; set; }

    public string Mes { get; set; }

    public string Estado { get; set; }

    public Nullable<int> Subtotal { get; set; }

    public Nullable<int> Total { get; set; }



    public virtual Cargo Cargo { get; set; }

    public virtual Control_Pago Control_Pago { get; set; }

    public virtual Empleado Empleado { get; set; }

}

}
