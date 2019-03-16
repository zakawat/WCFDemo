using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {
        public Student aikStudentsLeKarAwo(String id)
        {
            int ID = int.Parse(id);
            if (ID == 5)
            {
                return new Student() { id = 5, name = "Ali", age=33 };
            }
            return new Student() { id = 8, name = "Hassan", age = 23 };
        }

        public Student aikStudentsLeKarAwoNameSay(string name)
        {
            List<Student> students = new List<Student>();

            SqlCommand cmd = new SqlCommand($"SELECT * FROM Student WHERE name LIKE '%{name}%'", new SqlConnection("Data Source=ZakiPC;Initial Catalog=systemPrograming;User ID=sa;Password=loveYouMomAndDad"));
            cmd.Connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                Student s = new Student();
                s.age = int.Parse(sdr["age"].ToString());
                s.id = int.Parse(sdr["id"].ToString());
                s.name = sdr["name"].ToString();
                sdr.Close();
                cmd.Connection.Close();
                return s;
            }

            else
            {
                sdr.Close();
                cmd.Connection.Close();
                return new Student{ };
            }

            
        }

        public List<Student> sareStudentsLeKarAwo()
        {
            List<Student> students = new List<Student>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Student", new SqlConnection("Data Source=ZakiPC;Initial Catalog=systemPrograming;User ID=sa;Password=loveYouMomAndDad"));
            cmd.Connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Student s = new Student();
                s.age = int.Parse(sdr["age"].ToString());
                s.id = int.Parse(sdr["id"].ToString());
                s.name = sdr["name"].ToString();
                students.Add(s);
            }

            sdr.Close();
            cmd.Connection.Close();

            return students;
        }

        public List<NewStudent> sareStudentsLeKarAwoNative()
        {
            List<NewStudent> students = new List<NewStudent>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Student", new SqlConnection("Data Source=ZakiPC;Initial Catalog=systemPrograming;User ID=sa;Password=loveYouMomAndDad"));
            cmd.Connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                NewStudent s = new NewStudent();
                s.age = int.Parse(sdr["age"].ToString());
                s.id = int.Parse(sdr["id"].ToString());
                s.name = sdr["name"].ToString();
                s.key = sdr["name"].ToString();

                students.Add(s);
            }

            sdr.Close();
            cmd.Connection.Close();

            return students;
        }
    }
}
