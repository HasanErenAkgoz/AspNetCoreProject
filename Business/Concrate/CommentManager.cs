using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal comment)
        {
            _commentDal = comment;
        }
        public void Add(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public int CommentCount()
        {
            return _commentDal.GetList().Count();
        }

        public void Delete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(x=>x.BlogId==id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetListWithBlog();
        }

        public void Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
