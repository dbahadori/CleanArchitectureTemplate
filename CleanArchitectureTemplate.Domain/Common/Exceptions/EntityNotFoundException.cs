
namespace CleanArchitectureTemplate.Domain.Common.Exceptions;

public class EntityNotFoundException : CustomException
{

    public EntityNotFoundException()
        : base(string.Empty, null)
    {
    }


    public EntityNotFoundException(string resourceName, object key, string? userFriendlyMessage)
        : base(userFriendlyMessage)
    {
        DeveloperDetail = $"Resource \"{resourceName}\" ({key}) was not found.";
    }
}
