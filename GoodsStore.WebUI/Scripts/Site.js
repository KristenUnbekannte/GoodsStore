function set_rate() {
    var clickX = (event.layerX == undefined ? event.offsetX : event.layerX) + 1;
    var container = document.getElementById('stars_container');
    var containerWidth = container.clientWidth || container.offsetWidth;

    if (clickX <= containerWidth) {
        var rate = Math.ceil(clickX / containerWidth * 5);
        document.getElementById('stars').style.width = rate * 20 + "%";
        document.getElementById('rate').value= rate;
    }
}

function OpenCloseReviews() {
    var review = document.getElementById('reviews');
    console.log(review.style.display);
    review.style.display == 'none' ? review.style.display = 'block' : review.style.display = 'none';
    console.log(review.style.display);
};

function Decrease() {
    var result = +document.getElementById('quantity').value;
    if (result > 1) {
        document.getElementById('quantity').value = result - 1;
    }
};

function Increase() {
    var result = +document.getElementById('quantity').value;
    document.getElementById('quantity').value = result + 1;
};

function OpenDescription() {
    window.location.href = '/Goods/GetGoodsDescription?goodsId=@Model.GoodsId&page=1';
};

function OnSuccess(data) {
    var results = $('#review');
    results.empty();
    for (var i = 0; i < data.length; i++) {
        results.append('<td>' + data[i].Review.UserName + '<br/>' + data[i].Review.Date.ToShortDateString() + '</td>');
        results.append('<td>' + data[i].Review.Comment + '</td>');
    }
}