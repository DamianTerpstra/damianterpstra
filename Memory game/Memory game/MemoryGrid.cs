using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Memory_game
{
    public class MemoryGrid
    {
        private Grid grid;
        private int rows, cols;

        public MemoryGrid(Grid grid, int rows, int cols)
        {
            this.grid = grid;
            this.rows = rows;
            this.cols = cols;
            InitializeGameGrid();
            AddImages();
        }

        private void AddImages()
        {
            List<ImageSource> images = GetImagesList();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Image backsideImage = new Image();
                    backsideImage.Source = new BitmapImage(new Uri("IMG\\backside.png", UriKind.Relative));
                    backsideImage.Tag = images.First();
                    images.RemoveAt(0);
                    backsideImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backsideImage, col);
                    Grid.SetRow(backsideImage, row);
                    grid.Children.Add(backsideImage);
                }
            }
        }

        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }

        private void InitializeGameGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private List<ImageSource> GetImagesList()
        {
            List<ImageSource> images = new List<ImageSource>();

            for(int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("IMG\\" + imageNr + ".png",UriKind.Relative));
                images.Add(source);
            }

            return images;
        }

        //private void AssignIconsToSquares()
        //{
        //    // Sla huidig label op
        //    Label label;
        //    int randomNumber;

        //    // Ga door elke control van het layout panel (dus elke label)
        //    for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
        //    {
        //        if (tableLayoutPanel1.Controls[i] is Label)
        //        {
        //            label = (Label)tableLayoutPanel1.Controls[i];
        //        }
        //        else
        //        {
        //            continue;
        //        }

        //        // Maak een willekeurig nummer om een icoontje uit te kiezen
        //        randomNumber = random.Next(0, icons.Count);
        //        label.Text = icons[randomNumber];

        //        // Haal het nummer weg
        //        icons.RemoveAt(randomNumber);
        //    }
        //}
    }
}
