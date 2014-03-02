using System;

namespace RoverPlayXamarin
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to game, playing with Rover on Mars!");
			Console.WriteLine ("We are using default grid in size 100x100 and your Rover's name is Max.");
			Console.WriteLine ();
			Console.WriteLine ("Please write position action in format(F - forward, B - backward, L - turn left, R - turn right), finish with command Q.");
			Console.WriteLine ("Also you can define target position by T(x,y) and receive commands' steps.");

			var mars = new Mars (new Tuple<uint, uint> (100, 100));
			var rover = new Rover ("Max", mars);

			while (true) {

				var commands = Console.ReadLine ().Trim ().ToUpper ();
				if (commands == "Q") {
					Console.WriteLine ("Quiting ... ");
					break;
				}

				if (commands.StartsWith ("T")) {
					Tuple<uint,uint> result = new Tuple<uint, uint> (0, 0);
					if (commands.ParseTarget (out result)) {
						var steps = rover.MoveToPosition (result);
						Console.WriteLine ("Expecting rover's steps: " + steps);
						Console.WriteLine ("New position of your rover is : " + rover.ToString ());
					} else {
						Console.WriteLine ("Your target's command is invalid! Try again.");
						continue;
					}
				}

				if (commands.VerificationCommands ()) {
					rover.Commands (commands);
					Console.WriteLine ("New position of your rover is : " + rover.ToString ());

				} else {
					Console.WriteLine ("Your commands are invalid! Try again.");
					continue;
				}

				Console.WriteLine ("New commands ?");
			}
				
			Console.ReadLine ();

		}
	}
}
