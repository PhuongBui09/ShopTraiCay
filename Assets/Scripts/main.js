// thanh xổ chi tiết
//$(document).ready(function () {
//    $("#cacLoaiId").click(function () {
//        $("#cacLoaiId_Child").slideToggle("slow");
//    });
//});

// tìm kiếm sản phẩm trùng khớp
$(document).ready(function () {
    $(".sp_home-header").hide();
    $(".sp_home-header:first-child").fadeIn();
    $("#cacLoaiId_Child ul li:first-child").addClass("active-sanpham");
    $("#cacLoaiId_Child ul li").click(function () {
        $("#cacLoaiId_Child ul li").removeClass("active-sanpham");
        $(this).addClass("active-sanpham");

        let x = $(this).children("a").attr("href");
        $(".sp_home-header").hide();
        $(x).fadeIn();
    })
})

//$(document).ready(function () {
//    $("header-tongthe li").click(function () {
//        $("ul.tongquan-hd li").removeclass("active-test");
//        $(this).addClass("active-test");
//        console.log("ok");
//    })
//})

//$(document).ready(function () {
//    $("ul.tongquan-hd > li > a").click(function () {
//        $("ul.tongquan-hd > li > a").removeclass("active-header-text");
//        $("ul.tongquan-hd > li > a").css("color", "");
//        $(this).addClass("active-header-text");
//        $(this).css("color", "red");
//        });
//});

// Số lượng hàng mua

$(document).ready(function () {

    var quantitiy = 1;
    $('.quantity-right-plus').click(function (e) {

        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        var quantity = parseInt($('#quantity').val());

        // If is not undefined

        $('#quantity').val(quantity + 1);


        // Increment

    });

    $('.quantity-left-minus').click(function (e) {
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        var quantity = parseInt($('#quantity').val());

        // If is not undefined

        // Increment
        if (quantity > 1) {
            $('#quantity').val(quantity - 1);
        }
    });

});

//Thêm 1 sản phẩm vào giỏ hàng
function themTC(maSP, nameOfProduct) {
    swal(nameOfProduct, "Đã được thêm vào giỏ hàng!", "success");
    $.get("/CuaHang/AddToCart", { maSP: maSP })
        .done(function (data) {
        });
}
//Thêm nhiều sản phẩm
function themChiTiet(nameOfProduct) {
    let maSP = document.getElementById("maSP").value;
    let slThemMoi = document.getElementById("quantity").value;
    if (slThemMoi > 0) {
        swal(nameOfProduct, "Đã được thêm vào giỏ hàng!", "success");
        $.get("/CuaHang/AddToCarts", { maSP: maSP, slThemMoi: slThemMoi })
            .done(function (data) {
            });
    } else {
        swal(nameOfProduct, "Thêm thất bại vì số lượng nhỏ hơn hoặc bằng 0!", "error");
    }
}
//Active link
const hrefLocation = location.href;
const menuItem = document.querySelectorAll('.act');
const menuLength = menuItem.length;
for (let i = 0; i < menuLength; i++) {
    if (menuItem[i].href === hrefLocation) {
        menuItem[i].className = "active-test";
    }
}

window.onload = function () {
    document.getElementById("load").style.display = 'none';
}