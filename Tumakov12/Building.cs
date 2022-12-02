using System;

namespace Build
{
    public class Building
    {
        public static uint countBuilding = 0;
        private uint id = 137742; // first ID
        private float height;
        private byte numberStoreys;
        private ushort numberFlats;
        private byte numberEntrance;
        #region GetSet methods
        public uint GetID()
        {
            return id;
        }
        public float GetHeight()
        {
            return height;
        }
        public byte GetNummberStoreys()
        {
            return numberStoreys;
        }
       public ushort GetNumberFlats()
        {
            return numberFlats;
        }
       public byte GetNumberEntrance()
        {
            return numberEntrance;
        }
        public void SetNumberEntrance(byte numberEntrance)
        {
            this.numberEntrance = numberEntrance;
        }
        #endregion

        internal Building()
        {
            id += countBuilding;
            countBuilding++;
        }
        internal Building(float height, byte numberStoreys, byte numberEntrance, ushort numberFlats) : this()
        {
            this.height = height;
            this.numberEntrance = numberEntrance;
            this.numberStoreys = numberStoreys;
            this.numberFlats = numberFlats;
        }
        public void Display()
        {
            Console.WriteLine("ID: " + GetID());
            Console.WriteLine("Высота: " + GetHeight());
            Console.WriteLine("Количество подьездов: " + GetNumberEntrance());
            Console.WriteLine("Количество квартир: " + GetNumberFlats());
            Console.WriteLine("Количество этажей: " + GetNummberStoreys());
        }
    }
}