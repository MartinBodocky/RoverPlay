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
		public static Tuple<int,int> UpdateTupleValue (this Tuple<int,int> tuple, int value1, int value2)
		{
			return new Tuple<int, int> (tuple.Item1 + value1, tuple.Item2 + value2);
		}

		/// <summary>
		/// Verification whether new position is on Mars or not
		/// </summary>
		/// <returns><c>true</c>, if on mars was accepteded, <c>false</c> otherwise.</returns>
		/// <param name="mars">Mars.</param>
		/// <param name="newPosition">New position.</param>
		public static bool AcceptedOnMars(this Tuple<uint, uint> mars, Tuple<int,int> newPosition)
		{
			if (mars.Item1 >= newPosition.Item1
			    && mars.Item2 >= newPosition.Item2
			    && newPosition.Item1 >= 0
			    && newPosition.Item2 >= 0)
				return true;
			else
				return false;
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
	}
}

