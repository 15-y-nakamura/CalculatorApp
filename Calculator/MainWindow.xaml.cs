using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
        public partial class MainWindow : Window
        {
            string disp = "0";
            int rem = 0;
            int memory = 0;
            int memoryrem = 0;
            double memorydouble = 0;
            string op = "";
            int i = 0;
            bool b = true;
             bool rems = true;
        bool divFlag = false;
        int usememory = 0;
        double usememorydouble = 0;
            public MainWindow()
            {
                InitializeComponent();
                lblDisplay.Content = disp;
                subDisplay.Content = memory;

            }

            private void ResetAllButtonColors()
            {
                for (int i = 0; i < MainGrid.Children.Count; i++)
                {
                    if (MainGrid.Children[i] is Button btn)
                    {
                        btn.ClearValue(Button.BackgroundProperty);
                    }
                }//グリッドの中にあるオブジェクトの数分グリッドのプロパティを初期化しています。
            }





            private void one_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();//ボタンの色を初期化
                if (disp == "0")
                { disp = "1"; }
                else
                { disp += "1"; }
                lblDisplay.Content = disp;
                one.Background = Brushes.LightBlue;
            }
            private void two_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();
                if (disp == "0")
                { disp = "2"; }
                else
                { disp += "2"; }
                lblDisplay.Content = disp;
                two.Background = Brushes.LightBlue;
            }

            private void three_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();
                if (disp == "0")
                { disp = "3"; }
                else
                { disp += "3"; }
                lblDisplay.Content = disp;
                three.Background = Brushes.LightBlue;
            }

            private void four_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();
                if (disp == "0")
                { disp = "4"; }
                else
                { disp += "4"; }
                lblDisplay.Content = disp;
                four.Background = Brushes.LightBlue;
            }

            private void five_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();
                if (disp == "0")
                { disp = "5"; }
                else
                { disp += "5"; }
                lblDisplay.Content = disp;
                five.Background = Brushes.LightBlue;
            }

            private void six_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();
                if (disp == "0")
                { disp = "6"; }
                else
                { disp += "6"; }
                lblDisplay.Content = disp;
                six.Background = Brushes.LightBlue;
            }

            private void seven_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();
                if (disp == "0")
                { disp = "7"; }
                else
                { disp += "7"; }
                lblDisplay.Content = disp;
                seven.Background = Brushes.LightBlue;
            }

            private void eight_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();
                if (disp == "0")
                { disp = "8"; }
                else
                { disp += "8"; }
                lblDisplay.Content = disp;
                eight.Background = Brushes.LightBlue;
            }

            private void nine_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                ResetAllButtonColors();
                if (disp == "0")
                { disp = "9"; }
                else
                { disp += "9"; }
                lblDisplay.Content = disp;
                nine.Background = Brushes.LightBlue;
            }

            private void zero_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                if (disp != "0")
                {
                    ResetAllButtonColors();
                    disp = disp + "0";
                    lblDisplay.Content = disp;
                    zero.Background = Brushes.LightBlue;
                }
                else { return; }
            }

            private void double_zero_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length >= 8)
                {
                    disp = "ERROR";
                    lblDisplay.Content = disp;
                    return;
                }
                if (disp == "ERROR")
                { disp = "0"; }
                if (disp != "0")
                {
                    ResetAllButtonColors();
                    disp = disp + "00";
                    lblDisplay.Content = disp;
                    double_zero.Background = Brushes.LightBlue;
                }
                else { return; }
            }
            private void Calc()
            {
                if (disp == "ERROR") { return; }
                else if (b == true)
                {
                    if (op == "+")
                    {
                        memory += int.Parse(disp);
                        memorydouble += double.Parse(disp);
                    }
                    else if (op == "-")
                    {
                        memory -= int.Parse(disp);
                        memorydouble -= double.Parse(disp);
                    }
                    else if (op == "*")
                    {
                        memory *= int.Parse(disp);
                        memorydouble *= double.Parse(disp);
                    }
                    else if (op == "/")
                    {
                        memory /= int.Parse(disp);
                        memorydouble /= double.Parse(disp);
                        rem %= int.Parse(disp);
                    divFlag = true;
                    only.Content = "小数";
                        i = 1;
                    }
                }
                else
                {

                    if (op == "+")
                    {
                        memorydouble += double.Parse(disp);
                    }
                    else if (op == "-")
                    {
                        memorydouble -= double.Parse(disp);
                    }
                    else if (op == "*")
                    {
                        memorydouble *= double.Parse(disp);
                    }
                    else if (op == "/")
                    {
                        memorydouble /= double.Parse(disp);
                        divFlag = true;
                        only.Content = "小数";
                        i = 1;
                    }
                }

            }
            //＋
            private void plus_Click(object sender, RoutedEventArgs e)
            {
            divFlag = false;
                if (rems == false)
                {
                    memory = rem;
                    rems = true;
                }
                if (disp == "ERROR") { return; }
                else if (disp != "0" || memory != 0)
                {
                    if (op == "" && disp != "0")
                    {
                        if (b == true)
                        {
                            memory += (int.Parse(disp));
                            memorydouble += double.Parse(disp);
                        }
                        else
                        {
                            memorydouble += double.Parse(disp);
                        }
                    }
                    else if (op != "" && disp != "0")
                    { Calc(); }
                    else { return; }
                    if (b == true)
                    {
                        subDisplay.Content = memory;
                        disp = "0";
                        op = "+";
                        lblDisplay.Content = disp;
                    }
                    else
                    {
                        subDisplay.Content = memorydouble;
                        disp = "0";
                        op = "+";
                        lblDisplay.Content = disp.ToString();
                    }
                }
                else { return; }
            }
            //-
            private void minus_Click(object sender, RoutedEventArgs e)
            {
            divFlag = false;
                if (rems == false)
                {
                    memory = rem;
                    rems = true;
                }
            if (disp == "ERROR") { return; }
            else if (disp != "0" && op == "")
            {
                if (b == true)
                {
                    memory += int.Parse(disp);
                    memorydouble += double.Parse(disp);
                }
                else { memorydouble += double.Parse(disp); }
                disp = "0";
                op = "-";
            }
            else if (disp != "0" && disp != "-" && op != "")
            {
                Calc();
                disp = "-";
            }
            else if (disp == "0")
            {
                disp = "-";


                if (op != "*" && op != "/")
                {
                    op = "+";
                }
            }
            else { return; }
             lblDisplay.Content = disp; 

            
            
                if (b)
            {
                subDisplay.Content = memory;
            }
            else { subDisplay.Content = memorydouble; }
        }

            private void multiply_Click(object sender, RoutedEventArgs e)
            {
            divFlag = false;
                if (rems == false)
                {
                    memory = rem;
                    rems = true;
                }
                if (disp == "ERROR") { return; }
                else if (disp != "0" || memory != 0)
                {
                    if (op == "" && disp != "0")
                    {
                        if (b == true)
                        {
                            memory += int.Parse(disp);
                            memorydouble += double.Parse(disp);
                        }
                        else { memorydouble += double.Parse(disp); }
                    }
                    else if (op != "" && disp != "0")
                    { Calc(); }
                    else { return; }
                    if (b == true)
                    {
                        subDisplay.Content = memory;
                    }
                    else { subDisplay.Content = memorydouble; ; }
                    disp = "0";
                    op = "*";
                    lblDisplay.Content = disp;
                }
                else if (memory != 0)
                {
                    op = "*";
                }
                else { return; }
            }
            private void division_Click(object sender, RoutedEventArgs e)
            {
            
                if (rems == false)
                {
                    memory = rem;
                    rems = true;
                }
                if (disp == "ERROR") { return; }
                else if (disp != "0" || memory != 0)
                {
                    if (op == "" && disp != "0")
                    {
                        if (b == true)
                        {
                            memory += int.Parse(disp);
                            memorydouble += double.Parse(disp);
                            rem += int.Parse(disp);
                        }
                        else
                        {
                            memorydouble += double.Parse(disp);
                        }
                    }
                    else if (op != "" && disp != "0")
                    { Calc(); }
                    else { return; }
                    if (memory != 0 || memorydouble != 0)
                    {
                        if (b == true)
                        {
                            subDisplay.Content = memory;
                        }
                        else { subDisplay.Content = memorydouble; }
                        disp = "0";
                        op = "/";
                        lblDisplay.Content = disp;
                    }
                }
                else if (memory != 0)
                {
                    op = "/";
                }
                else { return; }

            }
            private void equal_Click(object sender, RoutedEventArgs e)
            {
                if (disp == "ERROR") { return; }
                else if (op != "" && b == true && disp != "0" && disp != "-")
                {
                    Calc();
                    disp = memory.ToString();
                    if (disp.Length <= 8)
                    {
                        lblDisplay.Content = disp;
                        subDisplay.Content = memory;
                        op = "";
                        disp = "0";
                    }
                    else
                    {
                        disp = "ERROR";
                        lblDisplay.Content = disp;
                    }
                }

                else if (b == false)
                {
                    Calc();
                    disp = memorydouble.ToString("0.#######");
                    lblDisplay.Content = disp;
                    subDisplay.Content = memorydouble.ToString("0.#######");
                    op = "";
                    disp = "0";
                }
                else
                {
                    if (memory != 0)
                    {
                        disp = memory.ToString();
                        lblDisplay.Content = disp;
                    }
                }
                return;
            }


            private void clear_Click(object sender, RoutedEventArgs e)
            {
                disp = "0";
                lblDisplay.Content = disp;
                ResetAllButtonColors();
            }

            private void all_clear_Click(object sender, RoutedEventArgs e)
            {
                disp = "0";
                lblDisplay.Content = disp;
                memory = 0;
                op = "";
                subDisplay.Content = memory;
                b = true;
                i = 0;
                only.Content = "除算後";
                memorydouble = 0;
                rem = 0;
                ResetAllButtonColors();
                rems = true;
            divFlag = false;
            }

            private void back_space_Click(object sender, RoutedEventArgs e)
            {
                if (disp.Length == 1 && disp != "-")
                {
                    disp = "0";
                    lblDisplay.Content = disp;
                }
                else if (disp.Length > 0)
                {
                    disp = disp.Substring(0, disp.Length - 1);
                    lblDisplay.Content = disp;
                }
                else { return; }
                ResetAllButtonColors();
            }

            private void only_Click(object sender, RoutedEventArgs e)
            {
            if (divFlag==false) 
            { return; }
            else
            {
                i++;
                if (i == 1)
                {
                    b = false;
                    if (memory == 0)
                    { disp = "0"; }
                    else
                    { disp = memory.ToString("########"); }
                    subDisplay.Content = memory;
                    only.Content = "小数";
                }
                if (i == 2)
                {
                    b = false;
                     disp= memorydouble.ToString("0.#######");
                    lblDisplay.Content=disp;
                    subDisplay.Content = memorydouble;
                    only.Content = "余り";
                }
                else if (i == 3)
                {
                    rems = false;
                    b = true;
                    disp = rem.ToString("#######0");
                    lblDisplay.Content = disp;
                    subDisplay.Content = rem;
                    only.Content = "整数";
                    i = 0;
                }
                lblDisplay.Content = disp;
            }
                
            }

            private void decimal_point_Click(object sender, RoutedEventArgs e)
            {
                if (b == true)
                {
                if (disp == "-")
                { disp += "0"; }
                    b = false;
                    disp += ".";
                    lblDisplay.Content = disp;
                }
                else if (!disp.Contains("."))
                {
                    disp += ".";
                    lblDisplay.Content = disp;
                }
                else
                { return; }
            }

            private void plus_minus_Click(object sender, RoutedEventArgs e)
            {
                if (disp != "0" && disp[0] != '-')
                {
                    disp = "-" + disp;
                    lblDisplay.Content = disp;
                }
                else if (disp != "0" && disp[0] == '-')
                {
                    disp = disp.Substring(1);
                    lblDisplay.Content = disp;
                }
                else { return; }
            }

        private void memory_plus_Click(object sender, RoutedEventArgs e)
        {
            if (disp != "" && int.TryParse(disp, out int memoryi)) 
            { usememory += memoryi; }
            else if (disp != "" && double.TryParse(disp, out double d))
            { usememorydouble += d; }
            else { return; }
        }       

        private void memory_resource_Click(object sender, RoutedEventArgs e)
        {
            if (usememory == 0 && usememorydouble==0)
            {
                disp = "0";
            }
            else if(usememory!=0)
            {
                disp = usememory.ToString();
            }
            else
            {
                disp = usememorydouble.ToString();
            }
           
            lblDisplay.Content = disp;
        }

        private void memory_clear_Click(object sender, RoutedEventArgs e)
        {
            usememory = 0;
            usememorydouble = 0;
        }
    }
    }
