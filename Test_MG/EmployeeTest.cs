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
        /// <summary>
        /// Escenario listar todos los empleados
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ListAllEmployeesTest()
        {
            var employee = Application.Container.Resolve<IEmployee>();

            var result = await employee.GetAsync(0);

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
            var employee = Application.Container.Resolve<IEmployee>();

            var result = await employee.GetAsync(2);

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
                var employee = Application.Container.Resolve<IEmployee>();

                var result = await employee.GetAsync(-1);
            }
            catch (System.Exception ex)
            {
                Assert.AreEqual(ex.Message, "El identificador de filtro no es valido");
            }
        }
    }
}
