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
        }

        public void GetInput()
        {
            Question question = new Question();
            if(questxt.Text != "") {
                question.question = "Questions: " + questxt.Text;
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
                answer.text = "A: " + ansAtxt.Text;
                answer.isKey = ansAcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansBtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = "B: " + ansBtxt.Text;
                answer.isKey = ansBcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansCtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = "C: " + ansCtxt.Text;
                answer.isKey = ansCcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansDtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = "D: " + ansDtxt.Text;
                answer.isKey = ansDcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansEtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = "E: " + ansEtxt.Text;
                answer.isKey = ansEcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansFtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = "F: " + ansFtxt.Text;
                answer.isKey = ansFcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansGtxt.Text != "")
            {
                Answer answer = new Answer();
                answer.text = "G: " + ansGtxt.Text;
                answer.isKey = ansFcb.IsChecked.Value;
                answers.Add(answer);
            }
            return answers;
        }

        private void doneClick(object sender, EventArgs e)
        {
            GetInput();
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            fileController.SaveDataToFile(questions, fileController.filePath);
            MessageBox.Show("Save Successfully!");
        }
    }
}