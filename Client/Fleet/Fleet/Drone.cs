using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fleet
{
    internal class Drone
    {
        private Random valueGenerator;
        public int id { get; set; }
        public bool state { get; set; }
        public Drone(int id)
        {
            valueGenerator = new Random();
            this.id = id;
            this.state = true;
        }
        public int getSpeed() 
        { 
            return valueGenerator.Next(0, 60);
        }
        public Position getPosition()
        {
            return new Position(valueGenerator.Next(0, 100), valueGenerator.Next(0, 100), valueGenerator.Next(0, 100));
        }
        public int getBattery()
        {
            return valueGenerator.Next(0, 100);
        }
        public void changeState(bool command)
        {
            this.state = command;
        }
        public DateTime getTime()
        {
            return DateTime.Now;
        }
    }
}
