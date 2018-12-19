using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leran.Web.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learn_Web_API_ASP.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return GetBooks();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IList<Book>> Get(int id)
        {
            IList<Book> books = GetBooks().Where(x => x.Id == id).ToList();
            if (books.Count > 0)
            {
                return Ok(books);
            }
            else
            {
                return BadRequest("Data kosong.");
            }

            
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book param)
        {
            return Ok(param);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book param)
        {
          return Ok(GetBooks().Where(x => x.Id == id)
                .Select(x => new Book
                {
                    Tittle = param.Tittle == null ? x.Tittle : param.Tittle,
                    Author = param.Author == null ? x.Author : param.Author,
                    Genres = param.Genres == null ? x.Genres : param.Genres,
                    Published = param.Published == 0 ? x.Published : param.Published,
                    Description = param.Description == null ? x.Description : param.Description
                }));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(id);
        }

        private Book[] GetBooks ()
        {
            return new Book[] {
                new Book
                {
                     Id = 1,
                     Tittle = "Learning JavaScript Design Patterns",
                     Author = "Addy Osmani",
                     Published = 2007,
                     Genres = new string[] { "Programming", "JavaScript", "Design Patterns" },
                     Description = @"Explore many popular design patterns, including Modules, Observers, Facades, and Mediators. 
                                    Learn how modern architectural patterns--such as MVC, MVP, and MVVM--are useful from the perspective of a modern web application developer. 
                                    This book also walks you through modern module formats, how to namespace code effectively, and other essential topics: Learn the structure of design patterns and how they are written; Understand different pattern categories, including creational, structural, and behavioral; Walk through more than 20 classical 
                                    and modern design patterns in JavaScript; Use several options for writing modular code--including the Module pattern, Asyncronous Module Definition (AMD), 
                                    and CommonJS; Discover design patterns implemented in the jQuery library; Learn popular design patterns for writing maintainable jQuery plug-ins"
                },
                 new Book
                {
                     Id = 2,
                     Tittle = "Eloquent JavaScript: A Modern Introduction to Programming",
                     Author = "Marijn Haverbeke",
                     Published = 2011,
                     Genres = new string[] { "Programming", "JavaScript" },
                     Description = @"JavaScript lies at the heart of almost every modern web application, from social apps like Twitter to browser-based game frameworks like Phaser and Babylon. 
                                    Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full-scale applications"
                }
            };
        }
    }
}
