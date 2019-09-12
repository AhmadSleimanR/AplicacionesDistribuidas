package pe.edu.upc.cliente.resource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import pe.edu.upc.cliente.model.Cliente;
import pe.edu.upc.cliente.service.ClienteService;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api")
public class ClienteResource {
	@Autowired
	ClienteService clienteService;

	@GetMapping("/clientes")
	public ResponseEntity getAll(){
		List<Cliente> clientes = clienteService.findAll();
		if(clientes.isEmpty()){
			return new ResponseEntity<>(HttpStatus.NO_CONTENT);
		}
		return new ResponseEntity<>(clientes, HttpStatus.OK);
	}

	@GetMapping("/clientes/{id}")
	public ResponseEntity getClienteById(@PathVariable Integer id){
		Optional<Cliente> cliente = clienteService.findById(id);
		if(!cliente.isPresent()){
			return new ResponseEntity(HttpStatus.NOT_FOUND);
		}
		return new ResponseEntity<>(cliente, HttpStatus.OK);
	}

	@PostMapping("/clientes")
	public ResponseEntity createCliente(@RequestBody Cliente cliente){
		clienteService.create(cliente);
		return new ResponseEntity<>(cliente, HttpStatus.CREATED);
	}

	@PutMapping("/clientes/{id}")
	public ResponseEntity updateCliente(@PathVariable Integer id, @RequestBody Cliente cliente){
		Optional<Cliente> currentCliente = clienteService.findById(id);
		if(!currentCliente.isPresent()){
			return new ResponseEntity(HttpStatus.NOT_FOUND);
		}
		cliente.setId(currentCliente.get().getId());
		clienteService.update(cliente);
		return new ResponseEntity<>(cliente, HttpStatus.OK);
	}

	@DeleteMapping("/clientes/{id}")
	public ResponseEntity deleteCliente(@PathVariable Integer id){
		Optional<Cliente> currentCliente = clienteService.findById(id);
		if(!currentCliente.isPresent()){
			return new ResponseEntity(HttpStatus.NOT_FOUND);
		}
		clienteService.delete(currentCliente.get());
		return new ResponseEntity<>(HttpStatus.OK);
	}
}
