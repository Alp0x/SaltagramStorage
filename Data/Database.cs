// export AZURE_TABLE_STORAGE_URI = "https://.../";
// export AZURE_TABLE_STORAGE_ACCOUNT_NAME = "marcusoftnettables";
// export AZURE_TABLE_STORAGE_ACCOUNT_KEY = "h8934gvh93i2h3oivnio3rg";

// var storageUri = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_URI");
// var accountName = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_ACCOUNT_NAME"); ;
// var storageAccountKey = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_ACCOUNT_KEY"); ;

// var serviceClient = new TableServiceClient(
//     new Uri(storageUri),
//     new TableSharedKeyCredential(accountName, storageAccountKey));
// string tableName = "CreatedWithCodeTable";
// TableItem table = serviceClient.CreateTableIfNotExists(tableName);

// Console.WriteLine($"The created table's name is {table.Name}.");
// Console.ReadLine(); AZURE TABLES - CONNECTINGAZURE TABLES - CONNECTING
// CONNECT WITH ACCOUNT KEYCONNECT WITH ACCOUNT KEY
// CONNECTION STRINGCONNECTION STRING

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