namespace Todos.Client.Pages;

public sealed partial class TodoItems
{
    class TodoItem
    {
        public TodoItem(string Title, string Description, bool Done)
        {
            this.Title = Title;
            this.Description = Description;
            this.Done = Done;
        }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Done { get; set; }
    };

    List<TodoItem> Todos { get; } = new()
    {
        new TodoItem("Item 1", "The first todo item", false),
        new TodoItem("Item 2", "The second todo item", false),
        new TodoItem("Item 3", "The third todo item", false),
    };

    void AddTodoItem(string title, string descrition, bool done)
    {
        Todos.Add(new(title, descrition, done));
    }
}
