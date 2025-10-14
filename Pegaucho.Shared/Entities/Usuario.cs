using Pegaucho.Shared.Entities;
using Pegaucho.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Orders.Shared.Entities;

public class Usuario : IEntityWithName
{
    [Key]
    public int IdLogin { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    [MaxLength(50, ErrorMessage = "El campo no puede tener mas caracteres")]
    public string usuario { get; set; } = null!;

    public string contrasena { get; set; } = null!;

    // Implementación de IEntityWithName
    [NotMapped]
    public string Name
    {
        get => usuario;
        set => usuario = value;
    }

    [JsonIgnore]
    public ICollection<PanelControl> Paneles { get; set; } = new List<PanelControl>();

    [JsonIgnore]
    public ICollection<OrdenProduccion> OrdenesProducciones { get; set; } = new List<OrdenProduccion>();

    [NotMapped]
    public int OrdenesProduccionesNumber => OrdenesProducciones?.Count ?? 0;
}