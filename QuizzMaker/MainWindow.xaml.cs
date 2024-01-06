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
        public MainWindow()
        {
            InitializeComponent();
        }

        public void GetInput()
        {
            Question question = new Question();
            question.question = quesTxt.Text;
            question.answer = CreateAnswerList();
            questions.Add(question);
        }

        public List<Answer> CreateAnswerList()
        {
            Answer answer = new Answer();
            List<Answer> answers = new List<Answer>();
            if (ansATxt != null)
            {
                answer.text = ansATxt.Text;
                answer.isKey = ansAcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansBTxt != null)
            {
                answer.text = ansBTxt.Text;
                answer.isKey = ansBcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansCTxt != null)
            {
                answer.text = ansCTxt.Text;
                answer.isKey = ansCcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansDTxt != null)
            {
                answer.text = ansDTxt.Text;
                answer.isKey = ansDcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansETxt != null)
            {
                answer.text = ansETxt.Text;
                answer.isKey = ansEcb.IsChecked.Value;
                answers.Add(answer);
            }
            if (ansFTxt != null)
            {
                answer.text = ansFTxt.Text;
                answer.isKey = ansFcb.IsChecked.Value;
                answers.Add(answer);
            }
            return answers;
        }

        private void doneClick(object sender, RoutedEventArgs e)
        {
            GetInput();
            MessageBox.Show(questions[0].question);
        }
        
    }
}