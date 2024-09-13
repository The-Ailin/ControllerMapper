# Xbox Controller Mapper

A C# Windows Forms application that allows you to map Xbox One controller inputs to keyboard and mouse actions. Customize your gaming or application experience by configuring controller inputs to perform specific keyboard or mouse functions.

## Features

- **Map Controller Buttons to Keyboard/Mouse Actions**: Assign any controller button to a keyboard key or mouse button.
- **Analog Stick to Mouse Movement**: Use the left analog stick to control mouse movement with adjustable speed and acceleration.
- **Analog Stick to Scrolling**: Use the right analog stick to control mouse wheel scrolling in all directions.
- **Configurable Dead Zones**: Define dead zones for analog sticks to prevent unintentional movements.
- **Adjustable Mouse Speed and Acceleration**: Fine-tune mouse movement behavior to suit your preferences.
- **Continuous Input Handling**: Supports holding down buttons to simulate holding down keys or mouse buttons.
- **Multiple Simultaneous Inputs**: Recognizes and handles multiple simultaneous button presses.
- **Configuration Saving and Loading**: Save your custom mappings and settings to a configuration file for easy reuse.

## Getting Started

### Prerequisites

- **Operating System**: Windows 7 or later
- **.NET Framework**: .NET Framework 4.7.2 or later
- **Xbox One Controller**: Connected via USB or Bluetooth
- **Visual Studio** (optional): If you want to build the application from source

### Installation

1. **Download the Latest Release**:

   - Go to the [Releases](https://github.com/The-Ailin/ControllerMapper/releases) page.
   - Download the `Controller.Mapper.v0.0.1.zip` file from the latest release.

2. **Extract the Files**:

   - Extract it to a folder of your choice.

3. **Run the Application**:

   - Double-click `ControllerMapper.exe` to launch the application.

### Building from Source

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/The-Ailin/ControllerMapper.git

2. **Open the Solution in Visual Studio:**
   - Navigate to the project directory.
   - Open the solution file `ControllerMapper.exe` in Visual Studio.

3. **Restore NuGet Packages:**

   - The project uses the following NuGet packages:
        - SharpDX.XInput
        - InputSimulator
   - Visual Studio should automatically restore these packages. If not, restore them via the **NuGet Package Manager:**
        - Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution...
        - Install any missing packages.

4. **Build the Solution:**
   - In Visual Studio, build the solution by pressing `Ctrl+Shift+B` or by selecting Build > Build Solution from the menu.

5. **Run the Application:**
   - Start the application by pressing `F5` or by running the compiled executable from the `bin` directory.

### Usage

1. **Connect Your Xbox One Controller:**
   - Ensure your controller is connected to your PC via USB or Bluetooth.

2. **Launch the Application:**
   - Run `ControllerMapper.exe`.

3. **Configure Mappings:**
   - Controller Buttons:
          - Use the provided ComboBoxes to select controller buttons.
          - Select the keyboard key or mouse button to map to.
          - Click the Set button to assign the mapping.

   - Analog Sticks:
          - The left analog stick is hard-coded to control mouse movement.
          - The right analog stick is hard-coded to control mouse wheel scrolling.

4. **Adjust Settings:**
   - Mouse Speed: Adjust how fast the mouse cursor moves.
   - Mouse Acceleration: Adjust the acceleration factor for mouse movement.
   - Dead Zone: Define the dead zone for analog sticks to prevent unintended movements.
   - Scroll Speed: Adjust the speed of mouse wheel scrolling.

5. **Minimize Application:**
   - The application can be minimized and will continue to run in the background, processing controller inputs.

### Contributing

Contributions are welcome! This is a learner project for me to learn controller mapping, but also to learn how to use Github properly. To contribute:

1. **Fork the Repository:**
   - Click the Fork button at the top of the repository page.

2. **Create a Feature Branch:**

   ```bash
   git checkout -b feature/YourFeatureName

3. **Commit Your Changes:**

   ```bash
   git commit -m "Add YourFeatureName"

4. **Push to Your Fork:**

   ```bash
   git push origin feature/YourFeatureName

5. **Create a Pull Request:**
   - Open a pull request against the main repository.

### License

This project is licensed under the [MIT License](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt).

### Acknowledgments

  - [SharpDX.XInput](https://github.com/sharpdx/SharpDX): For Xbox controller input handling.
  - [InputSimulator](https://github.com/TChatzigiannakis/InputSimulatorPlus): For simulating keyboard and mouse input.
