using Library_MG;
using Library_MG.Src.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Unity;

namespace Test_MG
{
    /// <summary>
    /// Pruebas empleados
    /// </summary>
    [TestClass]
    public class EmployeeTest : TestBase
    {
        private IEmployee _employeeModule;

        public IEmployee EmployeeModule
        {
            get {
                if (_employeeModule == null)
                    _employeeModule = Application.Container.Resolve<IEmployee>();
                return _employeeModule;
            }
        }



        /// <summary>
        /// Escenario listar todos los empleados
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ListAllEmployeesTest()
        {
            var result = await EmployeeModule.GetAsync(0);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
        }

        /// <summary>
        /// Escenario filtrar usuario por su identificador
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ListEmployeeByFilterTest()
        {
            var result = await EmployeeModule.GetAsync(2);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 1);
        }

        /// <summary>
        /// Escenario de falla filtrando con un valor menor a cero
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ListEmployeeFailTest()
        {
            try
            {
                var result = await EmployeeModule.GetAsync(-1);
            }
            catch (System.Exception ex)
            {
                Assert.AreEqual(ex.Message, "El identificador de filtro no es valido");
            }
        }

        /// <summary>
        /// Escenario donde el identificador es valido pero no corresponde a ningun empleado
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NoEmployeeResultTest()
        {
            var result = await EmployeeModule.GetAsync(10);

            Assert.IsNull(result);
        }
    }
}
