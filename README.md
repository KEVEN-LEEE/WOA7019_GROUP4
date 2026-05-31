# ARStickyNotes

An innovative Augmented Reality application that enables users to create, place, and manage virtual sticky notes in real-world environments using AR technology.

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Usage](#usage)
- [Development](#development)
- [Project Team](#project-team)
- [License](#license)

## 🎯 Overview

ARStickyNotes is an Augmented Reality application designed for WOA7019 Group Project 4. The application allows users to overlay digital sticky notes onto physical spaces, making it an innovative tool for note-taking, task management, and collaboration in augmented reality environments.

## ✨ Features

- **AR-Enabled Note Creation**: Create and place sticky notes directly in your AR view
- **Real-World Anchoring**: Notes are anchored to physical locations for persistent viewing
- **Note Management**: Edit, delete, and organize your AR notes
- **Intuitive UI**: User-friendly interface designed for seamless interaction
- **Multi-Platform Support**: Built with cross-platform compatibility in mind

## 🛠️ Technology Stack

This project is built with a diverse technology stack optimized for Augmented Reality development:

| Technology | Usage | Percentage |
|-----------|-------|-----------|
| **C++** | Core engine and performance-critical components | 77% |
| **C#** | Unity scripting and application logic | 11.1% |
| **C** | Low-level system interfaces | 11.9% |
| **ShaderLab** | Graphics and visual effects | - |

**Primary Framework**: Unity Engine  
**Development Environment**: Visual Studio 2022 / VS Code

## 📁 Project Structure

```
WOA7019_GROUP4/
├── Assets/                 # Game assets and scripts
├── Library/                # Unity library cache
├── Packages/               # External dependencies and packages
├── ProjectSettings/        # Unity project configuration
├── ARStickyNotes.sln       # Visual Studio solution file
├── Assembly-CSharp.csproj  # C# project configuration
└── README.md              # This file
```

### Key Directories

- **Assets**: Contains all game scenes, prefabs, scripts, and resources
- **ProjectSettings**: Unity-specific project configuration files
- **Packages**: Unity package dependencies and custom packages

## 🚀 Getting Started

### Prerequisites

- Unity Engine (2020 LTS or higher recommended)
- Visual Studio 2022 or Visual Studio Code
- Git
- AR-capable device or ARKit/ARCore supported hardware

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/KEVEN-LEEE/WOA7019_GROUP4.git
   cd WOA7019_GROUP4
   ```

2. **Open in Unity**
   - Open Unity Hub
   - Click "Add" and select the project folder
   - Open the project with your preferred Unity version

3. **Install Dependencies**
   - Unity will automatically fetch packages from the `Packages` folder
   - Wait for package resolution to complete

4. **Set Up Development Environment**
   - Open the solution file `ARStickyNotes.sln` in Visual Studio for C++ and C# development
   - Configure your IDE to recognize the project structure

## 📖 Usage

1. **Launch the Application**
   - Build and run the project on an AR-capable device
   - Grant necessary camera and location permissions

2. **Create a Sticky Note**
   - Use the AR interface to position a note in your environment
   - Enter your note content
   - Place the note at the desired location

3. **Manage Notes**
   - Tap existing notes to view or edit them
   - Delete unwanted notes with the delete option
   - Organize notes by category or location

## 💻 Development

### Building the Project

**For Development (Editor)**
- Simply open the project in Unity Editor and use Play mode

**For Deployment**
- Build for your target platform:
  - iOS (ARKit)
  - Android (ARCore)
  - Other supported platforms

### Code Organization

- **C#**: High-level application logic and Unity interactions
- **C++**: Performance-critical algorithms and native plugins
- **C**: System-level interfaces and optimizations

### Contributing

To contribute to this project:

1. Create a feature branch
2. Make your changes with clear commit messages
3. Test thoroughly before submitting
4. Submit a pull request with detailed descriptions

## 📝 License

This project is open source. Please check the license file for specific terms and conditions.

## 🤝 Support & Feedback

For issues, questions, or suggestions, please open an issue on the GitHub repository.

---

**Last Updated**: May 2026  
**Repository**: [KEVEN-LEEE/WOA7019_GROUP4](https://github.com/KEVEN-LEEE/WOA7019_GROUP4)
