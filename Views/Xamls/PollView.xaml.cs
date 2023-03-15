using System;
using System.Collections.Generic;
using System.IO;
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

namespace Test.Views.Xamls
{
    /// <summary>
    /// Interaction logic for PollView.xaml
    /// </summary>
    public partial class PollView : UserControl
    {
        private int PageIndex { get; set; } = 0;
        private string[] Questions { get; set; } = new string[] { "Введіть Ваше ім'я", 
            "Яку ви полюбляєте кухню?", 
            "Введіть Ваш вік", 
            "Скільки у Вас грошей", 
            "2+2?", 
            "А 3+3?", 
            "Дякуємо за пройдене опитування!\n"};
        private List<string> Answers { get; set; }

        public PollView()
        {
            Answers = new List<string>(Questions);
            InitializeComponent();
        }
        private void Prew(object sender, RoutedEventArgs e)
        {
            Answers[PageIndex] = Answer.Text;

            PageIndex--;
            if (PageIndex < 0)
                PageIndex = 0;

            QuestionPlacheholder.Text = Questions[PageIndex];
            Answer.Text = "";
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Answers[PageIndex] = Answer.Text;

            PageIndex++;
            if (PageIndex > Questions.Length - 2)
            {
                Answer.Visibility = Visibility.Hidden;
                PrewButton.Visibility = Visibility.Hidden;

                NextButton.Content = "Надіслати!";
                NextButton.Margin = new Thickness(0, 269, 0, 0);
                NextButton.Width = 351;
            }
            if (PageIndex > Questions.Length - 1)
            {
                Answer.Visibility = Visibility.Visible;
                PrewButton.Visibility = Visibility.Visible;
                NextButton.Content = ">";
                NextButton.Margin = new Thickness(273, 369, 0, 0);
                NextButton.Width = 60;
                PageIndex = 0;
                SaveAnswers();
            }
            QuestionPlacheholder.Text = Questions[PageIndex];

            Answer.Text = "";
        }

        private void SaveAnswers()
        {
            var fileName = (@"D:\Навчання\8-й семестр\Розробка інтерфейсів користувача\WPF лаба\Test\bin\Release\" + DateTime.Now.ToString("MM/dd/yyyy_HH/mm/ss").Replace('.', '_') + ".txt");
            var s = File.Create(fileName);
            s.Close();
            using (StreamWriter w = new StreamWriter(fileName))
            {
                for(int i = 1; i <= Answers.Count; i++)
                {
                    w.WriteLine("###################" + i.ToString() + "###################");
                    w.WriteLine(Questions[i - 1]);
                    w.WriteLine(Answers[i - 1]);
                }
            }
            return;
        }
    }

}
