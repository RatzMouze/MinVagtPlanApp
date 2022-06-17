using MinVagtPlanDK.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MinVagtPlanDK.Services
{
    public static class Authenticator
    {
        static SQLiteAsyncConnection db;

        private static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MinVagtPlanDB.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<AuthObj>();
        }

        public static async Task RemoveAuthKey()
        {
            await db.DeleteAllAsync<AuthObj>();
        }

        public static string GetAuthKey()
        {
            Init();

            var authObjList = db.Table<AuthObj>().ToListAsync();

            if (authObjList != null)
            {
                foreach (AuthObj authObj in authObjList.Result)
                {
                    if (DateTime.Compare(DateTime.Now, authObj.KeyEndDate) < 0 && DateTime.Compare(DateTime.Now, authObj.LastLogin) > 0)
                        return authObj.AuthKey;
                }
            }

            return null;
        }

        public static void SetAuthKey(string _AuthKey)
        {
            Init();

            try
            {
                RemoveAuthKey();
            }
            catch { }

            var authObj = new AuthObj
            {
                AuthKey = "Bearer " + _AuthKey,
                LastLogin = DateTime.Now,
                KeyEndDate = DateTime.Now.AddMonths(3)
            };

            db.InsertAsync(authObj);
        }
    }
}
