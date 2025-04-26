using System;
using System.Collections.Generic;

namespace EmergencyResponseSimulation
{
    public abstract class EmergencyUnit
    {
        public string Name { get; protected set; }
        public int BaseSpeed { get; protected set; }

        public EmergencyUnit(string name, int baseSpeed)
        {
            Name = name;
            BaseSpeed = baseSpeed;
        }

        public abstract bool CanHandle(string incidentType);
        public abstract int CalculateResponseTime(string incidentLevel);
        public abstract void RespondToIncident(Incident incident);
    }

    public class Police : EmergencyUnit
    {
        public Police(string name, int baseSpeed) : base(name, baseSpeed) { }

        public override bool CanHandle(string incidentType)
        {
            return incidentType == "Crime" || incidentType == "Public Disturbance" || incidentType == "Traffic Accident";
        }

        public override int CalculateResponseTime(string incidentLevel)
        {
            switch (incidentLevel)
            {
                case "High": return BaseSpeed;
                case "Medium": return BaseSpeed + 2;
                case "Low": return BaseSpeed + 5;
                default: return BaseSpeed + 3;
            }
        }

        public override void RespondToIncident(Incident incident)
        {
            int responseTime = CalculateResponseTime(incident.Level);
            string action = incident.Type == "Crime" ? "apprehending suspect" :
                           incident.Type == "Public Disturbance" ? "handling disturbance" :
                           "managing traffic accident";

            Console.WriteLine($"{Name} is responding to {incident.Level.ToLower()} priority {incident.Type} at {incident.Location}...");
            Console.WriteLine($"{action} in {responseTime} minutes!");
        }
    }

    public class Firefighter : EmergencyUnit
    {
        public Firefighter(string name, int baseSpeed) : base(name, baseSpeed) { }

        public override bool CanHandle(string incidentType)
        {
            return incidentType == "Fire" || incidentType == "Hazardous Material";
        }

        public override int CalculateResponseTime(string incidentLevel)
        {
            switch (incidentLevel)
            {
                case "High": return BaseSpeed;
                case "Medium": return BaseSpeed + 3;
                case "Low": return BaseSpeed + 7;
                default: return BaseSpeed + 4;
            }
        }

        public override void RespondToIncident(Incident incident)
        {
            int responseTime = CalculateResponseTime(incident.Level);
            string action = incident.Type == "Fire" ? "extinguishing fire" : "containing hazardous material";

            Console.WriteLine($"{Name} is responding to {incident.Level.ToLower()} priority {incident.Type} at {incident.Location}...");
            Console.WriteLine($"{action} in {responseTime} minutes!");
        }
    }

    public class Ambulance : EmergencyUnit
    {
        public Ambulance(string name, int baseSpeed) : base(name, baseSpeed) { }

        public override bool CanHandle(string incidentType)
        {
            return incidentType == "Medical" || incidentType == "Traffic Accident";
        }

        public override int CalculateResponseTime(string incidentLevel)
        {
            switch (incidentLevel)
            {
                case "High": return BaseSpeed;
                case "Medium": return BaseSpeed + 1;
                case "Low": return BaseSpeed + 3;
                default: return BaseSpeed + 2;
            }
        }

        public override void RespondToIncident(Incident incident)
        {
            int responseTime = CalculateResponseTime(incident.Level);
            string action = incident.Type == "Medical" ? "stabilizing patient" : "treating accident victims";

            Console.WriteLine($"{Name} is responding to {incident.Level.ToLower()} priority {incident.Type} incident at {incident.Location}...");
            Console.WriteLine($"{action} in {responseTime} minutes!");
        }
    }

    public class Incident
    {
        public string Type { get; set; }
        public string Location { get; set; }
        public string Level { get; set; }

        public Incident(string type, string location, string level)
        {
            Type = type;
            Location = location;
            Level = level;
        }
    }

    public class EmergencySimulation
    {
        private List<EmergencyUnit> units;
        private int score;
        private const int TotalRounds = 5;

        public EmergencySimulation()
        {
            units = new List<EmergencyUnit>
            {
                new Police("Police Unit 1", 5),
                new Police("Police Unit 2", 7),
                new Firefighter("Firefighter Unit 1", 8),
                new Firefighter("Firefighter Unit 2", 6),
                new Ambulance("Ambulance Unit 1", 4),
                new Ambulance("Ambulance Unit 2", 3)
            };
            score = 0;
        }

        private int CalculatePoints(string incidentLevel)
        {
            switch (incidentLevel)
            {
                case "High": return 15;
                case "Medium": return 10;
                case "Low": return 5;
                default: return 10;
            }
        }

        public void RunSimulation()
        {
            Console.WriteLine("=== EMERGENCY RESPONSE SIMULATION ===");
            Console.WriteLine("Menu name: firezer settual");
            Console.WriteLine("ID: DBU1501744");
            Console.WriteLine($"Running for {TotalRounds} rounds...\n");

            for (int round = 1; round <= TotalRounds; round++)
            {
                Console.WriteLine($"--- Turn {round} ---");

                string incidentType = GetIncidentType();
                string incidentLevel = GetIncidentLevel();
                string location = GetLocation();

                Incident incident = new Incident(incidentType, location, incidentLevel);
                Console.WriteLine($"\nProcessing {incident.Level} priority {incident.Type} incident at {incident.Location}...");

                EmergencyUnit unit = units.Find(u => u.CanHandle(incident.Type));

                if (unit != null)
                {
                    unit.RespondToIncident(incident);
                    int points = CalculatePoints(incident.Level);
                    score += points;
                    Console.WriteLine($"+{points} points");
                }
                else
                {
                    Console.WriteLine($"No available unit to handle {incident.Type} incident!");
                    score -= 5;
                    Console.WriteLine("-5 points");
                }

                Console.WriteLine($"Current Score: {score}\n");
            }

            Console.WriteLine($"\nSimulation ended. Final Score: {score}");
        }

        private string GetIncidentType()
        {
            while (true)
            {
                Console.WriteLine("Select incident type:");
                Console.WriteLine("1. Crime");
                Console.WriteLine("2. Medical");
                Console.WriteLine("3. Fire");
                Console.WriteLine("4. Hazardous Material");
                Console.WriteLine("5. Traffic Accident");
                Console.WriteLine("6. Public Disturbance");
                Console.Write("Enter choice (1-6): ");

                switch (Console.ReadLine())
                {
                    case "1": return "Crime";
                    case "2": return "Medical";
                    case "3": return "Fire";
                    case "4": return "Hazardous Material";
                    case "5": return "Traffic Accident";
                    case "6": return "Public Disturbance";
                    default: Console.WriteLine("Invalid input! Please enter 1-6."); break;
                }
            }
        }

        private string GetIncidentLevel()
        {
            while (true)
            {
                Console.WriteLine("Select incident level:");
                Console.WriteLine("1. Low");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. High");
                Console.Write("Enter priority (1-3): ");

                switch (Console.ReadLine())
                {
                    case "1": return "Low";
                    case "2": return "Medium";
                    case "3": return "High";
                    default: Console.WriteLine("Invalid input! Please enter 1, 2, or 3."); break;
                }
            }
        }

        private string GetLocation()
        {
            while (true)
            {
                Console.Write("Enter incident location: ");
                string location = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(location)) return location;
                Console.WriteLine("Location cannot be empty!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new EmergencySimulation().RunSimulation();
        }
    }
}