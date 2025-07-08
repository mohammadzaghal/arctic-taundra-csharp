# 🐾 Arctic Tundra Simulation

This project simulates predator-prey dynamics in the Arctic tundra using object-oriented programming principles in Java. Colonies of animals interact based on species-specific rules, with reproduction, hunting, and extinction mechanics influencing the environment over time.

##  Features

- Multiple predator species:  Snowy Owl,  Arctic Fox,  Wolf  
- Multiple prey species:  Lemming,  Arctic Hare,  Gopher  
- Reproduction, overpopulation, starvation, and extinction rules  
- Turn-based simulation with real-time colony updates  
- Simulation ends when all prey are extinct or their population quadruples

##  Simulation Rules

- Prey reproduce every 2–4 turns (species dependent)
- If overpopulated, prey numbers drop sharply
- Predators hunt prey every turn
- If not enough prey, predators starve and die
- Predators reproduce every 8 turns (more offspring if prey population is very large)

##  Input File Format

The first line of the input file contains two integers: the number of prey colonies and predator colonies.  
Each subsequent line defines a colony in the format:


Species codes:
- `l` – Lemming  
- `h` – Arctic Hare  
- `g` – Gopher  
- `o` – Snowy Owl  
- `f` – Arctic Fox  
- `w` – Wolf  

Example:
3 2
Lemmy l 100
Hoppy h 50
Chuck g 40
Ollie o 10
Fang f 8
##  Design

- `Tundra`: Environment manager that holds colonies and controls simulation turns  
- `Colony` (base class): Represents a generic animal group  
- `Prey` and `Predator` (abstract subclasses): Define shared behavior  
- Species classes (e.g., `Lemming`, `Fox`, etc.) implement species-specific logic  
- Uses the **Visitor Design Pattern** for modular and flexible behavior extensions

##  Output

In each simulation turn, colony data is printed showing:
- Current population
- Any population changes (birth, death, predation)
- Simulation ends with a summary

##  Doccumentation 
Full documentation is included in the Documentation.docx file, covering:

- Analysis
- UML
- Specification (pre and post conditions with analogy)
- Algorithm
- Tests (black box testing)

## Made with ❤️ by Mohammad Alzaghal
