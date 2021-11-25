
var Utils = {

    AddToWishList: function (productId) {
        $.ajax({
            url: "/User/AddToWishList",
            method: "POST",
            cache: false,
            data: { productId: productId },
            success: function (result) {
                console.log(result);
                if (result === true) {
                    let productCount = $(".header-bottom .header-wishlist .pro-count").text();
                    productCount = parseInt(productCount) + 1;
                    $(".header-wishlist .pro-count").text(productCount);
                }
            }
        });
    },

    AddToCart: function (productId, quantity = 1, sizeid = 0) {
        $.ajax({
            url: "/Cart/AddToCart",
            method: "POST",
            cache: false,
            data: { id: productId, quantity: quantity, sizeid: sizeid },
            success: function (result) {
                if (result === true) {
                    let productCount = $(".header-bottom .header-cart .pro-count").text();
                    productCount = parseInt(productCount) + 1;
                    $(".header-cart .pro-count").text(productCount);
                }
            }
        });
    },

    CurrencyFormat: new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND',
        minimumFractionDigits: 0
    }),

}



