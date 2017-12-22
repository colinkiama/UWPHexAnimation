using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace anyDoApp.Control
{
    public sealed partial class superButton : UserControl
    {
        public superButton()
        {
            this.InitializeComponent();
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            makeAnimatinonHappen(animatedThing);
        }

        private void makeAnimatinonHappen(Windows.UI.Xaml.Shapes.Path animatedThing)
        {
            
        }
    }
}
