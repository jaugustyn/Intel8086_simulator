﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

namespace Projekt_architektura
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public List<Register> registers = new List<Register>();
        public MainWindow()
        {
            InitializeComponent();

            registers.Add(new Register { OneRegister = "AH", Value = "00" });
            registers.Add(new Register { OneRegister = "BH", Value = "00" });
            registers.Add(new Register { OneRegister = "CH", Value = "00" });
            registers.Add(new Register { OneRegister = "DH", Value = "00" });
            registers.Add(new Register { OneRegister = "AL", Value = "00" });
            registers.Add(new Register { OneRegister = "BL", Value = "00" });
            registers.Add(new Register { OneRegister = "CL", Value = "00" });
            registers.Add(new Register { OneRegister = "DL", Value = "00" });

            firstRegisterList.ItemsSource = registers;
            secondRegisterList.ItemsSource = registers;
        }

        private void Button_Registry(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            
        }

        private void MOV_Operation(object sender, RoutedEventArgs e)
        {

        }
        private void XCHG_Operation(object sender, RoutedEventArgs e)
        {

        }
        private void MOVALL_Operation(object sender, RoutedEventArgs e)
        {
            foreach (var reg in registers)
            {
                object input = FindName(reg.OneRegister);
                TextBox inputChild = input as TextBox;

                object output = FindName("result" + reg.OneRegister);
                TextBlock outputChild = output as TextBlock;
                
                if (!String.IsNullOrWhiteSpace(inputChild.Text))
                {
                    if (Register.HexValidator(inputChild.Text.ToUpper()))
                    {
                        inputChild.BorderBrush = System.Windows.Media.Brushes.Green;
                        inputChild.BorderThickness = new System.Windows.Thickness(2);

                        if (inputChild.Text.Length == 1)
                        {
                            inputChild.Text = "0" + inputChild.Text.ToUpper();
                        }
                        reg.Value = inputChild.Text.ToUpper();
                        outputChild.Text = inputChild.Text.ToUpper();

                    }
                    else
                    {
                        //MessageBox.Show("Register " + reg.OneRegister + " has wrong value. Please enter hexadecimal code");
                        //inputChild.Text = "";
                        inputChild.BorderBrush = System.Windows.Media.Brushes.Red;
                        inputChild.BorderThickness = new System.Windows.Thickness(1.5);
                    }
                }
                else
                {
                    outputChild.Text = "00";
                }

            }
        }
    }

    public class Register
    {
        public string OneRegister { get; set; }
        public string Value { get; set; }

        public static bool HexValidator(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!((input[i] >= '0' && input[i] <= '9') || input[i] >= 'A' && input[i] <= 'F'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
