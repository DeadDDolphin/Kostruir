using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace IndGraphCykl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool dfs(int key, int[,] a, int[] was, int n, int pred)
        {
            was[key] = 1;
            for (int i = 0; i < n; i++)
            {
                if (a[key,i]!=0)
                {
                    if (was[i] == 0 && pred != i)
                    {
                        if (dfs(i,a,was,n, key))
                            return true;
                    }
                    //else if (was[i] == 1 && pred!=i)
                    //{
                    //    return true;
                    //}
                }
            }
            was[key] = 2;
            return false;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            OpenFileDialog openGraph = new OpenFileDialog();

            openGraph.InitialDirectory = "C:\\Users\\Dima\\Documents\\GitHub\\Kostruir\\IndGraphCykl\\";
            openGraph.Filter = "txt files (*.txt)|*.txt";
            openGraph.FilterIndex = 2;
            openGraph.RestoreDirectory = true;

            if (graphMatrix.Text == "")
            {
                if (openGraph.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openGraph.FileName;
                    string text = File.ReadAllText(filePath);
                    graphMatrix.AppendText(text);
                }
            }

            string temp = graphMatrix.Text;
            double t = Math.Sqrt((temp.Length + 1) / 2);
            int n = (int)t;
            
            string[] temp2 = temp.Split(' ', '\n');
            int[,] matrData = new int[n, n];
            int q = 0;
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    matrData[j, k] = Int32.Parse(temp2[q]);
                    q++;
                }
            }

            int[] was = new int[n];
            for(int i = 0; i<n;i++)
            {
                was[i] = 0;
            }
            int cykles = 0;
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (was[i] != 2 && dfs(i, matrData, was, n, -1))
                    {
                        cykles++;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    was[i] = 0;
                }
            }
            temp = Convert.ToString(cykles);
            cykleNumber.AppendText(temp);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files |*.txt";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {

                using (FileStream fstream = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {

                    fstream.SetLength(0);
                    byte[] array = System.Text.Encoding.Default.GetBytes(temp);
                    fstream.Write(array, 0, array.Length);
                }

                MessageBox.Show("Сохранено", "Завершение работы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка. Повторите попытку", "Завершение работы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            saveFileDialog1.FileName = "";

        }
    }
}
