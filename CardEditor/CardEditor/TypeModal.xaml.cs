using CardEditor.ViewModels;
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

namespace CardEditor
{
    /// <summary>
    /// Interaction logic for TypeModal.xaml
    /// </summary>
    public partial class TypeModal : Window
    {
        public TypeViewModel TypeViewModel { get; set; }
        public TypeModal(EditViewModel editViewModel)
        {
            InitializeComponent();
            TypeViewModel = new TypeViewModel(this, editViewModel);
            DataContext = TypeViewModel;
        }
    }
}
