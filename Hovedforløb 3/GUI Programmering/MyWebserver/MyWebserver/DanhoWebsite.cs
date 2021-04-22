using DanhoLibrary.Extensions;

namespace MyWebserver
{
    public class DanhoWebsite
    {
        public static string Index() =>
            HTML("h1", "Welcome to my website!") +
            HTML("button", "Go to Hello", new TagAttribute("href", "/Hello")) +
            HTML("button", "Go to Hello but in a new page",
                new TagAttribute("href", "/Hello"),
                new TagAttribute("taget", "_blank")
            ) +
            HTML("div",
                HTML("p", "This is inside a div", new TagAttribute("class", "frontContent"))
            );

        public static string Hello() =>
            HTML("h1", "Hello  there") +
            HTML("h3", "General Kenobi");

        private static string HTML(string tag, string content, params TagAttribute[] attributes) =>
            $"<{tag} {(attributes.Length > 0 ? attributes.Map(tag => tag.ToString()).Combine(" ") : "")}>{content}</{tag}>";
    }
}
