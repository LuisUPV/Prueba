//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba
{
    using System;
    using System.Collections.Generic;
    
    public partial class productos
    {
        public int id_producto { get; set; }
        public string producto_nombre { get; set; }
        public string producto_descripcion { get; set; }
        public Nullable<int> producto_precio { get; set; }
        public Nullable<int> producto_cantidad_existencia { get; set; }
        public Nullable<int> producto_clave { get; set; }
    
        public virtual relacion_productos_por_pedido relacion_productos_por_pedido { get; set; }
    }
}