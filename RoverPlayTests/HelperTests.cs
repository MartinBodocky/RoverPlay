using NUnit.Framework;
using System;
using RoverPlayXamarin;

namespace RoverPlayTests
{
	[TestFixture]
	public class HelperTests
	{
		[Test]
		public void VerificationCommandTest ()
		{
			string input = "LRLLRFBBBF";
			var result = input.VerificationCommands ();
			var expected = true;
			Assert.AreEqual (expected, result);
		}

		[Test]
		public void VerificationCommandTest2 ()
		{
			string input = "LrlLRFbbbBBF";
			var result = input.VerificationCommands ();
			var expected = true;
			Assert.AreEqual (expected, result);
		}

		[Test]
		public void VerificationCommandTest3()
		{
			string input = "RFFLFF";
			var result = input.VerificationCommands ();
			var expected = true;
			Assert.AreEqual (expected, result);
		}

		[Test]
		public void VerificationCommandWrongTest()
		{
			string input = "LUK";
			var result = input.VerificationCommands ();
			var expected = false;
			Assert.AreEqual (expected, result);
		}

		[Test]
		public void ParseTarget1()
		{
			string input ="T(12,3)";
			Tuple<uint, uint> result = new Tuple<uint, uint> (0, 0);
			var ret = input.ParseTarget (out result);
			Assert.AreEqual (true, ret);
			Assert.AreEqual (new Tuple<uint, uint> (12, 3), result);
		}

		[Test]
		public void ParseTarget2()
		{
			string input ="T(1233,344)";
			Tuple<uint, uint> result = new Tuple<uint, uint> (0, 0);
			var ret = input.ParseTarget (out result);
			Assert.AreEqual (true, ret);
			Assert.AreEqual (new Tuple<uint, uint> (1233, 344), result);
		}

		[Test]
		public void ParseTarget3()
		{
			string input ="T(12a,3)";
			Tuple<uint, uint> result = new Tuple<uint, uint> (0, 0);
			var ret = input.ParseTarget (out result);
			Assert.AreEqual (false, ret);
		}

		[Test]
		public void ParseTarget4()
		{
			string input ="T(12.12,3)";
			Tuple<uint, uint> result = new Tuple<uint, uint> (0, 0);
			var ret = input.ParseTarget (out result);
			Assert.AreEqual (false, ret);
		}

		[Test]
		public void ParseTarget5()
		{
			string input ="T(12,-3)";
			Tuple<uint, uint> result = new Tuple<uint, uint> (0, 0);
			var ret = input.ParseTarget (out result);
			Assert.AreEqual (false, ret);
		}

		[Test]
		public void PositionOnMars1()
		{
			var _mars = new Mars (new Tuple<uint, uint> (100, 100));
			var result = _mars.Size.PositionOnMars (new Tuple<int, int> (100, 101));
			var expected = new Tuple<uint, uint> (100, 0);
			Assert.AreEqual (expected, result);
		}

		[Test]
		public void PositionOnMars2()
		{
			var _mars = new Mars (new Tuple<uint, uint> (100, 100));
			var result = _mars.Size.PositionOnMars (new Tuple<int, int> (100, -1));
			var expected = new Tuple<uint, uint> (100, 100);
			Assert.AreEqual (expected, result);
		}
	}
}

