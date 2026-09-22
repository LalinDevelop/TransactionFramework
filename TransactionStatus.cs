using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionFramework;
public class TransactionStatus
{
    public const string REQUEST = "Request";

    public const string SUCCESS = "Success";

    public const string WARNING = "Warning";

    public const string ERROR = "Error";

    public const string TIMEOUT = "Timeout";
}
