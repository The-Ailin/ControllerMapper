using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using Newtonsoft.Json;
using SharpDX.XInput;
using WindowsInput;
using WindowsInput.Native;

namespace ControllerMapper
{
    public partial class MainForm : Form
    {
        private Controller controller;
        private InputSimulator inputSimulator;
        private float mouseSpeed = 10f;
        private float accelerationFactor = 2f;
        private float deadZone = 0.1f;
        private float scrollSpeed = 1f;
        private float accumulatedScrollVertical = 0f;
        private float accumulatedScrollHorizontal = 0f;
        private Dictionary<GamepadInput, InputAction> inputMappings = new Dictionary<GamepadInput, InputAction>();
        private HashSet<GamepadInput> pressedInputs = new HashSet<GamepadInput>();
        private const byte TriggerThreshold = 30;
        private string filePath = @"config.json";
        private System.Timers.Timer inputTimer;

        public MainForm()
        {
            InitializeComponent();
            numericUpDownMouseSpeed.ValueChanged += NumericUpDownMouseSpeed_ValueChanged;
            numericUpDownMouseAcceleration.ValueChanged += NumericUpDownMouseAcceleration_ValueChanged;
            numericUpDownDeadZone.ValueChanged += NumericUpDownDeadZone_ValueChanged;
            numericUpDownScrollSpeed.ValueChanged += NumericUpDownScrollSpeed_ValueChanged;
            cbController.DataSource = Enum.GetValues(typeof(GamepadInput));
            PopulateKeyboardMouseComboBox();
            controller = new Controller(UserIndex.One);
            inputSimulator = new InputSimulator();
            InitializeMappings();
            SetupTimer();
        }

        private void InitializeMappings()
        {
            if (!File.Exists(filePath))
            {
                SaveConfiguration(filePath);
            }
            LoadConfiguration(filePath);
        }

        private void SetupTimer()
        {
            inputTimer = new System.Timers.Timer();
            inputTimer.Interval = 10; // Poll every 10 ms
            inputTimer.Elapsed += InputTimer_Elapsed;
            inputTimer.AutoReset = true;
            inputTimer.Start();
        }

        private void InputTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!controller.IsConnected)
                return;

            State state = controller.GetState();
            Gamepad gamepad = state.Gamepad;

