namespace SistemaUsuarios.Models.Entities
{
    public class Institucion
    {
        public int Id { get; init; }
        public string Codigo { get; init; }
        public string Nombre { get; init; }
        public bool Activo { get; init; } = true;
    }
}
