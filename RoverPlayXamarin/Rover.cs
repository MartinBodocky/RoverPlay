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
		public Tuple<uint, uint> Position {
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
			this.Position = new Tuple<uint, uint> (0, 0);
			this.Facing = Facing.North;
		}

		/// <summary>
		/// Initialize rover with given position and facing
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="position">Position.</param>
		/// <param name="facing">Facing.</param>
		/// <param name="mars">Mars</param> 
		public Rover (string name, Mars mars, Tuple<uint, uint> position, Facing facing)
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
			return string.Format ("{0},{1},{2}", Position.Item1, Position.Item2, Facing.ToString ().Substring (0, 1));
		}

		/// <summary>
		/// Rover move forward
		/// </summary>
		public bool MoveForward ()
		{
			var updatedPosition = new Tuple<uint, uint> (0, 0);

			switch (this.Facing) {

			case Facing.East:
				updatedPosition = this.Mars.Size.PositionOnMars (this.Position.UpdateTupleValue (1, 0));
				if (!Mars.Obstacles.Contains (updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				}
				else
					return false;

			case Facing.South:
				updatedPosition = this.Mars.Size.PositionOnMars (this.Position.UpdateTupleValue (0, -1));
				if (!Mars.Obstacles.Contains (updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				}
				else
					return false;

			case Facing.North:
				updatedPosition = this.Mars.Size.PositionOnMars (this.Position.UpdateTupleValue (0, 1));
				if (!Mars.Obstacles.Contains (updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				}
				else
					return false;

			case Facing.West:
				updatedPosition = this.Mars.Size.PositionOnMars (this.Position.UpdateTupleValue (-1, 0));
				if (!Mars.Obstacles.Contains (updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				}
				else
					return false;
			}

			throw new ArgumentOutOfRangeException ("We cannot recognise this facing direction ...");
		}

		/// <summary>
		/// Rover moves the backward.
		/// </summary>
		public bool MoveBackward ()
		{
			var updatedPosition = new Tuple<uint, uint> (0, 0);

			switch (this.Facing) {

			case Facing.East:
				updatedPosition = this.Mars.Size.PositionOnMars (this.Position.UpdateTupleValue (-1, 0));
				if (!Mars.Obstacles.Contains (updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				}
				else
					return false;

			case Facing.West:
				updatedPosition = this.Mars.Size.PositionOnMars (this.Position.UpdateTupleValue (1, 0));
				if (!Mars.Obstacles.Contains (updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				}
				else
					return false;

			case Facing.North:
				updatedPosition = this.Mars.Size.PositionOnMars (this.Position.UpdateTupleValue (0, -1));
				if (!Mars.Obstacles.Contains (updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				}
				else
					return false;

			case Facing.South:
				updatedPosition = this.Mars.Size.PositionOnMars (this.Position.UpdateTupleValue (0, 1));
				if (!Mars.Obstacles.Contains (updatedPosition)) {
					this.Position = updatedPosition;
					return true;
				}
				else
					return false;
			}

			throw new ArgumentOutOfRangeException ("We cannot recognise this facing direction ...");
		}

		/// <summary>
		/// Executed commands from stream
		/// </summary>
		/// <param name="input">Input.</param>
		public bool Commands (string input, out int positionHit)
		{
			positionHit = 0;
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
					if (!this.MoveForward ()) {
						positionHit = i+1;
						return false;
					}
					break;
				case 'B':
					if (!this.MoveBackward ()) {
						positionHit = i + 1;
						return false;
					}
					break;
				}
			}
			return true;
		}

		/// <summary>
		/// Function moves with rover to target position
		/// </summary>
		/// <returns>The to position.</returns>
		/// <param name="target">Target.</param>
		public string MoveToPosition (Tuple<uint, uint> target, out bool hit)
		{
			string steps = "";
			// we need to fit our target position into Mars grid
			target = new Tuple<uint, uint> (target.Item1 % Mars.Size.Item1, target.Item2 % Mars.Size.Item2);
			hit = false;

			// first move to the same horizontal level
			if (target.Item2 >= this.Position.Item2) {
				// target is higher, we need to face to north
				while (this.Facing != Facing.North) {
					steps += "L";
					this.TurnLeft ();
				}
				// go to the same horizontal level
				while (this.Position.Item2 != target.Item2) {
					if (!this.MoveForward ()) {
						hit = true;
						return steps;
					}
					steps += "F";
				}
			} else {
				// target is lower, we need to face to south
				while (this.Facing != Facing.South) {
					steps += "L";
					this.TurnLeft ();
				}
				// go to the same horizontal level
				while (this.Position.Item2 != target.Item2) {
					if (!this.MoveForward ()) {
						hit = true;
						return steps;
					}
					steps += "F";
				}
			}

			//now we are the same horizontal level, 
			//we need to face to right direction are reach target
			if (target.Item1 >= this.Position.Item1) {
				// we need to face east
				while (this.Facing != Facing.East) {
					steps += "L";
					this.TurnLeft ();
				}
				// reach target
				while (this.Position.Item1 != target.Item1) {
					if (!this.MoveForward ()) {
						hit = true;
						return steps;
					}
					steps += "F";
				}
			} else {
				// we need to face west
				while (this.Facing != Facing.West) {
					steps += "L";
					this.TurnLeft ();
				}
				// reach target
				while (this.Position.Item1 != target.Item1) {
					if (!this.MoveForward ()) {
						hit = true;
						return steps;
					}
					steps += "F";
				}
			}

			return steps;
		}
	}
}

