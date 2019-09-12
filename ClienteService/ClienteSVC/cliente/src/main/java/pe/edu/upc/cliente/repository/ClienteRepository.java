package pe.edu.upc.cliente.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pe.edu.upc.cliente.model.Cliente;
@Repository
public interface ClienteRepository extends JpaRepository<Cliente, Integer> {
}
