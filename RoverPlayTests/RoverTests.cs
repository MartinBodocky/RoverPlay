using NUnit.Framework;
using System;
using RoverPlayXamarin;

namespace RoverPlayTests
{
	[TestFixture]
	public class RoverTests
	{
		private Mars _mars = new Mars (new Tuple<uint, uint> (100, 100));

		[Test]
		public void InitRover ()
		{
			var _rover = new Rover ("TestRover", _mars);
			Assert.AreEqual (Facing.North, _rover.Facing);
			Assert.AreEqual (new Tuple<uint, uint> (0, 0), _rover.Position);
		}

		[Test]
		public void InitRoverWithPosition ()
		{
			var _rover = new Rover ("TestRover", _mars, new Tuple<uint,uint> (1, 5), Facing.South);
			Assert.AreEqual (new Tuple<uint, uint> (1, 5), _rover.Position);
			Assert.AreEqual (Facing.South, _rover.Facing);
		}

		[Test]
		public void RoverTurningLeft ()
		{
			var _rover = new Rover ("TestRover", _mars);
			_rover.TurnLeft ();
			Assert.AreEqual (Facing.West, _rover.Facing);
			_rover.TurnLeft ();
			Assert.AreEqual (Facing.South, _rover.Facing);
		}

		[Test]
		public void RoverTurningRight ()
		{
			var _rover = new Rover ("TestRover", _mars);
			_rover.TurnRight ();
			Assert.AreEqual (Facing.East, _rover.Facing);
			_rover.TurnRight ();
			Assert.AreEqual (Facing.South, _rover.Facing);
		}

		[Test]
		public void RoverMovingForward ()
		{
			var _rover = new Rover ("TestRover", _mars);
			_rover.MoveForward ();
			_rover.MoveForward ();
			Assert.AreEqual (new Tuple<uint,uint> (0, 2), _rover.Position);
			Assert.AreEqual (Facing.North, _rover.Facing);
		}

		[Test]
		public void RoverMovingBackward ()
		{
			var _rover = new Rover ("TestRover", _mars);
			_rover.MoveBackward ();
			Assert.AreEqual (new Tuple<uint,uint> (0, 100), _rover.Position);
			Assert.AreEqual (Facing.North, _rover.Facing);
		}

		[Test]
		public void RoverMovingForwardUntilEnd ()
		{
			var _rover = new Rover ("TestRover", _mars);
			while (_rover.Position.Item2 != 100) {
				_rover.MoveForward ();
			}
			Assert.AreEqual (new Tuple<uint,uint> (0, 100), _rover.Position);
		}

		[Test]
		public void RoverMovingToOppositeCorner ()
		{
			var _rover = new Rover ("TestRover", _mars);
			while (_rover.Position.Item2 != 100) {
				_rover.MoveForward ();
			}
			Assert.AreEqual (new Tuple<uint,uint> (0, 100), _rover.Position);
			_rover.TurnRight ();
			Assert.AreEqual (Facing.East, _rover.Facing);
			while (_rover.Position.Item1 != 100) {
				_rover.MoveForward ();
			}
			Assert.AreEqual (new Tuple<uint, uint> (100, 100), _rover.Position);
		}

		[Test]
		public void RoverMovingInMiddleAndBack ()
		{
			var _rover = new Rover ("TestRover", _mars);

			_rover.TurnRight ();
			Assert.AreEqual (Facing.East, _rover.Facing);

			while (_rover.Position.Item1 != 50) {
				_rover.MoveForward ();
			}
			Assert.AreEqual (new Tuple<uint,uint> (50, 0), _rover.Position);

			_rover.TurnLeft ();
			Assert.AreEqual (Facing.North, _rover.Facing);

			while (_rover.Position.Item2 != 50) {
				_rover.MoveForward ();
			}
			Assert.AreEqual (new Tuple<uint, uint> (50, 50), _rover.Position);

			//now we are going to backward back to left boardline
			_rover.TurnRight ();
			Assert.AreEqual (Facing.East, _rover.Facing);

			while (_rover.Position.Item1 != 0) {
				_rover.MoveBackward ();
			}
			Assert.AreEqual (new Tuple<uint, uint> (0, 50), _rover.Position);

			_rover.TurnRight ();
			Assert.AreEqual (Facing.South, _rover.Facing);

			while (_rover.Position.Item2 != 0) {
				_rover.MoveForward ();
			}
			Assert.AreEqual (new Tuple<uint, uint> (0, 0), _rover.Position);
		}

		[Test]
		public void RoverRepresentation ()
		{
			var _rover = new Rover ("Max", _mars);
			Assert.AreEqual ("0,0,N", _rover.ToString ());
			_rover.MoveForward ();
			Assert.AreEqual ("0,1,N", _rover.ToString ());
			_rover.TurnLeft ();
			Assert.AreEqual ("0,1,W", _rover.ToString ());
		}

		[Test]
		public void RoverCommands ()
		{
			var _rover = new Rover ("Max", _mars);
			var positionHit = 0;
			_rover.Commands ("FFRFRF", out positionHit);
			Assert.AreEqual (new Tuple<uint, uint> (1, 1), _rover.Position);
		}
	}
}

