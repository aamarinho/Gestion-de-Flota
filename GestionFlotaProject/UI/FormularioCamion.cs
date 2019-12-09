﻿using System;
using WFrms=System.Windows.Forms;
using System.Drawing;

namespace GestionFlotaProject.UI
{
    public partial class FormularioCamion : WFrms.Form
    {
        public FormularioCamion()
        {
            this.Build();
            
        }

        private void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                AutoScroll = true,
                Dock=WFrms.DockStyle.Fill,
                Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            
            mainPanel.Controls.Add(this.BuildMatricula());
            mainPanel.Controls.Add(this.BuildTipo());
            mainPanel.Controls.Add(this.BuildMarca());
            mainPanel.Controls.Add(this.BuildConsumo());
            mainPanel.Controls.Add(this.BuildFechaAdquisicion());
            mainPanel.Controls.Add(this.BuildFechaFabricacion());
            mainPanel.Controls.Add(this.BuildBotonAceptar());
            this.Controls.Add(mainPanel);
        }

        private WFrms.Panel BuildMatricula()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblMatricula= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Matricula"
            };
            this.EdMadricula = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text="??"
            };
            
            pnl.Controls.Add(this.EdMadricula);
            pnl.Controls.Add(lblMatricula);
            return pnl;
        }
        
        private WFrms.Panel BuildMarca()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblMarca= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Marca"
            };
            this.EdMarca = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "??"
            };
            
            pnl.Controls.Add(this.EdMarca);
            pnl.Controls.Add(lblMarca);
            return pnl;
        }
        
        private WFrms.Panel BuildConsumo()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblConsumo= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Consumo"
            };
            this.EdConsumo = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "??"
            };
            
            pnl.Controls.Add(this.EdConsumo);
            pnl.Controls.Add(lblConsumo);
            return pnl;
        }
        
        private WFrms.Panel BuildFechaAdquisicion()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblFechaAdquisicion= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Fecha Adquisicion"
            };
            this.EdFechaAdquisicion = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "??"
            };
            
            pnl.Controls.Add(this.EdFechaAdquisicion);
            pnl.Controls.Add(lblFechaAdquisicion);
            return pnl;
        }

        private WFrms.Panel BuildFechaFabricacion()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblFechaFabricacion= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Fecha Fabricacion"
            };
            this.EdFechaFabricacion = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "??"
            };
                     
            pnl.Controls.Add(this.EdFechaFabricacion);
            pnl.Controls.Add(lblFechaFabricacion);
            return pnl;
        }

        WFrms.Panel BuildTipo()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblTipo= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Tipo"
            };
            this.CbTipo = new WFrms.ComboBox() {
                Dock = WFrms.DockStyle.Fill,
                DropDownStyle = WFrms.ComboBoxStyle.DropDownList,
            };
            this.CbTipo.Items.AddRange(new String[] {"Camion","Camion articulado"});
            this.CbTipo.SelectedIndex = 0;
            
            pnl.Controls.Add(this.CbTipo);
            pnl.Controls.Add(lblTipo);
            
            return pnl;
        }

        WFrms.Panel BuildBotonAceptar()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            this.BotonAceptar = new WFrms.Button {
                Dock=WFrms.DockStyle.Top,
                BackColor = Color.Turquoise,
                Size = new Size(100, 50),
                Text = "INSERTAR"
            };
            pnl.Controls.Add(BotonAceptar);
            return pnl;
        }
        public WFrms.TextBox EdMadricula { get; private set; }
        public WFrms.TextBox EdMarca { get; private set; }
        public WFrms.TextBox EdConsumo { get; private set; }
        public WFrms.TextBox EdFechaAdquisicion { get; private set; }
        public WFrms.TextBox EdFechaFabricacion { get; private set; }
        public WFrms.ComboBox CbTipo { get; private set; }
        public WFrms.Button BotonAceptar { get; private set; }

    }
}