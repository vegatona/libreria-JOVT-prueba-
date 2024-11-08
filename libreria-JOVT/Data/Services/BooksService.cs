﻿using libreria_JOVT.Data.Models;
using libreria_JOVT.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace libreria_JOVT.Data.Models.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero= book.Genero,
                Autor = book.Autor,
                ConverUrl = book.ConverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        //metodo que nos permite obtener la lista de todos los libros de la BD
        public List<Book> GetAllBks() => _context.Books.ToList();
        //Metodo que nos permite obtener el libro que estamos pidiendo de la BD
        public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);
        
        //METODO QUE NOS PERMITE MODIFICAR UN LIBRO QUE SE ENCUENTRE EN LA BD
        public Book UpdateBookByID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.ConverUrl = book.ConverUrl;
                _context.SaveChanges();
            }
            return _book;
        }

        //metodo para eliminar
        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(N => N.id == bookid);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
