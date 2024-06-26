namespace NewGymIgalTalProject.App_Code
{
    public class AccountDetails
    {
        public int UserId { get; private set; }
        public string UserPassword { get; private set; }

        public AccountDetails()
        {
        }

        public AccountDetails(int userId, string userPassword)
        {
            UserId = userId;
            UserPassword = userPassword;
        }

        public int AccoundID
        {
            get
            {
                return UserId;
            }
        }

        public string AcocoundPassword
        {
            get
            {
                return UserPassword;
            }
        }

        public AccountDetails GetAccount(int userId, string userPassword)
        {
            AccountDetails account = new AccountDetails(userId, userPassword);
            return account;
        }
    }
}
