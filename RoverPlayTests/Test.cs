using NUnit.Framework;
using System;
using RoverPlayXamarin;

namespace RoverPlayTests
{
	[TestFixture ()]
	public class RoverTests
	{
		private Rover _rover;

		public RoverTests()
		{
			_rover = new Rover ("TestRover");
		}

		[Test]
		public void InitRover ()
		{
			Assert.AreEqual (Facing.North, _rover.Facing);
			Assert.AreEqual (new Tuple<int, int> (0, 0), _rover.Position);
		}

		[Test]
		public void RoverTurning()
		{
			_rover = new Rover ("TestRover");
			_rover.TurnLeft ();
			Assert.AreEqual (Facing.West, _rover.Facing);
			_rover.TurnLeft ();
			Assert.AreEqual (Facing.South, _rover.Facing);
		}

		[Test]
		public void RoverTurning2()
		{
			_rover = new Rover ("TestRover");
			_rover.TurnRight ();
			Assert.AreEqual (Facing.East, _rover.Facing);
			_rover.TurnRight ();
			Assert.AreEqual (Facing.South, _rover.Facing);
		}
	}
}

