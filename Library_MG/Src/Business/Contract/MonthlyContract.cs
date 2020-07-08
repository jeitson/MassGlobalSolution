namespace Library_MG.Src.Business
{
    /// <summary>
    /// Implementación de un contrato mensual
    internal class MonthlyContract : IContract
    {
        /// <summary>
        /// Propiedad valor del contrato
        /// </summary>
        private decimal Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public MonthlyContract(decimal value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Implementación del metodo calcular salario anual
        /// </summary>
        /// <returns></returns>
        public decimal CalculateAnualSalary()
        {
            return this.Value * 12;
        }
    }
}
