using System.Diagnostics;
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

namespace QuizzMaker
{

    public partial class MainWindow : Window
    {
        public List<Question> questions;
        FileController fileController;
        public MainWindow()
        {
            fileController = new FileController();
            questions = new List<Question>();
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public void GetInput()
        {
            Question question = new Question();
            if(questxt.Text != "") {
                question.question = questxt.Text;
                question.answer = CreateAnswerList();
                questions.Add(question);
                quesQuantity.Text =  "Questions: " + questions.Count.ToString();
                MessageBox.Show("Add Successfully!");
            }
            else
            {
                MessageBox.Show("No Question text!");
            }
        }

        public List<Answer> CreateAnswerList()
        {
            List<Answer> answers = new List<Answer>();
            if (ansAtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = ansAtxt.Text;
                answer.isKey = ansAcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansBtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = ansBtxt.Text;
                answer.isKey = ansBcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansCtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = ansCtxt.Text;
                answer.isKey = ansCcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansDtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = ansDtxt.Text;
                answer.isKey = ansDcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansEtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = ansEtxt.Text;
                answer.isKey = ansEcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansFtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = ansFtxt.Text;
                answer.isKey = ansFcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansGtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = ansGtxt.Text;
                answer.isKey = ansGcb.IsChecked.Value;
                answers.Add(answer);
            }
            return answers;
        }

        private void doneClick(object sender, EventArgs e)
        {
            GetInput();
            questxt.Text = "";
            ansAtxt.Text = "";
            ansBtxt.Text = "";
            ansCtxt.Text = "";
            ansDtxt.Text = "";
            ansEtxt.Text = "";
            ansFtxt.Text = "";
            ansGtxt.Text = "";
            ansAcb.IsChecked = false;
            ansBcb.IsChecked = false;
            ansCcb.IsChecked = false;
            ansDcb.IsChecked = false;
            ansEcb.IsChecked = false;
            ansFcb.IsChecked = false;
            ansGcb.IsChecked = false;
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            fileController.SaveDataToFile(questions, filePath.Text);
            questions.Clear();
        }

        private void goToExamClick(object sender, RoutedEventArgs e)
        {
            DoExam doExam = new DoExam();
            this.Close();
            doExam.filePath.Text = filePath.Text;
            doExam.Show();
        }
        public void QuitClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(questions[0].answer[0].text);
        }

    }
}