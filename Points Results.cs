using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NewGraphicsPackage
{
    public partial class Points_Results : Form
    {
        List<List<float>> results = new List<List<float>>();
        public Points_Results(List<List<float>> points, char c)
        {
            InitializeComponent();
            results = points;
            

            switch(c)
            {
                case 'B':
                    Bresenham_DisplayResults();
                    break;
                case 'C':
                    Circle_DisplayResults();
                    break;
                case 'D':
                    DDA_DisplayResults();
                    break;
                case 'E':
                    Ellipse_DisplayResults();
                    break;

            }
        }

        private void DDA_DisplayResults()
        {
            tableResults.Controls.Clear();
            tableResults.ColumnCount = results.ElementAt(0).Count;

            String [] columnsNames = { "X", "Y", "X(k+1)", "Y(k+1)"};

            for (int i = 0; i < results.Count; i++)
            {
                for (int j = 0; j < results[i].Count; j++)
                {
                    // Create labels to display data
                    Label label = new Label();

                    if (i == 0)
                    {
                        // Set column names for the first row
                        label1.Text = "X";
                        label2.Text = "Y";
                        label3.Text = "X(k+1)";
                        label4.Text = "Y(k+1)";

                    }

                    // Set data values for other rows
                    label.Text = results[i][j].ToString();

                    // Add label to TableLayoutPanel
                    tableResults.Controls.Add(label);

                    // Set row and column indices for label
                    tableResults.SetRow(label, i);
                    tableResults.SetColumn(label, j);
                }

            }
        }

        private void Bresenham_DisplayResults()
        {
            tableResults.Controls.Clear();
            tableResults.ColumnCount = results.ElementAt(0).Count;


            for (int i = 0; i < results.Count; i++)
            {
                for (int j = 0; j < results[i].Count; j++)
                {
                    // Create labels to display data
                    Label label = new Label();

                    if (i == 0)
                    {
                        // Set column names for the first row
                        label1.Text = "P";
                        label2.Text = "X(k+1)";
                        label3.Text = "Y(k+1)";
                        label4.Text = "";

                    }

                    // Set data values for other rows
                    label.Text = results[i][j].ToString();

                    // Add label to TableLayoutPanel
                    tableResults.Controls.Add(label);

                    // Set row and column indices for label
                    tableResults.SetRow(label, i);
                    tableResults.SetColumn(label, j);
                }

            }
        }


        private void Circle_DisplayResults()
        {
            tableResults.Controls.Clear();
            tableResults.ColumnCount = results.ElementAt(0).Count;


            for (int i = 0; i < results.Count; i++)
            {
                for (int j = 0; j < results[i].Count; j++)
                {
                    // Create labels to display data
                    Label label = new Label();

                    if (i == 0)
                    {
                        // Set column names for the first row
                        label1.Text = "P";
                        label2.Text = "X(k+1)";
                        label3.Text = "Y(k+1)";
                        label4.Text = "";

                    }

                    // Set data values for other rows
                    label.Text = results[i][j].ToString();

                    // Add label to TableLayoutPanel
                    tableResults.Controls.Add(label);

                    // Set row and column indices for label
                    tableResults.SetRow(label, i);
                    tableResults.SetColumn(label, j);
                }

            }
        }

        private void Ellipse_DisplayResults()
        {
            tableResults.Controls.Clear();
            tableResults.ColumnCount = results.ElementAt(0).Count;


            for (int i = 0; i < results.Count; i++)
            {
                for (int j = 0; j < results[i].Count; j++)
                {
                    // Create labels to display data
                    Label label = new Label();

                    if (i == 0)
                    {
                        // Set column names for the first row
                        label1.Text = "P";
                        label2.Text = "X(k+1)";
                        label3.Text = "Y(k+1)";
                        label4.Text = "";

                    }

                    // Set data values for other rows
                    label.Text = results[i][j].ToString();

                    // Add label to TableLayoutPanel
                    tableResults.Controls.Add(label);

                    // Set row and column indices for label
                    tableResults.SetRow(label, i);
                    tableResults.SetColumn(label, j);
                }

            }
        }


    }
}
