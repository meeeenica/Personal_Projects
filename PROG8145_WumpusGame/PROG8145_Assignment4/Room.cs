using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG8145_Assignment4
{
    class Room
    {
        public static List<int> Rooms = new List<int>();
        public static Random rndGetRandom = new Random();
        public static int intCurRoom = 1;
        public static int intWumpusRoom;
        public static int intSpiderRm1;
        public static int intSpiderRm2;
        public static int intPit;
        public static int intSupplyRoom;
        public static int intBat;

        public static void SetRooms(int start, int NumOfObj)
        {
            var rng = new Random();
            var values = Enumerable.Range(start, NumOfObj).OrderBy(x => rng.Next()).ToArray();
            intWumpusRoom = values[0];
            intSpiderRm1 = values[1];
            intSpiderRm2 = values[2];
            intPit = values[3];
            intSupplyRoom = values[4];
            intBat = values[5];
        }

        public static int NumberOfRooms;
        public static int[,] RoomNumber = new int[NumberOfRooms, 4];
        public static int[] RoomNumbers = new int[NumberOfRooms];
        public static string[] RoomDescription = new string[NumberOfRooms];

        public static int GetRandom()
        {
            int RandomNumber = rndGetRandom.Next(2, NumberOfRooms);
            return RandomNumber;
        }


        
        public static int[] GetNextRooms(int curRoom)
        {
            var intNextRms = new int[3].ToArray();
            for(int i = 0; i < 3; i++)
            {
                intNextRms[i] = RoomNumber[curRoom-1, i+1];
                //Console.WriteLine(RoomNumber[curRoom-1, i+1]);
            }
            
            //var intNextRms = 
            int first = intNextRms[0];
            int second = intNextRms[1];
            int third = intNextRms[2];
            return intNextRms;
        }


        public static string[] roomValues;
        public static void loadMap(string FileName)
        {
            using (StreamReader RoomReader = new StreamReader(FileName))
            {
                string line = null;
                for (int room = 0; room < Room.NumberOfRooms; room++)
                {
                    RoomNumbers[room] = room;
                    //RoomArray[room,room] = new Room();
                    if (null != (line = RoomReader.ReadLine()))
                    {
                        roomValues = line.Split(',');
                        //RoomNumbers[room] = roomValues[];
                        for (int adjrm = 0; adjrm <= 4; adjrm++)
                        {
                            if (adjrm <= 3)
                            {
                                //Console.WriteLine("Room " + room + " Adjacent" + adjrm + ": " + roomValues[adjrm]);
                                int.TryParse(roomValues[adjrm], out RoomNumber[room,adjrm]);
                                //Console.WriteLine(RoomNumber[room, adjrm]);
                            }
                            else
                            {
                                RoomDescription[room] = roomValues[adjrm];
                                //Console.WriteLine(RoomDescription[room]);
                            }
                            
                        }
                    }

                }

            }
        }
    }
}
