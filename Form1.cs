using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Clicker
{
    public partial class Form1 : Form
    {
        // [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        // [return: MarshalAs(UnmanagedType.Bool)]
        // private static extern bool SetCursorPos(int x, int y);

        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);
        private bool status = false;

        //для удобства использования создаем перечисление с необходимыми флагами (константами), которые определяют действия мыши: 
        [Flags]
        enum MouseFlags
        {
            Move        = 0x0001, 
            LeftDown    = 0x0002, 
            LeftUp      = 0x0004, 
            RightDown   = 0x0008,
            RightUp     = 0x0010, 
            Absolute    = 0x8000
        };
        enum Status
        {
            Stop = 0,
            Start= 1
        };
        public Form1()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //


            if (status)
            {
                timer1.Enabled = false;
                status = false;
                button1.Text = "Пуск";
            }
            else
            {
                int sec = Convert.ToInt32(textBox_Sec.Text.ToString());
                timer1.Interval = 1000 * sec;
                timer1.Enabled = true; 
                status = true;
                button1.Text = "Стоп";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_Pos_X.Text = Cursor.Position.X.ToString();
            label_Pos_Y.Text = Cursor.Position.X.ToString();

            if (button1.Text == "")
            {
                button1.Text = "Стоп";
            }
            else
            {
                button1.Text = "";
            }

            int x = Convert.ToInt32(textBox_X.Text.ToString());
            int y = Convert.ToInt32(textBox_Y.Text.ToString());

            // mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
            // клик левой кнопки мыши
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);
            
            // клик правой кнопки мыши
            //mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, x, y, 0, UIntPtr.Zero);
            //mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, x, y, 0, UIntPtr.Zero);

        }
    }
}
