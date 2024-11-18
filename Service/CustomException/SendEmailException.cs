namespace IALClient.Service.CustomException;

public class SendEmailException(string message) : Exception(message)
{
}
