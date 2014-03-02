using System;
using System.Collections;
using System.Collections.Generic;

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
			this.Obstacles = new List<Tuple<uint, uint>> ();
		}

		/// <summary>
		/// Initialize Mars as grid and list of obstacles on this grid
		/// </summary>
		/// <param name="size">Size.</param>
		/// <param name="obstacles">Obstacles.</param>
		public Mars(Tuple<uint, uint> size, List<Tuple<uint, uint>> obstacles)
			:this( size)
		{
			this.Obstacles = obstacles;
		}

		/// <summary>
		/// Size of the grid
		/// </summary>
		/// <value>The size.</value>
		public Tuple<uint, uint> Size {
			get;
			private set;
		}

		/// <summary>
		/// List of obstacles on Mars
		/// </summary>
		/// <value>The obstacles.</value>
		public List<Tuple<uint,uint>> Obstacles {
			get;
			private set;
		}
	}
}

