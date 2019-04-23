<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LanguageTranslator.aspx.cs" Inherits="FinalProject.LanguageTranslator" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../CSS/style.css"/>

    <title>Language Translator</title>
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
        <div class="col-md-12">
            <h2>Language Translator</h2>
            <br />
            <form id="form1" runat="server">
                <div class="form-group, userInput">
                    <br />
                    <div class="fromLanguage">
                        <asp:Label CssClass="labelLT" ID="LblFrom" runat="server" Text="From:"></asp:Label>
                        <asp:DropDownList ID="DropDownListFrom" runat="server" class="form-control CountryDropdown"></asp:DropDownList>
                        <asp:TextBox CssClass="inputWord" ID="TxtTranslateString" runat="server" class="form-control" TextMode="multiline" placeholder="Enter the word to be translated"></asp:TextBox>
                    </div>
                    <div class="toLanguage">
                        <asp:Label CssClass="labelLT" ID="LblTo" runat="server" Text="To:"></asp:Label>
                        <asp:DropDownList ID="DropDownListTo" runat="server" class="form-control CountryDropdown"></asp:DropDownList>
                        <asp:TextBox CssClass=" convertedWord" ID="LblResult" runat="server" TextMode="multiline"></asp:TextBox>
                        <br />
                    </div>
                    <asp:Button ID="BtnTranslate" runat="server" OnClick="BtnTranslate_Click" Text="Translate" class="btn btn-primary btnTranslate" />
                </div>
            </form>

        </div>
    </div>
</body>
</html>
