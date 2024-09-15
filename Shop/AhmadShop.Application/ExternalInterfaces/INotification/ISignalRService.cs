using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Application.ExternalInterfaces.INotification;

public interface ISahabService
{
    public Task<object> Ocr(object request);
}
