﻿using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options ) : base( options ) { }      
        DbSet<Producto> Producto {  get; set; }
    }
}
