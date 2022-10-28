using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public enum ImageFormat
    {
        PNG, JPG
    }

    public class CoverImage
    {
        public int Id { get; set; }
        public ImageFormat Format { get; set; }
        public byte[] ImageData { get; set; }
    }
}

