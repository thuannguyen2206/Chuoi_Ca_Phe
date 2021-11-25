using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Messages
{
    public class UserMessage
    {
        public const string CreateFailed = "User.CreateFailed";

        public const string UpdateFailed = "User.UpdateFailed";

        public const string NotFound = "User.NotFound";

        public const string WishlistExisted = "Wishlist.Existed";

        public const string WishlistNotFound = "Wishlist.NotFound";

        public const string ExistUserName = "User.ExistUserName";

        public const string ExistEmail = "User.ExistEmail";

        public const string ChangePassFailed = "User.ChangePassFailed";

        public const string NotPermisstion = "User.NotPermisstion";

        public const string ContactNotFound = "Contact.NotFound";
    }
}
