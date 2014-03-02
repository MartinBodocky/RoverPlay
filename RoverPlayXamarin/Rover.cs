using System;
using System.Linq;

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
		/// Mars grid
		/// </summary>
		/// <value>The mars.</value>
		public Mars Mars {
			get;
			private set;
		}

		/// <summary>
		/// Initialize our rover
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="mars">Mars</param> 
		public Rover (string name, Mars mars)
		{
			this.Mars = mars;
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
		/// <param name="mars">Mars</param> 
		public Rover (string name, Mars mars, Tuple<int, int> position, Facing facing)
			: this (name, mars)
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
			return string.Format ("{0},{1},{2}", Position.Item1, Position.Item2, Facing.ToString().Substring(0,1));
		}

		/// <summary>
		/// Rover move forward
		/// </summary>
		public bool MoveForward ()
		{
			var updatedPosition = new Tuple<int, int> (0, 0);

			switch (this.Facing) {

			case Facing.East:
				updatedPosition = this.Position.UpdateTupleValue (1, 0);
				if (this.Mars.Size.AcceptedOnMars(updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				} else
					return false;

			case Facing.South:
				updatedPosition = this.Position.UpdateTupleValue (0, -1);
				if (this.Mars.Size.AcceptedOnMars(updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				} else
					return false;

			case Facing.North:
				updatedPosition = this.Position.UpdateTupleValue (0, 1);
				if (this.Mars.Size.AcceptedOnMars(updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				} else
					return false;

			case Facing.West:
				updatedPosition = this.Position.UpdateTupleValue (-1, 0);
				if (this.Mars.Size.AcceptedOnMars(updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				} else
					return false;

			}
			throw new ArgumentOutOfRangeException ("We are defining wrong facing direction...");
		}

		/// <summary>
		/// Rover moves the backward.
		/// </summary>
		public bool MoveBackward()
		{
			var updatedPosition = new Tuple<int, int> (0, 0);

			switch (this.Facing) {

			case Facing.East:
				updatedPosition = this.Position.UpdateTupleValue (-1, 0);
				if (this.Mars.Size.AcceptedOnMars(updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				} else
					return false;
					
			case Facing.West:
				updatedPosition = this.Position.UpdateTupleValue (1, 0);
				if (this.Mars.Size.AcceptedOnMars(updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				} else
					return false;

			case Facing.North:
				updatedPosition = this.Position.UpdateTupleValue (0, -1);
				if (this.Mars.Size.AcceptedOnMars(updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				} else
					return false;
					
			case Facing.South:
				updatedPosition = this.Position.UpdateTupleValue (0, 1);
				if (this.Mars.Size.AcceptedOnMars(updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				} else
					return false;
			}

			throw new ArgumentOutOfRangeException ("We are defining wrong facing direction...");
		}

		/// <summary>
		/// Executed commands from stream
		/// </summary>
		/// <param name="input">Input.</param>
		public void Commands(string input)
		{
			char[] cmds = input.ToCharArray ();
			for (int i = 0; i < cmds.Length; i++) {
				switch (cmds [i]) {
				case 'L':
					this.TurnLeft ();
					break;
				case 'R':
					this.TurnRight ();
					break;
				case 'F':
					this.MoveForward ();
					break;
				case 'B':
					this.MoveBackward ();
					break;
				}
			}
		}
	}
}

