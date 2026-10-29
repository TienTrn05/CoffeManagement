using QuanLyQuanCaPhe.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.BLL
{
    class AccountBLL
    {
        private static AccountBLL _instance;

      
        public static AccountBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AccountBLL();
                return _instance;
            }
        }

        private AccountBLL() { }

        public List<Account> GetAllAccounts()
        {
            using (var context = new CoffeeManagementEntities1())
            {
                return context.Accounts.ToList();
            }
         
        }

        public bool InsertAccount(string username, string displayName, string access)
        {
            using (var context = new CoffeeManagementEntities1())
            {
                foreach (var a in context.Accounts)
                {
                    if (a.Username == username)
                        return false;
                }

                Account acc = new Account
                {
                    Username = username,
                    DisplayName = displayName,
                    Password = PasswordHasher.Md5("1"),
                    Access = access
                };

                context.Accounts.Add(acc);
                context.SaveChanges();
                return true;
            }
        }

        public bool UpdateAccount(string username, string currentPassword, string newPassword, string newDisplayName)
        {
            try
            {
                using (var context = new CoffeeManagementEntities1())
                {
                    string hashedCurrent = PasswordHasher.Md5(currentPassword);

                    var acc = context.Accounts
                                     .FirstOrDefault(a => a.Username == username && a.Password == hashedCurrent);

                    if (acc != null)
                    {
                        acc.DisplayName = newDisplayName;

                        if (!string.IsNullOrEmpty(newPassword))
                            acc.Password = PasswordHasher.Md5(newPassword);

                        context.SaveChanges();
                        return true;
                    }

                    MessageBox.Show("Mật khẩu hoặc tên đăng nhập không đúng");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                return false;
            }
        }


        public bool EditAccount(string username, string newDisplayName, string access)
        {
            using (var context = new CoffeeManagementEntities1())
            {

                var acc = context.Accounts
                                 .FirstOrDefault(a => a.Username == username);

                if (acc.Username == username)
                    {
                        acc.DisplayName = newDisplayName;
                        acc.Access = access;
                        context.SaveChanges();
                        return true;
                    }
                
                return false;
            }
        }

        public bool DeleteAccount(string username)
        {
            using (var context = new CoffeeManagementEntities1())
            {
                for (int i = 0; i < context.Accounts.Count(); i++)
                {
                    var acc = context.Accounts.ToList()[i];
                    if (acc.Username == username)
                    {
                        context.Accounts.Remove(acc);
                        context.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
        }

 

        public bool IsLoginValid(string username, string password)
        {
            using (var context = new CoffeeManagementEntities1())
            {
                string hashed = PasswordHasher.Md5(password);
                foreach (var acc in context.Accounts)
                {
                    if (acc.Username == username && acc.Password == hashed)
                        return true;
                }
                return false;
            }
        }

        public Account GetAccountByUsername(string username)
        {
            using (var context = new CoffeeManagementEntities1())
            {
               var acc = context.Accounts
                            .FirstOrDefault(a => a.Username == username);
                if (acc.Username == username)
                        return acc;
                

                return null;
            }
        }
    }
}
