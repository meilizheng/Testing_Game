using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Testing_Game
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    public partial class Window1 : Window
    {
        int right = 0;
        public Window1()
        {
            InitializeComponent();
            Random rand = new Random();
            int num3 = rand.Next(0, 10);
            int num4 = rand.Next(0, 10);
            if(num3 < num4)
            {
                int temp = num3;
                num3 = num4;
                num4 = temp;
            }
            txtNum3.Text = num3.ToString();
            txtNum4.Text = num4.ToString();
        }   

        private void butSubSubmit_Click(object sender, RoutedEventArgs e)
        {
            int Num3 = int.Parse(txtNum3.Text);
            int Num4 = int.Parse(txtNum4.Text);
            
                int subResult = Num3 - Num4;
                int inputResult = int.Parse(txtSubResult.Text);

                if (subResult == inputResult)
                {
                    lbSubtractResult.ClearValue(ListBox.ItemsSourceProperty);
                    lbSubtractResult.ItemsSource = new List<string> { (Num3 + "-" + Num4 + "=" + subResult).ToString() };
                    Random rnd = new Random();
                    int randomNum1 = rnd.Next(0, 10);
                    int randomNum2 = rnd.Next(0, 10);

                if (randomNum1 < randomNum2)
                {
                    int temp = randomNum1;
                    randomNum1 = randomNum2;
                    randomNum2 = temp;
                }

                    txtNum3.Text = randomNum1.ToString();
                    txtNum4.Text = randomNum2.ToString();
                    right++;
                    if (right >= 8)
                    {
                        MessageBox.Show("Congratulations! you passed the exam!");            
                        SoundPlayer sound = new SoundPlayer(@"C:\Users\belle\Documents\cheering.wav");
                        sound.Play();            
                    }
                }
                else
                {
                    lbSubtractResult.ItemsSource = new List<string> { "Please try again." };
                }
        }                   
    }
}
