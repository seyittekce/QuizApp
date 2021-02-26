using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuizApp.Models.Addons
{
    public class ListingExam
    {
        private static readonly DBContext db = new DBContext();
        public string Name { get; set; }
        public int StartComparedDate { get; set; }
        public int EndComparedDate { get; set; }
        public string Comment { get; set; }
        public int QuestionCount { get; set; }
        public Library LibraryID { get; set; }
        public Class ClassID { get; set; }
        public Questions Questions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int KalanGun { get; set; }

        private static ArrayList GetStudentClasses()
        {
            var ClassFinder = db.Class.ToList();
            var StudentClasses = new ArrayList();
            foreach (var classes in ClassFinder)
                if (classes.Students != null)
                {
                    var getStudents = classes.Students.Split('|').ToArray();
                    foreach (var Students in getStudents)
                        if (Students != null)
                        {
                            var ID = Convert.ToInt32(Students);
                            if (ID == StudentLogin.GetLoginStudent.StudentID) StudentClasses.Add(classes.ClassID);
                        }
                }
                else
                {
                    return null;
                }

            return StudentClasses;
        }

        public static List<ListingExam> ListExam()
        {
            var Getstudent = GetStudentClasses();
            var list = new List<ListingExam>();
            foreach (var Get in Getstudent)
                if (Get != null)
                {
                    var ClassID = Convert.ToInt32(Get);
                    var ClassFinder = db.Class.Find(ClassID);
                    var LibraryList = ClassFinder.QuizLib.Split('|').ToArray();
                    foreach (var Library in LibraryList)
                        if (!string.IsNullOrEmpty(Library))
                        {
                            var KalanGun = ClassFinder.EndDate - ClassFinder.StartDate;
                            var LibID = Convert.ToInt32(Library);
                            var LibraryFinder = db.QuizLibrary.Find(LibID);
                            var getQuestionCount = LibraryFinder.Questions.Split('|').ToArray();
                            list.Add(new ListingExam
                            {
                                Name = LibraryFinder.Name,
                                LibraryID = LibraryFinder,
                                ClassID = ClassFinder,
                                Comment = LibraryFinder.Comment,
                                QuestionCount = getQuestionCount.Count(),
                                EndComparedDate = DateTime.Compare(DateTime.Now, ClassFinder.EndDate),
                                StartComparedDate = DateTime.Compare(DateTime.Now, ClassFinder.StartDate),
                                StartDate = ClassFinder.StartDate,
                                EndDate = ClassFinder.EndDate,
                                KalanGun = KalanGun.Days
                            });
                        }
                }

            return list;
        }

        public static int GetResult(Library Library, Class Class)
        {
            var Bul = db.Answers.Where(x =>
                x.LibraryID == Library.LibraryID && x.StudentID == StudentLogin.GetLoginStudent.StudentID &&
                x.Class.ClassID == Class.ClassID).ToList();
            var toplamsoru = 0;
            var dogrusoru = 0;
            var yanlissoru = 0;
            foreach (var item in Bul)
            {
                toplamsoru++;
                if (item.Pass)
                    dogrusoru++;
                else
                    yanlissoru++;
            }

            var hes = dogrusoru * 100;
            return hes / toplamsoru;
        }
    }
}