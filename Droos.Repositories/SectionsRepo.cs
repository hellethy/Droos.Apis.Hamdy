namespace Droos.Repositories
{
    public class SectionsRepo //: RepoBase
    {
        //public SectionsRepo(DbContext dbContext) : base(dbContext)
        //{
        //}

        public IEnumerable<Models.Section> GetSections(Guid subjectId)
        {
            throw new NotImplementedException();
        }

        public Guid CreateSection(Models.Section section)
        {
            throw new NotImplementedException();
        }
        public Guid UpdateSection(Models.Section section)
        {
            throw new NotImplementedException();
        }
        public Guid DeactivateSection(Guid sectionId)
        {
            throw new NotImplementedException();
        }
    }

}
