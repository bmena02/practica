using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSoluciones.Properties
{
    public interface IEmpleadoRepositorio
    {
        OperationResult Create(Empleado empleado);
        OperationResult GetAll();
        OperationResult FindById(int ID_Suplidor);
        OperationResult Update(Empleado empleado, int ID);
        OperationResult HardDelete(int ID);
        OperationResult SoftDelete(int ID);


    }
}
