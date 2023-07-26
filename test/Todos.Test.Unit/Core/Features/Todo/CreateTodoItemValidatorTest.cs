namespace Todos.Test.Unit.Core.Features.Todo;

public class CreateTodoItemValidatorTest
{
    private readonly CreateTodoItemValidator _sut = new();

    [Theory]
    [InlineData(1, 0, true)]
    [InlineData(Limits.MaxShortString, Limits.MaxLongString, false)]
    public void Validate_ShouldReturnTrue(int titleLength, int descriptionLength, bool done)
    {
        var command = new CreateTodoItemCommand
        {
            Title = new string('*', titleLength),
            Description = new string('*', descriptionLength),
            Done = done,
        };

        _sut.Validate(command).IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null, 0, true)]
    [InlineData(1, null, false)]
    [InlineData(0, 0, true)]
    [InlineData(Limits.MaxShortString + 1, 0, false)]
    [InlineData(1, Limits.MaxLongString + 1, false)]
    public void Validate_ShouldReturnFalse(int? titleLength, int? descriptionLength, bool done)
    {
        var command = new CreateTodoItemCommand
        {
            Title = titleLength is not null ? new string('*', titleLength.Value) : null!,
            Description = descriptionLength is not null ? new string('*', descriptionLength.Value) : null!,
            Done = done,
        };

        _sut.Validate(command).IsValid.Should().BeFalse();
    }
}
