// See https://aka.ms/new-console-template for more information
using PDFStatementGenerator.PDFLibrary;

Console.WriteLine("Hello, World!");
PDFCreatorService PDFCreatorService = new PDFCreatorService();
PDFCreatorService.CreatePDF();
