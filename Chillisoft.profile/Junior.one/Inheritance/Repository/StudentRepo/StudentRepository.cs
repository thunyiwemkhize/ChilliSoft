namespace Junior.one.Inharitance.Repository.StudentRepo
{
    public class StudentRepository
    {
        private readonly IGenericRepository<Student> _studentRepo;

        public StudentRepository(IGenericRepository<Student> student)
        {
            _studentRepo = student;
        }
        public List<Student> _personList = new();

        public void Create(Student entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.FullName) || string.IsNullOrEmpty(entity.Course) || string.IsNullOrEmpty(entity.StudentNumber))
                throw new ArgumentNullException();
            _studentRepo.Create(entity);
        }

        public IEnumerable<Student> GetData()
        {
            return _studentRepo.GetData();
        }
    }
}
