using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Projekt_architektura
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Memory> MemoryAdresses = new();
        public List<Register> Registers = new();

        public MainWindow()
        {
            InitializeComponent();
            var registerNames = new[] {"AH", "BH", "CH", "DH", "AL", "BL", "CL", "DL"};
            for (var i = 0; i < registerNames.Length; i++)
                Registers.Add(new Register {Name = registerNames[i], Value = "00"});

            // firstRegisterList.ItemsSource = Registers;
            // secondRegisterList.ItemsSource = Registers;
            // singleRegisterList.ItemsSource = Registers;

            for (var i = 0; i < 65536; i++) //65 536 => 64KB
                MemoryAdresses.Add(new Memory {Name = i.ToString("X"), Value = "0000"});
        }
        // public void checkMemoryAddress(object sender, RoutedEventArgs e)
        // {
        //     object input = memoryAdressName;
        //     TextBlock inputChild = input as TextBlock;
        //
        //     Memory test = (Memory)memoryAdresses.Select(x => x.Name);
        //     var test2 = from entry in memoryAdresses select entry.Name;
        //     MessageBox.Show(test.Value);
        //     memoryAdresses.First(l => l.Name == "nazwa");
        //
        // }

        public class Register
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public static bool HexValidator(string input)
            {
                for (var i = 0; i < input.Length; i++)
                    if (!(input[i] >= '0' && input[i] <= '9' || input[i] >= 'A' && input[i] <= 'F'))
                        return false;
                return true;
            }

            public static string RandomHexGenerator()
            {
                const string chars = "0123456789ABCDEF";
                var rand = new Random();
                return new string(Enumerable.Repeat(chars, 2).Select(s => s[rand.Next(s.Length)]).ToArray());
            }
        }

        public class Memory
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}