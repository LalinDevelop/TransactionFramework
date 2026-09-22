using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionFramework.Models;
public class TransactionRequestModel
{
    public string Token { get; set; }

    public string User { get; set; }

    public string Application { get; set; }

    public string HostName { get; set; }

    public string Ip { get; set; }

    public string Transaction { get; set; }

    public string Status { get; set; }

    public string Message { get; set; }

    public object TransactionAttributes { get; set; }
}