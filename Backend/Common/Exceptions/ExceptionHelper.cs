namespace Common.Exceptions
{
    public static class ExceptionHelper
    {
        public static InnerException InvalidCredentials()
        {
            throw new InnerException("Неверный логин или пароль! Пожалуйста, попробуйте еще раз!", "password");
        }
    }
}
