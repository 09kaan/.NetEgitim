using FluentValidation;
using MediatR;
using FluentValidation.Results;

namespace Gun16.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
    {
        return await next();
    }
    ValidationContext<TRequest> context = new(request);

    List<ValidationFailure> failures = new();

    foreach (IValidator<TRequest> validator in _validators)
    {
        ValidationResult result = await validator.ValidateAsync(context, cancellationToken);

        failures.AddRange(result.Errors);
    }
    if (failures.Count > 0)
    {
        throw new ValidationException(failures);
    }
        return await next();
    }
}