            // Handle inputs on the background thread
            HandleControllerInputs(gamepad);
        }

        private void HandleControllerInputs(Gamepad gamepad)
        {
            // Handle button presses
            HandleButtonPresses(gamepad);

            // Handle analog sticks
            HandleAnalogStick(gamepad);
            HandleRightAnalogStick(gamepad);
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!controller.IsConnected)
                return;

            State state = controller.GetState();
            Gamepad gamepad = state.Gamepad;

            HandleButtonPresses(gamepad);
            HandleAnalogStick(gamepad);
            HandleRightAnalogStick(gamepad);
        }
        private void MouseButtonDown(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton:
                    inputSimulator.Mouse.LeftButtonDown();
                    break;
                case MouseButton.RightButton:
                    inputSimulator.Mouse.RightButtonDown();
                    break;
                case MouseButton.MiddleButton:
                    inputSimulator.Mouse.MiddleButtonDown();
                    break;
                case MouseButton.XButton1:
                    inputSimulator.Mouse.XButtonDown(1);
                    break;
                case MouseButton.XButton2:
                    inputSimulator.Mouse.XButtonDown(2);
                    break;
            }
        }

        private void MouseButtonUp(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton:
                    inputSimulator.Mouse.LeftButtonUp();
                    break;
                case MouseButton.RightButton:
                    inputSimulator.Mouse.RightButtonUp();
                    break;
                case MouseButton.MiddleButton:
                    inputSimulator.Mouse.MiddleButtonUp();
                    break;
                case MouseButton.XButton1:
                    inputSimulator.Mouse.XButtonUp(1);
                    break;
                case MouseButton.XButton2:
                    inputSimulator.Mouse.XButtonUp(2);
                    break;
            }
        }

        private void NumericUpDownMouseSpeed_ValueChanged(object sender, EventArgs e)
        {
            mouseSpeed = (float)numericUpDownMouseSpeed.Value;
            SaveConfiguration(filePath);
        }

        private void NumericUpDownMouseAcceleration_ValueChanged(object sender, EventArgs e)
        {
            accelerationFactor = (float)numericUpDownMouseAcceleration.Value;
            SaveConfiguration(filePath);
        }

        private void NumericUpDownDeadZone_ValueChanged(object sender, EventArgs e)
        {
            deadZone = (float)numericUpDownDeadZone.Value;
            SaveConfiguration(filePath);
        }

        private void NumericUpDownScrollSpeed_ValueChanged(object sender, EventArgs e)
        {
            scrollSpeed = (float)numericUpDownScrollSpeed.Value;
            SaveConfiguration(filePath);
        }


        private void HandleButtonPresses(Gamepad gamepad)
        {
            foreach (var mapping in inputMappings)
            {
                var input = mapping.Key;
                var inputAction = mapping.Value;
                bool isPressed = false;

                // Determine if the input is pressed
                switch (input)
                {
                    // Handle buttons
                    case GamepadInput.ButtonA:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.A) != 0;
                        break;
                    case GamepadInput.ButtonB:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.B) != 0;
                        break;
                    case GamepadInput.ButtonX:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.X) != 0;
                        break;
                    case GamepadInput.ButtonY:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.Y) != 0;
                        break;
                    case GamepadInput.DPadDown:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.DPadDown) != 0;
                        break;
                    case GamepadInput.DPadUp:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.DPadUp) != 0;
                        break;
                    case GamepadInput.DPadLeft:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.DPadLeft) != 0;
                        break;
                    case GamepadInput.DPadRight:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.DPadRight) != 0;
                        break;
                    case GamepadInput.Back:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.Back) != 0;
                        break;
                    case GamepadInput.Start:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.Start) != 0;
                        break;
                    case GamepadInput.LeftShoulder:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.LeftShoulder) != 0;
                        break;
                    case GamepadInput.RightShoulder:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.RightShoulder) != 0;
                        break;
                    case GamepadInput.LeftThumb:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.LeftThumb) != 0;
                        break;
                    case GamepadInput.RightThumb:
                        isPressed = (gamepad.Buttons & GamepadButtonFlags.RightThumb) != 0;
                        break;

                    // Handle triggers
                    case GamepadInput.LeftTrigger:
                        isPressed = gamepad.LeftTrigger > TriggerThreshold;
                        break;
                    case GamepadInput.RightTrigger:
                        isPressed = gamepad.RightTrigger > TriggerThreshold;
                        break;
                }

                if (isPressed)
                {
                    if (!pressedInputs.Contains(input))
                    {
                        // Key down or mouse button down event
                        switch (inputAction.ActionType)
                        {
                            case ActionType.KeyboardKey:
                                inputSimulator.Keyboard.KeyDown(inputAction.KeyCode);
                                break;
                            case ActionType.MouseButton:
                                MouseButtonDown(inputAction.MouseButton);
                                break;
                        }
                        pressedInputs.Add(input);
                    }
                }
                else
                {
                    if (pressedInputs.Contains(input))
                    {
                        // Key up or mouse button up event
                        switch (inputAction.ActionType)
                        {
                            case ActionType.KeyboardKey:
                                inputSimulator.Keyboard.KeyUp(inputAction.KeyCode);
                                break;
                            case ActionType.MouseButton:
                                MouseButtonUp(inputAction.MouseButton);
                                break;
                        }
                        pressedInputs.Remove(input);
                    }
                }
            }
        }
        private void HandleAnalogStick(Gamepad gamepad)
        {
            // Normalize the stick values between -1 and 1
            float normLX = NormalizeAxis(gamepad.LeftThumbX);
            float normLY = NormalizeAxis(gamepad.LeftThumbY);

            // Apply dead zones
            if (Math.Abs(normLX) < deadZone) normLX = 0;
            if (Math.Abs(normLY) < deadZone) normLY = 0;

            // Apply acceleration
            float accelLX = ApplyAcceleration(normLX);
            float accelLY = ApplyAcceleration(normLY);

            // Calculate mouse movement
            int moveX = (int)(accelLX * mouseSpeed);
            int moveY = (int)(-accelLY * mouseSpeed); // Invert Y-axis

            if (moveX != 0 || moveY != 0)
            {
                inputSimulator.Mouse.MoveMouseBy(moveX, moveY);
            }
        }
        private float NormalizeAxis(short value)
        {
            float norm = 0;

            if (value < 0)
                norm = (float)value / 32768f;
            else
                norm = (float)value / 32767f;

            // Apply dead zone
            if (Math.Abs(norm) < deadZone)
                norm = 0;

            return norm;
        }

        private float ApplyAcceleration(float value)
        {
            return value * Math.Abs(value) * accelerationFactor;
        }

        private void SaveConfiguration(string filePath)
        {
            Configuration config = new Configuration
            {
                MouseSpeed = mouseSpeed,
                AccelerationFactor = accelerationFactor,
                DeadZone = deadZone,
                ScrollSpeed = scrollSpeed,
                InputMappings = inputMappings
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void LoadConfiguration(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            string json = File.ReadAllText(filePath);
            Configuration config = JsonConvert.DeserializeObject<Configuration>(json);

            mouseSpeed = config.MouseSpeed;
            numericUpDownMouseSpeed.Value = (decimal)config.MouseSpeed;
            accelerationFactor = config.AccelerationFactor;
            numericUpDownMouseAcceleration.Value = (decimal)config.AccelerationFactor;
            deadZone = config.DeadZone;
            numericUpDownDeadZone.Value = (decimal)config.DeadZone;
            scrollSpeed = config.ScrollSpeed;
            numericUpDownScrollSpeed.Value = (decimal)config.ScrollSpeed;
            inputMappings = config.InputMappings;
        }

        private void PopulateKeyboardMouseComboBox()
        {
            var inputActionItems = new List<InputActionItem>();

            // Add commonly used keyboard keys
            var commonKeys = new VirtualKeyCode[]
            {
                VirtualKeyCode.VK_A, VirtualKeyCode.VK_B, VirtualKeyCode.VK_C,
                VirtualKeyCode.VK_D, VirtualKeyCode.VK_E, VirtualKeyCode.VK_F,
                VirtualKeyCode.VK_G, VirtualKeyCode.VK_H, VirtualKeyCode.VK_I,
                VirtualKeyCode.VK_J, VirtualKeyCode.VK_K, VirtualKeyCode.VK_L,
                VirtualKeyCode.VK_M, VirtualKeyCode.VK_N, VirtualKeyCode.VK_O,
                VirtualKeyCode.VK_P, VirtualKeyCode.VK_Q, VirtualKeyCode.VK_R,
                VirtualKeyCode.VK_S, VirtualKeyCode.VK_T, VirtualKeyCode.VK_U,
                VirtualKeyCode.VK_V, VirtualKeyCode.VK_W, VirtualKeyCode.VK_X,
                VirtualKeyCode.VK_Y, VirtualKeyCode.VK_Z, VirtualKeyCode.VK_0, 
                VirtualKeyCode.VK_1, VirtualKeyCode.VK_2, VirtualKeyCode.VK_3, 
                VirtualKeyCode.VK_4, VirtualKeyCode.VK_5, VirtualKeyCode.VK_6, 
                VirtualKeyCode.VK_7, VirtualKeyCode.VK_8, VirtualKeyCode.VK_9, 
                VirtualKeyCode.SPACE, VirtualKeyCode.RETURN, VirtualKeyCode.ESCAPE, 
                VirtualKeyCode.TAB, VirtualKeyCode.SHIFT, VirtualKeyCode.CONTROL, 
                VirtualKeyCode.SUBTRACT, VirtualKeyCode.ADD, VirtualKeyCode.UP,
                VirtualKeyCode.RIGHT, VirtualKeyCode.DOWN, VirtualKeyCode.LEFT, 
                VirtualKeyCode.BROWSER_BACK, VirtualKeyCode.BROWSER_FORWARD, VirtualKeyCode.VOLUME_DOWN,
                VirtualKeyCode.VOLUME_UP, VirtualKeyCode.VOLUME_MUTE
            };

            foreach (var keyCode in commonKeys)
            {
                inputActionItems.Add(new InputActionItem
                {
                    ActionType = ActionType.KeyboardKey,
                    KeyCode = keyCode,
                    DisplayName = $"Key: {GetKeyDisplayName(keyCode)}"
                });
            }

            // Add mouse buttons
            foreach (MouseButton mouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                inputActionItems.Add(new InputActionItem
                {
                    ActionType = ActionType.MouseButton,
                    MouseButton = mouseButton,
                    DisplayName = $"Mouse: {mouseButton}"
                });
            }

            cbMnK.DataSource = inputActionItems;
            cbMnK.DisplayMember = "DisplayName";
            cbMnK.ValueMember = "KeyCode";
        }

        private string GetKeyDisplayName(VirtualKeyCode keyCode)
        {
            // Handle common prefixes like VK_A, VK_1, etc.
            string name = keyCode.ToString();

            if (name.StartsWith("VK_"))
            {
                // Remove the VK_ prefix to display simple letter keys
                return name.Substring(3);
            }

            // Handle specific special keys that should be displayed more clearly
            switch (keyCode)
            {
                case VirtualKeyCode.RETURN:
                    return "Enter";
                case VirtualKeyCode.SPACE:
                    return "Space";
                case VirtualKeyCode.TAB:
                    return "Tab";
                case VirtualKeyCode.ESCAPE:
                    return "Escape";
                case VirtualKeyCode.SHIFT:
                    return "Shift";
                case VirtualKeyCode.CONTROL:
                    return "Ctrl";
                case VirtualKeyCode.MENU:
                    return "Alt";
                case VirtualKeyCode.LEFT:
                    return "Left Arrow";
                case VirtualKeyCode.RIGHT:
                    return "Right Arrow";
                case VirtualKeyCode.UP:
                    return "Up Arrow";
                case VirtualKeyCode.DOWN:
                    return "Down Arrow";
                // Add more special cases if needed
                default:
                    return name; // Return the default string if no special case is found
            }
        }


        private void buttonSet_Click(object sender, EventArgs e)
        {
            // Get selected controller button
            if (cbController.SelectedItem is GamepadInput selectedControllerInput)
            {
                // Get selected input action
                if (cbMnK.SelectedItem is InputActionItem selectedInputAction)
                {
                    // Create an InputAction object
                    InputAction inputAction = new InputAction
                    {
                        ActionType = selectedInputAction.ActionType,
                        KeyCode = selectedInputAction.KeyCode,
                        MouseButton = selectedInputAction.MouseButton
                    };

                    // Update the inputMappings dictionary
                    if (inputMappings.ContainsKey(selectedControllerInput))
                    {
                        inputMappings[selectedControllerInput] = inputAction;
                    }
                    else
                    {
                        inputMappings.Add(selectedControllerInput, inputAction);
                    }

                    MessageBox.Show($"Mapped {selectedControllerInput} to {selectedInputAction.DisplayName}");

                    SaveConfiguration(filePath);
                }
                else
                {
                    MessageBox.Show("Please select a valid keyboard key or mouse button.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid controller button.");
            }
        }

        private void HandleRightAnalogStick(Gamepad gamepad)
        {
            // Get the raw input values
            float normRX = NormalizeAxis(gamepad.RightThumbX);
            float normRY = NormalizeAxis(gamepad.RightThumbY);

            // Apply dead zones (if needed)
            if (Math.Abs(normRX) < deadZone) normRX = 0;
            if (Math.Abs(normRY) < deadZone) normRY = 0;

            // Proceed if there's input beyond the dead zone
            if (normRX != 0 || normRY != 0)
            {
                // Handle scrolling based on input
                HandleMouseWheelScrolling(normRX, normRY);
            }
        }

        private void HandleMouseWheelScrolling(float normRX, float normRY)
        {
            // Introduce a scaling factor to reduce sensitivity
            float scalingFactor = 0.1f; // Adjust this value as needed (try 0.01f for even finer control)

            // Calculate scroll amounts
            float scrollAmountVertical = -normRY * scrollSpeed * scalingFactor;
            float scrollAmountHorizontal = normRX * scrollSpeed * scalingFactor;

            // Accumulate scroll amounts
            accumulatedScrollVertical += scrollAmountVertical;
            accumulatedScrollHorizontal += scrollAmountHorizontal;

            // Check if accumulated scroll amounts have reached a whole number
            int scrollUnitsVertical = (int)accumulatedScrollVertical;
            int scrollUnitsHorizontal = (int)accumulatedScrollHorizontal;

            // Perform scrolling if we have accumulated enough
            if (scrollUnitsVertical != 0)
            {
                inputSimulator.Mouse.VerticalScroll(-scrollUnitsVertical);
                accumulatedScrollVertical -= scrollUnitsVertical;
            }

            if (scrollUnitsHorizontal != 0)
            {
                inputSimulator.Mouse.HorizontalScroll(scrollUnitsHorizontal);
                accumulatedScrollHorizontal -= scrollUnitsHorizontal;
            }
        }
    }

    public enum ActionType
    {
        KeyboardKey,
        MouseButton
    }

    public enum MouseButton
    {
        LeftButton,
        RightButton,
        MiddleButton,
        XButton1,
        XButton2
    }

    public class InputAction
    {
        public ActionType ActionType { get; set; }
        public VirtualKeyCode KeyCode { get; set; } // For keyboard keys
        public MouseButton MouseButton { get; set; } // For mouse buttons
    }

    public enum GamepadInput
    {
        ButtonA,
        ButtonB,
        ButtonX,
        ButtonY,
        LeftShoulder,
        RightShoulder,
        LeftThumb,
        RightThumb,
        DPadUp,
        DPadDown,
        DPadLeft,
        DPadRight,
        Start,
        Back,
        LeftTrigger,
        RightTrigger
    }

    public class Configuration
    {
        public float MouseSpeed { get; set; }
        public float AccelerationFactor { get; set; }
        public float DeadZone { get; set; }
        public float ScrollSpeed { get; set; }
        public Dictionary<GamepadInput, InputAction> InputMappings { get; set; }
    }

    public class InputActionItem
    {
        public ActionType ActionType { get; set; }
        public VirtualKeyCode KeyCode { get; set; }
        public MouseButton MouseButton { get; set; }
        public string DisplayName { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}