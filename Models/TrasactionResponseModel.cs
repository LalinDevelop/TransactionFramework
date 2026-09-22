using System.Collections.Generic;


public class TransactionResponseModel
{
    public string Token { get; set; }

    public string User { get; set; }

    public string Application { get; set; }

    public string HostName { get; set; }

    public string Ip { get; set; }

    public string Transaction { get; set; }

    public string Status { get; set; }

    public string Message { get; set; }

    public List<object> Results { get; set; }
}