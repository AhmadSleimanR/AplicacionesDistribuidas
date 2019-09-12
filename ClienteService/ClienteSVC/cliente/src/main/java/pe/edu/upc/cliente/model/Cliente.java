package pe.edu.upc.cliente.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

	@NoArgsConstructor
	@AllArgsConstructor
	@Entity
	@Table(name = "CLIENTES")
	@Data
	@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
	public class Cliente {
		@Id
		@GeneratedValue(strategy=GenerationType.IDENTITY)
		private Integer id;
		private String username;
		private String userpass;
		private String nombre;
		private String apellidos;
		private String email;
		private String direccion;
		private String dni;

	@Override
	public String toString(){
		return "Id: "+id;
	}
}
