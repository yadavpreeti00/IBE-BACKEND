namespace IBE_BACKEND.GraphQLQueries
{
    public class Queries
    {
        public static string defaultPromotions = "query MyQuery {\n" +
           "        listPromotions {\n" +
           "        is_deactivated\n" +
           "        minimum_days_of_stay\n" +
           "        price_factor\n" +
           "        promotion_description\n" +
           "        promotion_id\n" +
           "        promotion_title\n" +
           "        }\n" +
           "        }";

        public static string minimumNightlyRateQuery = "query MyQuery {\n" +
                "  listRoomTypes(where: {property_id: {equals: 3}, room_rates: {some: {room_rate: {date: {gte: \"2023-03-01T00:00:00.000Z\", lte: \"2023-05-31T00:00:00.000Z\"}}}}}, take: 1000, skip: 0) {\n" +
                "    room_rates {\n" +
                "      room_rate {\n" +
                "        basic_nightly_rate\n" +
                "        date\n" +
                "      }\n" +
                "    }\n" +
                "    property_id\n" +
                "  }\n" +
                "}\n";

        public static string rateBetweenDateRangeQuery = "query MyQuery { " +
                 "listRoomRates(where: {date: {gte:\"2023-03-01T00:00:00.000Z\", lte: \"2023-03-28T00:00:00.000Z\"}, AND: {room_types: {some: {room_type: {property_id: {equals: 3}}}}}}, take: 1000) { " +
                     "basic_nightly_rate " +
                     "room_types { " +
                         "room_type { " +
                             "property_id " +
                             "room_type_name " +
                         "} " +
                     "} " +
                 "} " +
             "}";

        public static string searchResultsQuery = "query MyQuery {\n" +
                " listRoomAvailabilities(where: {property_id: {equals: 3}, date: {gte:\"2023-05-01T00:00:00.000Z\", lte: \"2023-05-28T00:00:00.000Z\"}, booking_id: {equals: 0}}, take: 1000) {\n" +
                " date\n" +
                " room_id\n" +
                " room {\n" +
                " room_type {\n" +
                " room_type_name\n" +
                " single_bed\n" +
                " room_type_id\n" +
                " max_capacity\n" +
                " double_bed\n" +
                " area_in_square_feet\n" +
                " }\n" +
                " }\n" +
                " }\n" +
                "}";

        public static string roomRatesBreakDown = "query MyQuery {\n" +
                "  listRoomTypes(where: {property_id: {equals: 3}}, skip: 0, take: 1000) {\n" +
                "    room_type_name\n" +
                "    room_rates {\n" +
                "      room_rate {\n" +
                "        basic_nightly_rate\n" +
                "        date\n" +
                "      }\n" +
                "    }\n" +
                "  }\n" +
                "}\n";
    }

}
