using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Messages
{
    public static class AuthMessage
    {
        // sign in
        public const string UserNotFound = "SignIn.UserNotFound";
        public const string UserLockout = "SignIn.UserLockout";
        public const string Invalid = "SignIn.Invalid";
        public const string LoginException = "SignIn.SignInException";
        public const string EmailConfirmRequired = "SignIn.EmailConfirmRequired";

        // sign up
        public const string ExistUsername = "SignUp.ExistUsername";
        public const string ExistEmail = "SignUp.ExistEmail";
        public const string CannotSendEmail = "SignUp.CannotSendEmail";

        // reset password
        public const string ResetPasswordFailed = "ResetPasswordFailed";

        // subject email
        public const string SubjectConfirmEmail = "Xác nhận email đăng kí";
        public const string SubjectResetPassword = "Đổi mật khẩu";
        public const string SubjectNewOrder = "Đơn hàng mới";

    }
}
