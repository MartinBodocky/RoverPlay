using System;

namespace RoverPlayXamarin
{
	public static class Helpers
	{
		/// <summary>
		/// Create a new tuple with updated values
		/// </summary>
		/// <returns>The tuple value.</returns>
		/// <param name="tuple">Tuple.</param>
		/// <param name="value1">Value1.</param>
		/// <param name="value2">Value2.</param>
		public static Tuple<int,int> UpdateTupleValue (this Tuple<uint,uint> tuple, int value1, int value2)
		{
			return new Tuple<int, int> ( (int)tuple.Item1 + value1, (int)tuple.Item2 + value2);
		}

		/// <summary>
		/// Create position on Mars, because Mars is sphere
		/// </summary>
		/// <returns>The on mars.</returns>
		/// <param name="mars">Mars.</param>
		/// <param name="newPoistion">New poistion.</param>
		public static Tuple<uint, uint> PositionOnMars(this Tuple<uint, uint> mars, Tuple<int,int> newPoistion)
		{
			uint item1, item2;

			if (newPoistion.Item1 < 0)
				item1 = mars.Item1;
			else if (mars.Item1 >= newPoistion.Item1)
				item1 = (uint)newPoistion.Item1;
			else
				item1 = 0;

			if (newPoistion.Item2 < 0)
				item2 = mars.Item2;
			else if (mars.Item2 >= newPoistion.Item2)
				item2 = (uint)newPoistion.Item2;
			else
				item2 = 0;

			return new Tuple<uint, uint> (item1, item2);
		}

		/// <summary>
		/// We need to verify user input
		/// </summary>
		/// <param name="input">Input.</param>
		public static bool VerificationCommands(this string input)
		{
			input = input.ToUpper ();
			var invalidInput = input.Replace ("L", "").Replace ("R", "").Replace ("F", "").Replace ("B", "");
			if (invalidInput.Length > 0)
				return false;
			else
				return true;
		}

		/// <summary>
		/// Parse user input about target
		/// </summary>
		/// <returns>The target.</returns>
		/// <param name="input">Input.</param>
		public static bool ParseTarget(this string input, out Tuple<uint, uint> result)
		{
			result = new Tuple<uint,uint> (0, 0);
			if (input.StartsWith ("T(")) {
				var index1 = input.IndexOf ('(');
				var index2 = input.IndexOf (',');
				if (index2 == -1 || index1 == -1)
					return false;
				string Xstr = input.Substring (index1+1, index2 - index1-1);
				uint X = 0;
				if (!uint.TryParse (Xstr, out X))
					return false;
				var index3 = input.IndexOf (')');
				if (index3 == -1)
					return false;
				string Ystr = input.Substring (index2+1, index3 - index2-1);
				uint Y = 0;
				if (!uint.TryParse (Ystr,out  Y))
					return false;

				result = new Tuple<uint, uint> (X, Y);
				return true;

			} else
				return false;
		}
	}
}

