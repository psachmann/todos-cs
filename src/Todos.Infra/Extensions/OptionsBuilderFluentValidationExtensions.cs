namespace Todos.Infra.Extensions;

public static class OptionsBuilderFluentValidationExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluently<TOptions>(this OptionsBuilder<TOptions> optionsBuilder)
        where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>((provider) =>
            new FluentValidationOptions<TOptions>(optionsBuilder.Name, provider.GetRequiredService<IValidator<TOptions>>()));

        return optionsBuilder;
    }
}
