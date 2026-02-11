# MartianRobots

A C# console application that simulates robots navigating the surface of Mars. 
Robots follow a sequence of instructions to move on a grid. If they move beyond the grid's boundaries, they are lost forever. 
Lost robots leave a scent that prohibits future robots from dropping off at the same grid point.

## Tech Stack

- **C#**
- **.NET 10**
- **xUnit**

## Approach

The goal was to keep the code simple, modular and testable, whilst adhering to SOLID principles.

- **Command and Factory Pattern** — each instruction is encapsulated as its own class implementing `ICommand`. New commands can be added without modifying existing code by creating a new `ICommand` implementation and adding it to the `CommandFactory`.
- **Separation of Concerns** — `Mars` manages the grid and scent state, `Robot` holds direction, position and lost status. `InputParser` handles all input reading and validation.

## Input Format

The first line defines the upper-right coordinates of the grid (the lower-left is assumed to be `0 0`).
Each robot is then described by two lines:

1. Initial position and direction: `X Y Direction` (e.g. `1 1 E`).
2. Instruction string: a sequence of `L`, `R`, and `F` characters.

Directions: `N` (North), `E` (East), `S` (South), `W` (West).

### Commands

- `L` — Turn left
- `R` — Turn right
- `F` — Move forward in the current direction

## Output Format

After all robots have been processed, the application prints each robot's final position and direction. If a robot moved off the grid, `LOST` is appended.

```
1 1 E
3 3 N LOST
```

## How to run

```
cd MartianRobots
dotnet run
```

Enter input in console, go to next line and indicate end of input by pressing `Ctrl + Z` then `Enter` (Windows) or `Ctrl + D` (MacOS/Linux).

## Example

Input:
```
5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL
```

Output:
```
1 1 E
3 3 N LOST
2 3 S
```