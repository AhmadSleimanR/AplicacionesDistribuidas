<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>Clientes-add</title>
    <link rel="stylesheet" href="{{asset("assets/bootstrap/css/bootstrap.min.css")}}">
    <link rel="stylesheet" href="{{asset("assets/css/Contact-Form-Clean.css")}}">
    <link rel="stylesheet" href="{{asset("assets/css/Footer-Basic.css")}}">
    <link rel="stylesheet" href="{{asset("assets/css/Navigation-with-Button.css")}}">
    <link rel="stylesheet" href="{{asset("ssets/css/styles.css")}}">




    <script type="text/javascript">
            function generar(longitud)
            {
                long=parseInt(longitud);
                var caracteres = "abcdefghijkmnpqrtuvwxyzABCDEFGHIJKLMNPQRTUVWXYZ2346789";
                var contrasena = "";
                for (i=0; i<long; i++) contrasena += caracteres.charAt(Math.floor(Math.random()*caracteres.length));
                return contrasena;
            }

    </script>
</head>

<body>
    <div>
        <nav class="navbar navbar-light navbar-expand-md navigation-clean-button" style="color: rgb(255,255,255);background-color: rgb(0,0,0);">
            <div class="container"><a class="navbar-brand" href="index.html">UPC EDU</a><button data-toggle="collapse" class="navbar-toggler" data-target="#navcol-1"><span class="sr-only">Toggle navigation</span><span class="navbar-toggler-icon"></span></button>
                <div class="collapse navbar-collapse"
                    id="navcol-1">
                    <ul class="nav navbar-nav mr-auto">
                        <li class="nav-item" role="presentation"><a class="nav-link active" href="#" style="color: rgb(255,255,255);">Transacciones</a></li>
                        <li class="nav-item" role="presentation"></li>
                        <li class="dropdown nav-item"><a class="dropdown-toggle nav-link" data-toggle="dropdown" aria-expanded="false" href="#" style="color: rgb(255,255,255);">Ver más</a>
                            <div class="dropdown-menu" role="menu"><a class="dropdown-item" role="presentation" href="#">First Item</a><a class="dropdown-item" role="presentation" href="#">Second Item</a><a class="dropdown-item" role="presentation" href="#">Third Item</a></div>
                        </li>
                    </ul><span class="navbar-text actions"> <a class="login" href="#" style="color: rgb(255,255,255);">Log In</a><a class="btn btn-light action-button" role="button" href="#" style="background-color: #1e6add;">Registro</a></span></div>
            </div>
        </nav>
    </div>
    <div class="contact-clean">
        <form method="post" action="{{route("Cliente.store")}}" >
            @csrf
            <h2 class="text-center">Registrar Cliente</h2>
            <div class="form-group">
                <input placeholder="Email"  required class="form-control" type="email" id="email" name="email">
                <input placeholder="Contraseña"  required class="form-control" type="password" id="contrasena" name="contrasena">

                <br>
                <br>
                <input placeholder="DNI" class="form-control" max="8" min="8" required name="dni" id="dni" type="text">
                <input placeholder="Nombre" class="form-control" type="text" required id="nombre" name="nombre">
                <input placeholder="Apellidos" class="form-control" type="text" required id="apellidos" name="apellidos">
                <input placeholder="Direccion" class="form-control" type="text" required id="direccion" name="direccion">
             </div>
            <div class="form-group"><button class="btn btn-primary" type="submit">Registrar</button></div>
        </form>
    </div>
    <div class="footer-basic">
        <footer>
            <ul class="list-inline">
                <li class="list-inline-item"><a href="#">Home</a></li>
                <li class="list-inline-item"><a href="#">Servicios</a></li>
                <li class="list-inline-item"></li>
                <li class="list-inline-item"><a href="#">Términos y Condiciones</a></li>
                <li class="list-inline-item"><a href="#">Política de Privacidad</a></li>
            </ul>
            <p class="copyright">UPC EDU© 2019</p>
        </footer>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>

<script  >
    var contra=generar(10);
    $("#contrasena").val(contra)
</script>
</body>

</html>
