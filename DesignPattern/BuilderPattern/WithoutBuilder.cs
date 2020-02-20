using System;
using System.Text;

namespace BuilderPattern
{
    public class WithoutBuilder
    {
        public void GenerateHtml()
        {
            string hello = "Hello from Aakash";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");

            sb.Append("<ul>");
            sb.Append("<li>");
            sb.Append("Hello");
            sb.Append("</li>");
            sb.Append("<li>");
            sb.Append("World");
            sb.Append("</li>");
            sb.Append("/<ul>");


            Console.WriteLine(sb);
        }
    }
}
