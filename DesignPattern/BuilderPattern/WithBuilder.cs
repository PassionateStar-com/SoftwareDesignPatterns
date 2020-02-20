using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{

    public class HtmlElement
    {
        public string TagName;
        public string Text;
        public List<HtmlElement> ChildElements = new List<HtmlElement>();
        private const int indentSize = 2;

        //Empty constructor for root element
        public HtmlElement()
        {

        }

        public HtmlElement(string tag, string text)
        {
            this.TagName = tag;
            this.Text = text;
        }
        

        private string CustomToString(int indent)
        {
            var spaces = new string(' ', indentSize * indent);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}<{TagName}>");

            if (string.IsNullOrEmpty(Text) == false)
            {
                sb.Append(new string(' ', indentSize * indent + 1));
                sb.AppendLine(Text);
            }
            foreach (var element in ChildElements)
            {
                sb.Append(element.CustomToString(indent + 1));
            }
            sb.AppendLine($"{spaces}</{TagName}>");


            return sb.ToString();
        }

        public override string ToString()
        {
            return CustomToString(0);
        }
    }




    public class HtmlBuilder
    {
        private HtmlElement root = new HtmlElement();
        private string rootName;

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.TagName = rootName;
        }

        public void AddChild(string tag, string content)
        {
            HtmlElement child = new HtmlElement(tag, content);
            root.ChildElements.Add(child);
        }

        //Fluent Interface to return the reference of the class to chain the methods together.
        public HtmlBuilder AddChildRecursive(string tag, string content)
        {
            HtmlElement child = new HtmlElement(tag, content);
            root.ChildElements.Add(child);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }
    }

    public class WithBuilder
    {
        public void GenerateHtml()
        {
            HtmlBuilder builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello");
            builder.AddChild("li", "World");

            builder.AddChildRecursive("li", "Aakash").AddChildRecursive("li", "Chotrani");

            Console.WriteLine(builder.ToString());
        }
    }
}
