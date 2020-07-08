namespace Library_MG.Src.Business
{
    /// <summary>
    /// Implementación de un contrato por horas
    /// </summary>
    internal class HourlyContract : IContract
    {
        /// <summary>
        /// Propiedad valor del contrato
        /// </summary>
        private decimal Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public HourlyContract(decimal value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Implementación del metodo calcular salario anual
        /// </summary>
        /// <returns></returns>
        public decimal CalculateAnualSalary()
        {
            return 120 * this.Value * 12;
        }
    }
}
