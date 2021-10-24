<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForm.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 86px;
        }

        .auto-style3 {
            width: 99%;
            height: 143px;
        }

        .auto-style4 {
            width: 196px;
        }

        .auto-style5 {
            width: 185px;
        }

        .auto-style6 {
            direction: ltr;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form id="form" runat="server" style="margin: 100px; margin-left: 400px;">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style1">UserName</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtName" runat="server" Width="183px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="User Name is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style1">Email</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" Width="183px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="mailValidation" runat="server" ControlToValidate="txtEmail" ErrorMessage="Not ITI Email" ForeColor="Red" OnServerValidate="mailValidation_ServerValidate" Display="Dynamic">*</asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Password</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="183px"></asp:TextBox>
                        <%--<input id="txtPassword" class="auto-style5" type="password" runat="server" />--%></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ClientValidationFunction="IsITIEmail" ControlToValidate="txtPassword" ErrorMessage="Password is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Language</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="dpdownLang" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:CheckBox ID="ckbRemember" runat="server" Text=" Remember me" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button CssClass="btn btn-primary" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
     <script>
        function IsITIEmail(source, args) {
            if (args.Value.includes("@iti.gov.eg"))
                args.IsValid = true;
            else
                args.IsValid = false;
        }
     </script>
</asp:Content>
