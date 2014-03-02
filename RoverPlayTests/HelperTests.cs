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
	}
}

