namespace Entities.Exceptions
{
    public sealed class RolNotFoundException : NotFoundException
    {
        public RolNotFoundException(string rol)
            : base($"The rol with name: {rol} doesn't exist in the database.")
        {
        }
    }
}
