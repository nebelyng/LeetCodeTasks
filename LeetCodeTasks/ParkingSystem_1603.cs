using System;

namespace LeetCodeTasks
{
    class ParkingSystem
    {
        int[] slot = new int[3];
        public ParkingSystem(int big, int medium, int small)
        {
            slot[0] = big;
            slot[1] = medium;
            slot[2] = small;
        }

        public bool AddCar(int carType)
        {
            --carType;
            if(slot[carType] > 0)
            {
                --slot[carType];
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
