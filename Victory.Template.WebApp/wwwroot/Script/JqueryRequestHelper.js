

//此方法必须放在bootbox.js后引用，因为网络请求，需要转菊花
function MyAjax(ajaxjson) {


    var dialog =   bootbox.dialog({
        message: '<div class="text-center"><i class="fa fa-spin fa-spinner"></i> Loading...</div>',
        closeButton: false
    })


    $.ajax({
        url: ajaxjson.url,
        type: ajaxjson.type,
        data: ajaxjson.data,
        success: (result) => {


            dialog.modal('hide');

            if (result.Code === 302) {
                console.log("请配置权限");
                window.location = "/UserRight/NoPermission";

            } else if (result.Code === 404) {
                alert_danger(result.Message);
            } else if (result.Code === 405) {
                alert_danger(result.Message);
            } else if (result.Code === 401) {
                alert_danger("登录过期，请重新登录！");
            } else {

                ajaxjson.success(result);

            }
        },

        error: (err) => {

            dialog.modal('hide');

            ajaxjson.success({ "Code": 500, "Message": "服务器异常", "error:": err });
        }
    })


}