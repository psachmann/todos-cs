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

    private string TitleInput { get; set; } = string.Empty;

    private string DescriptionInput { get; set; } = string.Empty;

    private List<TodoItem> Todos { get; } = new();

    private void AddTodoItem()
    {
        if (TitleInput != string.Empty && DescriptionInput != string.Empty)
        {
            Todos.Add(new(TitleInput, DescriptionInput, false));
            ResetInput();
        }
    }

    private void ResetInput()
    {
        TitleInput = string.Empty;
        DescriptionInput = string.Empty;
    }
}
