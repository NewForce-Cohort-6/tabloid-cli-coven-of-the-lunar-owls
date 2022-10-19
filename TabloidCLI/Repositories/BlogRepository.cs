using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    internal class BlogRepository : DatabaseConnector, IRepository<Blog>
    {
        public BlogRepository(string connectionString): base(connectionString) { }

//-------------INSERT---------------
        public void Insert(Blog blog)
        {
            using (SqlConnection conn=Connection)
            {
                conn.Open();
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Blog(Title, URL) VALUES (@title, @url)";
                    cmd.Parameters.AddWithValue("@title", blog.Title);
                    cmd.Parameters.AddWithValue("@url", blog.Url);
                    cmd.ExecuteNonQuery();

                }
            }
        }
//----------------END INSERT-------------

//---------------GET ALL------------------
        public List<Blog> GetAll()
        {
            using (SqlConnection conn=Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Title, URL FROM Blog";

                    List<Blog> blogs = new List<Blog>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Blog blog = new Blog()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Url = reader.GetString(reader.GetOrdinal("URL")),
                        };
                        blogs.Add(blog);
                    }
                        reader.Close();
                        return blogs;

                }
            }
        }
//-----------END GET ALL--------------------

//---------------GET------------------------
        public Blog Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd= conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Blog.Id AS BlogId, Blog.Title, Blog.Url, Tag.Id AS TagId, Tag.Name 
                                        FROM Blog
                                        LEFT JOIN BlogTag on Blog.Id = BlogTag.BlogId
                                        LEFT JOIN Tag on Tag.Id = BlogTag.TagId
                                        WHERE blog.Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    Blog blog = null;

                    SqlDataReader reader= cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        if (blog==null)
                        {
                            blog = new Blog()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("BlogId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Url = reader.GetString(reader.GetOrdinal("URL")),

                            };
                        }
                        if(!reader.IsDBNull(reader.GetOrdinal("TagId")))
                        {
                            blog.Tags.Add(new Tag()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("TagId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                            });

                        }
                    }
                    reader.Close();
                    return blog;

                }
            }
        }
//--------------------END GET-------------------------

//----------------------UPDATE-----------------------------
    public void Update(Blog blog)
        {
            using(SqlConnection conn= Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Blog SET Title = @title, Url = @url WHERE id = @id";
                    cmd.Parameters.AddWithValue("@title", blog.Title);
                    cmd.Parameters.AddWithValue("@url", blog.Url);
                    cmd.Parameters.AddWithValue("@id", blog.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
//--------------------END UPDATE---------------------------

//----------------------DELETE-----------------------------
       public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Blog WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
//------------------------END DELETE-------------------------------------

//-----------------------INSERT TAG--------------------------------------

        public void InsertTag(Blog blog, Tag tag)
        {
            using (SqlConnection conn= Connection)
            {
                conn.Open();
                using (SqlCommand cmd= conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO BlogTag (BlogId, TagId) VALUES (@blogId, @tagId)";
                    cmd.Parameters.AddWithValue("@blogId", blog.Id);
                    cmd.Parameters.AddWithValue("@tagId", tag.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
//------------------------END INSERT TAG-------------------------------------


    }
}
