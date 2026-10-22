using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using Microsoft.EntityFrameworkCore;

namespace ASPHW6.Domain
{
    public class StudentRepository : IRepository<Student, Guid>
    {
        private readonly AppDbContext context;

        public StudentRepository(AppDbContext context) => this.context = context;

        public Student Get(Guid id)
        {
           return context.Students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students.AsNoTracking().ToList();
        }

        public IEnumerable<Student> GetBy(Func<Student, bool> predicate)
        {
            return context.Students.AsNoTracking().Where(predicate).ToList();
        }

        public bool Remove(Guid id)
        {
            context.Students.Remove(Get(id));
            context.SaveChangesAsync();
            return true;
        }

        public Student Save(Student entity)
        {
            entity.Id = Guid.NewGuid();
            context.Students.Add(entity);
            context.SaveChangesAsync();
            return entity;
        }

        public Student Update(Student entity)
        {
            var s = Get(entity.Id);

            if (!string.IsNullOrEmpty(entity.FullName))
                s.FullName = entity.FullName;
            if (!string.IsNullOrEmpty(entity.RecordBook))
                s.RecordBook = entity.RecordBook;
            if (!string.IsNullOrEmpty(entity.Phone))
                s.Phone = entity.Phone;
            if (entity.Course != 0)
                s.Course = entity.Course;

            context.Students.Update(s);
            context.SaveChangesAsync();
            return s;
        }
    }
}
