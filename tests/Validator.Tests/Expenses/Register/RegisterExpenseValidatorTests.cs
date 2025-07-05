using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommomTestsUtilities.Requests;
using Shouldly;

namespace Validator.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("         ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = title;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.ShouldSatisfyAllConditions(
            () => result.IsValid.ShouldBeFalse(),
            () => result.Errors.ShouldContain(r => r.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED)) 
        );
    }

    [Fact]
    public void Error_Date_Future()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.ShouldSatisfyAllConditions(
            () => result.IsValid.ShouldBeFalse(),
            () => result.Errors.ShouldContain(r => r.ErrorMessage.Equals(ResourceErrorMessages.DATE_CANNOT_BE_FOR_THE_FUTURE))
        );

    }

    [Fact]
    public void Error_PaymentType_Invalid()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)18;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.ShouldSatisfyAllConditions(
            () => result.IsValid.ShouldBeFalse(),
            () => result.Errors.ShouldContain(r => r.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID))
        );
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(-50)]
    public void Error_Amount_Invalid(decimal amount)
    {
        // Arrange 
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.ShouldSatisfyAllConditions(
            () => result.IsValid.ShouldBeFalse(),
            () => result.Errors.ShouldContain(r => r.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREAT_THAN_ZERO))
        );
    }

}
