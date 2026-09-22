using TransactionFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TransactionFramework;
public class TransactionApiClient
{
    private readonly HttpClient _httpClient;

    public TransactionApiClient(string baseAddress, int timeout)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseAddress),
            Timeout = TimeSpan.FromSeconds(timeout)
        };
    }

    public TransactionResponseModel ExecuteTransactionSync(dynamic transactionRequest)
    {
        string json = "";
        string text = "";
        TransactionResponseModel transactionResponseModel = new TransactionResponseModel();
        try
        {
            text = JsonSerializer.Serialize(transactionRequest);
            StringContent content = new StringContent(text, Encoding.UTF8, "application/json");
            HttpResponseMessage result = _httpClient.PostAsync("API/Transaction", content).Result;
            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                json = result.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<TransactionResponseModel>(json);
            }

            throw new Exception("No funciono");
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("Request timed out: " + ex.Message);
        }
        catch (HttpRequestException ex2)
        {
            Console.WriteLine("HTTP request error: " + ex2.Message);
        }
        catch (Exception ex3)
        {
            Console.WriteLine("Error: " + ex3.Message);
            TransactionRequestModel transactionRequest2 = JsonSerializer.Deserialize<TransactionRequestModel>(text);
            transactionResponseModel = PrepareTransactionResponseError(transactionRequest2, ex3.ToString());
            json = JsonSerializer.Serialize(transactionResponseModel);
        }

        return JsonSerializer.Deserialize<TransactionResponseModel>(json);
    }

    public string ExecuteTransactionSync(TransactionRequestModel transactionRequest)
    {
        string text = "";
        string text2 = "";
        TransactionResponseModel transactionResponseModel = new TransactionResponseModel();
        try
        {
            text2 = JsonSerializer.Serialize(transactionRequest);
            StringContent content = new StringContent(text2, Encoding.UTF8, "application/json");
            HttpResponseMessage result = _httpClient.PostAsync("API/Transaction", content).Result;
            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                text = result.Content.ReadAsStringAsync().Result;
                return text;
            }

            throw new Exception("No funciono");
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("Request timed out: " + ex.Message);
        }
        catch (HttpRequestException ex2)
        {
            Console.WriteLine("HTTP request error: " + ex2.Message);
        }
        catch (Exception ex3)
        {
            Console.WriteLine("Error: " + ex3.Message);
            TransactionRequestModel transactionRequest2 = JsonSerializer.Deserialize<TransactionRequestModel>(text2);
            transactionResponseModel = PrepareTransactionResponseError(transactionRequest2, ex3.ToString());
            text = JsonSerializer.Serialize(transactionResponseModel);
        }

        TransactionResponseModel transactionResponseModel2 = JsonSerializer.Deserialize<TransactionResponseModel>(text);
        return "";
    }

    private TransactionResponseModel PrepareTransactionResponseError(TransactionRequestModel transactionRequest, string errorMessage)
    {
        return new TransactionResponseModel
        {
            Transaction = transactionRequest.Transaction,
            Message = errorMessage,
            Results = new List<object>(),
            Status = "1"
        };
    }

    public async Task<string> ExecuteTransactionAsync(dynamic transactionRequest)
    {
        string responseBody = "";
        string jsonString = JsonSerializer.Serialize(transactionRequest);
        StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync("API/Transaction", content);
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            responseBody = await response.Content.ReadAsStringAsync();
        }
        else
        {
            object arg = response.StatusCode;
            Console.WriteLine($"Error: {arg} - {await response.Content.ReadAsStringAsync()}");
        }

        return responseBody;
    }

    public async Task Transaction(TransactionRequestModel transactionRequest)
    {
        string jsonString = JsonSerializer.Serialize(transactionRequest);
        StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        (await _httpClient.PostAsync("api/data", content)).EnsureSuccessStatusCode();
    }

    public T DeserializacionJSON<T>(string transactionEnJSON)
    {
        return JsonSerializer.Deserialize<T>(transactionEnJSON);
    }

    public string SerializacionJSON<T>(T transaction)
    {
        return JsonSerializer.Serialize(transaction);
    }

    public List<T> MappingTransactionResults<T>(TransactionResponseModel transactionResponse)
    {
        List<T> result = new List<T>();
        if (transactionResponse.Results.Count > 0)
        {
            string json = JsonSerializer.Serialize(transactionResponse.Results);
            result = JsonSerializer.Deserialize<List<T>>(json);
        }

        return result;
    }
}
