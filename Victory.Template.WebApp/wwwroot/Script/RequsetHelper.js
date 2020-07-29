



 function AjaxPost(json) {


  var ajax=  axios({
      method: 'post',
      url: json.url,
      params: json.data,
      headers: { 'X-Requested-With': 'XMLHttpRequest' },    //axios需要自己加ajax 请求头，jquery 不用，真坑
    });

    ajax.then((response) => {

        let result = response.data;

        if (result.Code === 302) {
            //服务端直接跳转了，所以这里并没有用上
            console.log("请配置权限");
            window.location = "/UserRight/NoPermission";

        } else if (result.Code === 404) {
            alert_danger(result.Message);
        } else if (result.Code === 405) {
            alert_danger(result.Message);
        } else if (result.Code === 401) {
            alert_danger("登录过期，请重新登录！");
        } else {

            //类似委托
            json.success(result);

        }

    }).catch((err) => {

        json.success({ "Code": 500, "Message": "服务器异常", "error": err });

    });
}




function AjaxGet(json) {


    var ajax = axios({
        method: 'get',
        url: json.url,
        params: json.data,
        headers: { 'X-Requested-With': 'XMLHttpRequest' },
    });

    ajax.then((response) => {

        let result = response.data;

        if (result.Code === 302) {
            //服务端直接跳转了，所以这里并没有用上
            console.log("请配置权限");
            window.location = "/UserRight/NoPermission";

        } else if (result.Code === 404) {
            alert_danger(result.Message);
        } else if (result.Code === 405) {
            alert_danger(result.Message);
        } else if (result.Code === 401) {
            alert_danger("登录过期，请重新登录！");
        } else {

            //类似委托
            json.success(result);

        }

    }).catch((err) => {

        json.success({ "Code": 500, "Message": "服务器异常", "error": err });

    });


}

