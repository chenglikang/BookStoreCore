using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookData
    {
        string _connString = "Data Source=.;Initial Catalog=BookStore;Integrated Security=True;";
        public List<BookViewModel> SelectNewBook(int count)
        {

            int i = 10;

            List<BookViewModel> list = new List<BookViewModel>();
            string sql = "select Top (@Count) BookId,BookName,ImageUrl from Books order by DateCreated desc";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Count", count));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = new BookViewModel();
                            book.BookId = reader.GetInt32(0);
                            book.BookName = reader.GetString(1);
                            book.ImageUrl = reader.GetString(2);
                            list.Add(book);
                        }
                    }
                }
            }
            return list;
        }


        public List<BookViewModel> SelectBookByCategoryId(int page,int count, int? categoryId)
        {
            List<BookViewModel> list = new List<BookViewModel>();

            string sql = "select BookId,BookName,ImageUrl from Books order by DateCreated desc offset @PageNum*@Count row fetch next @Count rowonly";

            //string sql = "select BookId,BookName,ImageUrl from Books order by DateCreated desc";
            if (categoryId != null)
            {
                sql = "select BookId,BookName,ImageUrl from Books where CategoryId = @CategoryId  order by DateCreated desc";
            }
            
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@PageNum", categoryId));
                    cmd.Parameters.Add(new SqlParameter("@Count", categoryId));
                    if (categoryId != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = new BookViewModel();
                            book.BookId = reader.GetInt32(0);
                            book.BookName = reader.GetString(1);
                            book.ImageUrl = reader.GetString(2);
                            list.Add(book);
                        }
                    }
                }
            }
            return list;
        }

        public List<Category> SelectCategorys()
        {
            List<Category> list = new List<Category>();
            string sql = "select CategoryId,Name from Categorys";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cat = new Category();
                            cat.CategoryId = reader.GetInt32(0);
                            cat.Name = reader.GetString(1);
                            list.Add(cat);
                        }
                    }
                }
            }
            return list;
        }

        public BookDetailsViewModel SelectBook(int id)
        {
            string sql = "select BookId,BookName,ImageUrl,Price,Details from Books where BookId = @Id";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var book = new BookDetailsViewModel();
                            book.BookId = reader.GetInt32(0);
                            book.BookName = reader.GetString(1);
                            book.ImageUrl = reader.GetString(2);
                            book.Price = reader.GetDecimal(3);
                            book.Details = reader.GetString(4);
                            return book;
                        }
                    }
                }
            }
            return null;
        }

    }
}
