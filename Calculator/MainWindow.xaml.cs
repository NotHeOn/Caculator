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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double sum = 0;
        bool blnClear = false;
        bool IsError = false;
        string strOper = "+";
        public MainWindow()
        {
            InitializeComponent();
        }

        //数字输入
        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsError) { ClearAll(); }
            if (strOper == "=") { ClearAll(); }
            if (blnClear)
            {
                textbox1.Text = "0";
                blnClear = false;
            }
            Button b = (Button)sender;
            if (textbox1.Text != "0")
                textbox1.Text += b.Content;
            else
                textbox1.Text = b.Content.ToString();
        }

        //小数点输入
        private void DotBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsError) { ClearAll(); }
            if (strOper == "=") { ClearAll(); }
            if (blnClear)
            {
                textbox1.Text = "0";
                blnClear = false;
            }
            int n = textbox1.Text.IndexOf(".");
            if (n == -1)
                textbox1.Text = textbox1.Text + ".";
        }

        //符号运算
        private void CalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsError) { ClearAll(); }
            double dbSecond = Convert.ToDouble(textbox1.Text);
            if (!blnClear)
                switch (strOper)
                {
                    case "+":
                        sum += dbSecond;
                        break;
                    case "-":
                        sum -= dbSecond;
                        break;
                    case "*":
                        sum *= dbSecond;
                        break;
                    case "/":
                        if(dbSecond == 0) { IsError = true; }
                        else { sum /= dbSecond; }
                        break;
                }
            if (sender == AddBtn)
                strOper = "+";
            if (sender == SubBtn)
                strOper = "-";
            if (sender == MulBtn)
                strOper = "*";
            if (sender == DivBtn)
                strOper = "/";
            if (sender == EquBtn)
                strOper = "=";
            if (IsError) { textbox1.Text = "Error!"; }
            else 
            { 
                if (Convert.ToString(sum) == "-0") { sum = -sum; }
                textbox1.Text = Convert.ToString(sum);
            }
            blnClear = true;
        }

        //归零
        private void CleBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        //归零函数
        private void ClearAll()
        {
            textbox1.Text = "0";
            sum = 0;
            blnClear = false;
            IsError = false;
            strOper = "+";
        }
    }
}
