using Library_MG.Src.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_MG.Src.Interfaces
{
    /// <summary>
    /// Interfaz del empleado
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// Consulta los empleados
        /// </summary>
        /// <param name="id">Identificador del empleado</param>
        /// <returns>empleados</returns>
        Task<List<EmployeeInfo>> GetAsync(int id);
    }
}
