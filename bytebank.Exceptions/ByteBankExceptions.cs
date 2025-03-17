namespace bytebank.Exceptions;

[Serializable]
public class ByteBankExceptions : Exception
{
    public ByteBankExceptions() { }

    public ByteBankExceptions(string message)
        : base("Aconteceu uma exceção -> " + message) { }

    public ByteBankExceptions(string message, System.Exception inner)
        : base(message, inner) { }

    protected ByteBankExceptions(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context
    )
    : base(info, context) { }
}
