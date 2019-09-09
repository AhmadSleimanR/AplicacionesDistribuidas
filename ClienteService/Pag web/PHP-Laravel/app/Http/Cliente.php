<?php


namespace App\Http;


class Cliente{

    public function __construct($Nombre, $Apellidos,$Email,$Direccion,$Dni,$Userpass)
    {
        $this->Nombre = $Nombre;
        $this->Apellidos = $Apellidos;
        $this->Email = $Email;
        $this->Direccion = $Direccion;
        $this->Dni = $Dni;
        $this->Userpass = $Userpass;
    }


}
