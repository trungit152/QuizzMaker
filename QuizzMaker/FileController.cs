using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzMaker
{
    class FileController
    {
        public string filePath = "nmcnpm.txt";
        public void SaveDataToFile(List<Question> questions, string filePath)
        {
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
                                if (answer.isKey) writer.WriteLine("*"+answer.text);
                                else writer.WriteLine(answer.text);
                            }
                        }
                        writer.WriteLine("}");
                    }
                }
            }
        }
    }
}
