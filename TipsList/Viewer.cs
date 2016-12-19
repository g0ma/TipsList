using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipsList
{
    public partial class Viewer : Form
    {
        string FilePath = @"E:\game.txt";
        public Viewer()
        {
            InitializeComponent();
        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(FilePath, Encoding.UTF8);
                string str = reader.ReadToEnd();
                reader.Close();
                string[] ReadItems = str.Split(new[] { "\r\n" }, StringSplitOptions.None);

                foreach (var item in ReadItems)
                {
                    ViewList.Items.Add(item);
                }

                Message.Text = "読込完了";
            }
            catch (FileNotFoundException ex)
            {
                Message.Text = ex.Message;
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            if (ViewList.SelectedIndex != -1)
            {
                ViewList.Items.RemoveAt(ViewList.SelectedIndex);
                Message.Text = "1行削除しました";
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter(FilePath, false, Encoding.UTF8);
                foreach(var item in ViewList.Items)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
                Message.Text = "保存しました";
            }
            catch
            {
                Message.Text = "保存失敗";
            }
        }
    }
}
