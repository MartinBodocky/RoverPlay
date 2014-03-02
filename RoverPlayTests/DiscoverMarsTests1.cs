using NUnit.Framework;
using System;
using RoverPlayXamarin;

namespace RoverPlayTests
{
	[TestFixture ()]
	public class DiscoverMarsTests1
	{
		private Mars _mars = new Mars(new Tuple<uint, uint>(100,100));

		[Test ()]
		public void MoveToTarget1 ()
		{
			var _rover = new Rover ("Max", _mars);
			var steps = _rover.MoveToPosition (new Tuple<uint, uint> (2, 2));
			var expected = "FFLLLFF";
			Assert.AreEqual (expected, steps);
		}

		[Test ()]
		public void MoveToTarget2 ()
		{
			var _rover = new Rover ("Max", _mars, new Tuple<int, int>(0,0),Facing.South);
			var steps = _rover.MoveToPosition (new Tuple<uint, uint> (2, 2));
			var expected = "LLFFLLLFF";
			Assert.AreEqual (expected, steps);
			Assert.AreEqual (new Tuple<int,int>(2,2), _rover.Position);
		}

		[Test ()]
		public void MoveToTarget3 ()
		{
			var _rover = new Rover ("Max", _mars, new Tuple<int, int>(10,0),Facing.South);
			var steps = _rover.MoveToPosition (new Tuple<uint, uint> (5, 5));
			var expected = "LLFFFFFLFFFFF";
			Assert.AreEqual (expected, steps);
			Assert.AreEqual (new Tuple<int,int>(5,5), _rover.Position);
		}

		[Test ()]
		public void MoveToTarget4 ()
		{
			var _rover = new Rover ("Max", _mars, new Tuple<int, int>(10,10),Facing.North);
			var steps = _rover.MoveToPosition (new Tuple<uint, uint> (5, 5));
			var expected = "LLFFFFFLLLFFFFF";
			Assert.AreEqual (expected, steps);
			Assert.AreEqual (new Tuple<int,int>(5,5), _rover.Position);
		}
	}
}

