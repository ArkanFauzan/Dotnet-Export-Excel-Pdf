using System.Collections.Generic;
using StudentExportApp.Models;

namespace StudentExportApp.Repositories.Interfaces;
public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
}