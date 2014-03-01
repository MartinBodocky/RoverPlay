using System;

namespace RoverPlayXamarin
{
	public enum Facing
	{
		North = 0,
		East = 1,
		South = 2,
		West = 3
	}

	public class Rover
	{
		/// <summary>
		/// Where rover is currently facing
		/// </summary>
		/// <value>The facing.</value>
		public Facing Facing {
			get;
			private set;
		}
		/// <summary>
		/// Name of rover
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get;
			private set;
		}
		/// <summary>
		/// Current position
		/// </summary>
		/// <value>The position.</value>
		public Tuple<int, int> Position {
			get;
			private set;
		}
			
		/// <summary>
		/// Initialize our rover
		/// </summary>
		/// <param name="name">Name.</param>
		public Rover (string name)
		{
			this.Name = name;
			this.Position = new Tuple<int, int> (0, 0);
			this.Facing = Facing.North;
		}
	}
}

