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

		[Test ()]
		public void InitRover ()
		{
			Assert.AreEqual (Facing.North, _rover.Facing);
			Assert.AreEqual (new Tuple<int, int> (0, 0), _rover.Position);
		}
	}
}

