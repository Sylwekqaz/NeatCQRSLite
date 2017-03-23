using System;

namespace Neat.CQRSLite.Contract.Commands
{
    public class ValidationError : IEquatable<ValidationError>
    {
        public ValidationError(string propertyName, string errorMessage, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            AttemptedValue = attemptedValue;
        }

        public string PropertyName { get; }
        public string ErrorMessage { get; }
        public object AttemptedValue { get; }

        public bool Equals(ValidationError other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(PropertyName, other.PropertyName) && string.Equals(ErrorMessage, other.ErrorMessage) &&
                   Equals(AttemptedValue, other.AttemptedValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValidationError) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = PropertyName?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (ErrorMessage?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (AttemptedValue?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}