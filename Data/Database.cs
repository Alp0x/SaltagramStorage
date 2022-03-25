
// Console.WriteLine($"The created table's name is {table.Name}.");
// Console.ReadLine(); AZURE TABLES - CONNECTINGAZURE TABLES - CONNECTING
// CONNECT WITH ACCOUNT KEYCONNECT WITH ACCOUNT KEY
// CONNECTION STRINGCONNECTION STRING


// var tableClient = new TableClient(
// new Uri(storageUri),
// "SaltagramTable",
// new TableSharedKeyCredential(accountName, storageAccountKey));
// await tableClient.CreateIfNotExistsAsync();

// var table2Client = new TableClient(
// new Uri(storageUri2),
// "SaltTable",
// new TableSharedKeyCredential(accountName, storageAccountKey));
// await table2Client.CreateIfNotExistsAsync();

// var rowKey = Guid.NewGuid().ToString();
// var partitionKey = "PartitionKey";
// var lastRowKey = "";

// var address = new TableEntity(partitionKey, rowKey)
// {
//     { "City", "Marcus" },
//     { "Street", "Teacher" },
//     { "Housenumber", 8 }
// };
// table2Client.AddEntity(address);

// for (int i = 0; i < 10; i++)
// {
//     lastRowKey = rowKey;
//     var entity = new TableEntity(partitionKey, rowKey)
//   {
//       { "Name", "Marcus" },
//       { "Role", "Teacher" },
//       { "Skill", 0.8 * i }
//   };
//     tableClient.AddEntity(entity);
// }

// System.Console.WriteLine("Reading dynamic data...");
// Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");
// foreach (TableEntity qEntity in queryResultsFilter)
// {
//     Console.WriteLine($"{qEntity.GetString("Name")}: {qEntity.GetDouble("Skill")}");
// // }
// new Salt[]
//         {
//             new Salt{
//                 Name = "Good Salt",
//                 GrainSize = "Big",
//                 Description = "Salty looking salty tasting",
//                 SourceSize = "1000000"
//             },
//             new Salt{
//                 Name = "Better Salt",
//                 GrainSize = "Gigantic",
//                 Description = "Saltier looking saltier tasting",
//                 SourceSize = "1000"
//             }
//         }