namespace IALClient.Service.CustomException;

public class CreateUserException(string message) : Exception(message)
{
}
