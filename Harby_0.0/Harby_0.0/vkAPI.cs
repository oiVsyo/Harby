using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace Harby_0._0
{
    class vkAPI
    {
        private int appId = 4785272; // указываем id приложения
        public int UserId = 0;
        public string AccessToken = "";

        public vkAPI(int userId, string accessToken)
        {
            this.UserId = userId;
            this.AccessToken = accessToken;
        }

        /// <summary>
        /// Возвращает профиль текущего пользователя
        /// </summary>
        public VkNet.Model.User GetProfile()
        {
            var api = new VkApi();
            api.AccessToken = AccessToken;
            var profile = api.Users.Get((long)UserId, ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Photo100);
            return profile;
        }
    }
}
