package pe.edu.upc.cliente;

import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import pe.edu.upc.cliente.model.Cliente;
import pe.edu.upc.cliente.repository.ClienteRepository;

@Slf4j
@SpringBootApplication
public class ClienteApplication implements CommandLineRunner {
	@Autowired
	ClienteRepository clienteRepository;

	public static void main(String[] args) {
		SpringApplication.run(ClienteApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		Cliente cliente = new Cliente();
		cliente.setNombre("Test");
		cliente.setApellidos("Sleiman Romero");
		cliente.setDireccion("test 123 San Borja");
		cliente.setDni("75116591");
		cliente.setEmail("werty_51@hotmail.com");
		cliente.setUsername("ahmadssr");
		cliente.setUserpass("admin123");
		Cliente clienteReturn = clienteRepository.save(cliente);
		log.info(clienteReturn.toString());
	}
}
