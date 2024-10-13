namespace TestEventService.Model
{
    public interface IVisitorsRepository
    {
        IEnumerable<Visitor> GetAll();
        Visitor GetVisitor(int id);
        void AddVistor(Visitor visitor);


    }
}
