using System;

namespace addressbook_tests_white
{
	public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
	{
		public string Name {get; set;}

		public int CompareTo(GroupData other)
		{
			if (Object.ReferenceEquals(other, null))
			{
				return 1;
			}
			return Name.CompareTo(other.Name);
		}

		public bool Equals(GroupData other)
		{
			if (Object.ReferenceEquals(other, null))
			{
				return false;
			}
			if (Object.ReferenceEquals(this, other))
			{
				return true;
			}
			return this.Name.Equals(other.Name);
		}
	}
}
