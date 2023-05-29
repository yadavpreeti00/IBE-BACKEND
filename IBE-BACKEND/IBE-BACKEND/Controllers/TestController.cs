using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using GraphQL.Client.Http;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models;
using IBE_BACKEND.Models.DynamoDbResponseModels;
using IBE_BACKEND.Models.GraphQLResponseModels;
using IBE_BACKEND.Services.ClientServices;
using IBE_BACKEND.Services.DatabaseServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using RoomRatesResponseData = IBE_BACKEND.Models.GraphQLResponseModels.RoomRatesResponseData;
using RoomType = IBE_BACKEND.Models.GraphQLResponseModels.RoomType;

namespace IBE_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly team03Context _team03Context;
        private readonly ILogger<TestController> _logger;
        private readonly GraphQLClientService _graphQLClientService;
        private readonly IAmazonDynamoDB _dynamoDbClient;
        private readonly SQSClientService _sQSClientService;
        private readonly IBookingStatusService _service;
        public TestController (ILogger<TestController> logger, team03Context team03Context, GraphQLClientService graphQLClientService, IAmazonDynamoDB amazonDynamoDB, SQSClientService sQSClientService,IBookingStatusService service)
        {
            _logger = logger;
            _team03Context = team03Context;
            _graphQLClientService = graphQLClientService;
            _dynamoDbClient = amazonDynamoDB;
            _sQSClientService = sQSClientService;
            _service = service;
        }

        [HttpGet]
        [EnableCors]
        public  IActionResult Test()
        {
            var respones =_service.GetBookingStatus("022758bc-f");
            return Ok(respones);
        }
    }
}
