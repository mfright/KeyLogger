using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyLogger1
{
    public partial class Form1 : Form
    {

        static ListBox listbox2;
        static Color buttonColor;
        static Boolean recording = false;
        static logWriter logwriter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //staticな参照に渡すことで、コールバックから操作する
            listbox2 = listBoxLogs;
            logwriter = new logWriter();
            

            // initialize both classes
            KeyboardHook keyboardHook = new KeyboardHook();

            // add as many events as you like
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);

            // install hooks
            keyboardHook.Install();
        }

        private static void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            Console.WriteLine(key.ToString());

            listbox2.Items.Add(key.ToString());
            listbox2.TopIndex = listbox2.Items.Count - 1;

            if (recording)
            {
                logwriter.write(key.ToString());
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (recording)
            {
                btnRecord.BackColor = buttonColor;
                btnRecord.Text = "Record to \"logs.txt\"";
                logwriter.close();
                recording = false;
            }
            else
            {
                buttonColor = btnRecord.BackColor;
                btnRecord.BackColor = Color.Yellow;
                btnRecord.Text = "Recording to \"logs.txt\" ";
                logwriter.init();
                recording = true;
            }
        }
    }
}
