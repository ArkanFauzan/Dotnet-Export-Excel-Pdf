using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using StudentExportApp.Models;
using StudentExportApp.Repositories.Interfaces;

namespace StudentExportApp.Repositories;

public class StudentRepository(
    IConfiguration cfg
) : IStudentRepository
{
    private readonly string _connStr = cfg.GetConnectionString("Default");

    public IEnumerable<Student> GetAll()
    {
        var list = new List<Student>();

        using var conn = new SqlConnection(_connStr);
        using var cmd  = new SqlCommand("GetAllStudent", conn)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };

        conn.Open();
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            list.Add(new Student
            {
                Nim      = rdr.GetString(0),
                Nama     = rdr.GetString(1),
                Email    = rdr.GetString(2),
                Fakultas = rdr.GetString(3),
                Jurusan  = rdr.GetString(4)
            });
        }

        return list;
    }
}