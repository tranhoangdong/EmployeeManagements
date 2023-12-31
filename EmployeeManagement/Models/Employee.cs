﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Employee
    {

        [Display(Name = "STT")]
        public int Id { set; get; }
        [Display(Name = " nhap FirstName")]
        public string FirstName { set; get; }
        [Display(Name = " nhap LastName")]
        public string LastName { set; get; }
        [Display(Name = " dia chi")]
        public string Address { set; get; }
    }
    public class EmployeeList
    {
        DBConection db;
        public EmployeeList()
        {
            db = new DBConection();
        }
        public List<Employee> GetEmployee(String Id)
        {
            List<Employee> EmpList = new List<Employee>();
            try
            {
                string sql;
                if (string.IsNullOrEmpty(Id))
                    sql = "SELECT * FROM Employee";
                else
                    sql = "SELECT * FROM Employee WHERE Id = " + Id;


                DataSet dt = new DataSet();
                SqlConnection con = db.GetConnection();
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                da.Fill(dt);
                da.Dispose();
                con.Close();

                foreach (DataRow row in dt.Tables[0].Rows)
                {
                    Employee tmpEmp = new Employee();
                    tmpEmp.Id = Convert.ToInt32(row["Id"].ToString());
                    tmpEmp.FirstName = row["FirstName"].ToString();
                    tmpEmp.LastName = row["LastName"].ToString();
                    tmpEmp.Address = row["Address"].ToString();
                    EmpList.Add(tmpEmp);
                }

            }
            catch (Exception ex)
            {

            }
            return EmpList;

        }
    }
}