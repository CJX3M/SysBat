using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SysbatLib.Models
{
    /// <summary>
    /// Class that hold the Objetos to be used in the system
    /// </summary>
    public class Objeto
    {
        public Objeto()
        {
            this.Propiedades = new List<Propiedad>();
            this.Valores = new List<ObjetoValores>();
        }
        [Key]
        public int Oid { get; set; }
        [Required]
        [Display(Name="Nombre", Description="Nombre del Objeto")]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Propiedad> Propiedades { get; set; }
        [JsonIgnore]
        public virtual ICollection<ObjetoValores> Valores { get; set; }
    }
    /// <summary>
    /// Porperties of the Objetos of the system
    /// </summary>
    public class Propiedad
    {
        public Propiedad()
        {
            this.Objetos = new List<Objeto>();
            this.Valores = new List<PropiedadValores>();
        }
        [Key]
        public int Oid { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        [NotMapped]
        public virtual Objeto Objeto{ get; set; }
        [JsonIgnore]
        public virtual ICollection<Objeto> Objetos { get; set; }
        [JsonIgnore]
        public virtual ICollection<PropiedadValores> Valores { get; set; }
    }

    /// <summary>
    /// This will be the values of the Objeto class, where we define the Objetos of the system
    /// </summary>
    public class ObjetoValores
    {
        public ObjetoValores()
        {
            this.Valores = new List<PropiedadValores>();
        }

        [Key]
        public int Oid { get; set; }
        public string Nombre { get; set; }
        public int ObjetoOid { get; set; }
        public virtual Objeto Objeto { get; set; }
        [JsonIgnore]
        public virtual ICollection<PropiedadValores> Valores { get; set; }
    }
    /// <summary>
    /// This will store the values of the properties that a ObjetoValue has
    /// </summary>
    public class PropiedadValores
    {        
        [Key]
        public int Oid { get; set; }
        public string Valor { get; set; }
        public int ObjetoOid { get; set; }
        public int PropiedadOid { get; set; }
        public virtual ObjetoValores Objeto { get; set; }
        public virtual Propiedad Propiedad { get; set; }
    }
}