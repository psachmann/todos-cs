namespace Todos.Core.Features.Todo;

public sealed class CreateTodoItemValidator : AbstractValidator<CreateTodoItemCommand>
{
    public static readonly int MaxTitleLength = 100;
    public static readonly int MaxDescriptionLength = 1_000;

    public CreateTodoItemValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .MaximumLength(MaxTitleLength);

        RuleFor(command => command.Description)
            .NotNull()
            .MaximumLength(MaxDescriptionLength);
    }
}
