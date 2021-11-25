
$(document).ready(function () {

    /* Home add to cart*/
    $(document).on("click", ".btn-add-to-cart", function () {
        let productId = $(this).data("id");
        Utils.AddToCart(productId);
    });

    /* Detail add to cart */
    $(document).on("click", ".btn-detail-add-to-cart", function () {
        let productId = $(this).data("id");
        let qty = $(".pro-details-quality").find(".cart-plus-minus-box").val();
        let sizeid = $(".pro-details-size-content").find(".activesize").data("sizeid");
        Utils.AddToCart(productId, qty, sizeid);
    });

    /* Home add to wishlist */
    $(document).on("click", ".btn-add-to-wishlist", function () {
        let productId = $(this).data("id");
        Utils.AddToWishList(productId);
    });

    /* Load mini cart*/
    $('.cart-active').off("click").on('click', function (e) {
        e.preventDefault();
        $.ajax({
            url: '/Cart/LoadMiniCart',
            type: "GET",
            success: function (result) {
                if (result != null) {
                    $('.sidebar-cart-active').html(result);
                    $('.sidebar-cart-active').addClass('inside');
                    $('.main-wrapper').addClass('overlay-active')
                }
            }
        });
    });

    /* Delete mini cart item */
    $(".sidebar-cart-active").on("click", ".cart-delete a", function () {
        let item = $(this);
        let itemId = item.data("itemid");
        if (item != null && itemId > 0) {
            $.ajax({
                url: '/Cart/RemoveMiniCartItem',
                type: 'POST',
                data: { itemId: itemId },
                success: function (res) {
                    if (res) {
                        item.closest(".single-product-cart").remove();
                        let productCount = $(".header-bottom .header-cart .pro-count").text();
                        productCount = parseInt(productCount) - 1;
                        productCount = productCount >= 0 ? productCount : 0;
                        $(".header-cart .pro-count").text(productCount);
                    }
                }
            });
        }
    });

    $(".sidebar-cart-active").on("click", ".cart-close", function () {
        $('.sidebar-cart-active').removeClass("inside");
        $('.main-wrapper').removeClass('overlay-active');
    });

    let baseuri = $("#base-uri").val();
    // Auto compelete search
    $(".txt-search").autocomplete({
        minLength: 1,
        source: function (request, response) {
            $.ajax({
                url: "/Product/Search",
                dataType: "json",
                data: {
                    keyword: request.term
                },
                success: function (data) {
                    response(data);
                }
            });
        },
        select: function (event, ui) {
            $(".txt-search").val(ui.item.name);
            return false;
        }
    }).autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
            .append(`<div><a href="/products/${item.id}/${item.seoAlias}"><img width="50px;" height="50px;" src="${baseuri}${item.defaultImage}" /> ${item.name} </a></div>`)
            .appendTo(ul);
    };

    // Quick view product
    $(document).on("click", ".btn-quickview-product", function () {
        let productid = $(this).data("id");
        if (productid != null && productid > 0) {
            $.ajax({
                url: '/Product/QuickViewProduct',
                type: 'GET',
                data: { id: productid },
                success: function (res) {
                    if (res != null) {
                        $("#productModal .modal-body").html(res);
                    }
                }
            });
        }
    });

    // Active size
    $(".pro-details-size-content").on("click", "a", function (e) {
        e.preventDefault();
        let item = $(this);
        $(".pro-details-size-content ul li a").removeClass("activesize");
        item.addClass("activesize");
    });

    // View product by color option
    $(".pro-details-color-content").on("click", "a", function () {
        let url = $(this).attr("href");
        window.location.href = url;
    });

    
});
