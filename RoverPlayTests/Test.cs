using NUnit.Framework;
using System;
using RoverPlayXamarin;

namespace RoverPlayTests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var comp = new Computation ();
			var result = comp.GetRandomNumber (12);
			var expected ="12";
			Assert.AreEqual (expected, result);
		}
	}
}

