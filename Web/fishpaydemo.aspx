<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fishpaydemo.aspx.cs" Inherits="Web.fishpaydemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        充值密钥[pkey]：<asp:TextBox ID="tb_pkey" Text="VCQ0lizO9U4JJrzJbGGUXLIz6ujrykci8PeS" runat="server"></asp:TextBox><br />
        平台ID[platform]：<asp:TextBox ID="tb_platform" Text="qpwan" runat="server"></asp:TextBox><br />
        游戏名[gkey]：<asp:TextBox ID="tb_gkey" Text="lzqpfishchannelgame" runat="server"></asp:TextBox><br />
        区服ID[skey]：<asp:TextBox ID="tb_skey" Text="1" runat="server"></asp:TextBox><br />
        <hr />
        用户ID[uid]：<asp:TextBox ID="tb_uid" Text="5544221" runat="server"></asp:TextBox><br />
        订单号[order_id]：<asp:TextBox ID="tb_order_id" Text="1001002" runat="server"></asp:TextBox><br />
        游戏币数量[coins]：<asp:TextBox ID="tb_coins" Text="5000000" runat="server"></asp:TextBox><br />
        人民币数量[moneys]：<asp:TextBox ID="tb_moneys" Text="2000" runat="server"></asp:TextBox> 分<br />
        <asp:Button ID="btn_sub" runat="server" Text="渔夫下单>>" OnClick="btn_sub_Click" />
        <br />
        <hr />

        <asp:Label ID="lb_msg" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
