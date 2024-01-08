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
using System.Windows.Shapes;

namespace QuizzMaker
{
    /// <summary>
    /// Interaction logic for DoExam.xaml
    /// </summary>
    public partial class DoExam : Window
    {
        FileController fileController;
        public List<Question> questions;
        public int quesIndex = 0;
        public DoExam()
        {
            questions = new List<Question>();
            fileController = new FileController();
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public List<bool> GetKey()
        {
            List<bool> keyList = new List<bool> { false, false, false, false, false, false, false };
            keyList[0] = ansAcb.IsChecked.Value;
            keyList[1] = ansBcb.IsChecked.Value;
            keyList[2] = ansCcb.IsChecked.Value;
            keyList[3] = ansDcb.IsChecked.Value;
            keyList[4] = ansEcb.IsChecked.Value;
            keyList[5] = ansFcb.IsChecked.Value;
            keyList[6] = ansGcb.IsChecked.Value;
            return keyList;
        }
        public void ShowQuestion()
        {
            questxt.Text = questions[quesIndex].question;
            List<string> anstxt = new List<string> { "", "", "", "", "", "", "" };
            for (int i = 0;i < questions[quesIndex].answer.Count(); i++)
            {
                if (questions[quesIndex].answer[i].isKey)
                {
                    anstxt[i] = RemoveFirstCharacter(questions[quesIndex].answer[i].text);
                }
                else anstxt[i] = questions[quesIndex].answer[i].text;
            }
            ansAtxt.Text = anstxt[0];
            ansBtxt.Text = anstxt[1];
            ansCtxt.Text = anstxt[2];
            ansDtxt.Text = anstxt[3];
            ansEtxt.Text = anstxt[4];
            ansFtxt.Text = anstxt[5];
            ansGtxt.Text = anstxt[6];
            ansAcb.IsChecked = false;
            ansBcb.IsChecked = false;
            ansCcb.IsChecked = false;
            ansDcb.IsChecked = false;
            ansEcb.IsChecked = false;
            ansFcb.IsChecked = false;
            ansGcb.IsChecked = false;
            for (int i = 0; i < 7; i++)
            {
                anstxt[i] = "";
            }
        }
        private void ApplyClick(object sender, RoutedEventArgs e)
        {
            bool check = true;
            for(int i = 0;i< questions[quesIndex].answer.Count();i++)
            {
                if (questions[quesIndex].answer[i].isKey != GetKey()[i]) check = false;
            }
            if (check)
            {
                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show("Incorrect");
            }
        }
        private void QuesQuantityUpdate()
        {
            quesQuantity.Text = (quesIndex + 1).ToString() + "/" + questions.Count.ToString();
        }
        private void loadbtn_Click(object sender, RoutedEventArgs e)
        {
            questions = fileController.ReadDataFromFile(filePath.Text);
            quesIndex = 0;
            QuesQuantityUpdate();
            ShowQuestion();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            if(quesIndex > 0)
            {
                quesIndex--;
                QuesQuantityUpdate();
                ShowQuestion();
            }
        }
        private void NextClick(object sender, RoutedEventArgs e)
        {
            if (quesIndex < questions.Count()-1)
            {
                quesIndex++;
                QuesQuantityUpdate();
                ShowQuestion();
            }
        }
        public void QuitClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.filePath.Text = filePath.Text;
            main.Show();
        }
        public string RemoveFirstCharacter(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
            {
                return string.Empty;
            }
            else
            {
                return input.Substring(1);
            }
        }

    }

}
