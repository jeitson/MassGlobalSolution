using Library_MG.Src.Business;
using Library_MG.Src.Interfaces;
using Unity;
using Unity.Lifetime;

namespace Library_MG
{
    /// <summary>
    /// Clase de inicialización de la libreria
    /// </summary>
    public class Application
    {
        #region Propiedades
        internal static UnityContainer container = null;
        public static UnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new UnityContainer();
                }
                return container;
            }
        } 
        #endregion

        /// <summary>
        /// Inicia el contenedor registrando todas las instancias
        /// </summary>
        public static void Start()
        {
            Container.RegisterType<IEmployee, EmployeeLogic>(new PerThreadLifetimeManager());
        }
    }
}
