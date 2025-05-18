using System.Collections.Generic;
using StudentExportApp.Models;
using StudentExportApp.Repositories.Interfaces;

namespace StudentExportApp.Repositories;

public class StudentRepository : IStudentRepository
{
    public IEnumerable<Student> GetAll()
        => new List<Student>
        {
            new(){ Nim="2021001", Nama="Arkan", Email="arkan@univ.ac.id", Fakultas="Teknik", Jurusan="Informatika" },
            new(){ Nim="2021002", Nama="Fauzan", Email="fauzan@univ.ac.id", Fakultas="Ekonomi", Jurusan="Manajemen" },
            new(){ Nim="2021003", Nama="Ayyasyi", Email="ayyasyi@univ.ac.id", Fakultas="Hukum", Jurusan="Ilmu Hukum" }
        };
}