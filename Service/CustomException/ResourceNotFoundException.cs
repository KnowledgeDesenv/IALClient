namespace IALClient.Service.CustomException;

public class ResourceNotFoundException(string message) : Exception(message)
{
}
