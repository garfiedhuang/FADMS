$(function () {
    delCookie("garfield_crm_show_wellcome");
    delCookie("garfield_report_menu");
    if (getCookie("garfield_uid") && getCookie("garfield_uid") != null) {
        $("#T_uid").val(getCookie("garfield_uid"));
    }
    var FromUrl = getQueryStringByName("FromUrl");
    if (!FromUrl) {
        FromUrl = encodeURIComponent("reports/index.html");
    }
    $(document).keydown(function (e) {
        if (e.keyCode == 13) {
            doLogin();
        }
    });
    $("#login").click(function () {
        doLogin();
    });
    $("#reset").click(function () {
        $(":input", "#loginForm").not(":button,:submit:reset:hidden").val("");
    });
    function doLogin() {
        var uid = $("#T_uid").val();
        var pwd = $("#T_pwd").val();
        var validate = $("#T_validate").val();
        if (validate == "") {
            alert("验证码不能为空！");
            $("#T_validate").focus();
            return;
        }
        else if (validate.length != 4) {
            alert("验证码错误！");
            $("#T_validate").focus();
            return;
        }
        if (uid == "") {
            alert("账号不能为空！");
            $("#T_uid").focus();
            return;
        }
        if (pwd == "") {
            alert("密码不能为空！");
            $("#T_pwd").focus();
            return;
        }
        $.ajax({
            type: 'post', dataType: 'json',
            url: 'Data/login.ashx',
            data: [
            { name: 'Action', value: 'login' },
            { name: 'username', value: uid },
            { name: 'password', value: $.md5(pwd) },
            { name: 'validate', value: validate },
            { name: 'rnd', value: Math.random() },
            { name: 'login_type', value: '2' }//add by garfield 20180224
            ],
            success: function (result) {
                if (typeof (result.status) == "number") {
                    switch (result.status) {
                        case 0:
                            alert("验证码错误！");
                            $("#validate").click();
                            $("#T_validate").val("");
                            $("#T_validate").focus();
                            break;
                        case 1:
                            alert("用户名或密码错误！");
                            $("#T_pwd").focus();
                            break;
                        case 2:
                            SetCookie("garfield_uid", uid, 30);
                            SetCookie("garfield_crm_show_wellcome", "1");
                            SetCookie("garfield_report_menu", result.message);//设置报表菜单
                            location.href = decodeURIComponent(FromUrl);
                            break;
                        case 3:
                            alert("账户异常，请联系管理员！");
                            break;
                        case 4:
                            alert("账户已限制登录！");
                            break;
                        case 5:
                            alert("账户无权限访问！");
                            break;
                    }
                }
                else {
                    alert('登陆失败,账号或密码有误!');
                    $("#password").focus();
                    return;
                }
            },
            error: function () {
                $("#validate").click();
                alert('发生系统错误,请与系统管理员联系!');
            },
            beforeSend: function () {
                $.ligerDialog.waitting("正在登陆中,请稍后...");
                $("#lgoin").attr("disabled", true);
            },
            complete: function () {
                $.ligerDialog.closeWaitting();
                $("#login").attr("disabled", false);
            }
        });
    }
})