using System.Collections;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows;

namespace Memory_game
{

    public partial class MainWindow : Window
    {
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        MemoryGrid grid;

        public MainWindow()
        {
            InitializeComponent();
            grid = new MemoryGrid(GameGrid, 4 , 4);
            
        }

        private void InitializeGameGrid()
        {
            for (int i = 0; i < NR_OF_ROWS; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < NR_OF_COLS; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}