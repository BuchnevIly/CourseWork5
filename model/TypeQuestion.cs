﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TypeQuestion : Entity, IEntity
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;


            var sqlCmd = new SqlCommand("load_type_question", cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id", Id);
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Name = dataReader.GetValue(1).ToString();

            dataReader.Close();
        }

        public static List<TypeQuestion> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_type_question", cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();
            var list = new List<TypeQuestion>();

            while (dataReader.Read())
            {
                var typeQuestion = new TypeQuestion
                {
                    Id = (int) dataReader.GetValue(0),
                    Name = dataReader.GetValue(1).ToString()
                };
                list.Add(typeQuestion);
            }

            dataReader.Close();
            return list;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
