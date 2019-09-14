using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Platos.Dominio;
using Platos.Errores;
using Platos.Persistencia;

namespace Platos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Platos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Platos.svc o Platos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Platos : IPlatos
    {
        private PlatoDAO platoDAO = new PlatoDAO();
        public void EliminarPlato(int platoID)
        {
            platoDAO.EliminarPlato(platoID);



        }

        public Plato ModificarPlato(Plato platoCrear)
        {





            return platoDAO.ModificarPlato(platoCrear);
        }

        public Plato ObtenerPlatobyID(int platoID)
        {
            return platoDAO.ObtenerPlatoporId(platoID);
        }

        public Plato ObtenerPlatobyName(string platoName)
        {
            return platoDAO.ObtenerPlatoporNombre(platoName);
        }

        public List<Plato> ObtenerPlatos()
        {

            return platoDAO.ObtenerPlatos();
        }

        public Plato RegistrarPlato(Plato platoCrear)
        {
            if (platoDAO.ObtenerPlatoporNombre(platoCrear.Descripcion) != null){
                throw new FaultException<RepetidoException>
                (
                    new RepetidoException()
                    {
                        codigo = "101",
                        descripcion = "El plato que desea registrar ya existe"
                    }, new FaultReason("Error al registrar")
                );
            }
            else
            {
                return platoDAO.RegistrarPlato(platoCrear);
            }
        }
    }
}
