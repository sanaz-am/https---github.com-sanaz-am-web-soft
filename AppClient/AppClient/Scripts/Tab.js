$(document).ready(function () {
    $("#comotab22").hide();
    $("#comotab33").hide();
    $("#comotab44").hide();
    $("#resent").click(function () {
        $("#view").removeClass("active2");
        $("#comment").removeClass("active3");
        $(this).addClass("active");
        $("#Comment").hide();
        $("#View").hide();
        $("#Resent").fadeIn();
    })
    $("#view").click(function () {
        $("#resent").removeClass("active");
        $("#comment").removeClass("active3");
        $(this).addClass("active2");
        $("#Resent").hide();
        $("#Comment").hide();
        $("#View").fadeIn();
    })
    $("#comment").click(function () {
        $("#resent").removeClass("active");
        $("#view").removeClass("active2");
        $(this).addClass("active3");
        $("#View").hide();
        $("#Resent").hide();
        $("#Comment").fadeIn();
    })
    $("#comotab1").click(function () {
        $("#comotab2").removeClass("active");
        $("#comotab3").removeClass("active");
        $("#comotab4").removeClass("active");
        $("#comotab1").addClass("active");
        $("#comotab22").hide();
        $("#comotab33").hide();
        $("#comotab44").hide();
        $("#comotab11").show();
    })
    $("#comotab2").click(function () {
        $("#comotab1").removeClass("active");
        $("#comotab3").removeClass("active");
        $("#comotab4").removeClass("active");
        $("#comotab2").addClass("active");
        $("#comotab11").hide();
        $("#comotab33").hide();
        $("#comotab44").hide();
        $("#comotab22").show();
    })
    $("#comotab3").click(function () {
        $("#comotab2").removeClass("active");
        $("#comotab1").removeClass("active");
        $("#comotab4").removeClass("active");
        $("#comotab3").addClass("active");
        $("#comotab22").hide();
        $("#comotab11").hide();
        $("#comotab44").hide();
        $("#comotab33").show();
    })
    $("#comotab4").click(function () {
        $("#comotab2").removeClass("active");
        $("#comotab3").removeClass("active");
        $("#comotab1").removeClass("active");
        $("#comotab4").addClass("active");
        $("#comotab22").hide();
        $("#comotab33").hide();
        $("#comotab11").hide();
        $("#comotab44").show();
    })
 
})