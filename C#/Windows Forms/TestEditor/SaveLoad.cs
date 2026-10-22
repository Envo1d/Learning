using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace WinFormsHW3
{
    public class SaveLoad
    {

        [Serializable]
        [XmlType("Answers")]
        public class Answers
        {
            [XmlElement("Answer")]
            public string Answer { get; set; }
            [XmlElement("IsTrue")]
            public bool isTrue { get; set; }

            public Answers() { }
        }

        [Serializable]
        [XmlType("Question")]
        [XmlInclude(typeof(Answers))]
        public class Questions
        {
            [XmlElement("Question")]
            public string Question { get; set; }

            [XmlArray("AnswersList")]
            [XmlArrayItem("AnswersObject")]
            public List<Answers> answers = new List<Answers>();

            public Questions() { }

            public void AddAnswer(string name, bool right)
            {
                answers.Add(new Answers { Answer = name, isTrue = right });
            }
            public void DeleteAnswer(int idx)
            {
                answers.Remove(answers.ElementAt(idx));
            }
            public void EditAnswer(int idx, string newName, bool right)
            {
                answers.ElementAt(idx).Answer = newName;
                answers.ElementAt(idx).isTrue = right;
            }
        }

        [Serializable]
        [XmlType("Test")]
        [XmlInclude(typeof(Questions))]
        public class Test
        {
            [XmlElement("TestName")]
            public string Name { get; set; }
            [XmlElement("TestTime")]
            public decimal MaxTime { get; set; }
            [XmlElement("TestMaxMark")]
            public decimal MaxMark { get; set; }
            [XmlArray("QuestionsList")]
            [XmlArrayItem("QuestionsObject")]
            public List<Questions> questions = new List<Questions>();

            public Test() { }

            public void AddQuestion(string name)
            {
                questions.Add(new Questions { Question = name });
            }
            public void AddQuestionAnswer(int idx, string ansName, bool right)
            {
                questions.ElementAt(idx).AddAnswer(ansName, right);
            }
            public void DeleteQuestion(string name)
            {
                questions.Remove((from n in questions where n.Question == name select n).First());
            }
            public void DeleteQuestionAnswer(int qIdx, int ansIdx)
            {
                questions.ElementAt(qIdx).DeleteAnswer(ansIdx);
            }
            public void EditQuestion(string baseName, string newName)
            {
                var idx = questions.IndexOf((from n in questions where n.Question == baseName select n).First());
                questions.ElementAt(idx).Question = newName;
            }
            public void EditQuestionAnswer(int qIdx, int ansIdx, string newName, bool right)
            {
                questions.ElementAt(qIdx).EditAnswer(ansIdx, newName, right);
            }
        }

        [Serializable]
        [XmlRoot("TestList")]
        [XmlInclude(typeof(Test))]
        public class Info
        {
            [XmlArray("TestArray")]
            [XmlArrayItem("TestObject")]
            public List<Test> tests = new List<Test>();

            public Info() { }
        }

        public int countOfTests { get; set; }
        public int selectedIdx { get; set; }
        public Info info;
        private string path = "information.xml";

        public SaveLoad()
        {
            info = new Info();
            if (!File.Exists(path))
            {
                using(StreamWriter sw = new StreamWriter(path,false,System.Text.Encoding.Default))
                {
                    sw.Write("");
                }
            }
        }

        public void AddTest(string name, decimal time, decimal mark) => info.tests.Add(new Test { Name = name, MaxMark = mark, MaxTime = time });
        public void AddTestQuestion(string name) => info.tests.ElementAt(selectedIdx).AddQuestion(name);
        public void AddTestQuestionAnswer(int qIdx, string ansName, bool right) => info.tests.ElementAt(selectedIdx).AddQuestionAnswer(qIdx, ansName, right);
        public void EditTest(string name, decimal time, decimal mark)
        {
            info.tests.ElementAt(selectedIdx).Name = name;
            info.tests.ElementAt(selectedIdx).MaxMark = mark;
            info.tests.ElementAt(selectedIdx).MaxTime = time;
        }
        public void EditTestQuestion(string baseName, string newName) => info.tests.ElementAt(selectedIdx).EditQuestion(baseName, newName);
        public void EditTestQuestionAnswer(int qIdx, int ansIdx, string newName, bool right) => info.tests.ElementAt(selectedIdx).EditQuestionAnswer(qIdx, ansIdx, newName, right);
        public void DeleteTest() => info.tests.Remove(info.tests.ElementAt(selectedIdx));
        public void DeleteTestQuestion(string name) => info.tests.ElementAt(selectedIdx).DeleteQuestion(name);
        public void DeleteTestQuestionAnswer(int qIdx, int ansIdx) => info.tests.ElementAt(selectedIdx).DeleteQuestionAnswer(qIdx, ansIdx);

        public void SaveToFile()
        {
            Type[] types = { typeof(Answers), typeof(Questions), typeof(Test) };

            XmlSerializer formatter = new XmlSerializer(typeof(Info), types);

            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, info);
            }
        }

        public void LoadFromFile()
        {
            Type[] types = { typeof(Answers), typeof(Questions), typeof(Test) };

            XmlSerializer formatter = new XmlSerializer(typeof(Info), types);

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                if (fs.Length != 0)
                {
                    info = null;
                    info = (Info)formatter.Deserialize(fs);
                    countOfTests = info.tests.Count;
                }
            }
        }
        public string GetTestName(int idx) { if (info != null) return info.tests.ElementAt(idx).Name; else return null; }
    }
}