using TransactionFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TransactionFramework;
public static class TransactionHelper
{
    public static string MappingToJson<T>(this T obj, JsonSerializerOptions options = null)
    {
        if (obj == null)
        {
            return "null";
        }

        return JsonSerializer.Serialize(obj);
    }

    public static T MappingToObject<T>(this string jsonString, JsonSerializerOptions options = null)
    {
        if (string.IsNullOrWhiteSpace(jsonString))
        {
            return default(T);
        }

        return JsonSerializer.Deserialize<T>(jsonString, options);
    }

    public static List<T> MappingToListObject<T>(this string jsonString, JsonSerializerOptions options = null)
    {
        List<T> list = null;
        try
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return null;
            }

            return JsonSerializer.Deserialize<List<T>>(jsonString, options);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static List<T> MappingTransactionResultToObject<T>(this string jsonString, JsonSerializerOptions options = null)
    {
        List<T> list = null;
        try
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return null;
            }

            TransactionResponseModel transactionResponseModel = jsonString.MappingToObject<TransactionResponseModel>();
            return transactionResponseModel.Results.MappingToJson().MappingToListObject<T>();
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            list = null;
        }
    }
}