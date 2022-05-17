using DataAccess.Abstract;
using DataAccess.Repositories;
using Entity.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfMessageTwoDal : GenericRepository<MessageTwo>, IMessageTwoDal
    {
        public List<MessageTwo> GetListWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.messageTwos.Include(x =>x.SenderUser).Where(x => x.Receviver == id).ToList();
            }
        }

        public List<MessageTwo> GetSendboxWithByWriter(int id)
        {
            using (var context=new Context())
            {
                return context.messageTwos.Include(x => x.ReceiverUser).Where(y => y.Sender == id).ToList();
            }
        }
    }
}
