using System;
using System.Collections.Generic;

namespace RoverPlayXamarin
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to game, playing with Rover on Mars!");
			Console.WriteLine ("We are using default grid in size 100x100 and your Rover's name is Max.");
			Console.WriteLine ("The Mars has two obstacles one on 1,2 position and second on 12,10 position, be aware of them!");
			Console.WriteLine ();
			Console.WriteLine ("Please write position action in format(F - forward, B - backward, L - turn left, R - turn right), finish with command Q.");
			Console.WriteLine ("Also you can define target position by T(x,y) and receive commands' steps.");

			List<Tuple<uint, uint>> obstacles = new System.Collections.Generic.List<Tuple<uint, uint>> ();
			obstacles.Add (new Tuple<uint, uint> (1, 2));
			obstacles.Add (new Tuple<uint, uint> (12, 10));

			var mars = new Mars (new Tuple<uint, uint> (100, 100), obstacles);
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
						var hit = false;
						var steps = rover.MoveToPosition (result, out hit);
						if (hit) {
							Console.WriteLine ("Rover hits obstacle after steps: " + steps);
							Console.WriteLine ("New position of your rover is : " + rover.ToString ());
						} else {
							Console.WriteLine ("Expecting rover's steps: " + steps);
							Console.WriteLine ("New position of your rover is : " + rover.ToString ());
						}
					} else {
						Console.WriteLine ("Your target's command is invalid! Try again.");
					}
				}
				else if (commands.VerificationCommands ()) {
					int positionHit = 0;
					if (!rover.Commands (commands, out positionHit)) {
						Console.WriteLine ("Rover hits obstacle on position " + positionHit);
					}

					Console.WriteLine ("New position of your rover is : " + rover.ToString ());

				} else {
					Console.WriteLine ("Your commands are invalid! Try again.");
				}

				Console.WriteLine ("New commands ?");
			}
				
			Console.ReadLine ();

		}
	}
}
