        Firezer Settual DBU1501744  
Emergency Response Simulation System
Overview
This C# console application simulates an emergency response system where different units (Police, Firefighters, and Ambulance) respond to various types of incidents with different priority levels. The simulation runs for 5 rounds, tracking performance through a scoring system.

Features
Multiple Emergency Units:

Police (handles Crime, Public Disturbance, Traffic Accident)

Firefighters (handles Fire, Hazardous Material)

Ambulance (handles Medical, Traffic Accident)

Incident Types:

Crime

Medical

Fire

Hazardous Material

Traffic Accident

Public Disturbance

Priority Levels:

Low (+5 points)

Medium (+10 points)

High (+15 points)

Dynamic Response System:

Different response times based on incident priority

Specialized unit responses for each incident type

Score tracking with penalties for unhandled incidents

How It Works
The simulation runs for 5 rounds (turns)

Each turn:

User selects incident type (1-6)

User selects priority level (1-3)

User enters location

The system:

Finds appropriate emergency unit

Calculates response time based on priority

Displays response actions

Updates score

Final score is displayed after 5 rounds

OOP Concepts Applied
Abstraction:

EmergencyUnit abstract base class

Common interface for all emergency units

Inheritance:

Police, Firefighter, and Ambulance inherit from EmergencyUnit

Polymorphism:

Each unit implements its own versions of:

CanHandle()

CalculateResponseTime()

RespondToIncident()

Encapsulation:

Proper use of access modifiers

Separation of concerns

Class Structure
EmergencyUnit (abstract)
├── Police
├── Firefighter
└── Ambulance

Incident

EmergencySimulation (contains game logic)
Requirements
.NET Core 3.1 or later

 simple text-based class diagram
 EmergencyUnit (abstract)
│
├── Properties:
│   ├── Name : string
│   ├── BaseSpeed : int
│
├── Methods:
│   ├── CanHandle(incidentType: string) : bool
│   ├── CalculateResponseTime(incidentLevel: string) : int
│   ├── RespondToIncident(incident: Incident) : void
│
├── Derived Classes:
│   ├── Police
│   │   ├── CanHandle() - handles Crime, Public Disturbance, Traffic Accident
│   │   ├── CalculateResponseTime()
│   │   └── RespondToIncident()
│   │
│   ├── Firefighter
│   │   ├── CanHandle() - handles Fire, Hazardous Material
│   │   ├── CalculateResponseTime()
│   │   └── RespondToIncident()
│   │
│   └── Ambulance
│       ├── CanHandle() - handles Medical, Traffic Accident
│       ├── CalculateResponseTime()
│       └── RespondToIncident()

Incident
├── Properties:
│   ├── Type : string
│   ├── Location : string
│   └── Level : string
├── Constructor: initializes incident details

EmergencySimulation
├── Fields:
│   ├── units : List<EmergencyUnit>
│   ├── score : int
│   └── TotalRounds : const int (5)
│
├── Methods:
│   ├── RunSimulation()
│   ├── CalculatePoints(incidentLevel: string) : int
│   ├── GetIncidentType() : string
│   ├── GetIncidentLevel() : string
│   └── GetLocation() : string

Program
├── Main(args: string[])
│   └── Starts EmergencySimulation.RunSimulation()


How to Run
Clone the repository

Navigate to project directory

Run dotnet run in terminal

Sample Output
=== EMERGENCY RESPONSE SIMULATION ===
--- Turn 1 ---
Select incident type:
1. Crime
2. Medical
3. Fire
4. Hazardous Material
5. Traffic Accident
6. Public Disturbance
Enter choice (1-6): 5
Select incident level:
1. Low
2. Medium
3. High
Enter priority (1-3): 2
Enter incident location: Main Street

Processing Medium priority Traffic Accident incident at Main Street...
Police Unit 1 is responding to medium priority Traffic Accident at Main Street...
managing traffic accident in 7 minutes!
+10 points
Current Score: 10        
