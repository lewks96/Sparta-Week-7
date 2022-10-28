﻿using System.ComponentModel.DataAnnotations;

namespace SpartaToDo.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        [StringLength(50)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Complete?")]
        public bool Complete { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime Date { get; init; } = DateTime.Now;
    }
}
