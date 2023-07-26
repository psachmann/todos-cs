namespace Todos.Core.Features.Todo;

public sealed class CreateTodoListValidator : AbstractValidator<CreateTodoListCommand>
{
    public static readonly int MaxTitleLength = 100;

    public CreateTodoListValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .MaximumLength(MaxTitleLength);
    }
}
