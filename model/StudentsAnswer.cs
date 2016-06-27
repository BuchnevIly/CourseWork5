using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class StudentsAnswer : Entity, IEntity
    {
        public int Id { get; set; }

        public TestQuestion TestQuestion { get; set; }

        public Student Student { get; set; }

        public DateTime DateAnswer { get; set; }

        public bool IsTrue;

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("get_student_answer", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();
            dataReader.Read();

            Id = (int)dataReader.GetValue(0);
            TestQuestion = new TestQuestion {Id = (int) dataReader.GetValue(1)};
            Student = new Student {Id = (int) dataReader.GetValue(2)};
            DateAnswer = (DateTime)dataReader.GetValue(3);
            IsTrue = (bool) dataReader.GetValue(4);
            dataReader.Close();

            TestQuestion.Load();
            Student.Load();

        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_student_answer", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_test_question", TestQuestion.Id);
            sqlCmd.Parameters.AddWithValue("@id_student", Student.Id);
            sqlCmd.Parameters.AddWithValue("@is_true", IsTrue);

            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_student_answer",
                SqlDbType = SqlDbType.Int
            };
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public static List<StudentsAnswer> GetAll()
        {
            var studentAnswers = new List<StudentsAnswer>();

            var sqlCmd = new SqlCommand("get_all_student_answer", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            while (dataReader.Read())
            {
                var studentsAnswer = new StudentsAnswer
                {
                    Id = (int) dataReader.GetValue(0),
                    TestQuestion = new TestQuestion {Id = (int) dataReader.GetValue(1)},
                    Student = new Student {Id = (int) dataReader.GetValue(2)},
                    DateAnswer = (DateTime) dataReader.GetValue(3),
                    IsTrue = (bool) dataReader.GetValue(4)
                };
                studentAnswers.Add(studentsAnswer);
            }
            dataReader.Close();
            
            studentAnswers.ForEach(x =>
            {
                x.Student.Load();
                x.TestQuestion.Load();
            });
            return studentAnswers;            
        }
    }
}
