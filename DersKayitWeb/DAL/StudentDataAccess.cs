using DersKayitWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DersKayitWeb.DAL
{
    
    public class StudentDataAccess
    {
        private SchoolContext db = new SchoolContext();
        public IEnumerable<Student> GetStudent()
        {
            using (db=new SchoolContext())
            {
                return db.Students.ToList();
            }
            
        }
        public IQueryable<Student> GetStudentBySearchString(string searchString)
        {
            using (db = new SchoolContext())
            {
                var students=db.Students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
                return students;
            }
        }
        public Student FindStudentById(int id)
        {
            using (db=new SchoolContext())
            {
                var student =db.Students.Find(id);
                return student;
            }
        }
        public void AddStudent(Student student)
        {
            using (db=new SchoolContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        public void EditStudent(Student student)
        {
            using (db=new SchoolContext())
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteStudent(int id)
        {
            using (db=new SchoolContext())
            {
                db.Students.Remove(db.Students.Find(id));
                
                db.SaveChanges();
            }
        }
    }
}