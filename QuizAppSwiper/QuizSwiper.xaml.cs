using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizAppSwiper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizSwiper : ContentPage
    {
        List<int> questionList = new List<int>();
        int index = 0;
        int falseCount = 0;
        int trueCount = 0;
        
        public QuizSwiper()
        {
            InitializeComponent();
            LoadQuestions();
        }

        List<Question> questions = new List<Question>()
        { new Question("I love to meet new people.", "newPeople.jpg"),
          new Question("I like to try out new things.", "newThing.jpg"),
          new Question("I would rather spend time with a bunch of people than one close friend.", "friendTime.jpeg"),
          new Question("I describe my emotional experiences vividly.", "emotions.jpg"),
          new Question("I am the life of the party.", "party.jpeg")
        };

        List<string> truePersonalities = new List<string>()
        {
            "Couragous", "Brave", "Open", "Outgoing", "Cheerful"
        };

        List<string> falsePersonalities = new List<string>()
        {
            "Introverted", "Conservative", "Sensative", "Vulnerable", "Shy"
        };


        void LoadQuestions()
        {
            var questionNum = GenerateUniqueNumber(5, questionList);
            theLabel.Text = questions[questionNum].QuestionTitle;
            theImage.Source = questions[questionNum].Image;
        }
        void Restart_Clicked(object sender, EventArgs e)
        {
            //reset true/false count, questionList
            trueCount = 0;
            falseCount = 0;
            index = 0;
            questionList = new List<int>();
            RestartButton.IsVisible = false;
            LoadQuestions();
        }
        int GenerateUniqueNumber(int range, List<int> numbers)
        {
            // generate unique random number
            Random random = new Random();
            int number;
            do
            {
                number = random.Next(range);
            } while (numbers.Contains(number));
            numbers.Add(number);
            return number;
        }
        void OnSwiped(object sender, SwipedEventArgs e)
        {
            theLabel.Text = e.Direction.ToString() + " " + index;
            if (e.Direction == SwipeDirection.Right)
            {
                if (index >= questions.Count - 1)
                {
                    index = -1;
                }
                theLabel.Text = questions[++index].QuestionTitle;
                theImage.Source = questions[++index].Image;
                trueCount++;
                CheckQuestions();
            }
            else if (e.Direction == SwipeDirection.Left)
            {
                if (index <= 0)
                {
                    index = questions.Count;
                }
                theLabel.Text = questions[--index].QuestionTitle;
                theImage.Source = questions[++index].Image;
                falseCount++;
                CheckQuestions();
            }
        }
        void CheckQuestions()
        {
            int questionCount = trueCount + falseCount;
            if (questionCount == 5)
            {
                GeneratePersonality();
            }
            else
            {
                LoadQuestions();
            }
        }
        void GeneratePersonality()
        {
            string personality = "";
            for (int i = 0; i < trueCount; i++)
            {
                int number = GenerateUniqueNumber(5, new List<int>());
                personality += (truePersonalities[number] + ", ");
            }

            for (int i = 0; i < falseCount; i++)
            {
                int number = GenerateUniqueNumber(5, new List<int>());
                personality += (falsePersonalities[number] + ", ");
            }
            theLabel.Text = "You are a " + personality + " person.";
            theImage.Source = "result.jpg";
            RestartButton.IsVisible = true;
        }
    }
}