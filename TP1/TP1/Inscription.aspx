<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="TP1.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    <title></title>

    <nav class="navbar navbar-inverse" role="navigation">
        <h2 style="color: white">Inscription
        <a class="navbar-brand navbar-right" href="#">
                    <img src="http://placehold.it/150x50&text=Logo" alt="">
                </a>
            </h2>
    </nav>
</head>
<body>
    <form id="form1" runat="server">


        <div class="container">

            <div class="row">
            <div class="col-md-5 col-md-offset-2">

            <form class="form-signin">
                <h2 class="form-signin-heading">Please sign in</h2>

                <label for="inputNomU" class="sr-only">Username</label>
                <input type="name" id="nom_Usager" class="form-control" placeholder="Nom Usager" required autofocus>
                <label for="inputPrenom" class="sr-only">Prenom</label>
                <input type="name" id="Prenom_ID" class="form-control" placeholder="Prenom" required>
                <label for="inputNom" class="sr-only">Prenom</label>
                <input type="name" id="Nom_ID" class="form-control" placeholder="Nom" required>
                 <label for="inputEmail" class="sr-only">Email address</label>
                <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required>
                <label for="inputEmail" class="sr-only">Confirmer Email address</label>
                <input type="email" id="inputEmail_confrim" class="form-control" placeholder="Confirmer Email address" required >
                <label for="inputPassword" class="sr-only">Password</label>
                <input type="password" id="inputPassword" class="form-control" placeholder="Password" required>
                <label for="inputPassword" class="sr-only">Password</label>
                <input type="password" id="inputPassword_Con" data-match="#inputPassword" data-match-error="Whoops, these don't match" class="form-control" placeholder="Confirmer Password" required>
                
            </form>

                <div class="center_button">
                 <button class="btn btn-lg btn-primary btn-block" type="submit">Inscription</button>
                <button class="btn btn-lg btn-primary btn-block" type="submit">Annuler</button>
                <button class="btn btn-lg btn-primary btn-block" type="submit">Choisir</button>
            </div>

                </div>
                </div>
            
        </div>
        <!-- /container -->

    </form>

</body>
</html>
