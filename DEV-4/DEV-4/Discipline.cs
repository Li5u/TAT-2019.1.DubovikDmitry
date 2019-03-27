using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// This class contains all discipline materials.
    /// </summary>
    class Discipline : ObjectWithIdAndDescription, ICloneable
    {
        public List<Lecture> lectures;
        public List<Seminar> seminars;
        public List<LaboratoryWork> labs;

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="theme">Theme</param>
        public Discipline(string description)
            :base(description)
        {
            lectures = new List<Lecture>();
            seminars = new List<Seminar>();
            labs = new List<LaboratoryWork>();
        }

        /// <summary>
        /// The private class constructor for making deep copy of this object.
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="lectures">List of lectures</param>
        /// <param name="seminars">List of seminars</param>
        /// <param name="labs">List of labs</param>
        /// <param name="id">ID</param>
        private Discipline(string description, List<Lecture> lectures, List<Seminar> seminars, List<LaboratoryWork> labs, string id)
            :this(description)
        {
            Id = id;
            foreach(var lecture in lectures)
            {
                this.lectures.Add((Lecture)lecture.Clone());
            }

            foreach(var seminar in seminars)
            {
                this.seminars.Add((Seminar)seminar.Clone());
            }

            foreach(var lab in labs)
            {
                this.labs.Add((LaboratoryWork)lab.Clone());
            }
        }

        /// <summary>
        /// This method adds lecture to List od lectures.
        /// </summary>
        /// <param name="lecture">Lecture object</param>
        public void AddLecture(Lecture lecture)
        {
            lectures.Add(lecture);
        }

        /// <summary>
        /// This method returns all lections with specified theme.
        /// </summary>
        /// <param name="theme">Theme</param>
        /// <returns>lList of lectures</returns>
        public List<Lecture> GetLecturesByTheme(string theme)
        {
            var lectures = new List<Lecture>();
            foreach(var lecture in this.lectures)
            {
                if (lecture.theme == theme)
                {
                    lectures.Add(lecture);
                }
            }
            return lectures;
        }

        /// <summary>
        /// This method adds seminar to List od seminars.
        /// </summary>
        /// <param name="seminar">Seminar object</param>
        public void AddSeminar(Seminar seminar)
        {
            seminars.Add(seminar);
        }

        /// <summary>
        /// This method returns all seminars with specified theme.
        /// </summary>
        /// <param name="theme">Theme</param>
        /// <returns>List od seminars</returns>
        public List<Seminar> GetSeminarsByTheme(string theme)
        {
            var seminars = new List<Seminar>();
            foreach (var seminar in this.seminars)
            {
                if (seminar.theme == theme)
                {
                    seminars.Add(seminar);
                }
            }
            return seminars;
        }

        /// <summary>
        /// This method adds lab to List od lab.
        /// </summary>
        /// <param name="lab">LaboratoryWork object</param>
        public void AddLab(LaboratoryWork lab)
        {
            labs.Add(lab);
        }

        /// <summary>
        /// This method returns all labs with specified theme.
        /// </summary>
        /// <param name="theme">Theme</param>
        /// <returns>List of labs</returns>
        public List<LaboratoryWork> GetLabsByTheme(string theme)
        {
            var labs = new List<LaboratoryWork>();
            foreach (var lab in this.labs)
            {
                if (lab.theme == theme)
                {
                    labs.Add(lab);
                }
            }
            return labs;
        }

        /// <summary>
        /// This indexer returns all materials with specified theme.
        /// </summary>
        /// <param name="theme">Theme</param>
        /// <returns>List od materials</returns>
        public List<Material> this[string theme]
        {
            get
            {
                var materials = new List<Material>();
                foreach(var seminar in GetSeminarsByTheme(theme))
                {
                    materials.Add(seminar);
                }

                foreach (var lecture in GetLecturesByTheme(theme))
                {
                    materials.Add(lecture);
                }

                foreach (var lab in GetLabsByTheme(theme))
                {
                    materials.Add(lab);
                }
                return materials;
            }
        }

        /// <summary>
        /// This method returns copy of Discipline object.
        /// </summary>
        /// <returns>new object of class Discipline with cloned all fields</returns>
        public object Clone()
        {
            var disciplineCopy = new Discipline(this.Description, this.lectures, this.seminars, this.labs, this.Id);
            return disciplineCopy;
        }
    }
}
