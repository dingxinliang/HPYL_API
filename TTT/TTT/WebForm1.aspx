<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HPYL_API.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                <input id="Button1" type="button" value="测试" />
        </div>
    </form>

    <script>
           $("#Button1").click(function () {
        var APIURL ="/api/Calendar/InOrder";
        var datas = { PatientId: 590, Date: "2018-08-18", StartTime: "17:10", EndTime: "17:20", AddressId: "7", Address: "dfdfdfdfdfdfdfdfdffddfdfdfdf", ProjectIdList: "749,750,753,", Remind: "1", Content: "gghghghghghghg", zz: Math.random() };
        $.ajax({
            type: "Post",
            url: APIURL,
            data: datas,
            dataType: "json",
            success: function (re) {
                alert(re);
            }
        });

    });
    </script>
</body>
</html>
