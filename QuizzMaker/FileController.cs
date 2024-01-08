using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizzMaker
{
    class FileController
    {
        public void SaveDataToFile(List<Question> questions, string filePath)
        {
            if (filePath != null)
            {
                filePath += ".txt";
                if (File.Exists(filePath))
                {
                    using (StreamWriter writer = new StreamWriter(filePath, append: true))
                    {
                        foreach (Question question in questions)
                        {
                            writer.WriteLine("{");
                            writer.WriteLine(question.question);
                            foreach (Answer answer in question.answer)
                            {
                                if (answer.text != null)
                                {
                                    if (answer.isKey) writer.WriteLine("*" + answer.text);
                                    else writer.WriteLine(answer.text);
                                }
                            }
                            writer.WriteLine("}");
                        }
                    }
                    MessageBox.Show("Save Successfully!");
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (Question question in questions)
                        {
                            writer.WriteLine("{");
                            writer.WriteLine(question.question);
                            foreach (Answer answer in question.answer)
                            {
                                if (answer.text != null)
                                {
                                    if (answer.isKey) writer.WriteLine("*" + answer.text);
                                    else writer.WriteLine(answer.text);
                                }
                            }
                            writer.WriteLine("}");
                        }
                    }
                    MessageBox.Show("Save Successfully!");
                }
            }
            else
            {
                MessageBox.Show("No File Name!");
            }
        }

        public List<Question> ReadDataFromFile(string filePath)
        {
            filePath += ".txt";
            List<Question> questions = new List<Question>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if(line == "{")
                        {
                            Question question = new Question();
                            question.answer = new List<Answer>();
                            question.question = reader.ReadLine();
                            while (line != "}")
                            {
                                Answer answer = new Answer();
                                if (reader.Peek() == '*')
                                {
                                    answer.isKey = true;
                                }
                                else answer.isKey = false;
                                line = reader.ReadLine();
                                answer.text = line;
                                question.answer.Add(answer);
                            }
                            question.answer.Remove(question.answer.Last());
                            questions.Add(question);
                            
                        }                                             
                    }
                }
            }
            else
            {
                MessageBox.Show("No File Found!");
            }
            return questions;
        }
    }
}
