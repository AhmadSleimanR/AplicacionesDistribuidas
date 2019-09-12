package pe.edu.upc.cliente.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import pe.edu.upc.cliente.model.Cliente;
import pe.edu.upc.cliente.repository.ClienteRepository;

import java.util.List;
import java.util.Optional;
@Service
public class ClienteService implements BasicCRUD<Cliente, Integer> {
	@Autowired
	private ClienteRepository clienteRepository;

	@Override
	public void create(Cliente cliente) {
		clienteRepository.save(cliente);
	}

	@Override
	public Cliente update(Cliente cliente) {
		return clienteRepository.save(cliente);
	}

	@Override
	public void delete(Cliente cliente) {
		clienteRepository.delete(cliente);
	}

	@Override
	public List<Cliente> findAll() {
		return clienteRepository.findAll();
	}

	@Override
	public Optional<Cliente> findById(Integer id) {
		return clienteRepository.findById(id);
	}
}
