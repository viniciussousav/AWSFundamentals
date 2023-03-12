// See https://aka.ms/new-console-template for more information

using S3Playground;

var putObjectRequestHandler = new PutObjectRequestHandler();

var csvAsText = await putObjectRequestHandler.GetCsvAsText(); 

Console.WriteLine(csvAsText);

putObjectRequestHandler.Dispose();