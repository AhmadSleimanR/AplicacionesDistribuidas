<?php

namespace App\Http\Controllers;

use App\Http\Cliente;
use Artisaninweb\SoapWrapper\SoapWrapper;
use Illuminate\Http\Request;
use SoapClient;

class ClienteController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */

    protected $soapWrapper;

    /**
     * SoapController constructor.
     *
     * @param SoapWrapper $soapWrapper
     */
    public function __construct(SoapWrapper $soapWrapper)
    {
        $this->soapWrapper = $soapWrapper;
    }


    /**
     * @return \Illuminate\Contracts\View\Factory|\Illuminate\View\View
     * @throws \SoapFault
     */
    function obj2array($obj) {
        $out = array();
        foreach ($obj as $key => $val) {
            switch(true) {
                case is_object($val):
                    $out[$key] = $this->obj2array($val);
                    break;
                case is_array($val):
                    $out[$key] = $this->obj2array($val);
                    break;
                default:
                    $out[$key] = $val;
            }
        }
        return $out;
    }

    public function index()
    {


         $client = new SoapClient("http://localhost:15538/ClienteService.svc?wsdl");
        $params = array();


        $clienteObject = $client->__soapCall("ListarClientes"   ,     array($params));

        $clientes=$clienteObject->ListarClientesResult->Cliente;

         return view("clientes",compact("clientes"));

    }

    /**
     * Show the form for creating a new resource.
     *
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        return view ("clientes-add");
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
         $client = new SoapClient("http://localhost:15538/ClienteService.svc?wsdl");
        $Cliente = new Cliente($request->nombre, $request->apellidos,$request->email,$request->direccion,$request->dni,$request->contrasena);
        $params = array(
            "cliente" => $Cliente
        );
        $response = $client->__soapCall("Insert", array($params));

        return redirect()->route('Cliente.index');


     }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        $params = array(
            "dni" => $id
        );
        $client = new SoapClient("http://localhost:15538/ClienteService.svc?wsdl");
        $clienteObject = $client->__soapCall("FindCliente"   ,     array($params));
        $cliente=$clienteObject->FindClienteResult;

         return view ("clientes-update",compact("cliente"));

    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        $client = new SoapClient("http://localhost:15538/ClienteService.svc?wsdl");
        $Cliente = new Cliente(
            $request->nombre,
            $request->apellidos,
            $request->email,
            $request->direccion,
            $request->dni,""
        );
        $params = array(
            "cliente" => $Cliente
        );
        $response = $client->__soapCall("Update", array($params));
        return redirect()->route('Cliente.edit', ['id' => $id]);

    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {

         $params = array(
            "dni" => $id
        );

        $client = new SoapClient("http://localhost:15538/ClienteService.svc?wsdl");
        $clienteObject = $client->__soapCall("Delete"   ,     array($params));
        $cliente=$clienteObject->DeleteResult;


        return redirect()->route('Cliente.index');
    }
}
