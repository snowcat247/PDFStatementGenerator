using Aspose.Pdf;
using Aspose.Pdf.Devices;
using Aspose.Pdf.Drawing;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Operators;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFStatementGenerator.PDFLibrary
{
    internal class PDFCreatorService
    {
        public void CreatePDF()
        {
            string dataDir = @"C:\tempo\";
            Document pdfDocument = new Document(dataDir + "HelloWorld_out.pdf");

            // Set coordinates
            int lowerLeftX = 50;
            int lowerLeftY = 50;
            int upperRightX = 200;
            int upperRightY = 80;

            // Get the page where image needs to be added
            Page page = pdfDocument.Pages[1];
            // Load image into stream
            FileStream imageStream = new FileStream(dataDir + "mt.png", FileMode.Open);
            // Add image to Images collection of Page Resources
            page.Resources.Images.Add(imageStream);
            // Using GSave operator: this operator saves current graphics state
            page.Contents.Add(new Aspose.Pdf.Operators.GSave());
            // Create Rectangle and Matrix objects

            Aspose.Pdf.Rectangle rectangle = new Aspose.Pdf.Rectangle(lowerLeftX, page.PageInfo.Height - lowerLeftY, upperRightX, page.PageInfo.Height - upperRightY);

            //Aspose.Pdf.Rectangle rectangle = new Aspose.Pdf.Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY);
            Matrix matrix = new Matrix(new double[] { rectangle.URX - rectangle.LLX, 0, 0, rectangle.URY - rectangle.LLY, rectangle.LLX, rectangle.LLY });
            // Using ConcatenateMatrix (concatenate matrix) operator: defines how image must be placed
            page.Contents.Add(new Aspose.Pdf.Operators.ConcatenateMatrix(matrix));
            XImage ximage = page.Resources.Images[page.Resources.Images.Count];
            // Using Do operator: this operator draws image
            page.Contents.Add(new Aspose.Pdf.Operators.Do(ximage.Name));
            // Using GRestore operator: this operator restores graphics state
            page.Contents.Add(new Aspose.Pdf.Operators.GRestore());

            // header text


            TextFragment wideFragment = new TextFragment("Account Transaction History");
            wideFragment.TextState.Font = FontRepository.FindFont("Arial");
            wideFragment.TextState.FontSize = 14;
            wideFragment.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.DarkGreen);
            wideFragment.TextState.CharacterSpacing = 2.0f;
            wideFragment.Position = new Position(50, 730);
            page.Paragraphs.Add(wideFragment);



            TextFragment rFragment = new TextFragment("01 JUN 2023 - 31 AUG 2023");
            rFragment.TextState.Font = FontRepository.FindFont("Arial");
            rFragment.TextState.FontSize = 10;
            rFragment.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            rFragment.TextState.CharacterSpacing = 2.0f;
            rFragment.Position = new Position(300, 730);
            page.Paragraphs.Add(rFragment);



            TextFragment aFragment = new TextFragment("Dundee United" + Environment.NewLine + "Tannadice" 
                + Environment.NewLine + "Dundee" + Environment.NewLine + "DD1 1AA");
            aFragment.TextState.Font = FontRepository.FindFont("Helvetica");
            aFragment.TextState.FontSize = 10;
            aFragment.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            aFragment.TextState.CharacterSpacing = 1.0f;
            aFragment.Position = new Position(50, 700);
            page.Paragraphs.Add(aFragment);


            // Append TextFragment to TextBuilder instance
            // builder.appendText(wideFragment);


            TextFragment toplineFragment = new TextFragment("Date");
            toplineFragment.TextState.Font = FontRepository.FindFont("Helvetica");
            toplineFragment.TextState.FontSize = 9;
            toplineFragment.TextState.FontStyle = FontStyles.Bold;
            toplineFragment.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            toplineFragment.TextState.CharacterSpacing = 1.0f;
            toplineFragment.Position = new Position(50, 650);
            page.Paragraphs.Add(toplineFragment);

            TextFragment nextlineFragment = new TextFragment("Description");
            nextlineFragment.TextState.Font = FontRepository.FindFont("Helvetica");
            nextlineFragment.TextState.FontSize = 9;
            nextlineFragment.TextState.FontStyle = FontStyles.Bold;
            nextlineFragment.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            nextlineFragment.TextState.CharacterSpacing = 1.0f;
            nextlineFragment.Position = new Position(120, 650);
            page.Paragraphs.Add(nextlineFragment);

            TextFragment depFrag = new TextFragment("Deposits");
            depFrag.TextState.Font = FontRepository.FindFont("Helvetica");
            depFrag.TextState.FontSize = 9;
            depFrag.TextState.FontStyle = FontStyles.Bold;
            depFrag.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            depFrag.TextState.CharacterSpacing = 1.0f;
            depFrag.Position = new Position(280, 650);
            page.Paragraphs.Add(depFrag);

            TextFragment crFrag = new TextFragment("Withdrawals");
            crFrag.TextState.Font = FontRepository.FindFont("Helvetica");
            crFrag.TextState.FontSize = 9;
            crFrag.TextState.FontStyle = FontStyles.Bold;
            crFrag.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            crFrag.TextState.CharacterSpacing = 1.0f;
            crFrag.Position = new Position(370, 650);
            page.Paragraphs.Add(crFrag);

            TextFragment balFrag = new TextFragment("Balance");
            balFrag.TextState.Font = FontRepository.FindFont("Helvetica");
            balFrag.TextState.FontSize = 9;
            balFrag.TextState.FontStyle = FontStyles.Bold;
            balFrag.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            balFrag.TextState.CharacterSpacing = 1.0f;
            balFrag.Position = new Position(460, 650);
            page.Paragraphs.Add(balFrag);

            var graph = new Aspose.Pdf.Drawing.Graph(page.PageInfo.Width , 20);
            graph.Left=50;
            var line = new Line(new float[] { 500, 0, 0, 0 });
            graph.IsInLineParagraph = true;
            line.GraphInfo.Color = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            line.GraphInfo.LineWidth = 1;
            graph.Shapes.Add(line);
            page.Paragraphs.Add(graph);

            dataDir = dataDir + "AddImage_out.pdf";
            // Save updated document
            pdfDocument.Save(dataDir);

        }

        

    }
}
