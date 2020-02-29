using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class frame : Form
    {
        private List<ListViewItem> Selections;
        public frame()
        {
            InitializeComponent();
            Selections = new List<ListViewItem>();
    }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = global::Pokedex.Properties.Resources.backgroundAwake;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = global::Pokedex.Properties.Resources.backgroundSleeping;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                textBox3.Visible = true;
            }
            else
            {
                textBox3.Visible = false;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "" || this.textBox1.Text == "NOM DU POKÉMON")
            {
                this.textBox1.Text = "NOM DU POKÉMON";
                errorProvider1.SetError(textBox1, "Veuiller entrer le nom du pokémon");
                errorProvider2.SetError(textBox1, "");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                errorProvider2.SetError(textBox1, "OK");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int n;
            if(Int32.TryParse(this.textBox2.Text, out n))
            {
                if (n > 809)
                {
                    this.textBox2.Text = "NUMÉRO DU POKÉMON";
                    errorProvider1.SetError(textBox2, "Veuillez entrer un nombre entre 0 et 809");
                    errorProvider2.SetError(textBox2, "");
                }
                else
                {
                    errorProvider1.SetError(textBox2, "");
                    errorProvider2.SetError(textBox2, "OK");
                }
            }
            else
            {
                this.textBox2.Text = "NUMÉRO DU POKÉMON";
                errorProvider1.SetError(textBox2, "Veuillez entrer un nombre entre 0 et 809");
                errorProvider2.SetError(textBox2, "");
            }
            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "" || this.textBox3.Text == "DRESSEUR")
            {
                this.textBox3.Text = "DRESSEUR";
                errorProvider1.SetError(textBox3, "Veuiller entrer le nom du Dresseur");
                errorProvider2.SetError(textBox3, "");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
                errorProvider2.SetError(textBox3, "OK");
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                Selections.Add(listView1.Items[e.Index]);

                if(Selections.Count > 2)
                {
                    Selections[0].Checked = false;
                }
            }
            else
            {
                Selections.Remove(listView1.Items[e.Index]);
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "GÉNÉRATION")
            {
                errorProvider1.SetError(comboBox1, "Veuillez séléctionner une génération");
                errorProvider2.SetError(comboBox1, "");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
                errorProvider2.SetError(comboBox1, "OK");
            }
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            if(this.listView1.CheckedItems.Count == 0)
            {
                errorProvider1.SetError(listView1, "Veuillez séléctionner au moins un élément");
                errorProvider2.SetError(listView1, "");
            }
            else
            {
                errorProvider1.SetError(listView1, "");
                errorProvider2.SetError(listView1, "OK");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            textBox1_Leave(textBox1, null);
            textBox2_Leave(textBox2, null);
            comboBox1_Leave(comboBox1, null);
            listView1_Leave(listView1, null);
            if (checkBox1.Checked)
            {
                textBox3_Leave(textBox3, null);
            }

        }
    }
}
