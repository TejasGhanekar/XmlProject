<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindInDictionary.aspx.cs" Inherits="FinalProject.FindInDictionary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css" />
     <link rel="stylesheet" href="../CSS/style.css"/>

    <title>Find in Dictionary</title>
    <link rel="icon" href="../Images/logo3.jpg" />

    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-3.3.1.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/bootstrap.min.js"></script>
</head>
<body>

    <!--Nav bar-->
    <nav class="navbar navbar-inverse navbar-fixed-top dictionarNavBar">
        <div class="container dictionarNavBarContainer">
            <div class="navbar-header">
                <a class="navbar-brand dictionaryBrand" href="../Index.html">
                    <img class="logoimg" src="../Images/logo3.jpg" /></a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dictionary <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="../Pages/DictionaryWebService.aspx">Find in a General Dictionary</a></li>
                            <li><a href="../Pages/FindInDictionary.aspx">Find in a Specific Dictionary</a></li>
                        </ul>
                    </li>
                    <li><a href="../Pages/LanguageTranslator.aspx">Language Translator</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <img class="bgimg" src="../Images/bg2.jpg" />
     <div class="content-div" id="content">
        <div class="col-sm-3 col-md-6">
            <h2>Specific Dictionary</h2>
            <br />
            <form id="form1" runat="server">
                <div class="form-group" style="width: 40%">
                    <asp:Label ID="LblSelectDict" runat="server" Text="Select dictionary to find definition from"></asp:Label>

                    <asp:DropDownList ID="DropDownListSelectDict" runat="server" class="form-control">
                    </asp:DropDownList>

                    <br />
                    <asp:Label ID="LblWord" runat="server" Text="Please enter a word to get its definition:"></asp:Label>

                    <asp:TextBox ID="TextBoxWord" runat="server" class="form-control"></asp:TextBox>
                    <br />
                    <asp:Button ID="BtnFind" runat="server" Text="Find" OnClick="BtnFind_Click" class="btn btn-primary" />
                </div>
                <asp:BulletedList ID="BulletedListDefinition" runat="server" BulletStyle="Circle">
                </asp:BulletedList>
            </form>
        </div>
    </div>
</body>
</html>
