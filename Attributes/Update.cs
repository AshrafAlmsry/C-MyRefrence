namespace Attributes
{
	class Update
	{
		public Update(int no, string title)
		{
			this.no = no;
			this.title = title;
		}

		public int no;
		public string title;

		public override string ToString()
		{
			return $"{no} - {title}";
		}

	}
}