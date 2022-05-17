using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
  public  class MessageTwoManager:IMessageTwoService
    {
        IMessageTwoDal _messageTwoDal;
        public MessageTwoManager(IMessageTwoDal messageTwoDal)
        {
            _messageTwoDal = messageTwoDal;
        }

        public void Add(MessageTwo entity)
        {
             _messageTwoDal.Insert(entity);
        }

        public void Delete(MessageTwo entity)
        {
            throw new NotImplementedException();
        }

        public MessageTwo GetById(int id)
        {
            return _messageTwoDal.GetById(id);
        }

        public List<MessageTwo> GetInboxByWriter(int id)
        {
            return _messageTwoDal.GetListWithMessageByWriter(id);
        }

        public List<MessageTwo> GetList()
        {
            return _messageTwoDal.GetList();
        }

        public List<MessageTwo> GetSendboxWithByWriter(int id)
        {
            return _messageTwoDal.GetSendboxWithByWriter(id);
        }

        public void Update(MessageTwo entity)
        {
            throw new NotImplementedException();
        }
    }
}
