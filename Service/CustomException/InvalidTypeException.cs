namespace IALClient.Service.CustomException;

public class InvalidTypeException(string type) : Exception("The type: " + type + " is invalid")
{
}
