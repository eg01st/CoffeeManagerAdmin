using CoffeeManager.Models;
using MvvmCross.Platform;
using MvvmCross.Plugins.File;
using Newtonsoft.Json;

namespace CoffeeManagerAdmin.Core
{
    public class LocalStorage
    {
        private static IMvxFileStore storage = Mvx.Resolve<IMvxFileStore>();
        private const string UserInfo = "UserInfo";
        public static UserInfo GetUserInfo()
        {
            var info = GetStorage<UserInfo>(UserInfo);
            return info;
        }
        public static void SetUserInfo(UserInfo info)
        {
            storage.WriteFile(UserInfo, JsonConvert.SerializeObject(info));
        }

        private static T GetStorage<T>(string fileName) where T : new ()
        {
            string storageJson;
            if (storage.TryReadTextFile(fileName, out storageJson))
            {
                return JsonConvert.DeserializeObject<T>(storageJson);
            }
            else
            {
                return new T();
            }
        }
    }
}
