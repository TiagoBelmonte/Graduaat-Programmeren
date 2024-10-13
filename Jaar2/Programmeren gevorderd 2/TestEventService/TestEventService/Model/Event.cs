namespace TestEventService.Model
{
    public class Event
    {
        public Event() { }
        public Event( int id,string name, string location, DateTime date, int maxVisitors)
        {
            Id = id;
            Name = name;
            Location = location;
            Date = date;
            MaxVisitors = maxVisitors;
            visitors = new List<Visitor>();

        }
        public int Id { get; set; }
        public int MaxVisitors { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }

        public List<Visitor> visitors { get; set; }

        public void addVisitor(Visitor visitor)
        {
            if (visitors.Count < MaxVisitors)
            {
                if (!visitors.Contains(visitor))
                {
                    visitors.Add(visitor);
                }
                else
                {
                    throw new EventException("Visitor is already added in the list");

                }
            }
            else
            {
                throw new EventException("The capacity is already full");
            }

        }

        public void removeVisitor(Visitor visitor)
        {
            if (visitors.Contains(visitor))
            {
                visitors.Remove(visitor);
            }
            else
            {
                throw new EventException("Visitor is already removed from the list");

            }
        }


    }
}
