using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public static class NotificationConstants
    {
        // Common
        public const string UpDateSuccess = "Cập nhật thành công";

        public const string UpdateFailed = "Cập nhật KHÔNG thành công";

        public const string Error = "Đã có lỗi xảy ra, vui lòng thử lại sau.";

        public const string CreateSuccess = "Tạo mới thành công";

        public const string CreateFailed = "Tạo mới KHÔNG thành công";

        public const string DeleteSuccess = "Xóa thành công";

        public const string DeleteFailed = "Xóa KHÔNG thành công";

        public const string InvalidForm = "Thông tin trong form không hợp lệ";

        public const string FileNotFound = "Không có file nào được tìm thấy";

        public const string FileUploadSuccess = "Tải lên file thành công";


        // For user 
        public const string NotLogging = "Bạn chưa đăng nhập";

        public const string ExistUserName = "Tên đăng nhập đã tồn tại";

        public const string ExistEmail = "Email đã đăng kí cho tài khoản khác";

        public const string ChangePassFailed = "Không thể đổi mật khẩu";

        public const string ChangePassSuccess = "Đổi mật khẩu thành công";

        public const string UserNotFound = "Không tìm thấy tài khoản";

        public const string ExistInWishlist = "Sản phẩm đã có trong danh sách yêu thích";

        public const string AddToWishlistSuccess = "Thêm vào yêu thích thành công";

        public const string WishlistNotFound = "Không thể tải danh sách yêu thích";

        public const string InputCurrentPass = "Nhập mật khẩu hiện tại nếu bạn muốn đổi mật khẩu mới";

        public const string SignInFailed = "Đăng nhập không thành công, vui lòng thử lại";

        public const string SendConfirmEmailFailed = "Không thể gửi email xác nhận";

        public const string SignUpFailed = "Đăng kí không thành công, vui lòng thử lại";

        public const string SignUpSuccess = "Đăng kí thành công, vui lòng xác nhận email trước khi đăng nhập";

        public const string LockoutAccount = "Tài khoản này đã bị khóa, vui lòng thử tài khoản khác hoặc phản hồi lại";

        public const string FacebookSignInFailed = "Đăng nhập với facebook không thành công";

        public const string GoogleSignInFailed = "Đăng nhập với google không thành công";

        public const string SendResetPassEmailSuccess = "Đăng nhập với facebook không thành công";

        public const string GetTokenFailed = "Không thể lấy thông tin để đổi mật khẩu";


        // For contact (feedback)
        public const string FeedbackSuccess = "Thành công! Xin cảm ơn góp ý của bạn";

        public const string FeedbackFailed = "Không thể gửi phản hồi, vui lòng thử lại";

        public const string FeedbackNotFound = "Không tìm thấy phản hồi";


        // For cart and order
        public const string OrderNotFound = "Không tìm thấy đơn hàng";

        public const string AddToCartSussess = "Thêm vào giỏ thành công";

        public const string ExistInCart = "Sản phẩm này đã có trong giỏ hàng";

        public const string AddToCartFailed = "Không thể thêm vào giỏ hàng";

        public const string CouponInvalid = "Mã giảm giá không hợp lệ hoặc đã hết hạn";

        public const string CouponNotFound = "Mã giảm giá không tồn tại";

        public const string CouponSuccess = "Đã áp dụng mã giảm giá cho đơn hàng này";

        public const string CheckoutSuccess = "Đặt hàng thành công";

        public const string CheckoutFailed = "Đặt hàng không thành công";

        public const string RemoveCartItemSuccess = "Xóa sản phẩm thành công";

        public const string RemoveCartItemFailed = "Không thể xóa sản phẩm khỏi giỏ hàng";

        public const string ClearCartFailed = "Xóa giỏ hàng không thành công";

        public const string OrderDateFilterInvalid = "Thời gian lọc kết quả không hợp lệ";

        public const string AsyncCartFailed = "Không thể đồng bộ giỏ hàng của bạn";

        public const string OrderTrackingNotFound = "Rất tiếc chúng tôi không tìm thấy kết quả phù hợp. Vui lòng thử lại với mã đơn hàng khác.";

        public const string OrderCodeInValid = "Mã đơn hàng không hợp lệ. Vui lòng thử lại với mã đơn hàng khác.";

        public const string OrderTrackingSuccess = "Đã tìm thấy đơn hàng của bạn.";

        // For payment online
        public const string PaymentNotLogin = "Bạn cần đăng nhập để thanh toán online.";

        public const string PaymentInfoNotFound = "Không tìm thấy thông tin đặt hàng, vui lòng thực hiện lại.";

        public const string PaypalGetAccessTokenFailed = "Hiện tại không thể thanh toán qua Paypal, vui lòng chọn phương thức thanh toán khác.";

        public const string MomoSignatureNotEqual = "Thông tin thanh toán không hợp lệ.";

        public const string MomoCreatePaymentSuccess = "Thanh toán thành công.";



        // For brand
        public const string BrandNotFound = "Không tìm thấy thương hiệu";

        // For category
        public const string CategoryNotFound = "Không tìm thấy danh mục";

        // For menu
        public const string MenuNotFound = "Không tìm thấy menu";

        // For option
        public const string OptionNotFound = "Không tìm thấy tùy chọn";

        // For product
        public const string ProductNotFound = "Không tìm thấy sản phẩm";

        // For promotion
        public const string PromotionNotFound = "Không tìm thấy phiếu giảm giá";

        // For tag
        public const string TagNotFound = "Không tìm thấy thẻ nào";

        // For rating
        public const string CreateRatingSusscess = "Thành công! Xin cảm ơn đánh giá của bạn";

        // For post
        public const string PostNotFound = "Không tìm thấy bài viết";
        public const string CreatePostCommentSusscess = "Thành công! Xin cảm ơn đánh giá của bạn";

    }
}