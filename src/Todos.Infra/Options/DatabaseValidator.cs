namespace Todos.Infra.Options;

internal class DatabaseValidator : AbstractValidator<DatabaseOptions>
{
    public DatabaseValidator()
    {
        RuleFor((options) => options.Connection)
            .NotEmpty();
    }
}
