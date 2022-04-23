namespace DotNet_Design_Patterns_Vol2.Chapter_10.Coarse_GrainedLock
{
    public class DomainObject : BaseEntity
    {
        public DomainObject(Version version) : base(version)
        {
        }
        public int Id { get; set; }
        public DomainObject Parent { get; set; }
    }

    public class UnitOfWork
    {
        List<DomainObject> modifiedObjects;
        public void Commit()
        {
            foreach (var item in modifiedObjects)
            {
                if (item.Parent != null)
                    item.Parent.Version.Increment();
            }
            foreach (var item in modifiedObjects)
            {
                //save changes to database
            }
        }
    }
}
