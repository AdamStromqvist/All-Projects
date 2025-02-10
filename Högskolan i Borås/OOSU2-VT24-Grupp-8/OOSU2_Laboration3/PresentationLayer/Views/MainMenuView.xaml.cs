using OOSU2_Laboration3.PresentationLayer.ViewModels;
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

namespace OOSU2_Laboration3.PresentationLayer.Views
{
   
    /// Interaction logic for MainMenuView.xaml
 
    public partial class MainMenuView : Window
    {
        public MainMenuView()
        {
            InitializeComponent();
            DataContext = new MainMenuViewModel();

        }


    }
}
