# Nuclear War Simulation

![Nuclear War Simulation](https://img.shields.io/badge/Purpose-Educational-blue)
![Framework](https://img.shields.io/badge/Framework-ASP.NET%20Core%208-purple)
![License](https://img.shields.io/badge/License-Educational%20Use-green)

## 🎯 Project Overview

An interactive web application that simulates the effects of nuclear weapons on urban populations. This educational tool helps users understand the devastating consequences of nuclear warfare through scientifically accurate calculations and visualizations.

## ⚠️ Important Disclaimer

This simulation is designed for **educational purposes only**. It aims to promote awareness about the catastrophic consequences of nuclear weapons and support efforts toward nuclear disarmament and world peace. The application is not intended to glorify violence or warfare.

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core MVC (.NET 8)
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **Mapping**: Leaflet.js for interactive maps
- **Data**: In-memory city database with population data
- **Styling**: Custom CSS with Bootstrap components

## 🏗️ Architecture

For detailed system architecture, data flow, and component relationships, see [ARCHITECTURE.md](./ARCHITECTURE.md).

The application follows a clean MVC architecture with:
- **Controllers**: Handle HTTP requests and orchestrate business logic
- **Services**: Contain domain-specific calculations and data access
- **Models**: Define data structures and validation rules
- **Views**: Present data using Razor templates with interactive JavaScript

## ✨ Features

### 🏠 Home Page
- Introduction to the simulation with educational context
- Clear disclaimers about the purpose and nature of the tool
- Navigation to simulation and informational pages

### 🎯 Nuclear Impact Simulation
- Interactive map for target selection
- City dropdown with pre-populated major world cities
- Configurable parameters:
  - Bomb yield (0.1 to 100,000 kilotons)
  - Detonation type (Air burst vs Surface burst)
  - Population density considerations

### 📊 Results Visualization
- Interactive map showing multiple impact zones:
  - 🔥 **Fireball radius** - Complete destruction zone
  - ☢️ **Radiation radius** - Lethal radiation exposure area
  - 💥 **Air blast radius** - Structural damage from overpressure
  - 🌡️ **Thermal radiation** - Burns and fire ignition zones
  - 🌊 **Fallout patterns** - Radioactive contamination (surface bursts)

### 📈 Casualty Estimates
- Death toll calculations based on population density
- Injury estimates by impact zone
- Total affected population statistics
- Environmental impact assessments

### 📚 Educational Content
- Scientific basis and methodology
- Historical context and references
- Limitations and disclaimers
- Peace advocacy messaging

## 🔬 Scientific Accuracy

The calculations are based on:
- "The Effects of Nuclear Weapons" by Samuel Glasstone and Philip Dolan
- Declassified nuclear testing data
- Published academic research on nuclear weapon effects
- Historical data from Hiroshima and Nagasaki

### Calculation Methods
- **Fireball radius**: R = 90 × Y^(1/3) meters
- **Radiation radius**: R = 1200 × Y^(1/3) meters (500 rem dose)
- **Air blast radius**: R = 2200 × Y^(1/3) meters (5 psi overpressure)
- **Thermal radiation**: R = 3200 × Y^(1/3) meters (3rd degree burns)

Where Y is the yield in kilotons.

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- Web browser with JavaScript enabled

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd nuclear-war-simulation
   ```

2. **Build the project**
   ```bash
   dotnet build
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Open in browser**
   Navigate to `https://localhost:7xxx` (port will be displayed in console)

### Development

To run in development mode with hot reload:
```bash
dotnet watch run
```

## 🏗️ Project Structure

```
├── Controllers/
│   ├── HomeController.cs          # Home page and about
│   └── SimulationController.cs    # Simulation logic and results
├── Models/
│   ├── City.cs                    # City data model
│   ├── SimulationModel.cs         # Input parameters
│   └── SimulationResult.cs        # Calculation results
├── Services/
│   ├── CityService.cs             # City data provider
│   └── NuclearBlastCalculator.cs  # Physics calculations
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml           # Landing page
│   │   └── About.cshtml           # Educational information
│   ├── Simulation/
│   │   ├── Index.cshtml           # Simulation form
│   │   └── Results.cshtml         # Results visualization
│   └── Shared/
│       └── _Layout.cshtml         # Main layout template
└── wwwroot/
    ├── css/site.css               # Custom styling
    └── js/                        # JavaScript files
```

## 🎨 Features in Detail

### Interactive Map Integration
- Leaflet.js for responsive mapping
- Click-to-select target locations
- Real-time coordinate updates
- Multiple overlay circles for different effects

### Responsive Design
- Mobile-friendly interface
- Bootstrap 5 grid system
- Custom CSS for enhanced styling
- Progressive enhancement

### Form Validation
- Client-side and server-side validation
- Input range restrictions
- Error messaging and user guidance

## 🌍 City Database

The application includes data for 20 major world cities:
- New York, Los Angeles, Chicago, Houston (USA)
- London (UK), Paris (France), Berlin (Germany)
- Tokyo (Japan), Beijing (China), Moscow (Russia)
- Mumbai, Delhi (India)
- São Paulo (Brazil), Mexico City (Mexico)
- Cairo (Egypt), Istanbul (Turkey)
- Sydney (Australia), Toronto (Canada)
- Seoul (South Korea), Bangkok (Thailand)

Each city includes:
- Geographic coordinates
- Population data
- Population density estimates

## 🕊️ Peace Mission

This project supports:
- Nuclear disarmament education
- Awareness of nuclear weapon consequences
- Informed public discourse on nuclear policy
- International peace and cooperation efforts

## ⚖️ Legal and Ethical Considerations

- Educational use only
- No weapons design information
- Focus on consequences, not creation
- Promotes peace and disarmament
- Based on publicly available scientific data

## 🤝 Contributing

This is an educational project. If you'd like to contribute:
1. Focus on educational value
2. Maintain scientific accuracy
3. Support peace advocacy goals
4. Follow responsible disclosure practices

## 📝 License

This project is for educational purposes only. Use responsibly and ethically.

## 📚 Additional Resources

- [Nuclear Threat Initiative](https://www.nti.org/)
- [International Campaign to Abolish Nuclear Weapons](https://www.icanw.org/)
- [Federation of American Scientists](https://fas.org/)
- [Bulletin of the Atomic Scientists](https://thebulletin.org/)

---

*"The unleashed power of the atom has changed everything save our modes of thinking and we thus drift toward unparalleled catastrophe."* - Albert Einstein
