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

		/// <summary>
		/// Initialize rover with given position and facing
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="position">Position.</param>
		/// <param name="facing">Facing.</param>
		public Rover (string name, Tuple<int, int> position, Facing facing)
			: this (name)
		{
			this.Position = position;
			this.Facing = facing;
		}

		/// <summary>
		/// Turn rover in right direction.
		/// </summary>
		public void TurnRight ()
		{
			if (this.Facing == Facing.West)
				this.Facing = Facing.North;
			else
				this.Facing++;
		}

		/// <summary>
		/// Turn rover in left direction
		/// </summary>
		public void TurnLeft ()
		{
			if (this.Facing == Facing.North)
				this.Facing = Facing.West;
			else
				this.Facing--;
		}

		public override string ToString ()
		{
			return string.Format ("[Rover: Facing={0}, Name={1}, Position={2}]", Facing, Name, Position);
		}

		/// <summary>
		/// Rover move forward
		/// </summary>
		public void MoveForward ()
		{
			switch (this.Facing) {

			case Facing.East:
				this.Position = this.Position.UpdateTupleValue (1, 0);
				break;
			case Facing.South:
				this.Position = this.Position.UpdateTupleValue (0, -1);
				break;
			case Facing.North:
				this.Position = this.Position.UpdateTupleValue (0, 1);
				break;
			case Facing.West:
				this.Position = this.Position.UpdateTupleValue (-1, 0);
				break;
			}
		}

		/// <summary>
		/// Rover moves the backward.
		/// </summary>
		public void MoveBackward()
		{
			switch (this.Facing) {

			case Facing.East:
				this.Position = this.Position.UpdateTupleValue (-1, 0);
				break;
			case Facing.West:
				this.Position = this.Position.UpdateTupleValue (1, 0);
				break;
			case Facing.North:
				this.Position = this.Position.UpdateTupleValue (0, -1);
				break;
			case Facing.South:
				this.Position = this.Position.UpdateTupleValue (1, 0);
				break;

			}
		}
	}
}

