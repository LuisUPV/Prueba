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
    
    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            this.pedidos = new HashSet<pedidos>();
        }
    
        public int id_usuario { get; set; }
        public string usuario_nombre { get; set; }
        public string usuario_password { get; set; }
        public string usuario_correo { get; set; }
        public Nullable<int> usuario_id_rol { get; set; }
        public string usuario_apellido_paterno { get; set; }
        public string usuario_apellido_materno { get; set; }
        public string usuario_foto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidos> pedidos { get; set; }
        public virtual roles roles { get; set; }
    }
}
