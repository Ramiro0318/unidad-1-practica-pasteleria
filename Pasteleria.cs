using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace unidad_1_practica_pasteleria
{
    public class Pasteleria : INotifyPropertyChanged
    {
        public ObservableCollection<Pan> Panes { get; set; } = new();

        public ObservableCollection<Pan> CajaPanes { get; set; } = new()
        {
            new Pan{ Nombre = "Quequito", Precio = 10m, Disponibilidad = 10, Imagen = ""},
            new Pan{ Nombre = "Dona", Precio = 10m, Disponibilidad = 10, },
            new Pan{ Nombre = "Quaso", Precio = 10m, Disponibilidad = 10 },
            new Pan{ Nombre = "PanBlanco", Precio = 10m, Disponibilidad = 10 },
            new Pan{ Nombre = "GalletaChispas", Precio = 10m, Disponibilidad = 10 },
            new Pan{ Nombre = "QuequitoChispas", Precio = 10m, Disponibilidad = 10 },
            new Pan{ Nombre = "Pretzel", Precio = 10m, Disponibilidad = 10 },
            new Pan{ Nombre = "GalletaCuadrada", Precio = 10m, Disponibilidad = 10 },
            new Pan{ Nombre = "GalletaEstrella", Precio = 10m, Disponibilidad = 10 }
        };


        public Pan Pan { get; set; } = new();

        public decimal Total { get; set; } = new();
        public int CantidadComprar { get; set; }
        public string Error { get; set; } = "";
        public ICommand AgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand VenderCommand { get; set; }

        public Pasteleria()
        {
            AgregarCommand = new RelayCommand<Pan>(Agregar);
            EliminarCommand = new RelayCommand<Pan>(Eliminar);
            VenderCommand = new RelayCommand(Vender);
            Cargar();

        }



        public void Vender()
        {
            if (Panes != null)
            {
                Panes.Clear();
                Total = 0;
                CantidadComprar = 0;
                Error = "";
                Guardar();
            }
        }

        public void Eliminar(Pan p)
        {
            Pan = p;
            if (p != null)
            {
                Total -= Pan.TotalPorPan;
                Pan.CantidadVenta = 0;
                Panes.Remove(Pan);
                Guardar();
            }
        }

        public void Agregar(Pan p)
        {
            Pan = p;
            Error = "";
            Total = 0;
            if (Pan != null)
            {

                if (Pan.Disponibilidad == 0)
                {
                    Error = "No hay más pan disponible de este tipo";
                }
                else
                {
                    //Pan.TotalPorPan = 0;
                    Pan.Disponibilidad -= CantidadComprar;
                    Pan.CantidadVenta += CantidadComprar;
                    if (Panes.Any(x => x.Nombre == Pan.Nombre))
                    {
                        Panes.Add(Pan);
                        Panes.RemoveAt(Panes.IndexOf(Pan));
                        //Panes.Insert(Panes.IndexOf(Pan), Pan);
                    }
                    else
                    {
                        Panes.Add(Pan);
                    }
                    foreach (Pan pan in Panes)
                    {
                        Total += pan.Precio * pan.CantidadVenta;
                    }
                    Guardar();
                }
                Actualizar(Error);
            }
        }

        private void Actualizar(string? nombre = null)
        {
            PropertyChanged?.Invoke(this, new(nombre));
        }

        string str = "panes.json";
        private void Guardar()
        {
            var json = JsonSerializer.Serialize(Panes);
            File.WriteAllText(str, json);
        }
        private void Cargar()
        {
            if (File.Exists(str))
            {
                string json = File.ReadAllText(str);
                var panes = JsonSerializer.Deserialize<ObservableCollection<Pan>>(json);

                if (panes != null)
                {
                    foreach (var p in panes)
                    {
                        Panes.Add(p);
                        Total += p.Precio * p.CantidadVenta;
                    }
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
