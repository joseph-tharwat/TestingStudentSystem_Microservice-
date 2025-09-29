﻿using System.Collections.ObjectModel;
using TestManagment.Domain.ValueObjects;

namespace TestManagment.Domain.Entities
{
    public class Question
    {
        public int Id { get; private set; }
        public QuestionTxt QuestionText { get;private set; }
        public QuestionChoise Choise1 { get; private set; }
        public QuestionChoise Choise2 { get; private set; }
        public QuestionChoise Choise3 { get; private set; }
        public string Answer {  get; private set; }
        public Collection<TestQuestion> TestQuestions { get; set; }

    }
}
