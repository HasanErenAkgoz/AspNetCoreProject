using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
  public  interface IMessageTwoDal : IGenericDal<MessageTwo>
    {
        List<MessageTwo> GetListWithMessageByWriter(int id);
        List<MessageTwo> GetSendboxWithByWriter(int id);

    }
}
