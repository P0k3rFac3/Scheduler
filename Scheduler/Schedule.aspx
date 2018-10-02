<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Scheduler.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="AgentName" HeaderText="AgentName" SortExpression="AgentName" />
                <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="Start_ime" />
                <asp:BoundField DataField="Lunch" HeaderText="Lunch" SortExpression="Lunch" />
                <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegConnectionString %>" SelectCommand="SELECT [AgentName], [StartTime], [Lunch], [EndTime] FROM [Agents] ORDER BY [StartTime], [AgentName]"></asp:SqlDataSource>
    </form>
</body>
</html>
