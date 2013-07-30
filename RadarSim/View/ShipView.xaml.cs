using RadarSim.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RadarSim.View
{
    /// <summary>
    /// Interaction logic for ShipView.xaml
    /// </summary>
    public partial class ShipView : UserControl
    {
        private ShipViewModel shipVM;

        public ShipView()
        {
            InitializeComponent();
            this.RenderLayout();
            this.DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.shipVM = e.NewValue as ShipViewModel;
            this.shipVM.ShipFired += (o, a) => { this.OnShipFired(); };
        }

        private void RenderLayout()
        {
            double shipArea = this.ShipCanvas.Height / 2;

            Canvas.SetLeft(this.Ship, shipArea - 6);
            Canvas.SetTop(this.Ship, shipArea - 6);

            Canvas.SetLeft(this.Identifier, shipArea);
            Canvas.SetTop(this.Identifier, shipArea);

            this.Sensor.Height = this.ShipCanvas.Height;
            this.Sensor.Width = this.ShipCanvas.Width;
        }

        private void OnShipFired()
        {
            double x = this.shipVM.CurrentPosition.X;
            double y = this.shipVM.CurrentPosition.Y;

            this.ShipCanvas.Children.Add(
                new Line()
                {
                    X1 = x,
                    Y1 = y,
                    X2 = 0,
                    Y2 = 0,
                    Stroke = Brushes.Blue,
                    StrokeThickness = 2
                });
        }
    }
}