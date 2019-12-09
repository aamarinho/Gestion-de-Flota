using System;
using System.Collections.Generic;
using WFrm = System.Windows.Forms;

namespace GestionFlotaProject.UI
{
    public class MainWindowController
    {
        public MainWindowController()
        {
            this.MainView = new MainView();
            this.Formulario=new Formulario(); 
            this.Vehiculos=new ColeccionVehiculos();
            this.VistaDetallada=new VistaDetallada(new Vehiculo("","","","","","","",new List<string>()));
            this.MainView.BotonInsertar.Click += this.MostrarForm;
            this.Formulario.botonAceptar.Click +=this.Insertar;
            this.MainView.Lista.Click += this.Visualizar;
            this.VistaDetallada.botonModificar.Click += this.Modificar;
            this.VistaDetallada.botonEliminar.Click += this.Eliminar;
            this.MainView.BotonGuardar.Click += this.Guardar;
            this.MainView.BotonRecuperar.Click += this.Recuperar;
        }

        void MostrarForm(Object sender, EventArgs e)
        {
            Formulario.ShowDialog();
        }

        void Insertar(Object sender, EventArgs e)
        {
            Console.WriteLine("insertar");
            String txtMatricula = Formulario.EdMadricula.Text;
            String txtTipo = Formulario.CbTipo.Text;
            String txtMarca = Formulario.EdMarca.Text;
            String txtModelo = Formulario.EdModelo.Text;
            String txtConsumo = Formulario.EdConsumo.Text;
            String txtFechaAdquisicion = Formulario.EdFechaAdquisicion.Text;
            String txtFechaFabricacion = Formulario.EdFechaFabricacion.Text;
            bool wifi = Formulario.EdWifi.Checked;
            bool bluetooth = Formulario.EdBluetooth.Checked;
            bool acc = Formulario.EdAcc.Checked;
            bool litera = Formulario.EdLitera.Checked;
            bool tv = Formulario.EdTV.Checked;
            List<string> comodidades = new List<string>();
            
            if (wifi) {
                comodidades.Add("wifi");
            }
            if (bluetooth) {
                comodidades.Add("bluetooth");
            }
            if (acc) {
                comodidades.Add("aire acondicionado");
            }
            if (litera) {
                comodidades.Add("litera");
            }
            if (tv) {
                comodidades.Add("tv");
            }
                
            Vehiculo v = new Vehiculo(txtMatricula, txtTipo, txtMarca, txtModelo, txtConsumo, txtFechaAdquisicion, txtFechaFabricacion,comodidades);

            Vehiculos.Inserta(v);
            MainView.Lista.Items.Add(v.ToString());
        }

        Vehiculo encontrarVehiculo(String matricula)
        {
            Vehiculo toret = new Vehiculo("","","","","","","",new List<string>());

            foreach (Vehiculo v in Vehiculos.Vehiculos) {
                if (v.Matricula.Equals(matricula)) {
                    toret = v;
                    break;
                }
            }
            return toret;
        }
        
        void Visualizar(Object sender, EventArgs e)
        {
            Vehiculo vehiculoActual = new Vehiculo("","","","","","","",new List<string>());
            String matricula = MainView.Lista.SelectedItems[0].Text.Substring(0, 7);
            Console.WriteLine("visualizar");
            Console.WriteLine(matricula);
            vehiculoActual = encontrarVehiculo(matricula);
            VistaDetallada.Vehiculo = vehiculoActual;
            VistaDetallada.ShowDialog();
        }
        
        void Modificar(Object sender, EventArgs e)
        {
            Console.WriteLine("modificar");
            String txtMatricula = VistaDetallada.EdMadricula.Text;
            String txtTipo = VistaDetallada.CbTipo.Text;
            String txtMarca = VistaDetallada.EdMarca.Text;
            String txtModelo = VistaDetallada.EdModelo.Text;
            String txtConsumo = VistaDetallada.EdConsumo.Text;
            String txtFechaAdquisicion = VistaDetallada.EdFechaAdquisicion.Text;
            String txtFechaFabricacion = VistaDetallada.EdFechaFabricacion.Text;
            bool wifi = VistaDetallada.EdWifi.Checked;
            bool bluetooth = VistaDetallada.EdBluetooth.Checked;
            bool acc = VistaDetallada.EdAcc.Checked;
            bool litera = VistaDetallada.EdLitera.Checked;
            bool tv = VistaDetallada.EdTV.Checked;
            List<string> comodidades = new List<string>();
            if (wifi) {
                comodidades.Add("wifi");
            }
            if (bluetooth) {
                comodidades.Add("bluetooth");
            }
            if (acc) {
                comodidades.Add("aire acondicionado");
            }
            if (litera) {
                comodidades.Add("litera");
            }
            if (tv) {
                comodidades.Add("tv");
            }
            Console.WriteLine("MATRICULA PARA HACER LA CONSULTA"+txtMatricula);
            Vehiculo vehiculoActual = encontrarVehiculo(txtMatricula);

            vehiculoActual.Matricula = txtMatricula;
            vehiculoActual.Tipo = txtTipo;
            vehiculoActual.Marca = txtMarca;
            vehiculoActual.Modelo = txtModelo;
            vehiculoActual.Consumo = txtConsumo;
            vehiculoActual.FechaAdquisicion = txtFechaAdquisicion;
            vehiculoActual.FechaFabricacion = txtFechaFabricacion;
            vehiculoActual.Comodidades = comodidades;
            
            int pos = Vehiculos.Posicion(vehiculoActual);
            
            MainView.Lista.Items.RemoveAt(pos);
            MainView.Lista.Items.Insert(pos, vehiculoActual.ToString());
        }
        
        void Eliminar(Object sender, EventArgs e)
        {
            String textMatricula = VistaDetallada.EdMadricula.Text;
            Vehiculo vehiculoActual = this.encontrarVehiculo(textMatricula);
            int pos = Vehiculos.Posicion(vehiculoActual);
            Vehiculos.Elimina(vehiculoActual);
            MainView.Lista.Items.RemoveAt(pos);
        }
        
        void Guardar(Object sender, EventArgs e)
        {
            Vehiculos.VuelcaXML();
        }
        
        void Recuperar(Object sender, EventArgs e)
        {
            Vehiculo[] vehiculosRecuperar = Vehiculos.LeerVehiculosXmlDom();
            for (int i = 0; i < vehiculosRecuperar.Length; i++)
            {
                MainView.Lista.Items.Add(vehiculosRecuperar[i].ToString());
                Vehiculos.Inserta(vehiculosRecuperar[i]);
            }
            MainView.Lista.Refresh();
        }
        
        public MainView MainView { get; set; }
        public ColeccionVehiculos Vehiculos { get; set; }
        public Formulario Formulario { get; set; }
        public VistaDetallada VistaDetallada { get; set; }
       
        
        
    }
    }
