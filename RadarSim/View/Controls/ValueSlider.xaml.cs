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

namespace RadarSim.View.Controls
{
    /// <summary>
    /// Interaction logic for ValueSlider.xaml
    /// </summary>
    public partial class ValueSlider : DockPanel
    {
        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PropertyName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(string), typeof(ValueSlider), new PropertyMetadata(string.Empty));

        public int PropertyValue
        {
            get { return (int)GetValue(PropertyValueProperty); }
            set { SetValue(PropertyValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PropertyValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropertyValueProperty =
            DependencyProperty.Register("PropertyValue", typeof(int), typeof(ValueSlider), new PropertyMetadata(0));

        public int MinSliderValue
        {
            get { return (int)GetValue(MinSliderValueProperty); }
            set { SetValue(MinSliderValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinSliderValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinSliderValueProperty =
            DependencyProperty.Register("MinSliderValue", typeof(int), typeof(ValueSlider), new PropertyMetadata(0));

        public int MaxSliderValue
        {
            get { return (int)GetValue(MaxSliderValueProperty); }
            set { SetValue(MaxSliderValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxSliderValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxSliderValueProperty =
            DependencyProperty.Register("MaxSliderValue", typeof(int), typeof(ValueSlider), new PropertyMetadata(0));

        public ValueSlider()
        {
            InitializeComponent();
        }
    }
}