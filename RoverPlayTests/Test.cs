using NUnit.Framework;
using System;
using RoverPlayXamarin;

namespace RoverPlayTests
{
	[TestFixture ()]
	public class RoverTests
	{
		[Test]
		public void InitRover ()
		{
			var _rover = new Rover ("TestRover");
			Assert.AreEqual (Facing.North, _rover.Facing);
			Assert.AreEqual (new Tuple<int, int> (0, 0), _rover.Position);
		}

		[Test]
		public void InitRoverWithPosition()
		{
			var _rover = new Rover ("TestRover", new Tuple<int,int> (1, 5), Facing.South);
			Assert.AreEqual (new Tuple<int, int> (1, 5), _rover.Position);
			Assert.AreEqual (Facing.South, _rover.Facing);
		}

		[Test]
		public void RoverTurningLeft()
		{
			var _rover = new Rover ("TestRover");
			_rover.TurnLeft ();
			Assert.AreEqual (Facing.West, _rover.Facing);
			_rover.TurnLeft ();
			Assert.AreEqual (Facing.South, _rover.Facing);
		}

		[Test]
		public void RoverTurningRight()
		{
			var _rover = new Rover ("TestRover");
			_rover.TurnRight ();
			Assert.AreEqual (Facing.East, _rover.Facing);
			_rover.TurnRight ();
			Assert.AreEqual (Facing.South, _rover.Facing);
		}

		[Test]
		public void RoverMovingForward()
		{
			var _rover = new Rover ("TestRover");
			_rover.MoveForward ();
			_rover.MoveForward ();
			Assert.AreEqual (new Tuple<int,int> (0, 2), _rover.Position);
			Assert.AreEqual (Facing.North, _rover.Facing);
		}

		[Test]
		public void RoverMovingBackward()
		{
			var _rover = new Rover ("TestRover");
			_rover.MoveBackward ();
			Assert.AreEqual (new Tuple<int,int> (0, -1), _rover.Position);
			Assert.AreEqual (Facing.North, _rover.Facing);
		}
	}
}

