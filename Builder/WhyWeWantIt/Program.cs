using System;
using System.Collections.Generic;
using System.Text;

namespace WhyWeWantIt {

    public class HtmlElement {

        public string Name { get; set; }
        public string Text { get; set; }
        public List<HtmlElement> Elements { get; set; } = new List<HtmlElement> ();
        private const int indentSize = 2;

        public HtmlElement (string name, string text) {
            this.Name = name;
            this.Text = text;

        }
        public HtmlElement () {

        }

        private string ToSTringImpl(int indent) 
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent );
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1) ));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToSTringImpl(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToSTringImpl(0);
        }       

    }
    
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public HtmlBuilder AddCHild(string childName, string childText) 
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);

            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement{};
            root.Name = this.rootName;

        }
    }

    class Program {
        static void Main (string[] args) {
            // Not effective 
            var hello = "hello";
            //StringBuilder is a Builder
            var sb = new StringBuilder ();
            sb.Append ("<p>");
            sb.Append (hello);
            sb.Append ("</p>");
            System.Console.WriteLine (sb);

            var words = new [] { "hello", "world" };
            sb.Clear ();
            sb.Append ("<ul>");

            foreach (var word in words) {
                sb.AppendFormat ("<li>{0}</li>", word);
            }

            sb.Append ("</ul>");

            System.Console.WriteLine (sb);

            // Use the HTML builder

            var builder = new HtmlBuilder("ul")
                .AddCHild("li", "hello")
                .AddCHild("li", "world");

            System.Console.WriteLine(builder.ToString());            

        }
    }
}