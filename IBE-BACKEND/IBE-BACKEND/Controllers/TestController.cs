using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using GraphQL.Client.Http;
using IBE_BACKEND.Models;
using IBE_BACKEND.Models.DynamoDbResponseModels;
using IBE_BACKEND.Models.GraphQLResponseModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using RoomRatesData = IBE_BACKEND.Models.GraphQLResponseModels.RoomRatesData;
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
        public TestController (ILogger<TestController> logger, team03Context team03Context, GraphQLClientService graphQLClientService,IAmazonDynamoDB amazonDynamoDB)
        {
            _logger = logger;
            _team03Context = team03Context;
            _graphQLClientService = graphQLClientService;
            _dynamoDbClient = amazonDynamoDB;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> Test()
        {
            int propertyId = 3; // Replace with the actual property ID
            int skip = 0; // Replace with the desired value for skip
            int take = 1000; // Replace with the desired value for take
            Console.WriteLine("hiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");

            //string query = string.Format(GraphQLQueries.Queries.roomRatesBreakDown, propertyId, skip, take);
            //Console.WriteLine(query);
            // var response = await _graphQLClientService.SendQueryAsync<JsonObject>(GraphQLQueries.Queries.roomRatesBreakDown);
            GraphQlResponseModel < Models.GraphQLResponseModels.RoomRatesData > response = await _graphQLClientService.SendQueryAsync<GraphQlResponseModel<Models.GraphQLResponseModels.RoomRatesData>>(GraphQLQueries.Queries.roomRatesBreakDown);
            // var response = await _graphQLClientService.SendQueryAsync<JsonObject>(GraphQLQueries.Queries.roomRatesBreakDown);

            RoomRatesData roomRatesData = response.Data;
            List<RoomType> roomTypes = roomRatesData.ListRoomTypes;
            Console.WriteLine(roomTypes.Count);
            foreach(RoomType roomType in roomTypes)
            {
                Console.WriteLine(roomType.RoomTypeName);
                roomType.RoomRates.ForEach(roomRate => Console.WriteLine(roomRate.RoomRateData.BasicNightlyRate));
                
                //foreach (Models.RoomRates roomRate in roomType.room_rates)
                //{
                //    Console.WriteLine(roomRate);
                //    Console.WriteLine(roomRate.RoomRate.Date);
                //    Console.WriteLine(roomRate.RoomRate.BasicNightlyRate);
                //    //Console.WriteLine(roomRate.date);
                //    //Console.WriteLine(roomRate.basic_nightly_rate);

                //}
            }

            return Ok(response);
        }
    }
}
