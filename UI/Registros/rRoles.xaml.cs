using Registro_Con_Detalle.BLL;
using Registro_Con_Detalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro_Con_Detalle.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles role = new Roles();

        public rRoles()
        {
            InitializeComponent();
            InitializeComponent();
            this.DataContext = role;
            RolIDTextBox.Text = "0";

            PermisoIDCombobox.ItemsSource = PermisosBLL.GetPermisos();
            nombreComboBox.ItemsSource = PermisosBLL.GetPermisos();
            DescripcionComBox.ItemsSource = PermisosBLL.GetPermisos();

            PermisoIDCombobox.SelectedValuePath = "PermisoID";
            PermisoIDCombobox.DisplayMemberPath = "PermisoID";
            nombreComboBox.DisplayMemberPath = "Nombre";
            DescripcionComBox.DisplayMemberPath = "Descripcion";
        }
        private void Limpiar()
        {
            RolIDTextBox.Text = "0";
            DetalleDataGrid.ItemsSource = new List<RolesDetalle>();
            Actuallizar();
        }
        private void Actuallizar()
        {
            this.DataContext = null;
            this.DataContext = role;
        }
        private bool ValidarGuardar()
        {
            bool esValido = true;
            if (DetalleDataGrid.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, Debe agregar roles", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Rol = RolesBLL.Buscar(Utilidades.ToInt(RolIDTextBox.Text));

            if (Rol != null)
            {
                DescripcionTextBox.Text = role.Descripcion;
                this.role = Rol;
            }
            else
            {
                this.role = new Roles();
            }
            this.DataContext = this.role;

        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            role.RolesDetalle.Add(new RolesDetalle(Utilidades.ToInt(RolIDTextBox.Text), Utilidades.ToInt(PermisoIDCombobox.Text)));

            Actuallizar();

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Actuallizar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidarGuardar())
                return;
            bool paso = false;

            if (role.RoiID == 0)
            {
                paso = RolesBLL.Guardar(role);
            }
            else
            {
                if (Existe())
                {
                    paso = RolesBLL.Guardar(role);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "ERROR");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(int.Parse(RolIDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se ha podido Eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool Existe()
        {
            Roles esValido = RolesBLL.Buscar(role.RoiID);

            return (esValido != null);
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            {
                role.RolesDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Actuallizar();
            }
        }
    }
}
