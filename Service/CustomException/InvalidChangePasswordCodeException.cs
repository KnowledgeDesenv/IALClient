namespace IALClient.Service.CustomException;

public class InvalidChangePasswordCodeException() : Exception("The account is not pendent to change password or the code is invalid")
{
    
}
