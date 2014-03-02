using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using RoverPlayXamarin;

namespace RoverPlayTests
{
	[TestFixture]
	public class DiscoverMarsTests2
	{
		[Test]
		public void DiscoveringWithNoHit ()
		{
			List<Tuple<uint, uint>> obstacles = new System.Collections.Generic.List<Tuple<uint, uint>> ();
			obstacles.Add (new Tuple<uint, uint> (10, 10));
			var _mars = new Mars (new Tuple<uint,uint> (100, 100), obstacles);
			var _rover = new Rover ("Max", _mars);
			var hit = false;
			var steps = _rover.MoveToPosition (new Tuple<uint, uint> (9, 10), out hit);
			var expected = "FFFFFFFFFFLLLFFFFFFFFF";
			Assert.AreEqual (expected, steps);
		}

		[Test]
		public void DiscoveringWithHit1 ()
		{
			List<Tuple<uint, uint>> obstacles = new System.Collections.Generic.List<Tuple<uint, uint>> ();
			obstacles.Add (new Tuple<uint, uint> (0, 1));
			var _mars = new Mars (new Tuple<uint,uint> (100, 100), obstacles);
			var _rover = new Rover ("Max", _mars);
			var flag = _rover.MoveForward ();
			Assert.AreEqual (false, flag);
			Assert.AreEqual (new Tuple<uint,uint>(0,0), _rover.Position);
		}


		[Test]
		public void DiscoveringWithHit2 ()
		{
			List<Tuple<uint, uint>> obstacles = new System.Collections.Generic.List<Tuple<uint, uint>> ();
			obstacles.Add (new Tuple<uint, uint> (0, 6));
			var _mars = new Mars (new Tuple<uint,uint> (100, 100), obstacles);
			var _rover = new Rover ("Max", _mars);
			var hit = false;
			var steps = _rover.MoveToPosition (new Tuple<uint, uint> (0, 8), out hit);
			var expectedSteps = "FFFFF";
			Assert.AreEqual (true, hit);
			Assert.AreEqual (expectedSteps, steps);
			Assert.AreEqual (new Tuple<uint, uint> (0, 5), _rover.Position);
		}

		[Test]
		public void DiscoveringWithHit3 ()
		{
			List<Tuple<uint, uint>> obstacles = new System.Collections.Generic.List<Tuple<uint, uint>> ();
			obstacles.Add (new Tuple<uint, uint> (0, 6));
			var _mars = new Mars (new Tuple<uint,uint> (100, 100), obstacles);
			var _rover = new Rover ("Max", _mars);
			var positionHit = 0;
			var flag = _rover.Commands ("FFFFFFFFF", out positionHit);
			var expectedPosition = 6;
			Assert.AreEqual (false, flag);
			Assert.AreEqual (expectedPosition, positionHit);
			Assert.AreEqual (new Tuple<uint, uint> (0, 5), _rover.Position);
		}

	}
}

