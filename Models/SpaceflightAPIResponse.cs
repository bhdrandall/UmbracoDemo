namespace UmbracoDemo.Models
{
	public class SpaceflightApiResponse
	{
		public int Count { get; set; }
		public string Next { get; set; }
		public string Previous { get; set; }
		public List<Article> Results { get; set; }
	}

	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public List<Author> Authors { get; set; }
		public string Url { get; set; }
		public string ImageUrl { get; set; }
		public string NewsSite { get; set; }
		public string Summary { get; set; }
		public DateTime PublishedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool Featured { get; set; }
		public List<object> Launches { get; set; }
		public List<object> Events { get; set; }
	}

	public class Author
	{
		public string Name { get; set; }
		public object Socials { get; set; }
	}
}
