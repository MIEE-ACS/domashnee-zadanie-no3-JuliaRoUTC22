using System;
using System.Collections.Generic;
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

namespace Wpf_homework_3
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_code_Click(object sender, RoutedEventArgs e)
        {
            string text = Convert.ToString(tbA.Text);
          
            int key = Convert.ToInt32(tbK.Text);

            if (key >= 0)
            {

                const string alphabet_cyrillic = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                const string alphabet_latin = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                string alphabet;
                if (cmbx.SelectedIndex == 1)
                { 
                   alphabet = alphabet_cyrillic;
                }

                else if (cmbx.SelectedIndex == 2)
                {
                    alphabet = alphabet_latin;
                }

                else
                {
                   MessageBox.Show("Язык не выбран! Пожалуйста, выберите язык.");
                    return;
                }

                var fullAlphabet = alphabet + alphabet.ToLower();
                var letterQuantity = fullAlphabet.Length;
                var code = "";
                for (int i = 0; i < text.Length; i++)
                {
                    var symbol = text[i];
                    var index = fullAlphabet.IndexOf(symbol);
                    if (index < 0)
                    {
                        code += symbol.ToString(); //если символ не найден, его не меняем
                    }
                    else
                    {
                        var code_Index = (letterQuantity + index + key) % letterQuantity;
                        code += fullAlphabet[code_Index];
                    }
                }

                tbB.Text = String.Format($"{code}");
                tbB.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("Некорректно введён ключ! Сдвиг должен быть неотрицательным.");
            }

        }

     
    }
}
