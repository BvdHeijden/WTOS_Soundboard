using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTOS_Soundboard
{
    public partial class Form1 : Form
    {
        private SoundPlayer Player = null;

        public Form1()
        {
            InitializeComponent();

            button1.Tag = Properties.Resources.door;
            button2.Tag = Properties.Resources.michelis;
            button3.Tag = Properties.Resources.wahoo;
            button4.Tag = Properties.Resources.witte;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Control btn = sender as Control;

            foreach ( Control b in this.Controls)
            {
                b.BackColor = Color.LightGray;
            }
            btn.BackColor = Color.Aqua;
            PlayWav(btn.Tag as Stream);
        }

        private void PlayWav(Stream stream)
        {
            if (Player != null)
            {
                Player.Stop();
                Player.Dispose();
                Player = null;
            }

            if (stream == null) return;

            Player = new SoundPlayer(stream);

            Player.Play();

        }
    }
}
