using System;
using System.Collections.Generic;
using System.Threading;
using SlimDX;
using SlimDX.DirectInput;

public class JoystickHandler : IDisposable
{
    private DirectInput directInput;
    private List<Joystick> joysticks;

    public JoystickHandler()
    {
        directInput = new DirectInput();
        joysticks = new List<Joystick>();

        // Find all connected joysticks
        var joystickGuids = directInput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly);

        // Initialize Joystick objects for each connected joystick
        foreach (var deviceInstance in joystickGuids)
        {
            var joystick = new Joystick(directInput, deviceInstance.InstanceGuid);
            joystick.Acquire(); // Acquire the joystick
            joysticks.Add(joystick);
        }
    }

    public void HandleInput(Action<Guid, int> buttonPressedCallback, CancellationToken cancellationToken)
    {
        // Dictionary to keep track of the debounce state for each button on each joystick
        Dictionary<Guid, Dictionary<int, bool>> debounceStates = new Dictionary<Guid, Dictionary<int, bool>>();

        while (true)
        {
            foreach (var joystick in joysticks)
            {
                joystick.Poll();
                var state = joystick.GetCurrentState();
                var buttonState = state.GetButtons();

                for (int i = 0; i < buttonState.Length; i++)
                {
                    bool isPressed = buttonState[i];

                    // Initialize debounce state for this joystick and button if not already done
                    if (!debounceStates.ContainsKey(joystick.Information.InstanceGuid))
                    {
                        debounceStates[joystick.Information.InstanceGuid] = new Dictionary<int, bool>();
                    }

                    // Check if the button state changed and debounce time has passed
                    if (isPressed && (!debounceStates[joystick.Information.InstanceGuid].ContainsKey(i) || !debounceStates[joystick.Information.InstanceGuid][i]))
                    {
                        // Button is pressed and not debounced yet
                        buttonPressedCallback?.Invoke(joystick.Information.InstanceGuid, i);
                        debounceStates[joystick.Information.InstanceGuid][i] = true; // Set debounce flag
                    }
                    else if (!isPressed)
                    {
                        // Button is released, reset debounce state
                        debounceStates[joystick.Information.InstanceGuid][i] = false;
                    }
                }
            }

            // Check for cancellation
            if (cancellationToken.IsCancellationRequested)
            {
                // Exit the loop if cancellation is requested
                break;
            }

            // Wait for a short time before polling again
            System.Threading.Thread.Sleep(100);
        }
    }



    public void Dispose()
    {
        // Check if the DirectInput object is not null and dispose it
        if (directInput != null)
        {
            directInput.Dispose();
            directInput = null; // Set to null to indicate that it's disposed
        }

        // Dispose each joystick in the list
        foreach (var joystick in joysticks)
        {
            joystick.Unacquire();
            joystick.Dispose();
        }
        // Clear the list of joysticks
        joysticks.Clear();
    }
}
