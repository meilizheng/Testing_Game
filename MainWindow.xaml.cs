using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Testing_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int right = 0;
        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();

            int randomNum1 = rnd.Next(0, 10);
            int randomNum2 = rnd.Next(0, 10);
            //int randomNum3 = rnd.Next(0, 10);
            //int randomNum4 = rnd.Next(0, 10);


            txtNum1.Text = randomNum1.ToString();
            txtNum2.Text = randomNum2.ToString();
            //txtNum3.Text = randomNum3.ToString();
            //txtNum4.Text = randomNum4.ToString();

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            int num1 = int.Parse(txtNum1.Text);
            int num2 = int.Parse(txtNum2.Text);
           
            int inputSum = int.Parse(txtSum.Text);
           
            int sum = num1 + num2;
           
            if (inputSum == sum)
            {
                lbDisplay.ClearValue(ListBox.ItemsSourceProperty);
                lbDisplay.ItemsSource = new List<string> { (num1 + "+" + num2 + "=" + inputSum).ToString() };
                Random rnd = new Random();
                int randomNum1 = rnd.Next(0, 10);
                int randomNum2 = rnd.Next(0, 10);

                txtNum1.Text = randomNum1.ToString();
                txtNum2.Text = randomNum2.ToString();
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
                lbDisplay.ItemsSource = new List<string> { "Please try again." };
            }                    
        }

        private void btnGoToNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new Window1();


            // Show the new window as a dialog window
            newWindow.ShowDialog();

            // Optionally, subscribe to the Closed event for cleanup if necessary
            newWindow.Closed += (s, args) =>
            {
                // Cleanup code if needed

                // Unsubscribe from the Closed event to avoid memory leaks
                newWindow.Closed -= (s, args) => { };
            };
        }
    }
}
