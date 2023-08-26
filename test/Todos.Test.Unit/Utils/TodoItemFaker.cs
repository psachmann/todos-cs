namespace Todos.Test.Unit.Utils;

public class TodoItemFaker : AutoFaker<TodoItemEntity>
{
    public const string RuleSetPersisted = "Persisted";
    public const string RuleSetNotPersisted = "NotPersisted";

    public TodoItemFaker()
    {
        RuleSet(RuleSetPersisted, (rules) => { });

        RuleSet(RuleSetNotPersisted, (rules) =>
        {
            RuleFor((fake) => fake.Id, () => Guid.Empty);
            RuleFor((fake) => fake.CreatedAt, () => DateTime.Now);
            RuleFor((fake) => fake.UpdatedAt, () => DateTime.Now);
        });
    }
}
