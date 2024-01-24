using FluentValidation.Results;

namespace GenshinTools.Application.Exceptions;
public class BadRequestException : Exception {
    public IDictionary<string, string[]> ValidationErrors { get; set; }
    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, ValidationResult valResult) : base(message) {
        ValidationErrors = valResult.ToDictionary();
    }
}