using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Wpfpgm1
{
    public partial class MainWindow : Window
    {
        private readonly string outputFilePath = "output.txt";

        public MainWindow()
        {
            InitializeComponent();
            input1.AcceptsReturn = true; 
            input1.TextChanged += Input1_TextChanged;
                 
        }

        private void Input1_TextChanged(object sender, TextChangedEventArgs e)
        {

            string inputText = input1.Text;
           
            if (inputText.Contains("STOP"))
            {
                File.WriteAllText(outputFilePath, inputText.Split(new string[] { "STOP" }, StringSplitOptions.None)[0]);
                MessageBox.Show("Input saved successfully!", "Success");
                input1.IsEnabled = false;
              
            }
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            output.Text = File.ReadAllText(outputFilePath);
            output.IsEnabled = false;
            
        }
    }
}
