using System;

namespace RoverPlayXamarin
{
	/// <summary>
	/// Object represents Mars
	/// </summary>
	public class Mars
	{
		/// <summary>
		/// Intialize Mars by size of its grid, it cannot have negative points
		/// </summary>
		/// <param name="size">Size.</param>
		public Mars (Tuple<uint, uint> size)
		{
			this.Size = size;
		}

		/// <summary>
		/// Size of the grid
		/// </summary>
		/// <value>The size.</value>
		public Tuple<uint, uint> Size {
			get;
			private set;
		}
	}
}

