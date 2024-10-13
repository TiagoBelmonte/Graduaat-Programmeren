namespace TestEventService.Model
{
    public class Visitor
    {
        public Visitor() { }
        public Visitor(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        public Visitor( string name, DateTime birthday, int id)
        {
            Name = name;
            Birthday = birthday;
            Id = id;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

    }
}
