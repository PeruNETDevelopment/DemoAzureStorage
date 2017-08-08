using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace DemoAzureBlobStorage
{
    public class DataBlob
    {
        public int Id { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public string RutaArchivo { get; set; }

        [NotMapped]
        public Bitmap Imagen { get; set; }
    }
}