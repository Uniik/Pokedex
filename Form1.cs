using System;
using System.Collections;
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
        public List<ListViewItem> Selections;
        private Hashtable pokeList;
        private bool male = true; // le pokémon est un male par défaut
        public frame()
        {
            InitializeComponent();
            Selections = new List<ListViewItem>();
            pokeList = new Hashtable();
            // boutton male séléctionné par défaut
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 4;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // male séléctionné
        private void button1_Click(object sender, EventArgs e)
        {
            male = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(180)))));
            this.button2.FlatAppearance.BorderSize = 1;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 4;
        }

        // femelle selectionné
        private void button2_Click(object sender, EventArgs e)
        {
            male = false;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 1;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(180)))));
            this.button2.FlatAppearance.BorderSize = 4;
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

                if (pokeList.ContainsKey(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "Un autre pokémon porte déja ce numéro");
                    errorProvider2.SetError(textBox2, "");
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

        // boutton enregistrer cliqué
        private void button4_Click(object sender, EventArgs e)
        {
            bool validated = true;
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

            foreach (Control ctrl in panel2.Controls)
            {
                // The child or one of its children has an error.
                if (errorProvider1.GetError(ctrl) != "")
                    validated = false;
            }
            if (validated)
            {
                Pokemon pokemon;
                if (Selections.Count == 1)
                {
                    Console.WriteLine("the test" + Selections[0].ImageIndex);
                    pokemon = new Pokemon(textBox1.Text, male, comboBox1.SelectedIndex + 1, textBox3.Text, Selections[0].ImageIndex);
                }
                else
                {
                    pokemon = new Pokemon(textBox1.Text, male, comboBox1.SelectedIndex + 1, textBox3.Text, Selections[0].ImageIndex, Selections[1].ImageIndex);
                }
                pokeList.Add(textBox2.Text, pokemon);
                reloadStats(pokemon);
                disableErrorsProviders();
                panel3.Visible = true;
                cleanAll();
            }

        }

        private void reloadStats(Pokemon pokemon)
        {
            label5.Text = pokemon.Nom;
            label7.Text = "(" + pokemon.Generation.ToString() + ")";
            label9.Text = pokemon.Dresseur;
            if (pokemon.Male)
            {
                pictureBox1.BackgroundImage = global::Pokedex.Properties.Resources.Male;
            }
            else
            {
                pictureBox1.BackgroundImage = global::Pokedex.Properties.Resources.Female;

            }
            pictureBox2.Image = imageList1.Images[pokemon.Element1Index];
            if(pokemon.Element2Index > -1)
            {
                pictureBox3.Image = imageList1.Images[pokemon.Element2Index];
            }
            progressBar1.Value = pokemon.HP1;
            textBox4.Text = pokemon.HP1.ToString();
            progressBar2.Value = pokemon.Attack1;
            textBox5.Text = pokemon.Attack1.ToString();
            progressBar3.Value = pokemon.Defense1;
            textBox6.Text = pokemon.Defense1.ToString();
            progressBar4.Value = pokemon.Speed1;
            textBox7.Text = pokemon.Speed1.ToString();
            progressBar5.Value = pokemon.TotalStats1;
            textBox8.Text = pokemon.TotalStats1.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void disableErrorsProviders()
        {
            foreach (Control ctrl in panel2.Controls)
            {
                errorProvider1.SetError(ctrl, "");
                errorProvider2.SetError(ctrl, "");
            }
        }

        private void cleanAll()
        {
            textBox1.Text = "NOM DU POKÉMON";
            textBox2.Text = "NUMÉRO DU POKÉMON";
            textBox3.Text = "DRESSEUR";
            comboBox1.SelectedItem = null;
            comboBox1.Text = "GÉNÉRATION";
            checkBox1.Checked = false;
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }

            button1_Click(null, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pokeList.ContainsKey(textBox9.Text))
            {
                reloadStats((Pokemon)pokeList[textBox9.Text]);
                textBox9.Text = "NUM";
                panel3.Visible = true;
            }
            else
            {
                errorProvider1.SetError(button6, "Le numéro entré est introuvable");
            }
        }
    }





}
