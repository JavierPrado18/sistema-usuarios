namespace SistemaUsuarios.Models.Entities
{
    public class Rol
    {
        public int Id { get; init; }
        public string Nombre { get; init; }
        public string Descripcion { get; init; }
        public bool Activo { get; init; } = true;
    }
}
