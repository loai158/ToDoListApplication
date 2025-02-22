namespace ToDoListApplication.ViewModels
{
    public class ListFromUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateOnly DeadlineDate { get; set; }
        public TimeOnly DeadlineTime { get; set; }
    }
}
