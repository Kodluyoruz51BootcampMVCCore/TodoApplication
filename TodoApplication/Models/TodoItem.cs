using System;
using System.Collections.Generic;

namespace TodoApplication.Models
{
    //ORM : Object Relational Mapping

    //DB-First : önce db normalizasyonu
    //Code-First* : model (entity) sınıfları tasarlanır
    //Model-First : db-class diyagramı
    
    public class TodoItem //POCO - Plain old clr objects
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        public string Title { get; set; } //code snippet
        public DateTimeOffset? DueAt { get; set; }
    }
}
