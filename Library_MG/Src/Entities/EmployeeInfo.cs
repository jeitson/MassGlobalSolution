using System.Runtime.Serialization;

namespace Library_MG.Src.Entities
{
    /// <summary>
    /// Clase empleado
    /// </summary>
    [DataContract]
    public class EmployeeInfo
    {
        /// <summary>
        /// Identificador del empleado
        /// </summary>
        [DataMember(Name = "id")]
        public readonly int Id;
        /// <summary>
        /// Nombre del empleado
        /// </summary>
        [DataMember(Name = "name")]
        public readonly string Name;
        /// <summary>
        /// Tipo de contrato
        /// </summary>
        [DataMember(Name = "contractType")]
        public readonly string ContractType;
        /// <summary>
        /// Identificador del rol
        /// </summary>
        [DataMember(Name = "roleId")]
        public readonly int RoleId;
        /// <summary>
        /// Nombre del rol
        /// </summary>
        [DataMember(Name = "roleName")]
        public readonly string RoleName;
        /// <summary>
        ///Descripción del rol 
        /// </summary>
        [DataMember(Name = "roleDescription")]
        public readonly string RoleDescription;
        /// <summary>
        /// Salario por hora
        /// </summary>
        [DataMember(Name = "hourlySalary")]
        public readonly decimal HourlySalary;
        /// <summary>
        /// Salario mensual
        /// </summary>
        [DataMember(Name = "monthlySalary")]
        public readonly decimal MonthlySalary;
        /// <summary>
        /// Salario anual
        /// </summary>
        [DataMember(Name = "anualSalary")]
        public readonly decimal AnualSalary;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="contractType"></param>
        /// <param name="roleId"></param>
        /// <param name="roleName"></param>
        /// <param name="roleDescription"></param>
        /// <param name="hourlySalary"></param>
        /// <param name="monthlySalary"></param>
        public EmployeeInfo(int id, string name, string contractType, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary, decimal anualSalary)
        {
            this.Id = id;
            this.Name = name;
            this.ContractType = (contractType == "HourlySalaryEmployee") ? "Por hora" : "Mensual";
            this.RoleId = roleId;
            this.RoleName = roleName;
            this.RoleDescription = roleDescription;
            this.HourlySalary = hourlySalary;
            this.MonthlySalary = monthlySalary;
            this.AnualSalary = anualSalary;            
        }
    }
}
