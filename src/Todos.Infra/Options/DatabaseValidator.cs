namespace Todos.Infra.Options;

internal class DatabaseValidator : AbstractValidator<DatabaseOptions>
{
    public DatabaseValidator()
    {
        RuleFor((options) => options.Host)
            .NotEmpty();

        RuleFor((options) => options.Database)
            .NotEmpty();

        RuleFor((options) => options.Username)
            .NotEmpty();

        RuleFor((options) => options.Password)
            .NotEmpty();
    }
}
