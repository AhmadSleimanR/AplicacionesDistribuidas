using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_REST.Dominio;
using WCF_REST.Errores;

namespace WCF_REST
{
    public class Platos : IPlatos
    {
        private PlatoDAO platoDAO = new PlatoDAO();
        public void EliminarPlato(string platoID)
        {
            platoDAO.EliminarPlato(Convert.ToInt32(platoID));

        }

        public Plato ModificarPlato(Plato platoCrear)
        {
            return platoDAO.ModificarPlato(platoCrear);
        }

        public Plato ObtenerPlatobyID(string platoID)
        {
            return platoDAO.ObtenerPlatoporId(Convert.ToInt32(platoID));
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
            if (platoDAO.ObtenerPlatoporNombre(platoCrear.Nombre) != null)
            {
                throw new WebFaultException<ManejoException>
                (
                    new ManejoException()
                    {
                        codigo = "101",
                        descripcion = "El plato que desea registrar ya existe"
                    }, System.Net.HttpStatusCode.Conflict
                );
            }
            else
            {
                return platoDAO.RegistrarPlato(platoCrear);
            }
        }
    }
}
