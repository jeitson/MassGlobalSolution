namespace Library_MG.Src.Business
{
    /// <summary>
    /// Fabrica para resolver tipos de contratos
    /// </summary>
    internal static class ContractFactory
    {
        /// <summary>
        /// Crea un objeto del tipo de contrato indicado
        /// </summary>
        /// <param name="type">Tipo de contrato</param>
        /// <param name="hourlyValue">Valor por hora</param>
        /// <param name="monthlyvalue">Valor mensual</param>
        /// <returns></returns>
        public static IContract Create(string type, decimal hourlyValue, decimal monthlyvalue)
        {
            IContract contract = null;

            switch (type)
            {
                case "HourlySalaryEmployee": 
                    {
                        contract = new HourlyContract(hourlyValue);
                        break; 
                    }
                case "MonthlySalaryEmployee": 
                    {
                        contract = new MonthlyContract(monthlyvalue);
                        break; 
                    }
            }

            return contract;
        }
    }
}
