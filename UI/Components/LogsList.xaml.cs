using DataLayer.Database;
using DataLayer.Model;
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

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for LogsList.xaml
    /// </summary>
    public partial class LogsList : UserControl
    {
        public LogsList()
        {
            InitializeComponent();

            using (var context = new DatabaseContext())
            {
                var records = context.Logs.ToList();
                logs.DataContext = records;
            }
        }

        private void MouseDoubleClickHandler(object sender, MouseEventArgs e)
        {
            var datagrid = (DataGrid) sender;
            //var items = (List<DatabaseLogger>) datagrid.DataContext;
            var item = (DatabaseLogger)datagrid.SelectedItem;
            if (item == null)
                return;

            MessageBox.Show($"{item.Message}");
            
        }
    }
}
