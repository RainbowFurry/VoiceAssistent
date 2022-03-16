using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{

    public partial class DWC_DataGridCell : UserControl
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        //SCROLLBAR BEARBEITEN...
        public SolidColorBrush GridCellHeaderTextColor { get; set; }
        public SolidColorBrush GridCellHeaderBackgroundColor { get; set; }

        public SolidColorBrush GridCellContentTextColor { get; set; }
        public SolidColorBrush GridCellContentBackgroundColor { get; set; }

        public SolidColorBrush GridLineBrush { get; set; }
        public SolidColorBrush RowBackground { get; set; }

        private int HeaderColumIndex = 0;

        DataGrid dataGrid;

        public DWC_DataGridCell()
        {
            InitializeComponent();
            dataGrid = this.DWC_DataGrid;
            //addGridCellHeader("TESTing");
            //addGridCellContent();
        }

        public void addGridCellHeader(String title)
        {
            dataGrid.Columns[HeaderColumIndex].Header = title;
            HeaderColumIndex++;
        }

        public void addGridCellContent()
        {
            //https://www.wpf-tutorial.com/de/89/das-datagrid-steuerelement/datagrid-spalten/
            dataGrid.Items.Add(new DataGridTextColumn());
        }

        public void build()
        {
            //
        }

    }
}
