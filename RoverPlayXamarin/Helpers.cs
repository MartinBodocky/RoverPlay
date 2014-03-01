using System;

namespace RoverPlayXamarin
{
	public static class Helpers
	{
		public static Tuple<int,int> UpdateTupleValue (this Tuple<int,int> tuple, int value1, int value2)
		{
			return new Tuple<int, int> (tuple.Item1 + value1, tuple.Item2 + value2);
		}
	}
}

