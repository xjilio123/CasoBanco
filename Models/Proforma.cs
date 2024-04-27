using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace movieappauth.Models
{
    [Table("t_proforma")]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Proforma
    {
        public Proforma()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserID { get; set; }
        public Producto? Producto { get; set; }
        public int Cantidad { get; set; }
        [NotNull]
        public Decimal Precio { get; set; }
        public string Status { get; set; } = "PENDIENTE";

        private string GetDebuggerDisplay()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return ToString();
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}