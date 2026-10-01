using System;
using UnityEngine;

namespace HNS
{
	public class InputManager : MonoBehaviour
	{
		private static InputManager _instance;

		private static InputState _state;

		private static InputConfig _config;

		private static InputDeviceDetector _deviceDetector;

		public static InputState State => _state;

		public static InputConfig Config => _config;

		public static InputDevice CurrentDevice => _deviceDetector.CurrentDevice;

		public static GamepadType GamepadType => _deviceDetector.GetGamepadType();

		public static bool IsUsingGamepad => CurrentDevice == InputDevice.Gamepad;

		public static bool IsUsingKeyboardMouse => CurrentDevice == InputDevice.KeyboardMouse;

		public static bool IsXboxController => _deviceDetector.IsXboxController();

		public static bool IsPlayStationController => _deviceDetector.IsPlayStationController();

		public static string GamepadName => _deviceDetector.GetGamepadName();

		public static event Action<ButtonInput> OnButtonPressed;

		public static event Action<ButtonInput> OnButtonHeld;

		public static event Action<ButtonInput> OnButtonReleased;

		public static event Action<Vector2> OnMovementChanged;

		public static event Action<Vector2> OnLookChanged;

		public static event Action<InputDevice> OnDeviceChanged;

		private void OnEnable()
		{
			if (_instance != null && _instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			_instance = this;
			_state = new InputState();
			_config = GetComponent<InputConfig>();
			_deviceDetector = new InputDeviceDetector();
			if (_config == null)
			{
				_config = base.gameObject.AddComponent<InputConfig>();
			}
			InputDeviceDetector deviceDetector = _deviceDetector;
			deviceDetector.OnDeviceChanged = (Action<InputDevice>)Delegate.Combine(deviceDetector.OnDeviceChanged, new Action<InputDevice>(HandleDeviceChanged));
		}

		private void OnDisable()
		{
			if (_deviceDetector != null)
			{
				InputDeviceDetector deviceDetector = _deviceDetector;
				deviceDetector.OnDeviceChanged = (Action<InputDevice>)Delegate.Remove(deviceDetector.OnDeviceChanged, new Action<InputDevice>(HandleDeviceChanged));
			}
		}

		private void Update()
		{
			_deviceDetector.Update();
			_state.Update();
			ProcessButtonEvents();
			ProcessAxisEvents();
		}

		private void HandleDeviceChanged(InputDevice newDevice)
		{
			OnDeviceChanged?.Invoke(newDevice);
		}

		private void ProcessButtonEvents()
		{
			foreach (ButtonInput value in Enum.GetValues(typeof(ButtonInput)))
			{
				if (_state.GetButtonDown(value))
				{
					OnButtonPressed?.Invoke(value);
				}
				if (_state.GetButton(value))
				{
					OnButtonHeld?.Invoke(value);
				}
				if (_state.GetButtonUp(value))
				{
					OnButtonReleased?.Invoke(value);
				}
			}
		}

		private void ProcessAxisEvents()
		{
			Vector2 movement = _state.Movement;
			if (movement.sqrMagnitude > 0.01f)
			{
				OnMovementChanged?.Invoke(movement);
			}
			Vector2 look = _state.Look;
			if (look.sqrMagnitude > 0.01f)
			{
				OnLookChanged?.Invoke(look);
			}
		}
	}
}
