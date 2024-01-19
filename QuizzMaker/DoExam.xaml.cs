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
        Random rand;
        public DoExam()
        {
            questions = new List<Question>();
            fileController = new FileController();
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            PreviewKeyDown += DoExam_PreviewKeyDown;
            rand = new Random();
        }
        private void DoExam_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                if (quesIndex < questions.Count() - 1)
                {
                    quesIndex++;
                    QuesQuantityUpdate();
                    ShowQuestion();
                }
            }
            if (e.Key == Key.Left)
            {
                if (quesIndex > 0)
                {
                    quesIndex--;
                    QuesQuantityUpdate();
                    ShowQuestion();
                }
            }
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
            List<bool> ansIsKey = new List<bool> { false, false, false, false, false, false, false };
            for (int i = 0; i < questions[quesIndex].answer.Count(); i++)
            {
                if (questions[quesIndex].answer[i].isKey)
                {
                    anstxt[i] = i.ToString() + RemoveFirstCharacter(questions[quesIndex].answer[i].text);
                }
                else anstxt[i] = i.ToString() + questions[quesIndex].answer[i].text;
                ansIsKey[i] = questions[quesIndex].answer[i].isKey;
            }
            List<string> filteredAns = new List<string>();
            for (int i = 0; i < anstxt.Count(); i++)
            {
                if (anstxt[i] != "")
                {
                    filteredAns.Add(anstxt[i]);
                }
            }
            filteredAns = filteredAns.OrderBy(x => rand.Next()).ToList();
            List<Answer> temp = new List<Answer>();
            for (int i = 0;i<filteredAns.Count(); i++)
            {
                temp.Add(new Answer { text = filteredAns[i], isKey = false});

                for (int j = 0; j < questions[quesIndex].answer.Count(); j++)
                {
                    if (filteredAns[i].ElementAt(0) == anstxt[j].ElementAt(0))
                    {
                        temp[i].isKey = ansIsKey[j];
                    } 
                }
            }
            for(int i = 0; i < temp.Count(); i++)
            {
                if (!temp[i].isKey)
                temp[i].text = temp[i].text.Substring(1);
            }
            questions[quesIndex].answer = temp;
            while (filteredAns.Count < 7)
            {
                filteredAns.Add("");
            }
            ansAtxt.Text = RemoveFirstCharacter(filteredAns[0]);
            ansBtxt.Text = RemoveFirstCharacter(filteredAns[1]);
            ansCtxt.Text = RemoveFirstCharacter(filteredAns[2]);
            ansDtxt.Text = RemoveFirstCharacter(filteredAns[3]);
            ansEtxt.Text = RemoveFirstCharacter(filteredAns[4]);
            ansFtxt.Text = RemoveFirstCharacter(filteredAns[5]);
            ansGtxt.Text = RemoveFirstCharacter(filteredAns[6]);
            ansAcb.IsChecked = false;
            ansBcb.IsChecked = false;
            ansCcb.IsChecked = false;
            ansDcb.IsChecked = false;
            ansEcb.IsChecked = false;
            ansFcb.IsChecked = false;
            ansGcb.IsChecked = false;
            for (int i = 0; i < 7; i++)
            {
                filteredAns[i] = "";
                anstxt[i] = "";
            }
        }
        private void ApplyClick(object sender, RoutedEventArgs e)
        {
            bool check = true;
            for (int i = 0; i < questions[quesIndex].answer.Count(); i++)
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
            if (quesIndex > 0)
            {
                quesIndex--;
                QuesQuantityUpdate();
                ShowQuestion();
            }
        }
        private void NextClick(object sender, RoutedEventArgs e)
        {
            if (quesIndex < questions.Count() - 1)
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

        public void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            questions = questions.OrderBy(x => rand.Next()).ToList();
            QuesQuantityUpdate();
            ShowQuestion();
        }

    }

}