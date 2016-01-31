using Learn_TDD.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Learn_TDD.Models.Entities;
using System.Data.SqlClient;
using System.Data;
using Learn_TDD.Helpers;
using Dapper;

namespace Learn_TDD.Models.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private string _connStr;

        public ContractRepository(string connStr)
        {
            if(string.IsNullOrEmpty(connStr))
            {
                throw new ArgumentException("Must not be empty", "connStr");
            }
            _connStr = connStr;
        }

        public IList<Contract> GetAll()
        {
            DataTable dt = new DataTable();
            List<Contract> contracts = new List<Contract>();

            using (SqlConnection conn = new SqlConnection(_connStr))
            {



                //conn.Open();

                string cmdTxt = "select * from Contracts";
                //SqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = cmdTxt;

                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //adapter.Fill(dt);

                var cList = conn.Query<Contract>(cmdTxt).ToList();
                if(cList.Count > 0)
                {
                    contracts.AddRange(cList);
                }

            }

            //if(dt.Rows.Count > 0)
            //{
            //    foreach(DataRow row in dt.Rows)
            //    {
            //        Contract c = new Contract();
            //        c.Id = row["Id"].AsInt();
            //        c.LastName = row["LastName"].AsString();
            //        c.FirstName = row["FirstName"].AsString();
            //        c.MiddleName = row["MiddleName"].AsString();

            //        contracts.Add(c);
            //    }
            //}
            //throw new NotImplementedException();
            return contracts;
        }

        public Contract GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string cmdTxt = "select * from Contracts where Id = @id";
                var res = conn.Query<Contract>(cmdTxt, new { id }).FirstOrDefault();
                return res;
            }
            //throw new NotImplementedException();
        }

        public IList<Contract> GetBySnils(string snils)
        {
            throw new NotImplementedException();
        }
    }
}