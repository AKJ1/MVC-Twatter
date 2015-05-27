$('.TwattForm').submit(function (event) {
    event.preventDefault();
    //alert("error");
    $.ajax({
        url: this.action,
        type: this.method,
        data: $(this).serialize(),
        sucess: function(result) {
            console.log(result);
        }
    });
    this.reset();
});

var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
$(document).ready(function () {
    //app.updateTimer();
    setInterval(app.updateTimer,1000);
});

var app = new function() {
    this.updateTimer = function()
    {
        $('.twatt-time-ago').each(function () {

            $(this).attr("time", parseFloat($(this).attr("time")) + 1000);
            var secondsAgo = parseFloat($(this).attr("time")) / 1000;
            var newVal;
            if (secondsAgo > 604800) {
                var date = (Date.now() - secondsAgo * 1000);
                newVal = (date.getDate() + " " + monthNames[date.getMonth()] + " " + date.getYear);
            }else if (secondsAgo > 86400) {
                newVal = (Math.round(secondsAgo / 86400) + "d" + " ago");
            }else if (secondsAgo > 3600) {
                newVal = (Math.round(secondsAgo / 3600) + "h" + " ago");
            }else if (secondsAgo > 60) {
                newVal = (Math.round(secondsAgo / 60) + "m" + " ago");
            } else {
                newVal = (Math.round(secondsAgo) + "s" + " ago");
            }
        $(this).html(newVal);
    });      
    }
    return this;
}