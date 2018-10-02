<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyAgent.aspx.cs" Inherits="Scheduler.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 164px;
        }
        .auto-style3 {
            margin-bottom: 0px;
        }
        .auto-style5 {
            margin-left: 600px;
        }
        .auto-style6 {
            height: 29px;
        }
        .auto-style7 {
            height: 29px;
            width: 152px;
        }
        .auto-style10 {
            height: 29px;
            width: 97px;
        }
        .auto-style11 {
            height: 29px;
            width: 163px;
        }
        .auto-style12 {
            height: 29px;
            width: 192px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        We have someone new? Great!!! Add them to the list asap!<br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Name</td>
                <td>
                    <asp:TextBox ID="agentName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Start Time</td>
                <td>
                    <asp:TextBox ID="agentStart" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Lunch</td>
                <td>
                    <asp:TextBox ID="agentLunch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">End Time</td>
                <td>
                    <asp:TextBox ID="agentEnd" runat="server" CssClass="auto-style3"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="agentAddButton" runat="server" Text="Add" OnClick="agentAddButton_Click" />
        <br />
        <div class="auto-style5">
            <asp:Button ID="viewSchedule" runat="server" Height="64px" OnClick="viewSchedule_Click" Text="View Schedule" Width="152px" />
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">Name</td>
                <td class="auto-style11">Start Time</td>
                <td class="auto-style12">Lunch</td>
                <td class="auto-style10">End Time</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:DropDownList ID="agentListDown" runat="server" DataTextField="AgentName" DataValueField="AgentName" Height="16px" OnSelectedIndexChanged="agentListDown_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">
                    <asp:DropDownList ID="startDown" runat="server" DataSourceID="SqlDataSource1" DataTextField="Time" DataValueField="Time">
                    </asp:DropDownList>
                </td>
                <td class="auto-style12">
                    <asp:DropDownList ID="lunchDown" runat="server" DataSourceID="SqlDataSource1" DataTextField="Time" DataValueField="Time">
                    </asp:DropDownList>
                </td>
                <td class="auto-style10">
                    <asp:DropDownList ID="endDown" runat="server" DataSourceID="SqlDataSource1" DataTextField="Time" DataValueField="Time">
                    </asp:DropDownList>
                </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegConnectionString %>" SelectCommand="SELECT [Time] FROM [Timing]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegConnectionString %>" SelectCommand="SELECT * FROM [Agents]" OnSelecting="SqlDataSource2_Selecting"></asp:SqlDataSource>
        <asp:Button ID="update" runat="server" OnClick="update_Click" Text="Update" />
    </form>
</body>
</html>
