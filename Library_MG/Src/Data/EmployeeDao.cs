using Library_MG.Src.Data.HttpIntegration;
using Library_MG.Src.Entities.Dtox;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_MG.Src.Data
{
    /// <summary>
    /// Clase de acceso a datos para los empleados
    /// </summary>
    internal class EmployeeDao
    {
        #region Propiedades
        /// <summary>
        /// Url para consultar los empleados
        /// </summary>
        private string UrlService = "http://masglobaltestapi.azurewebsites.net/api/Employees";
        
        /// <summary>
        /// Singleton de la clase para consumir servicios http
        /// </summary>
        private HttpRepository httpModule;
        private HttpRepository HttpModule
        {
            get
            {
                if (httpModule == null)
                    httpModule = new HttpRepository();
                return httpModule;
            }
        } 
        #endregion

        /// <summary>
        /// Consulta el servicio de  empleados
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDtox>> GetAsync()
        {
            //consultar servicio
            var employees = await HttpModule.Get<List<EmployeeDtox>>(UrlService);
            return employees;
        }
    }
}
