function createConfirm(message, okHandler) {
    var confirm = '<p id="confirmMessage">' + message + '</p><div class="clearfix dropbig">' +
            '<input type="button" id="confirmYes" class="alignleft ui-button ui-widget ui-state-default" value="Yes" />' +
            '<input type="button" id="confirmNo" class="ui-button ui-widget ui-state-default" value="No" /></div>';

    $.fn.colorbox({
        html: confirm,
        onComplete: function () {
            $("#confirmYes").click(function () {
                okHandler();
                $.fn.colorbox.close();
            });
            $("#confirmNo").click(function () {
                $.fn.colorbox.close();
            });
        }
    });
}