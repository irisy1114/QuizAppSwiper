using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppSwiper
{
    class Question
    {
        public string QuestionTitle { get; set; }
        public string Image { get; set; }
        public Question(string title, string image)
        {
            this.QuestionTitle = title;
            this.Image = image;
        }
    }
}
