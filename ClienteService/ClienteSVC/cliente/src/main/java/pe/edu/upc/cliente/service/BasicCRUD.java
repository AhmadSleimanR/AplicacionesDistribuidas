package pe.edu.upc.cliente.service;

import java.util.List;
import java.util.Optional;

public interface BasicCRUD<T, T2> {
	void create(T t);
	T update(T t);
	void delete(T t);

	List<T> findAll();
	Optional<T> findById(T2 t2);

}
