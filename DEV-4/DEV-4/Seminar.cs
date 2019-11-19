using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Class for seminars.
    /// </summary>
    class Seminar : Material
    {
        public List<string> tasks;
        public List<string> questions;
        public List<string> answersTheQuestions;

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="theme">Theme</param>
        public Seminar(string description, string theme)
            :base(description, theme)
        {
            tasks = new List<string>();
            questions = new List<string>();
            answersTheQuestions = new List<string>();
        }

        /// <summary>
        /// The private class constructor for making deep copy of this object.
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="theme">Theme</param>
        /// <param name="tasks">List of tasks</param>
        /// <param name="questions">List od questions</param>
        /// <param name="answers">List of answers</param>
        /// <param name="id">ID</param>
        private Seminar(string description, string theme, List<string> tasks, List<string> questions, List<string> answers, string id)
            :this(description, theme)
        {
            Id = id;
            foreach (var task in tasks)
            {
                this.tasks.Add(task);
            }

            foreach (var question in questions)
            {
                this.questions.Add(question);
            }

            foreach (var answer in answers)
            {
                this.answersTheQuestions.Add(answer);
            }
        }

        /// <summary>
        /// This method adds task to seminar tasks.
        /// </summary>
        /// <param name="task">Task</param>
        public void AddTask(string task)
        {
            tasks.Add(task);
        }

        /// <summary>
        /// This method adds question and answer for that question to fields.
        /// </summary>
        /// <param name="question">Tuple(quesrion, answer)</param>
        public void AddQuestion(Tuple<string, string> questionAndAnswer)
        {
            questions.Add(questionAndAnswer.Item1);
            answersTheQuestions.Add(questionAndAnswer.Item2);
        }

        /// <summary>
        /// This method returns copy of Seminar object.
        /// </summary>
        /// <returns>new object of class Seminar with cloned all fields</returns>
        public object Clone()
        {
            var seminarCopy = new Seminar(this.Description, this.Theme, this.tasks, this.questions, this.answersTheQuestions, this.Id);
            return seminarCopy;
        }
    }
}
