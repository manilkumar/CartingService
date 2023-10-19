namespace Domain.Exceptions
{
    public sealed class BadKeyException : BadRequestException
    {
        public BadKeyException(string entity, string? entityId, string? passedId)
            : base(String.Format("Passed key {2} not matching Entity {0} key {1}.", entity, entityId, passedId))
        {
        }
    }
}