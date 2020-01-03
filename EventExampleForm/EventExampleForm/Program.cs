using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventExampleForm
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm();
            //form.Click += form.FormClicked;
            form.ShowDialog();
        }
    }

    class MyForm : Form
    {
        private TextBox textbox;
        private Button button;

        public MyForm()
        {
            this.textbox = new TextBox();
            this.button = new Button();
            this.Controls.Add(this.button);
            this.Controls.Add(this.textbox);
            this.button.Click += this.ButtonClicked;
            this.button.Text = "Say Hello";
            this.button.Top = 100;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            this.textbox.Text = "Hello World";
        }

        //internal void FormClicked(object sender, EventArgs e)
        //{
        //    this.Text = DateTime.Now.ToString();
        //}
    }
}
