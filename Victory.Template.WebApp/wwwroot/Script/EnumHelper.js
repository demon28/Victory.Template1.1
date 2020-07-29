



//权限类型
function Power_Typelist() {

    var Typelist = [];

    Typelist.push({ value: 1, text: "页面访问" });
    Typelist.push({ value: 2, text: "功能操作" });

    return Typelist;

}


//枚举取值
function EnumGetSingle(value, Array) {

    var res = "";

    Array.forEach(function (element) {
        if (element.value == value) {
            res = element.text;
        }
    });
    return res;
}