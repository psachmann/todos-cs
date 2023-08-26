namespace Todos.Test.Unit.Utils;

public class TodoItemFaker : AutoFaker<TodoItemEntity>
{
    public TodoItemFaker(bool wasPersisted = false)
    {
        if (wasPersisted)
        {
            RuleFor((fake) => fake.Id, () => AutoFaker.Generate<Guid>());
            RuleFor((fake) => fake.CreatedAt, () => AutoFaker.Generate<DateTimeOffset>());
            RuleFor((fake) => fake.UpdatedAt, () => AutoFaker.Generate<DateTimeOffset>());
        }

        RuleFor((fake) => fake.Title, () => AutoFaker.Generate<string>());
        RuleFor((fake) => fake.Description, () => AutoFaker.Generate<string>());
        RuleFor((fake) => fake.IsDone, () => AutoFaker.Generate<bool>());
    }
}
