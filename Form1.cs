using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gasm
{
    public partial class Form1 : Form
    {
        string[] gachi = new string[]
        {
            ":male_sign:AAAAHHHH$:male_sign:",
":male_sign:Fisting is 300$:male_sign:",
":male_sign:Fucking slaves:male_sign:",
":male_sign:AhhAhhAAAAHHH:male_sign:",
":male_sign:Fucking cumming:male_sign:",
":male_sign:boy next door:male_sign:",
":male_sign:deep dark fantasies:male_sign:",
":male_sign:boss in this gym:male_sign:",
":male_sign:semen:male_sign:",
":male_sign:Wooo:male_sign:",
":male_sign:What the hell are you two doing:male_sign:",
":male_sign:oh shit i'm sorry:male_sign:",
":male_sign:dungeon master:male_sign:",
":male_sign:that's amazing:male_sign:",
        }.Select(m => m.Replace(":male_sign:", "♂")).ToArray();
        public Form1()
        {
            InitializeComponent();
        }

        string replaceToGachi(string text)
        {
            List<int> rndNumbers = new List<int>();
            Random random = new Random();
            for (int i = 0; i <= text.Length - 1; i++)
            {
                rndNumbers.Add(random.Next(0, 101));
            }
            try
            {
                string[] ab = textBoxInput.Text.Split(' ');
                for (int i = 0; i <= ab.Length - 1; i++)
                {
                    if (rndNumbers[i] <= int.Parse(textBoxChance.Text))
                        if (ab[i].Length >= int.Parse(MinimalLetters.Text)) ab[i] = gachi[random.Next(0, gachi.Length)];
                }
                textBoxStatus.Text = $"Букв: {MinimalLetters.Text}\r\nШанс: {textBoxChance.Text}%";
                return string.Join(" ", ab);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = replaceToGachi(textBoxInput.Text);
        }
    }
}
