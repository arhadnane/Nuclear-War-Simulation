# Nuclear War Simulation - Architecture

## 🏗️ System Architecture

```mermaid
graph TB
    subgraph "Presentation Layer"
        UI[Web Browser]
        Views[Razor Views]
        JS[JavaScript + Leaflet.js]
        CSS[Bootstrap + Custom CSS]
    end
    
    subgraph "Application Layer"
        HC[HomeController]
        SC[SimulationController]
        Models[Data Models]
    end
    
    subgraph "Business Logic Layer"
        NBC[NuclearBlastCalculator]
        CS[CityService]
    end
    
    subgraph "Data Layer"
        CityData[In-Memory City Database]
        Results[Simulation Results]
    end
    
    UI --> Views
    Views --> HC
    Views --> SC
    SC --> NBC
    SC --> CS
    CS --> CityData
    NBC --> Results
    Views --> JS
    Views --> CSS
    
    classDef controller fill:#e1f5fe
    classDef service fill:#f3e5f5
    classDef data fill:#e8f5e8
    classDef ui fill:#fff3e0
    
    class HC,SC controller
    class NBC,CS service
    class CityData,Results data
    class UI,Views,JS,CSS ui
```

## 🔄 Application Flow

```mermaid
sequenceDiagram
    participant User
    participant Browser
    participant Controller
    participant Calculator
    participant CityService
    participant Database
    
    User->>Browser: Access Home Page
    Browser->>Controller: GET /
    Controller->>Browser: Return Home View
    
    User->>Browser: Navigate to Simulation
    Browser->>Controller: GET /Simulation
    Controller->>CityService: GetAllCities()
    CityService->>Database: Retrieve Cities
    Database-->>CityService: City List
    CityService-->>Controller: Cities Data
    Controller->>Browser: Return Simulation View + Cities
    
    User->>Browser: Configure Parameters & Submit
    Browser->>Controller: POST /Simulation/RunSimulation
    Controller->>Calculator: CalculateBlastEffects(model)
    Calculator->>Calculator: Physics Calculations
    Calculator-->>Controller: SimulationResult
    Controller->>Browser: Return Results View
    Browser->>User: Display Interactive Map + Stats
```

## 📊 Data Model Structure

```mermaid
classDiagram
    class SimulationModel {
        +string TargetCity
        +double BombYield
        +DetonationType DetonationType
        +double Latitude
        +double Longitude
        +int PopulationDensity
    }
    
    class SimulationResult {
        +string TargetCity
        +double BombYield
        +DetonationType DetonationType
        +double Latitude
        +double Longitude
        +int PopulationDensity
        +double FireballRadius
        +double RadiationRadius
        +double AirBlastRadius
        +double ThermalRadiationRadius
        +double LightBlastRadius
        +int EstimatedDeaths
        +int EstimatedInjuries
        +int TotalAffected
        +double FalloutRadius
        +string RadiationLevel
        +bool FirestormProbability
        +DateTime SimulationDate
    }
    
    class City {
        +string Name
        +string Country
        +double Latitude
        +double Longitude
        +int Population
        +int PopulationDensity
    }
    
    class DetonationType {
        <<enumeration>>
        AirBurst
        SurfaceBurst
    }
    
    SimulationModel --> DetonationType
    SimulationResult --> DetonationType
    SimulationModel ..> SimulationResult : transforms to
```

## 🔧 Service Architecture

```mermaid
graph LR
    subgraph "Controllers"
        HC[HomeController]
        SC[SimulationController]
    end
    
    subgraph "Services"
        NBC[NuclearBlastCalculator]
        CS[CityService]
    end
    
    subgraph "Calculations"
        FB[Fireball Calculation]
        RAD[Radiation Calculation]
        AB[Air Blast Calculation]
        TH[Thermal Calculation]
        CAS[Casualty Estimation]
    end
    
    SC --> NBC
    SC --> CS
    NBC --> FB
    NBC --> RAD
    NBC --> AB
    NBC --> TH
    NBC --> CAS
    
    classDef controller fill:#ffecb3
    classDef service fill:#c8e6c9
    classDef calc fill:#f8bbd9
    
    class HC,SC controller
    class NBC,CS service
    class FB,RAD,AB,TH,CAS calc
```

## 🌐 Frontend Architecture

```mermaid
graph TB
    subgraph "Views"
        Layout[_Layout.cshtml]
        Home[Home/Index.cshtml]
        About[Home/About.cshtml]
        SimIndex[Simulation/Index.cshtml]
        SimResults[Simulation/Results.cshtml]
    end
    
    subgraph "Frontend Technologies"
        Bootstrap[Bootstrap 5]
        Leaflet[Leaflet.js Maps]
        CustomCSS[Custom CSS]
        Validation[Client Validation]
    end
    
    subgraph "Interactive Features"
        Map[Interactive Map]
        Form[Simulation Form]
        Results[Results Visualization]
        Charts[Casualty Statistics]
    end
    
    Layout --> Home
    Layout --> About
    Layout --> SimIndex
    Layout --> SimResults
    
    SimIndex --> Map
    SimIndex --> Form
    SimResults --> Results
    SimResults --> Charts
    
    Map --> Leaflet
    Form --> Validation
    Results --> Leaflet
    Charts --> Bootstrap
    
    Home --> Bootstrap
    About --> Bootstrap
    SimIndex --> Bootstrap
    SimResults --> Bootstrap
    
    All --> CustomCSS
```

## 🔐 Security & Validation Flow

```mermaid
graph TD
    Input[User Input] --> ClientVal[Client-Side Validation]
    ClientVal --> ServerVal[Server-Side Validation]
    ServerVal --> CSRF[Anti-Forgery Token Check]
    CSRF --> ModelState[Model State Validation]
    ModelState --> Processing[Business Logic Processing]
    
    ClientVal -->|Invalid| Error1[Display Error]
    ServerVal -->|Invalid| Error2[Return to Form]
    CSRF -->|Invalid| Error3[Security Error]
    ModelState -->|Invalid| Error4[Validation Error]
    
    Processing --> Result[Generate Results]
    
    classDef validation fill:#fff3cd
    classDef error fill:#f8d7da
    classDef success fill:#d4edda
    
    class ClientVal,ServerVal,CSRF,ModelState validation
    class Error1,Error2,Error3,Error4 error
    class Result success
```

## 📁 Project Structure

```mermaid
graph TD
    Root[Nuclear War Simulation]
    
    Root --> Controllers
    Root --> Models
    Root --> Services
    Root --> Views
    Root --> wwwroot
    Root --> Config[Configuration Files]
    
    Controllers --> HC[HomeController.cs]
    Controllers --> SC[SimulationController.cs]
    
    Models --> SM[SimulationModel.cs]
    Models --> SR[SimulationResult.cs]
    Models --> C[City.cs]
    
    Services --> NBC[NuclearBlastCalculator.cs]
    Services --> CS[CityService.cs]
    
    Views --> Home
    Views --> Simulation
    Views --> Shared
    
    Home --> HI[Index.cshtml]
    Home --> HA[About.cshtml]
    
    Simulation --> SI[Index.cshtml]
    Simulation --> SRes[Results.cshtml]
    
    Shared --> Layout[_Layout.cshtml]
    Shared --> ViewImports[_ViewImports.cshtml]
    Shared --> ViewStart[_ViewStart.cshtml]
    
    wwwroot --> css
    wwwroot --> js
    wwwroot --> lib
    
    Config --> Program[Program.cs]
    Config --> AppSettings[appsettings.json]
    Config --> Project[NuclearWarSimulation.csproj]
```
