using System;
namespace Builder.Domain
{
	public interface IDocument
	{
		///void Read();
	}

	public class Pdf : IDocument
	{
        private readonly string _html;

        public Pdf(string html)
        {
            _html = html;
        }
    }

	public class Html : IDocument
	{
		private readonly string _html;

        public Html(string html)
        {
            _html = html;
        }
    }


}

