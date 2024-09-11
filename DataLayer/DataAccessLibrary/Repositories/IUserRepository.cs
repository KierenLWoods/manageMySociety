public interface IUserRepository
{
    Task<int> InsertUserRecord(UserSignUpModel userData);
}
