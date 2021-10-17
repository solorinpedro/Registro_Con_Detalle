using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Con_Detalle.Entidades
{
    public class Permisos
    {

        [Key]
        public int PermisoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int VecesAsignado { get; set; }

        [ForeignKey("PermisoID")]
        public virtual List<RolesDetalle> RolesDetalle { get; set; }

        public Permisos()
        {
            PermisoID = 0;
            RolesDetalle = new List<RolesDetalle>();
        }
    }
}

