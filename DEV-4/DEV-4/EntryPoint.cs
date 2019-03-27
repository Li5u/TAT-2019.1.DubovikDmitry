using System;
using System.Linq;

namespace DEV_4
{
    /// <summary>
    /// The entry point of programm.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// This method ckecks all functionality of classes realised in this program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                ///Make math discipline and initialize all fields.
                var mathematics = new Discipline("Science about numbers");
                var presentationAboutMultiplication = new Presentation("Presentation about multiplication", Format.PDF, "Multiplication", "Some pictures..");
                var lectionAboutMultiplication = new Lecture("Multiplication is good", "Lecture about multiplication", "Multiplication", presentationAboutMultiplication);
                var seminarAboutMultiplication = new Seminar("We will learn how to multiply", "Multiplication");
                seminarAboutMultiplication.AddTask("Drow '*' symbol");
                seminarAboutMultiplication.AddQuestion(new Tuple<string, string>("2*2", "4"));
                var labAboutMultiplication = new LaboratoryWork("Show multiplication with help of apples", "Multiplication");
                mathematics.AddLab(labAboutMultiplication);
                mathematics.AddLecture(lectionAboutMultiplication);
                mathematics.AddSeminar(seminarAboutMultiplication);

                //Show that deepcopy works.
                var mathematicsCopy = (Discipline)mathematics.Clone();
                Console.WriteLine(mathematics.Equals(mathematicsCopy));                //True
                Console.WriteLine(mathematics == mathematicsCopy);                     //False
                mathematicsCopy.lectures[0].textOfTheLecture = "Multiplication is bad";
                Console.WriteLine(mathematics.lectures[0].textOfTheLecture);           //Multiplication is good
                Console.WriteLine(mathematicsCopy.lectures[0].textOfTheLecture);       //Multiplication is bad

                //Indexer
                var material = mathematics["Multiplication"];
                Console.WriteLine(material.Count());                                   //3 (lection, seminat and lab)
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }
        }
    }
}
