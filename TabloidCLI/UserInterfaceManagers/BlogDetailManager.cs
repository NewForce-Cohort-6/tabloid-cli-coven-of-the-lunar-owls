using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class BlogDetailManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private BlogRepository _blogRepository;
        private AuthorRepository _authorRepository;
        private PostRepository _postRepository;
        private TagRepository _tagRepository;
        private int _blogId;

        public BlogDetailManager(IUserInterfaceManager parentUI, string connectionString, int blogId)
        {
            _parentUI = parentUI;
            _blogRepository = new BlogRepository(connectionString);
            _authorRepository = new AuthorRepository(connectionString);
            _postRepository = new PostRepository(connectionString);
            _tagRepository = new TagRepository(connectionString);
            _blogId = blogId;
        }

        public IUserInterfaceManager Execute()
        {
            Blog blog = _blogRepository.Get(_blogId);
            Console.WriteLine($"={blog.Title} Details=");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 2) View Blog Posts");
            Console.WriteLine(" 3) Add Tag");
            Console.WriteLine(" 4) Remove Tag");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    View();
                    return this;
                case "2":
                    throw new NotImplementedException();
                case "3":
                    throw new NotImplementedException();
                case "4":
                    throw new NotImplementedException();
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void View()
        {
            Console.WriteLine();
            Blog blog = _blogRepository.Get(_blogId);
            Console.WriteLine($"Blog Title: {blog.Title}");
            Console.WriteLine($"Blog URL: {blog.Url}");
            Console.WriteLine($"Tags: ");
            foreach(Tag tag in blog.Tags)
            {
                Console.WriteLine(" " + tag);
            }
            Console.WriteLine();
        }
    }
}
