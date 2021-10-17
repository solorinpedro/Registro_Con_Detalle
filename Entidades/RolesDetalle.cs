using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Con_Detalle.Entidades
{
    public class RolesDetalle
    {
        [Key]
        public int RolesDetalleID { get; set; }
        public int RoiID { get; set; }
        public int PermisoID { get; set; }
        public bool EsAsignado { get; set; }
        public RolesDetalle(int RoiID, int PermisoID)
        {
            RolesDetalleID = 0;
            this.RoiID = RoiID;
            this.PermisoID = PermisoID;
        }
    }
}
