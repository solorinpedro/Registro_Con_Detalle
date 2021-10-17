using Microsoft.EntityFrameworkCore;
using Registro_Con_Detalle.DAL;
using Registro_Con_Detalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Con_Detalle.BLL
{
    public class RolesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.RoiID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        public static bool Guardar(Roles roles)
        {
            if (!Existe(roles.RoiID))
                return Insertar(roles);
            else
                return Modificar(roles);
        }

        private static bool Insertar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var obj in roles.RolesDetalle)
                {
                    contexto.Permisos.Find(obj.PermisoID).VecesAsignado += 1;
                }
                contexto.Roles.Add(roles);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        private static bool Modificar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM RolesDetalle Where RolID = {roles.RoiID}");

                foreach (var item in roles.RolesDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(roles).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var rol = contexto.Roles.Find(id);

                if (rol != null)
                {
                    contexto.Roles.Remove(rol);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Roles Buscar(int id)
        {
            Roles roles = new Roles();
            Contexto contexto = new Contexto();

            try
            {
                roles = contexto.Roles.Include(x => x.RolesDetalle)
                    .Where(x => x.RoiID == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return roles;
        }

        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            List<Roles> Lista = new List<Roles>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Roles.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}

