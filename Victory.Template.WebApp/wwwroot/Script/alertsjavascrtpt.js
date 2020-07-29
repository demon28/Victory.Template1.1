

function alert_success(message)
{

    $(function () {

        $.bootstrapGrowl(message, {
            ele: 'body', // which element to append to
            type: 'success', // (null, 'info', 'danger', 'success')
            offset: { from: 'top', amount: 60 }, // 'top', or 'bottom'
            align: 'center', // ('left', 'right', or 'center')
            width: 250, // (integer, or 'auto')
            delay: 1000, // Time while the message will be displayed. It's not equivalent to the *demo* timeOut!
            allow_dismiss: true, // If true then will display a cross to close the popup.
            stackup_spacing: 10 // spacing between consecutively stacked growls.
        });
    });
   

}


function alert_danger(message) {
    $.bootstrapGrowl(message, {
        ele: 'body', // which element to append to
        type: 'danger', // (null, 'info', 'danger', 'success')
        offset: { from: 'top', amount: 70 }, // 'top', or 'bottom'
        align: 'center', // ('left', 'right', or 'center')
        width: 300, // (integer, or 'auto')
        delay: 1000, // Time while the message will be displayed. It's not equivalent to the *demo* timeOut!
        allow_dismiss: true, // If true then will display a cross to close the popup.
        stackup_spacing: 10 // spacing between consecutively stacked growls.
    });


}

function alert_info(message) {
    $.bootstrapGrowl(message, {
        ele: 'body', // which element to append to
        type: 'info', // (null, 'info', 'danger', 'success')
        offset: { from: 'top', amount: 70 }, // 'top', or 'bottom'
        align: 'center', // ('left', 'right', or 'center')
        width: 250, // (integer, or 'auto')
        delay: 1000, // Time while the message will be displayed. It's not equivalent to the *demo* timeOut!
        allow_dismiss: true, // If true then will display a cross to close the popup.
        stackup_spacing: 10 // spacing between consecutively stacked growls.
    });

}



function alert_loading_show(message) {

    var dialog = bootbox.dialog({
        title: message,
        message: '<p><i class="fa fa-spin fa-spinner"></i> Loading...</p>',
        closeButton: false 
    });

    return dialog;

} 

function alert_loading_close(dialog) {

    dialog.modal('hide');

}