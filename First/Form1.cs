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

namespace First
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_score(next_pic(sender, e), 1);
        }

        private void button2_click(object sender, EventArgs e)
        {
            add_score(next_pic(sender, e), 2);
        }

        private void button3_click(object sender, EventArgs e)
        {
            add_score(next_pic(sender, e), 3);
        }

        private void button4_click(object sender, EventArgs e)
        {
            add_score(next_pic(sender, e), 4);
        }

        //Returns the number of the picture
        private int next_pic(object sender, EventArgs e)
        {
            /*OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(ofd.FileName);
                pictureBox1.Image = bit;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }*/
            //One way to do it

            string[] arr = new string[] { @"C:\Users\Michael\Documents\WindowsFormPictures\Abdallah.jpg", @"C:\Users\Michael\Documents\WindowsFormPictures\Agera.jpg", @"C:\Users\Michael\Documents\WindowsFormPictures\apple.jpg", @"C:\Users\Michael\Documents\WindowsFormPictures\llama.jpg", @"C:\Users\Michael\Documents\WindowsFormPictures\Ref.jpg" };
            //Another way
            Random rnd = new Random();
            int choice = (rnd.Next())%5; //random number for the array, picks a random picture

            pictureBox1.Image = new Bitmap(arr[choice]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            return choice;
        }

        private void reset_file(string file)
        {
            System.IO.File.WriteAllText(file, "A0B0C0D0");
        }

        private void add_score(int choice, int button)
        {
            string[] arr = new string[] { @"C:\Users\Michael\Documents\WindowsFormScores\Abdallah.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Agera.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Apple.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Llama.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Ref.txt" };

            string file = arr[choice];
            StreamReader reader = new StreamReader(file);
            string input = reader.ReadLine();   //get scores
            reader.Close(); //close
            int A = input[1];
            int B = input[3];
            int C = input[5];
            int D = input[7];   //find the values of the scores
            if (button == 1)
            {
                A++;
            }
            else if (button == 2)
            {
                B++;
            }
            else if (button == 3)
            {
                C++;
            }
            else if (button == 4)
            {
                D++;
            }
            //increase score for the button that called this function

            string output = "A" + (A-48) + "B" + (B-48) + "C" + (C-48) + "D" + (D-48);
            System.IO.File.WriteAllText(file, output);//write back to the file, no append

        }

        private void reset_button(object sender, EventArgs e)
        {
            string[] arr = new string[] { @"C:\Users\Michael\Documents\WindowsFormScores\Abdallah.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Agera.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Apple.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Llama.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Ref.txt" };

            for (int i = 0; i < 5; i++)
            {
                reset_file(arr[i]);
            }

            System.IO.File.WriteAllText(@"C:\Users\Michael\Documents\WindowsFormScores\Results.csv", string.Empty);
        }

        private void print_button(object sender, EventArgs e)
        {
            StringBuilder csv = new StringBuilder();
            csv.AppendLine("Picture FileName, A, B, C, D");

            string[] arr = new string[] { @"C:\Users\Michael\Documents\WindowsFormScores\Abdallah.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Agera.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Apple.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Llama.txt", @"C:\Users\Michael\Documents\WindowsFormScores\Ref.txt" };
            int[,] ans = new int [5, 4];
            for (int i = 0; i < 5; i++)
            {
                StreamReader reader = new StreamReader(arr[i]);
                string input = reader.ReadLine();

                ans[i, 0] = input[1];
                ans[i, 1] = input[3];
                ans[i, 2] = input[5];
                ans[i, 3] = input[7];
            }
            //now the matrix of inputs is ready to be formatted to a string and printed to the CSV file
            //TODO
            string[] names = new string[] { "Abdallah", "Agera", "Apple", "Llama", "Ref" };
            for (int i = 0; i < 5; i++)
            {
                string temp = names[i] + "," + (ans[i, 0] -48) + "," + (ans[i, 1]-48) + "," + (ans[i, 2]-48) + "," + (ans[i, 3]-48);
                csv.AppendLine(temp);
            }

            System.IO.File.AppendAllText(@"C:\Users\Michael\Documents\WindowsFormScores\Results.csv", csv.ToString());

        }
    }
}
