using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.Inharitance.Repository.StudentRepo
{
    public class StudentRepository:IGenenricRepository<Student>
    {
        public List<Student> _personList = new();

        public void Create(Student entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.FullName) || string.IsNullOrEmpty(entity.Course) || string.IsNullOrEmpty(entity.StudentNumber))
                throw new ArgumentNullException();
            _personList.Add(entity);
        }
    }
}
