var gYear = 2018;//默认年份
var gInterval = 2000;//数据刷新间隔(单位：ms)
var gYears = [2018,2017,2016,2015,2014,2013];//年度下拉数据源

function initialReportSystem() {
    //访问权限验证
    var _uid = "";
    if (getCookie("garfield_uid") && getCookie("garfield_uid") != null) {
        _uid = getCookie("garfield_uid");
    } else {
        javascript: location.replace("../login2.aspx");
    }
    //初始化菜单
    var _menus = "";
    if (getCookie("garfield_report_menu") && getCookie("garfield_report_menu") != null) {
        _menus = getCookie("garfield_report_menu");
        $("#showMenu").html(_menus);
    } else {
        javascript: location.replace("../login2.aspx");
    }
    //年度下拉选框绑定数据
    $("#sltYear").empty();
    var _selectHtml = "";
    $.each(gYears, function (idx, item) {
        _selectHtml += "<option>"+item+"</option>";
    });
    $("#sltYear").html(_selectHtml);

    //年度下拉选框绑定change事件
    $("#sltYear").bind("change", function () {
        loadPage();
    });

    //加载页面数据
    loadPage();
}

function logout() {
    $.ligerDialog.confirm('您确认要退出系统？', function (yes) {
        if (yes) {
            $.ajax({
                type: 'post', dataType: 'json',
                url: '../Data/login.ashx',
                data: [{ name: 'Action', value: 'logout' }],
                success: function (result) {
                    javascript: location.replace("../login2.aspx");
                }
            });
        }
    });
}