using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IMessageTwoService : IGenericService<MessageTwo>
    {
        List<MessageTwo> GetInboxByWriter(int id);
        List<MessageTwo> GetSendboxWithByWriter(int id);




    }
}
