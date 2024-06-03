using Droos.Models;

namespace Droos.Repositories
{

    public class SubjectsRepo //: RepoBase
    {
        //public SubjectsRepo(DbContext dbContext) : base(dbContext)
        //{

        //}

        public IEnumerable<Subject> GetSubjects(Guid gradeId)
        {
            throw new NotImplementedException();
        }

        public Guid CreateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }
        public Guid UpdateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }
        public Guid DeactivateSubject(Guid subjectId)
        {
            throw new NotImplementedException();
        }
    }

}
