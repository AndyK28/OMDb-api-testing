using System;
using Applications.OMDb.Swagger.Api;
using NUnit.Framework;

namespace MovieDatabaseApi.Tests;

public class ApiTestHelper
{
    private readonly string? _apiKey;
    public readonly string BasePath;
    private const string BaseUrl = "http://www.omdbapi.com/";

    public IDParameterApi? idParameterApi;
    public SearchParameterApi? searchParameterApi;
    public TitleParameterApi? titleParameterApi;


    public ApiTestHelper()
    {
        _apiKey = Environment.GetEnvironmentVariable("MOVIE_API_KEY");
        if (string.IsNullOrEmpty(_apiKey))
        {
            var message = "API key is missing. Please set the MOVIE_API_KEY environment variable.";
            throw new InvalidOperationException(message);
        } else BasePath = $"{BaseUrl}?apikey={_apiKey}&";
    }

    [SetUp]
    public void Setup()
    {
        idParameterApi = new IDParameterApi(BasePath);
        searchParameterApi = new SearchParameterApi(BasePath);
        titleParameterApi = new TitleParameterApi(BasePath);
    }
}