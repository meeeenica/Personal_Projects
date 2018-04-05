using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG8145_Assignment4
{
    class Program
    {
        public static List<int> NxtOptionRooms = new List<int>();
        public static List<int> MoveRooms = new List<int>();
        public static int intArrows = 3;
        public static bool gameOver = false;
        public static char chrAction;
        public static int UserRooms, UserPits, UserSpider, SelRoom;
        public static string strAns = "";
        public static int SetRoomSel = 0;

        static void Main(string[] args)
        {
            while (gameOver != true)
            {
                ///User gets to play the wumpus game.
                int userRooms;
                Console.Write("How many rooms would you like to play? 10 or 25?  \n[Enter number of rooms]: ");
                int.TryParse(Console.ReadLine(), out userRooms);
                while (userRooms != 10 && userRooms != 25)
                {
                    Console.Write("\nIncorrect number of rooms. \nWould you like to play 10 or 25 rooms? \n[Enter number of rooms]:");
                    int.TryParse(Console.ReadLine(), out userRooms);
                }
                Console.Clear();
                UserSetRoom(userRooms);
            }
            if (gameOver == true)
            {
                strAns = "";
                Console.Write("\nWanna Play Again? (Yes/No)");
                strAns = Console.ReadLine().ToUpper();
                while (strAns.ToUpper() != "YES" && strAns.ToUpper() != "NO" && strAns.ToUpper() != "Y" && strAns.ToUpper() != "N")
                {
                    Console.WriteLine("Invalid input. \nWanna Play Again? (Yes/No)");
                    strAns = Console.ReadLine().ToUpper();
                }
                    if (strAns.ToUpper() == "YES" || strAns.ToUpper() == "Y")
                    {
                        Console.Clear();
                        gameOver = false;
                        intArrows = 3;
                        Main(null);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
            }
            Console.ReadKey();
        }

        public static void UserSetRoom(int SetRoomSel)
        {
            switch (SetRoomSel)
            {
                case 10:
                    Room.NumberOfRooms = 10;
                    Room.RoomNumbers = new int[10];
                    Room.RoomNumber = new int[10,4];
                    Room.RoomDescription = new string[10];
                    Room.loadMap("RoomDescriptions.txt");

                    RunWumpusGame();
                    break;
                case 25:
                    Room.NumberOfRooms = 25;
                    Room.RoomNumbers = new int[25];
                    Room.RoomNumber = new int[25, 4];
                    Room.RoomDescription = new string[25];
                    Room.loadMap("RoomDescriptions25.txt");

                    RunWumpusGame();
                    break;
                default:
                    Room.NumberOfRooms = 10;
                    Room.RoomNumbers = new int[10];
                    Room.RoomNumber = new int[10, 4];
                    Room.RoomDescription = new string[10];
                    Room.loadMap("RoomDescriptions.txt");

                    RunWumpusGame();
                    break;
            }
        }

        private static void RunWumpusGame()
        {
            intArrows = 3;
            Room.intCurRoom = 1;
            #region WumpusInitializeCommand
            Console.WriteLine("Welcome to Hunt the Wumpus!"
                + "\n\nThere are "+ Room.NumberOfRooms +" Rooms."
                + "\n You are in Room 1"
                + "\n You have 3 arrows left");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCAREFUL!");
            Console.ResetColor();
            Console.WriteLine("A wooden sign reads \"Beware of the Wumpus!\"");
            Room.SetRooms(2, Room.NumberOfRooms-1);
            //Console.WriteLine("Wumpus Room:" + Room.intWumpusRoom);
            //Console.WriteLine("Spider Room 1:" + Room.intSpiderRm1);
            //Console.WriteLine("Spider Room 2:" + Room.intSpiderRm2);
            //Console.WriteLine("Bottomless Pit:" + Room.intPit);
            //Console.WriteLine("Supply Room:" + Room.intSupplyRoom);
            //Console.WriteLine("Bat Room:" + Room.intBat);

            TheRooms("Initialize", Room.intCurRoom);
            //TheRooms("Special Room Check", null);
            while (gameOver == false)
            {
                try
                {
                    //Console.WriteLine("\nInside Main Method: " + chrAction);
                    if (ifBatMove == true)
                    {
                        MoveRoom(Room.intCurRoom);
                    }
                    else
                    {
                        while ((chrAction != 'S') && (chrAction != 'M'))
                        {
                            Console.WriteLine("\nYou entered an invalid action.");
                            TheRooms("Initialize", Room.intCurRoom);
                            TheRooms("Special Room Check", null);
                        }
                        if (chrAction == 'S')
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nWhich Room? ");
                            Console.ResetColor();
                            //SelRoom = int.Parse(Console.ReadLine());
                            while (!int.TryParse(Console.ReadLine(), out SelRoom))
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\nWhich Room? ");
                                Console.ResetColor();
                            }
                            RoomShoot(SelRoom);
                            //Console.WriteLine(gameOver);
                        }
                        else if (chrAction == 'M')
                        {
                            if (ifBatMove == true)
                            {
                                int intRooms = 0;
                                MoveRooms.Clear();
                                for (int o = 1; o <= 10; o++)
                                {
                                    if (o != Room.intCurRoom)
                                    {
                                        MoveRooms.Add(o);
                                        intRooms++;
                                    }
                                }
                                MoveRoom(Room.intCurRoom);
                            }
                            else
                            {
                                ifBatMove = false;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\nWhich Room? ");
                                Console.ResetColor();
                                //SelRoom = int.Parse(Console.ReadLine());
                                while(!int.TryParse(Console.ReadLine(), out SelRoom))
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\nWhich Room? ");
                                    Console.ResetColor();
                                }
                                //Console.WriteLine(SelRoom);
                                MoveRoom(SelRoom);
                            }
                        }
                    }
                        
                }
                catch (Exception e)
                {
                }
            }
            #endregion
        }
        public static string theUserInput;
        static void TheRooms (string Action, int? currentRoom)
        {
            switch (Action)
            {
                case "Initialize":
                    Console.Write("\nYour room has tunnels leading to rooms:");
                    int intRooms = 0;
                    MoveRooms.Clear();
                    bool RoomsNext = false;
                    NxtOptionRooms = Room.GetNextRooms(Room.intCurRoom).ToList();
                    foreach (int y in NxtOptionRooms)
                    {
                        if (intRooms != 3)
                        {
                            if (y != Room.intCurRoom)
                            {
                                Console.Write(y + " ");
                                MoveRooms.Add(y);
                                intRooms++;
                            }
                        }
                    }
                    Console.WriteLine();
                    TheRooms("Special Room Check", null);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (intArrows > 0)
                    {
                        Console.Write("\n(M)ove or (S)hoot? ");
                        //Console.WriteLine("This was caused by Initialize");
                        Console.ResetColor();
                        theUserInput = Console.ReadLine().ToUpper();
                        
                        while (string.IsNullOrWhiteSpace(theUserInput))
                        {
                            //Console.Write(theUserInput);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nYou entered an invalid action. \nRead and follow instructions carefully for better chances to survive. \nPress Enter to continue..");
                            Console.ResetColor();
                            theUserInput = Console.ReadLine().ToUpper();
                            TheRooms("Initialize", Room.intCurRoom);
                        }
                        if(theUserInput.ToUpper() == "MOVE")
                        {
                            theUserInput = "M";
                        }
                        else if (theUserInput.ToUpper() == "SHOOT")
                        {
                            theUserInput = "S";
                        }
                        char.TryParse(theUserInput.ToUpper(), out chrAction);
                        //char[] input1 = theUserInput.ToCharArray();
                        //chrAction = input1[0];
                    }
                    else
                    {
                        Console.WriteLine("\nYou are out of Arrows. Careful where you move next.");
                        Console.ResetColor();
                        chrAction = 'M';
                    }
                    break;
                case "Enumerate":
                    Console.Write("\nYour room has tunnels leading to rooms:");
                    foreach (int y in MoveRooms)
                    { Console.Write(y + " "); }
                    Console.WriteLine();
                    break;
                case "Special Room Check":
                    foreach (int y in MoveRooms)
                    {
                        if (y == Room.intSpiderRm1 || y == Room.intSpiderRm2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("You hear a faint clicking noise.");
                            Console.ResetColor();
                        }
                        if (y == Room.intPit)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("You smell a dank odor.");
                            Console.ResetColor();
                        }
                        if (y == Room.intWumpusRoom)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You smell some nasty Wumpus.");
                            Console.ResetColor();
                        }
                    }
                    break;
                case "Do Move or Shoot":
                    Console.ForegroundColor = ConsoleColor.White;
                    if (intArrows > 0)
                    {
                        Console.ResetColor();
                        //TheRooms("Special Room Check", null);
                        Console.Write("\n(M)ove or (S)hoot? ");
                        theUserInput = Console.ReadLine().ToUpper();

                        while (string.IsNullOrWhiteSpace(theUserInput))
                        {
                            //Console.Write(theUserInput);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nYou entered an invalid action. \nRead and follow instructions carefully for better chances to survive. \nPress Enter to continue..");
                            Console.ResetColor();
                            theUserInput = Console.ReadLine().ToUpper();
                            TheRooms("Initialize", Room.intCurRoom);
                        }
                        if (theUserInput.ToUpper() == "MOVE")
                        {
                            theUserInput = "M";
                        }
                        else if (theUserInput.ToUpper() == "SHOOT")
                        {
                            theUserInput = "S";
                        }
                        char.TryParse(theUserInput.ToUpper(), out chrAction);
                        //Console.WriteLine("\nInside Move or Shoot: " + chrAction);
                    }
                    else
                    {
                        Console.WriteLine("\nYou are out of Arrows. Careful where you move next.");
                        Console.ResetColor();
                        chrAction = 'M';
                    }
                    break;
                default:
                    break;
            }
        }

        public static bool ifBatMove = false, inOption = false;
        static void MoveRoom(int RoomSelection)
        {
            Room.intCurRoom = RoomSelection;
            if (ifBatMove == true)
            {
                //Console.WriteLine("From Bat Room");
                int intRooms = 0;
                MoveRooms.Clear();
                for(int o = 1; o<=10; o++)
                {
                    MoveRooms.Add(o);
                    intRooms++;
                }
                inOption = true;
            }
            else
            {
                inOption = false;
                ifBatMove = false;
            }
            Random bat = new Random();
            foreach (int rm in MoveRooms)
            {
                //Console.WriteLine("In Foreach loop. Room: " + RoomSelection);
                if (rm == RoomSelection)
                {
                    if (RoomSelection == Room.intPit)
                    {
                        if (ifBatMove == true)
                        {
                            Console.WriteLine("Sorry! Bat brought you to room " + Room.intCurRoom + " which has the pit. \nYou died at the pit!");
                        }
                        else
                        {
                            Console.WriteLine("You died at the pit!");
                        }
                        inOption = true;
                        ifBatMove = false;
                        gameOver = true;
                        break;
                    }
                    else if (RoomSelection == Room.intSpiderRm1 || RoomSelection == Room.intSpiderRm2)
                    {
                        if (ifBatMove == true)
                        {
                            Console.WriteLine("Sorry! Bat brought you to room " + Room.intCurRoom + " which is a room full of Spiders.  \nYou were eaten by spiders!");
                        }
                        else
                        {
                            Console.WriteLine("You were eaten by spiders!");
                        }
                        inOption = true;
                        ifBatMove = false;
                        gameOver = true;
                        break;
                    }
                    else if (RoomSelection == Room.intBat)
                    {
                        int AfterBat = bat.Next(1, 10);
                        while (AfterBat == Room.intCurRoom)
                        {
                            AfterBat = bat.Next(1, 10);
                        }
                        Room.intCurRoom = AfterBat;
                        Console.WriteLine("\nYou meet the bat!");
                        Console.WriteLine("The bat will take you to a random room.");//\nYou are now in Room " + Room.intCurRoom);
                        inOption = true;
                        ifBatMove = true;
                        break;
                    }
                    else if (RoomSelection == Room.intSupplyRoom)
                    {
                        if (ifBatMove == true)
                        {
                            Console.WriteLine("Bats dropped you to the supply room!");
                        }
                        else
                        {
                            Console.WriteLine("\nYour are LUCKY! You found the supply room.");
                        }
                        if (intArrows < 3)
                        {
                            intArrows = 3;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Arrow supply has been automatically refilled, you now have " +
                                intArrows + " arrows");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("But you already have enough. \nMaximum arrows you can carry is 3. \nCurrently you have " + intArrows + " arrows");
                            Console.ResetColor();
                        }

                        Console.Write("\nYou are now in Room " + Room.intCurRoom);
                        TheRooms("Initialize", Room.intCurRoom);
                        ifBatMove = false;
                    }
                    else if (RoomSelection == Room.intWumpusRoom)
                    {
                        if (ifBatMove == true)
                        {
                            Console.WriteLine("Sorry! Bat brought you to room " + Room.intCurRoom + " which is the WUMPUS room");
                            Console.WriteLine("Your dead!! WUMPUS eat you!");
                        }
                        else
                        {
                            Console.WriteLine("Your dead!! WUMPUS eat you!");
                        }
                        inOption = true;
                        ifBatMove = false;
                        gameOver = true;
                        break;
                    }
                    else
                    {
                        Console.Write("\nYou are now in Room " + Room.intCurRoom);
                        TheRooms("Initialize", Room.intCurRoom);
                        inOption = true;
                        ifBatMove = false;
                        break;
                    }
                }
            }
            if (inOption == false)
            {
                Console.WriteLine("\nDimwit! You can't get there from here!");
                TheRooms("Initialize", Room.intCurRoom);
            }
        }

        static void RoomShoot(int y)
        {
            bool ShootRmOption = false;
            foreach (int rm in MoveRooms)
            {
                //Console.WriteLine("In Foreach loop. Room: " + Room.intCurRoom);
                if (rm == y)
                {
                    if (y == Room.intSpiderRm1 || y == Room.intSpiderRm2 || y == Room.intPit)
                    {
                        Console.ResetColor();
                        if (y == Room.intPit)
                        {
                            Console.WriteLine("\nYour arrow goes down the tunnel and is lost. You missed.");
                            Console.WriteLine("There is a black pool of water in the corner");
                        }
                        else
                        {
                            Console.WriteLine("\nYour arrow kills a few spiders and is now lost.");
                        }
                        intArrows--;
                        Console.WriteLine("\nYou are STILL in Room " + Room.intCurRoom);
                        Console.WriteLine("You have " + intArrows + " arrows left.");
                        ShootRmOption = true;
                        gameOver = false;
                    }
                    else if (y == Room.intWumpusRoom)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nYour arrow goes down the tunnel and finds its mark!");
                        Console.WriteLine("You shot the Wumpus! **YOU WIN*\n Enjoy your Fame!");
                        Console.ResetColor();
                        ShootRmOption = true;
                        gameOver = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nRoom " + SelRoom + " is Empty.");
                        intArrows--;
                        Console.WriteLine("\nYou are STILL in Room " + Room.intCurRoom);
                        Console.WriteLine("You have " + intArrows + " arrows left.");
                        Console.ResetColor();
                        ShootRmOption = true;
                        gameOver = false;
                    }
                    if (gameOver == false)
                    {
                        TheRooms("Enumerate", null);
                        TheRooms("Special Room Check", null);
                        TheRooms("Do Move or Shoot", null);

                    }
                }
            }

            if (ShootRmOption == false)
            {
                Console.WriteLine("\nDimwit! You can't shoot that room from here!");
                TheRooms("Initialize", Room.intCurRoom);
            }
        }

        public static void UserDecides()
        {
            Console.WriteLine("Enter number of Rooms: ");
            int.TryParse(Console.ReadLine(), out UserRooms);
            Console.WriteLine("Enter number of Spider Rooms: ");
            int.TryParse(Console.ReadLine(), out UserSpider);
            Console.WriteLine("Enter number of Pit Rooms: ");
            int.TryParse(Console.ReadLine(), out UserPits);
        }

        public static void StartDefaults()
        {
            UserRooms = 10;
            UserSpider = 2;
            UserPits = 1;
        }
    }
}
