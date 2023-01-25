using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fleet
{
    internal class Drone
    {
        Random valueGenerator;
        int Id { get; set; }
        bool State { get; set; }
        public Drone(int id)
        {
            valueGenerator = new Random();
            this.Id = id;
            this.State = true;
        }
        int getSpeed() 
        { 
            return valueGenerator.Next(0, 60);
        }
        Position getPosition()
        {
            return new Position(valueGenerator.Next(0, 10000), valueGenerator.Next(0, 10000), valueGenerator.Next(0, 100));
        }
        int getBattery()
        {
            return valueGenerator.Next(0, 100);
        }
        DateTime getTime()
        {
            return DateTime.Now;
        }
        class AllValues
        {
            public int Id { get; set; }
            public bool State { get; set; }
            public int Speed { get; set; }
            public Position Position { get; set; }
            public int Battery { get; set; }
            public DateTime Time { get; set; }
            /*public AllValues(Drone drone)
            {
                this.Id = drone.Id;
                this.Speed = drone.getSpeed(); 
                this.Position= drone.getPosition();
                this.Battery = drone.getBattery();
                this.Time = drone.getTime();
            }*/

        }
        class MinimalValues
        {
            public int Id { get; set; }
            public bool State { get; set; }
            /*public MinimalValues(Drone drone)
            {
                this.Id = drone.Id;
            }*/
        }
        AllValues? allValues;
        
        MinimalValues? minimalValues;
        public void updateValues()
        {
            if (State)
            {
                allValues.Id = Id;
                allValues.State = State;
                allValues.Speed = getSpeed();
                allValues.Position = getPosition();
                allValues.Battery = getBattery();
                allValues.Time = getTime();
                minimalValues = null;
            }
            else
            {
                allValues = null;
                minimalValues.Id = Id;
                minimalValues.State = State;
            }
                
        }
        string aggregateValues()
        {
            if(State) 
                return JsonSerializer.Serialize(allValues);
            else
                return JsonSerializer.Serialize(minimalValues);
        }
        public void sendValues()
        {

        }
        public void printValues()
        {
            Console.WriteLine($"\rUpdate from {Id}\n\r\rState: " + (State ? $"Enabled\n\r\rSpeed: {allValues.Speed.ToString()} km/h\n\r\rPosition: ({allValues.Position.x.ToString()}, {allValues.Position.y.ToString()}, {allValues.Position.z.ToString()}) m\n\r\rBattery level: {allValues.Battery.ToString()}%\n\r\rDetection time: {allValues.Time.ToString()}" : $"Disabled") + "\n");
        }
        bool receivedCommand()
        {
            bool command = State;
            return command;
        }
        public void switchState()
        {
            State = receivedCommand(); 
        }
    }
}
