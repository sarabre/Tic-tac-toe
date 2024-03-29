# Tic-Tac-Toe

Welcome to Tic-Tac-Toe, a simple and entertaining implementation of the classic game built in Unity. Challenge yourself against the computer and enjoy different difficulty levels.

## Features

- **Computer Challenge:** Test your skills against the computer, which adapts its gameplay based on your selected difficulty level.
- **Scriptable Object Strategy:** Utilizing Scriptable Objects, different difficulty levels are implemented with unique strategies for suggested moves. Easily customize levels by creating lists of strategies and dynamically switching between them during gameplay.
- **Cell and Board Management:** The Cell class tracks individual grid cells with row and column indices and their respective neighbors (Up, Down, Left, Right, etc.). The Board class, with a 2D array of cells, manages game state, including determining win conditions and ensuring the game progresses smoothly.
- **Reduced Dependency:** Each class is designed to handle specific responsibilities, reducing dependencies and enhancing maintainability.
- **Model Assets:** Centralize common data such as turn information and game board configurations as models, facilitating easy access for components like UI Manager or Game Manager.

## Future Enhancements

While Actions are used to minimize inter-class communication, some may be incorrectly declared. Future updates aim to refine these areas and address potential bugs.

## Class Diagram

![Class Diagram](UML/UML.png)

This diagram illustrates the simplified class relationships and structure of our project. Each component plays a specific role in achieving the functionality of the system

## Try it Out

Experience Tic-Tac-Toe now by playing the WebGL build available https://sarabre.github.io/Tic-tac-toe/index .
