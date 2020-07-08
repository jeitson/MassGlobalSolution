using Library_MG.Src.Data;
using Library_MG.Src.Entities;
using Library_MG.Src.Entities.Dtox;
using Library_MG.Src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_MG.Src.Business
{
    /// <summary>
    /// Clase con logica de negocio para los empleados
    /// </summary>
    public class EmployeeLogic : IEmployee
    {
        #region Propiedades
        /// <summary>
        /// Instancia singleton clase employee de acceso a datos
        /// </summary>
        private EmployeeDao _employeeModule;
        private EmployeeDao EmployeeModule
        {
            get
            {
                if (_employeeModule == null)
                    _employeeModule = new EmployeeDao();
                return _employeeModule;
            }
        } 
        #endregion

        /// <summary>
        /// Consulta los empleados
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeInfo>> GetAsync(int id)
        {
            List<EmployeeInfo> result = null;
            try
            {
                if (id < 0)
                    throw new ArgumentException("El identificador de filtro no es valido");

                //se consultan los empleados llamando al modulo DAO
                var employees = await EmployeeModule.GetAsync();
                employees = ApplyFilter(id, employees);

                //si existen datos en la lista, realiza la creacion de los objetos
                if (employees != null && employees.Count > 0)
                {
                    result = new List<EmployeeInfo>();
                    decimal anualSalary = 0;
                    foreach (var employee in employees)
                    {
                        //se calcula el salario anual dependiendo del tipo de contrato
                        anualSalary = CalculateSalary(employee.contractTypeName, employee.hourlySalary, employee.monthlySalary);
                        
                        //se crea el empleado a través del constructor de la clase
                        result.Add(
                            new EmployeeInfo
                            (
                                employee.id,
                                employee.name,
                                employee.contractTypeName,
                                employee.roleId,
                                employee.roleName,
                                employee.roleDescription,
                                employee.hourlySalary,
                                employee.monthlySalary,
                                anualSalary
                            ));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Metodo que aplica el filtro por el identificador del empleado
        /// </summary>
        /// <param name="id">Identificador del empleado</param>
        /// <param name="employees">Lista de empleados</param>
        /// <returns>Lista de empleados</returns>
        private List<EmployeeDtox> ApplyFilter(int id, List<EmployeeDtox> employees)
        {
            //si el identificador del usuario es mayor a cero, se realiza el filtro en el listado.
            if (id > 0)
                employees = employees.Where(x => x.id == id).ToList();
            return employees;
        }

        /// <summary>
        /// Calcula el salario anual del empleado
        /// </summary>
        /// <param name="contractType">tipo de contrato</param>
        /// <param name="hourlySalary">valor por hora</param>
        /// <param name="monthlySalary">valor mensual</param>
        /// <returns></returns>
        private decimal CalculateSalary(string contractType, decimal hourlySalary, decimal monthlySalary)
        {
            decimal value = 0;

            //se valida si la propiedad tipo de contrato contiene datos
            if (!string.IsNullOrEmpty(contractType))
            {
                //se llama a la fabrica de contrato y se crea un contrato del tipo indicado
                var contract = ContractFactory.Create(contractType, hourlySalary, monthlySalary);

                //solo se calcula el salario anual basado en el tipo de contrato del empleado
                value = contract.CalculateAnualSalary();
            }

            return value;
        }
    }
}
