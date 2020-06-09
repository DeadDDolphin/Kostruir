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

namespace Алгоритм_Куна
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool dfs(int v, bool[] used, int[,] g, int size, int[] matching)
        {
            if (used[v])
                return false;
            used[v] = true;
            for (int i = 0; i < size; i++)
            {
                int t = g[v, i];
                if (matching[t] == -1 || dfs(matching[t], used, g, size, matching))
                {
                    matching[t] = v;
                    return true;
                }
            }
            return false;
        }

        string Kun(int[,]g, int size)
        {
            int []matching = new int[size];
            for (int i = 0; i < size; i++)
            {
                matching[i] = -1;
            }
            bool[] used = new bool[size];

            for (int i = 0;i<size;i++)
            {
                for (int j = 0; j < size; j++)
                {
                    used[j] = false;
                }
                dfs(i, used, g, size, matching);
            }
            string temp = "";
            for (int i = 0; i < size; i++)
            {
                if (matching[i] != -1)
                    temp += i + "->" + matching[i] + "\n";
            }
            return temp;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            OpenFileDialog openGraph = new OpenFileDialog();

            openGraph.InitialDirectory = "C:\\Users\\Dima\\Documents\\GitHub\\Kostruir\\Алгоритм Куна\\";
            openGraph.Filter = "txt files (*.txt)|*.txt";
            openGraph.FilterIndex = 2;
            openGraph.RestoreDirectory = true;

            if (matrCraph.Text == "")
            {
                if (openGraph.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openGraph.FileName;
                    string text = File.ReadAllText(filePath);
                    matrCraph.AppendText(text);
                }
            }

            string temp = matrCraph.Text;
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

            temp = Kun(matrData, n);
            parosoch.AppendText(temp);
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
