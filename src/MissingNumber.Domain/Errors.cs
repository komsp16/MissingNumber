using System;

namespace MissingNumber.Domain;

public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}

public class DuplicateValueException : InvalidInputException
{
    public DuplicateValueException(string message) : base(message) { }
}

public class OutOfRangeValueException : InvalidInputException
{
    public OutOfRangeValueException(string message) : base(message) { }
}
