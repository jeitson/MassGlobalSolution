namespace Library_MG.Src.Entities.Dtox
{
    /// <summary>
    /// Clase interna para la integración con el servicio
    /// </summary>
    internal class EmployeeDtox
    {
        /// <summary>
        /// Identificador del empleado
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Nombre del empleado
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Tipo de contrato
        /// </summary>
        public string contractTypeName { get; set; }
        /// <summary>
        /// Identificador del rol
        /// </summary>
        public int roleId { get; set; }
        /// <summary>
        /// Nombre del rol
        /// </summary>
        public string roleName { get; set; }
        /// <summary>
        /// Descripción del rol
        /// </summary>
        public string roleDescription { get; set; }
        /// <summary>
        /// Valor por hora
        /// </summary>
        public decimal hourlySalary { get; set; }
        /// <summary>
        /// Valor mensual
        /// </summary>
        public decimal monthlySalary { get; set; }
    }
}
