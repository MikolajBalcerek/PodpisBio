﻿using PodpisBio.Src.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodpisBio.Src.Author
{
    class AuthorController
    {
        public List<Author> authors = new List<Author>();

        private AuthorService service;

        public AuthorController()
        {
            service = new AuthorService();
            //domyślny autor pusty
            this.authors.Add(new Author(authors.Count, "Default"));

            this.authors.AddRange(service.getAuthors());
        }

        public void addAuthor(String name)
        {
            Author author = new Author(name);
            author = service.postAuthor(author);
            if (author != null) { authors.Add(author); }

            /*
            Author author = new Author(name);
            var response = service.postAuthor(author);
            if (response.IsSuccessStatusCode)
            {
                author = service.deserializeJson<Author>(response.Content.ReadAsStringAsync().Result);
                this.authors.Add(author);
            }*/
            
        }
        public List<String> getAuthorsNames()
        {
            List<String> names = new List<String>();

            foreach(var author in authors) { names.Add(author.getName()); }

            return names;
        }

        public Author getAuthor(String name)
        {
            foreach(var author in authors)
            {
                if (author.getName().Equals(name))
                {
                    return author;
                }
            }
            return null;
        }

        public bool isContaining(String name)
        {
            foreach(var author in authors)
            {
                if (author.getName().Equals(name)) { return true; }
            }
            return false;
        }
    }
}
