﻿using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projekt_architektura
{
    public partial class MainWindow
    {
        #region Double registers operations

        private void MovOperation(object sender, RoutedEventArgs e)
        {
            var firstReg = (Register) TwoRegistersOperationListFirst.SelectedItem;
            var secondReg = (Register) TwoRegistersOperationListSecond.SelectedItem;

            if (firstReg != null && secondReg != null)
            {
                var input = FindName("Result" + firstReg.Name);
                if (input is TextBlock inputChild) inputChild.Text = secondReg.Value;

                firstReg.Value = secondReg.Value;
            }
            else
            {
                MessageBox.Show("Wybierz oba rejestry!");
            }
        }

        private void XchgOperation(object sender, RoutedEventArgs e)
        {
            var firstReg = (Register) TwoRegistersOperationListFirst.SelectedItem;
            var secondReg = (Register) TwoRegistersOperationListSecond.SelectedItem;

            if (firstReg != null && secondReg != null)
            {
                var firstOutput = FindName("Result" + firstReg.Name);
                var secondOutput = FindName("Result" + secondReg.Name);
                var firstOutputChild = firstOutput as TextBlock;
                var secondOutputChild = secondOutput as TextBlock;

                var temp = firstReg.Value;
                if (firstOutputChild != null) firstOutputChild.Text = secondReg.Value;
                if (secondOutputChild != null) secondOutputChild.Text = temp;

                firstReg.Value = secondReg.Value;
                secondReg.Value = temp;
            }
            else
            {
                MessageBox.Show("Wybierz oba rejestry!");
            }
        }


        private void AndOperation(object sender, RoutedEventArgs e)
        {
            var firstReg = (Register) TwoRegistersOperationListFirst.SelectedItem;
            var secondReg = (Register) TwoRegistersOperationListSecond.SelectedItem;

            if (firstReg != null && secondReg != null)
            {
                var firstOutput = FindName("Result" + firstReg.Name);
                var firstOutputChild = firstOutput as TextBlock;

                var firstRegBinary = string.Join(string.Empty,
                    firstReg.Value.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                var secondRegBinary = string.Join(string.Empty,
                    secondReg.Value.Select(c =>
                        Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                var result = new StringBuilder();

                for (var i = 0; i < firstRegBinary.Length; i++)
                    if (firstRegBinary[i] == '1' && secondRegBinary[i] == '1')
                        result.Append("1");
                    else
                        result.Append("0");

                var resultHex = Convert.ToInt32(result.ToString(), 2).ToString("X");
                firstReg.Value = resultHex;

                if (resultHex.Length == 1)
                {
                    if (firstOutputChild != null) firstOutputChild.Text = "0" + resultHex.ToUpper();
                    firstReg.Value = "0" + resultHex.ToUpper();
                }
                else
                {
                    if (firstOutputChild != null) firstOutputChild.Text = resultHex.ToUpper();
                    firstReg.Value = resultHex.ToUpper();
                }
            }
            else
            {
                MessageBox.Show("Wybierz oba rejestry!");
            }
        }

        private void OrOperation(object sender, RoutedEventArgs e)
        {
            var firstReg = (Register) TwoRegistersOperationListFirst.SelectedItem;
            var secondReg = (Register) TwoRegistersOperationListSecond.SelectedItem;

            if (firstReg != null && secondReg != null)
            {
                var firstOutput = FindName("Result" + firstReg.Name);
                var firstOutputChild = firstOutput as TextBlock;

                var firstRegBinary = string.Join(string.Empty,
                    firstReg.Value.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                var secondRegBinary = string.Join(string.Empty,
                    secondReg.Value.Select(c =>
                        Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                var result = new StringBuilder();

                for (var i = 0; i < firstRegBinary.Length; i++)
                    if (!(firstRegBinary[i] == '0' && secondRegBinary[i] == '0'))
                        result.Append("1");
                    else
                        result.Append("0");

                var resultHex = Convert.ToInt32(result.ToString(), 2).ToString("X");
                firstReg.Value = resultHex;

                if (resultHex.Length == 1)
                {
                    if (firstOutputChild != null) firstOutputChild.Text = "0" + resultHex.ToUpper();
                    firstReg.Value = "0" + resultHex.ToUpper();
                }
                else
                {
                    if (firstOutputChild != null) firstOutputChild.Text = resultHex.ToUpper();
                    firstReg.Value = resultHex.ToUpper();
                }
            }
            else
            {
                MessageBox.Show("Wybierz oba rejestry!");
            }
        }

        private void XorOperation(object sender, RoutedEventArgs e)
        {
            var firstReg = (Register) TwoRegistersOperationListFirst.SelectedItem;
            var secondReg = (Register) TwoRegistersOperationListSecond.SelectedItem;

            if (firstReg != null && secondReg != null)
            {
                var firstOutput = FindName("Result" + firstReg.Name);
                FindName("Result" + secondReg.Name);
                var firstOutputChild = firstOutput as TextBlock;

                var firstRegBinary = string.Join(string.Empty,
                    firstReg.Value.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                var secondRegBinary = string.Join(string.Empty,
                    secondReg.Value.Select(c =>
                        Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                var result = new StringBuilder();

                for (var i = 0; i < firstRegBinary.Length; i++)
                    if (firstRegBinary[i] == '1' && secondRegBinary[i] == '0' ||
                        firstRegBinary[i] == '0' && secondRegBinary[i] == '1')
                        result.Append("1");
                    else
                        result.Append("0");

                var resultHex = Convert.ToInt32(result.ToString(), 2).ToString("X");
                firstReg.Value = resultHex;

                if (resultHex.Length == 1)
                {
                    if (firstOutputChild != null) firstOutputChild.Text = "0" + resultHex.ToUpper();
                    firstReg.Value = "0" + resultHex.ToUpper();
                }
                else
                {
                    if (firstOutputChild != null) firstOutputChild.Text = resultHex.ToUpper();
                    firstReg.Value = resultHex.ToUpper();
                }
            }
            else
            {
                MessageBox.Show("Wybierz oba rejestry!");
            }
        }

        private void AddOperation(object sender, RoutedEventArgs e)
        {
            var firstReg = (Register) TwoRegistersOperationListFirst.SelectedItem;
            var secondReg = (Register) TwoRegistersOperationListSecond.SelectedItem;

            if (firstReg != null && secondReg != null)
            {
                var firstOutput = FindName("Result" + firstReg.Name);
                var firstOutputChild = firstOutput as TextBlock;

                var firstRegInt = Convert.ToInt32(firstReg.Value, 16);
                var secondRegInt = Convert.ToInt32(secondReg.Value, 16);

                var result = new StringBuilder();

                var sum = firstRegInt + secondRegInt < 255
                    ? firstRegInt + secondRegInt
                    : (firstRegInt + secondRegInt) % 256;
                result.Append(sum.ToString("x"));

                firstReg.Value = result.ToString();

                if (result.Length == 1)
                {
                    if (firstOutputChild != null) firstOutputChild.Text = "0" + result.ToString().ToUpper();
                    firstReg.Value = "0" + result.ToString().ToUpper();
                }
                else
                {
                    if (firstOutputChild != null) firstOutputChild.Text = result.ToString().ToUpper();
                    firstReg.Value = result.ToString().ToUpper();
                }
            }
            else
            {
                MessageBox.Show("Wybierz oba rejestry!");
            }
        }

        private void SubOperation(object sender, RoutedEventArgs e)
        {
            var firstReg = (Register) TwoRegistersOperationListFirst.SelectedItem;
            var secondReg = (Register) TwoRegistersOperationListSecond.SelectedItem;

            if (firstReg != null && secondReg != null)
            {
                var firstOutput = FindName("Result" + firstReg.Name);
                var firstOutputChild = firstOutput as TextBlock;

                var firstRegInt = Convert.ToInt32(firstReg.Value, 16);
                var secondRegInt = Convert.ToInt32(secondReg.Value, 16);

                var result = new StringBuilder();

                var diff = firstRegInt - secondRegInt >= 0
                    ? firstRegInt - secondRegInt
                    : 256 + (firstRegInt - secondRegInt); // 256 + diff, because diff has minus sign
                result.Append(diff.ToString("x"));

                firstReg.Value = result.ToString();

                if (result.Length == 1)
                {
                    if (firstOutputChild != null) firstOutputChild.Text = "0" + result.ToString().ToUpper();
                    firstReg.Value = "0" + result.ToString().ToUpper();
                }
                else
                {
                    if (firstOutputChild != null) firstOutputChild.Text = result.ToString().ToUpper();
                    firstReg.Value = result.ToString().ToUpper();
                }
            }
            else
            {
                MessageBox.Show("Wybierz oba rejestry!");
            }
        }

        #endregion

        #region Single Register operations

        public void IncOperation(object sender, RoutedEventArgs e) // increase
        {
            var singleReg = (Register) OneRegisterOperationList.SelectedItem;

            if (singleReg != null)
            {
                var input = FindName("Result" + singleReg.Name);
                var inputChild = input as TextBlock;
                var intFromHex = int.Parse(singleReg.Value, NumberStyles.HexNumber) + 1;

                if (intFromHex == 256)
                    singleReg.Value = "0";
                else
                    singleReg.Value = intFromHex.ToString("X");

                if (singleReg.Value.Length == 1)
                {
                    if (inputChild != null) inputChild.Text = "0" + singleReg.Value.ToUpper();
                }
                else if (inputChild != null) inputChild.Text = singleReg.Value.ToUpper();
            }
            else
            {
                MessageBox.Show("Wybierz rejestr!");
            }
        }

        public void DecOperation(object sender, RoutedEventArgs e) //decrease
        {
            var singleReg = (Register) OneRegisterOperationList.SelectedItem;

            if (singleReg != null)
            {
                var input = FindName("Result" + singleReg.Name);
                var inputChild = input as TextBlock;
                var intFromHex = int.Parse(singleReg.Value, NumberStyles.HexNumber) - 1;

                if (intFromHex == -1)
                    singleReg.Value = "FF";
                else
                    singleReg.Value = intFromHex.ToString("X");

                if (singleReg.Value.Length == 1)
                {
                    if (inputChild != null) inputChild.Text = "0" + singleReg.Value.ToUpper();
                }
                else if (inputChild != null) inputChild.Text = singleReg.Value.ToUpper();
            }
            else
            {
                MessageBox.Show("Wybierz rejestr!");
            }
        }

        public void NotOperation(object sender, RoutedEventArgs e)
        {
            var singleReg = (Register) OneRegisterOperationList.SelectedItem;

            if (singleReg != null)
            {
                var input = FindName("Result" + singleReg.Name);
                var inputChild = input as TextBlock;
                var binaryString = string.Join(string.Empty,
                    singleReg.Value.Select(c =>
                        Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                var binaryNot = string.Concat(binaryString.Select(x => x == '0' ? '1' : '0'));

                singleReg.Value = Convert.ToInt32(binaryNot, 2).ToString("X");

                if (singleReg.Value.Length == 1)
                {
                    if (inputChild != null) inputChild.Text = "0" + singleReg.Value.ToUpper();
                }
                else if (inputChild != null) inputChild.Text = singleReg.Value.ToUpper();
            }
            else
            {
                MessageBox.Show("Wybierz rejestr!");
            }
        }

        public void NegOperation(object sender, RoutedEventArgs e)
        {
            var singleReg = (Register) OneRegisterOperationList.SelectedItem;

            if (singleReg != null)
            {
                var input = FindName("Result" + singleReg.Name);
                var inputChild = input as TextBlock;

                NotOperation(sender, e);
                IncOperation(sender, e);

                if (singleReg.Value.Length == 1)
                {
                    if (inputChild != null) inputChild.Text = "0" + singleReg.Value.ToUpper();
                }
                else if (inputChild != null) inputChild.Text = singleReg.Value.ToUpper();
            }
            else
            {
                MessageBox.Show("Wybierz rejestr!");
            }
        }

        #endregion

        #region All registers random movall clear

        private void MovAllOperation(object sender, RoutedEventArgs e)
        {
            foreach (var reg in Registers)
            {
                var input = FindName(reg.Name);
                var inputChild = input as TextBox;

                var output = FindName("Result" + reg.Name);
                var outputChild = output as TextBlock;

                if (inputChild != null && !string.IsNullOrWhiteSpace(inputChild.Text))
                {
                    if (Utils.HexValidator(inputChild.Text.ToUpper()))
                    {
                        inputChild.BorderBrush = Brushes.Green;
                        inputChild.BorderThickness = new Thickness(2);

                        if (inputChild.Text.Length == 1) inputChild.Text = "0" + inputChild.Text.ToUpper();
                        reg.Value = inputChild.Text.ToUpper();
                        if (outputChild != null) outputChild.Text = inputChild.Text.ToUpper();
                    }
                    else
                    {
                        inputChild.BorderBrush = Brushes.Red;
                        inputChild.BorderThickness = new Thickness(1.5);
                    }
                }
                else
                {
                    if (outputChild != null) outputChild.Text = "00";
                }
            }
        }

        public void ClearOperation(object sender, RoutedEventArgs e)
        {
            foreach (var reg in Registers)
            {
                var input = FindName(reg.Name);
                var inputChild = input as TextBox;
                if (inputChild == null) continue;
                inputChild.Text = "";
                inputChild.ClearValue(Border.BorderBrushProperty);
                inputChild.ClearValue(Border.BorderThicknessProperty);
            }
        }

        public void RandomOperation(object sender, RoutedEventArgs e)
        {
            foreach (var reg in Registers)
            {
                var input = FindName(reg.Name);
                var inputChild = input as TextBox;
                if (inputChild == null) continue;
                inputChild.ClearValue(Border.BorderBrushProperty);
                inputChild.ClearValue(Border.BorderThicknessProperty);
                inputChild.Text = Utils.RandomHexGenerator8Bit();
            }
        }


        #endregion

        #region Memory operations

        public void CheckMemoryAddress(object sender, RoutedEventArgs e)
        {
            object input = ChooseMemoryAddressName;
            TextBlock inputChild = input as TextBlock;

            // Memory test = (Memory)MemoryAddresses.Select(x => x.Name);
            // var test2 = from entry in MemoryAddresses select entry.Name;
            // MessageBox.Show(test.Value);
            var t = MemoryAddresses.First(l => l.Name == inputChild.Text);

        }
        public void PerformDirectAddressing(object sender, RoutedEventArgs e)
        {
            var toReg = (Register) DirectAddressingToRegister.SelectedItem;
            var fromMemoryObj = FindName("DirectAddressingFromMemory");
            var fromMemory = fromMemoryObj as TextBox;

            if (toReg != null && !string.IsNullOrWhiteSpace(fromMemory.Text))
            {
                if (Utils.HexValidator(fromMemory.Text.ToUpper()))
                {
                    fromMemory.BorderBrush = Brushes.DarkGray;
                    fromMemory.BorderThickness = new Thickness(1);

                    var memoryAddress = MemoryAddresses.First(x => x.Name == fromMemory.Text);
                    toReg.Value = memoryAddress.Value;

                    var input = FindName("Result" + toReg.Name);
                    if (input is TextBlock inputChild) inputChild.Text = memoryAddress.Value;
                }
                else
                {
                    fromMemory.BorderBrush = Brushes.Red;
                    fromMemory.BorderThickness = new Thickness(1.5);
                }
            }

            var fromReg = (Register) DirectAddressingFromRegister.SelectedItem;
            var toMemoryObj = FindName("DirectAddressingToMemory");
            var toMemory = toMemoryObj as TextBox;
            
            if (fromReg != null && !string.IsNullOrWhiteSpace(toMemory.Text))
            {
                if (Utils.HexValidator(toMemory.Text.ToUpper()))
                {
                    toMemory.BorderBrush = Brushes.DarkGray;
                    toMemory.BorderThickness = new Thickness(1);

                    var memoryAddress = MemoryAddresses.First(x => x.Name == toMemory.Text);
                    memoryAddress.Value = fromReg.Value;
                }
                else
                {
                    toMemory.BorderBrush = Brushes.Red;
                    toMemory.BorderThickness = new Thickness(1.5);
                }
            }
        }
        
        #endregion
    }
}