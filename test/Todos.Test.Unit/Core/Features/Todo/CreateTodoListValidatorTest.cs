namespace Todos.Test.Unit.Core.Features.Todo;

public class CreateTodoListValidatorTest
{
    private readonly CreateTodoListValidator _sut = new();

    [Theory]
    [InlineData(1)]
    [InlineData(Limits.MaxShortString)]
    public void Validate_ShouldReturnTrue(int titleLength)
    {
        var command = new CreateTodoListCommand
        {
            Title = new string('*', titleLength),
        };

        _sut.Validate(command).IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData(0)]
    [InlineData(Limits.MaxShortString + 1)]
    public void Validate_ShouldReturnFalse(int? titleLength)
    {
        var command = new CreateTodoListCommand
        {
            Title = titleLength is not null ? new string('*', titleLength.Value) : null!,
        };

        _sut.Validate(command).IsValid.Should().BeFalse();
    }
}
