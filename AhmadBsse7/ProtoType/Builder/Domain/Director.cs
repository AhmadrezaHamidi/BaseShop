using System;
using System.Text;

namespace Builder.Domain
{
	public class Director
	{

        private readonly IBuilder builder;

        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public IDocument FromRtf(string etfPath)
		{
            var conetet = "asdasdasdasd";
            builder.AddTitle(conetet);
            builder.AddParagraph(conetet);
            return builder.Build();
		}
	}

	public interface IBuilder
	{
		void AddTitle(string title);
		void AddParagraph(string parahgrah);

		IDocument Build();
	}

    public class HTmlBuilder : IBuilder
    {
        private StringBuilder _html = new StringBuilder();
        
        public void AddParagraph(string parahgrah)
        {
            _html.Append($"<h1>{parahgrah}<h1>");
        }

        public void AddTitle(string title)
        {
            _html.Append($"<h1>{title}<h1>");
        }

        public IDocument Build()
        {
            return new Html(this._html.ToString()); 
        }
    }
}

