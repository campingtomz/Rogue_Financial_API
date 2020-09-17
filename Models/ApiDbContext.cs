using RogueFinancialPortal.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Rogue_Financial_API.Models
{
    ///<summary>
    ///ApiDbContext
    ///</summary>
    public class ApiDbContext : DbContext
    {
        ///<summary>
        ///Connect to Database
        ///</summary>
        public ApiDbContext()

            : base("ApiConnection")
        {
        }
        #region Get Data By Id
        ///<summary>
        ///Gets the HouseHold data by Id
        ///</summary>
        ///<remarks> 
        ///</remarks>
        ///<returns>Id, OwnerId, HouseHoldName, Greeting, CreatedDate, IsDeleted</returns>
        public async Task<HouseHold> GetHouseholdDataById(int hhId)
        {
            return await Database.SqlQuery<HouseHold>("[GetHouseholdDataById] @hhId",
            new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }
        public async Task<BankAccount> GetBankDataById(int Id)
        {
            return await Database.SqlQuery<BankAccount>("[GetBankDataById] @Id",
            new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }
        public async Task<Budget> GetBudgetDataById(int Id)
        {
            return await Database.SqlQuery<Budget>("[GetBudgetDataById] @Id",
            new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }
        public async Task<BudgetItem> GetBudgetItemDataById(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("[GetBudgetItemDataById] @Id",
            new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }
        public async Task<Transaction> GetTransactionDataById(int Id)
        {
            return await Database.SqlQuery<Transaction>("[GetTransactionDataById] @Id",
            new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }
        public async Task<Member> GetHouseholdMemberById(int Id)
        {
            return await Database.SqlQuery<Member>("[GetHouseholdMemberById] @Id",
            new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }


        #endregion
        #region Get all data
        
        public async Task<List<BankAccount>> GetAllBankData(int hhId)
        {
            return await Database.SqlQuery<BankAccount>("[GetAllBankData] @hhId",
            new SqlParameter("hhId", hhId)).ToListAsync();

        }
        public async Task<List<Budget>> GetAllBudgetData(int hhId)
        {
            return await Database.SqlQuery<Budget>("[GetAllBudgetData] @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }
        public async Task<List<BudgetItem>> GetAllBudgetItemData(int hhId)
        {
            return await Database.SqlQuery<BudgetItem>("[GetAllBudgetItemData] @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }
        public async Task<List<Transaction>> GetAllTransactionData(int hhId)
        {
            return await Database.SqlQuery<Transaction>("[GetAllTransactionData] @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }
        public async Task<List<Transaction>> GetBankAndTransactionData(int Id)
        {
            return await Database.SqlQuery<Transaction>("[GetBankAndTransactionData] @Id",
                new SqlParameter("Id", Id)).ToListAsync();
        }
        public async Task<List<Member>> GetHouseholdMembers(int hhId)
        {
            return await Database.SqlQuery<Member>("[GetHouseholdMembers] @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }

        #endregion
        #region hard Delete By Id
        public int DeleteHouseHoldById(int hhId)
        {
            return Database.ExecuteSqlCommand("[DeleteHouseHoldById] @hhId",
               new SqlParameter("hhId", hhId));
        }
        public int DeleteBankAccountById(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteBankAccountById] @Id",
               new SqlParameter("Id", Id));
        }
        public int DeleteBudgetById(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteBudgetdById] @Id",
               new SqlParameter("Id", Id));
        }
        public int DeleteBudgetItemById(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteBudgetItemById] @Id",
               new SqlParameter("Id", Id));
        }
        public int DeleteTransactionById(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteTransactionById] @Id",
               new SqlParameter("Id", Id));
        }
        public int DeleteNotificationById(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteNotificationById] @Id",
               new SqlParameter("Id", Id));
        }
        
        #endregion
        #region soft Delete By Id
        public int SoftDeleteHouseHoldById(int hhId)
        {
            return Database.ExecuteSqlCommand("[SoftDeleteHouseHoldById] @hhId",
               new SqlParameter("hhId", hhId));
        }
        public int SoftDeleteBankAccountById(int Id)
        {
            return Database.ExecuteSqlCommand("[SoftDeleteBankAccountById] @Id",
               new SqlParameter("Id", Id));
        }
        public int SoftBudgetDeleteById(int Id)
        {
            return Database.ExecuteSqlCommand("[SoftBudgetDeleteById] @Id",
               new SqlParameter("Id", Id));
        }
        public int SoftBudgetItemDeleteById(int Id)
        {
            return Database.ExecuteSqlCommand("[SoftBudgetItemDeleteById] @Id",
               new SqlParameter("Id", Id));
        }
        public int SoftTransactionDeleteById(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteTransactionById] @Id",
               new SqlParameter("Id", Id));
        }
   
        #endregion
        #region insert/created
        public int CreateHouseHold(string OwnerId, string HouseHoldName, string Greeting)
        {
            return  Database.ExecuteSqlCommand("InsertHouseHoldData @OwnerId @HouseHoldName @Greeting",
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("HouseHoldName", HouseHoldName),
                new SqlParameter("Greeting", Greeting));
        }
        public int CreateBankAccount(int HouseHoldId, string OwnerId, string BankAccountName, decimal StartingBalance, decimal WarningBalance, int AccountType)
        {
            return Database.ExecuteSqlCommand("InsertBankAccountData @HouseHoldId @OwnerId @BankAccountName @StartingBalance @WarningBalance @AccountType",
                new SqlParameter("HouseHoldId", HouseHoldId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("BankAccountName", BankAccountName),
                new SqlParameter("StartingBalance", StartingBalance),
                new SqlParameter("WarningBalance", WarningBalance),
                new SqlParameter("AccountType", AccountType));
        }
        public int CreateBudget(int HouseHoldId, string OwnerId, int BankAccontId, string BudgetName, string Description)
        {
            return Database.ExecuteSqlCommand("InsertBudgetData @HouseHoldId @OwnerId @BankAccontId @BudgetName @Description ",
                new SqlParameter("HouseHoldId", HouseHoldId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("BankAccontId", BankAccontId),
                new SqlParameter("BudgetName", BudgetName),
                new SqlParameter("Description", Description)
                );
        }
        public int CreateBudgetItem(int HouseHoldId, string OwnerId, int BudgetId, string ItemName, string Description, decimal TargetAmount)
        {
            return  Database.ExecuteSqlCommand("InsertBudgetItemData @HouseHoldId @OwnerId @BudgetId @ItemName @Description @TargetAmount",
                new SqlParameter("HouseHoldId", HouseHoldId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("BudgetId", BudgetId),
                new SqlParameter("ItemName", ItemName),
                new SqlParameter("Description", Description),
                new SqlParameter("TargetAmount", TargetAmount)

                );
        }
        public int CreateTransaction(int OwnerId, int BankAccontId, int BudgetItemId, string TransactionType, string Amount, string Memo, string FilePath)
        {
            return  Database.ExecuteSqlCommand("InsertTransactionData @OwnerId @BankAccontId @BudgetItemId @TransactionType @Amount @Memo @FilePath",
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("BankAccontId", BankAccontId),
                new SqlParameter("BudgetItemId", BudgetItemId),
                new SqlParameter("TransactionType", TransactionType),
                new SqlParameter("Amount", Amount),
                new SqlParameter("CurrentAmount", Memo),
                new SqlParameter("TargetAmount", FilePath)
                );
        }
        public  int CreateMember(string Id, string FirstName, string LastName, string Description, string AvatarPath, int HouseHoldId, string Email, string PhoneNumber, string UserName)
        {
            return Database.ExecuteSqlCommand("InsertMemberData @Id @FirstName @LastName @Description @AvatarPath @HouseHoldId @Email @PhoneNumber @UserName",
                new SqlParameter("Id", Id),
                new SqlParameter("FirstName", FirstName),
                new SqlParameter("LastName", LastName),
                new SqlParameter("Description", Description),
                new SqlParameter("AvatarPath", AvatarPath),
                new SqlParameter("HouseHoldId", HouseHoldId),
                new SqlParameter("Email", Email),
                new SqlParameter("TargetAmount", PhoneNumber),
                new SqlParameter("UserName", UserName)
                );
        }
        #endregion
        #region Update Database Item
        public int UpdateHouseHold(int Id, string OwnerId, string HouseHoldName, string Greeting, int IsDeleted)
        {
            return Database.ExecuteSqlCommand("InsertHouseHoldData @Id @ OwnerId @HouseHoldName @Greeting @IsDeleted",
                new SqlParameter("Id", Id),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("HouseHoldName", HouseHoldName),
                new SqlParameter("Greeting", Greeting),
                new SqlParameter("IsDeleted", IsDeleted));
        }
        public int UpdateBankAccount(int HouseHoldId, int Id, string BankAccountName, decimal WarningBalance, int AccountType, int IsDeleted)
        {
            return Database.ExecuteSqlCommand("UpdateBankAccountDataById @HouseHoldId @Id @BankAccountName @WarningBalance @AccountType @IsDeleted",
                new SqlParameter("HouseHoldId", HouseHoldId),
                new SqlParameter("Id", Id),
                new SqlParameter("BankAccountName", BankAccountName),
                new SqlParameter("WarningBalance", WarningBalance),
                new SqlParameter("AccountType", AccountType),
                new SqlParameter("IsDeleted", IsDeleted));
        }
        public int UpdateBudget( int Id, int BankAccontId, string BudgetName, string Description, int IsDeleted)
        {
            return Database.ExecuteSqlCommand("UpdateBudgetDataById @Id @BankAccontId @BudgetName @Description  @IsDeleted",
               
                new SqlParameter("Id", Id),
                new SqlParameter("BankAccontId", BankAccontId),
                new SqlParameter("BudgetName", BudgetName),
                new SqlParameter("Description", Description),
                new SqlParameter("IsDeleted", IsDeleted)
                );
        }
        public int UpdateBudgetItem(int Id, int BudgetId, string ItemName, string Description,  decimal TargetAmount, int IsDeleted)
        {
            return Database.ExecuteSqlCommand("InsertBudgetItemData @Id @BudgetId @ItemName @Description  @TargetAmount @IsDeleted",
                new SqlParameter("Id", Id),
                new SqlParameter("BudgetId", BudgetId),
                new SqlParameter("ItemName", ItemName),
                new SqlParameter("Description", Description),
                new SqlParameter("TargetAmount", TargetAmount),
                new SqlParameter("IsDeleted", IsDeleted)
                );
        }
        public int UpdateTransaction(int Id, string BankAccontId, int BudgetItemId, string TransactionType, string Amount, string Memo, string FilePath, int IsDeleted)
        {
            return Database.ExecuteSqlCommand("InsertMemberData @Id @BankAccontId @BudgetItemId @TransactionType @Amount @Memo @FilePath @IsDeleted",
                new SqlParameter("Id", Id),
                new SqlParameter("BankAccontId", BankAccontId),
                new SqlParameter("BudgetItemId", BudgetItemId),
                new SqlParameter("TransactionType", TransactionType),
                new SqlParameter("Amount", Amount),
                new SqlParameter("CurrentAmount", Memo),
                new SqlParameter("FilePath", FilePath),               
                new SqlParameter("IsDeleted", IsDeleted)

                );
        }
        public int UpdateMember(string Id, string FirstName, string LastName, string Description, string AvatarPath, int HouseHoldId, string Email, string PhoneNumber, string UserName)
        {
            return Database.ExecuteSqlCommand("InsertMemberData @Id @FirstName @LastName @Description @AvatarPath @HouseHoldId @Email @PhoneNumber @UserName @IsDeleted",
                new SqlParameter("Id", Id),
                new SqlParameter("FirstName", FirstName),
                new SqlParameter("LastName", LastName),
                new SqlParameter("Description", Description),
                new SqlParameter("AvatarPath", AvatarPath),
                new SqlParameter("HouseHoldId", HouseHoldId),
                new SqlParameter("Email", Email),
                new SqlParameter("TargetAmount", PhoneNumber),
                new SqlParameter("UserName", UserName)
                );
        }
#endregion
    }
}
