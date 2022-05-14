namespace Application.Exceptions
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string msg) : base(msg) { }
    }
}
