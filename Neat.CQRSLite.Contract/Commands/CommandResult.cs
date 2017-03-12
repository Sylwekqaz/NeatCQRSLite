using System;
using System.Collections.Generic;
using System.Linq;

namespace Neat.CQRSLite.Contract.Commands
{
    public class CommandResult
    {
        private CommandResult(IEnumerable<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors == null
                ? new List<ValidationError>()
                : new List<ValidationError>(validationErrors);
        }

        public IReadOnlyList<ValidationError> ValidationErrors { get; }
        public bool WasSuccessful() => !ValidationErrors.Any();

        public static CommandResult Success()
        {
            return new CommandResult(null);
        }

        public static CommandResult NotValid(IEnumerable<ValidationError> validationResult)
        {
            if (validationResult == null) throw new ArgumentNullException(nameof(validationResult));
            if (!validationResult.Any())
                throw new ArgumentException(
                    "Cannot create notvalid command result if no validation errors was occurred.",
                    nameof(validationResult));
            System.Diagnostics.Contracts.Contract.EndContractBlock();

            return new CommandResult(validationResult);
        }
    }
}