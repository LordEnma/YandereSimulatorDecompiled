using System;
using UnityEngine;

// Token: 0x02000337 RID: 823
public class InputDeviceScript : MonoBehaviour
{
	// Token: 0x060018F2 RID: 6386 RVA: 0x000F6A28 File Offset: 0x000F4C28
	private void Start()
	{
		this.joystickNames = new string[20];
		for (int i = 0; i < 20; i++)
		{
			this.joystickNames[i] = "joystick 1 button " + i.ToString();
		}
	}

	// Token: 0x060018F3 RID: 6387 RVA: 0x000F6A68 File Offset: 0x000F4C68
	private void Update()
	{
		this.MouseDelta = Input.mousePosition - this.MousePrevious;
		this.MousePrevious = Input.mousePosition;
		InputDeviceType type = this.Type;
		if ((Input.GetJoystickNames().Length == 0 && Input.anyKey) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || this.MouseDelta != Vector3.zero)
		{
			this.Type = InputDeviceType.MouseAndKeyboard;
		}
		else
		{
			bool flag = false;
			for (int i = 0; i < 20; i++)
			{
				if (Input.GetKey(this.joystickNames[i]))
				{
					flag = true;
					break;
				}
			}
			bool flag2 = Math.Abs(Input.GetAxis("DpadX")) > 0.5f || Math.Abs(Input.GetAxis("DpadY")) > 0.5f;
			bool flag3 = Mathf.Abs(Input.GetAxis("Vertical")) == 1f || Mathf.Abs(Input.GetAxis("Horizontal")) == 1f;
			if (flag || flag2 || flag3)
			{
				this.Type = InputDeviceType.Gamepad;
			}
		}
		if (this.Type != type)
		{
			PromptSwapScript[] array = Resources.FindObjectsOfTypeAll<PromptSwapScript>();
			for (int j = 0; j < array.Length; j++)
			{
				array[j].UpdateSpriteType(this.Type);
			}
		}
		this.Horizontal = Input.GetAxis("Horizontal");
		this.Vertical = Input.GetAxis("Vertical");
	}

	// Token: 0x04002660 RID: 9824
	public InputDeviceType Type = InputDeviceType.Gamepad;

	// Token: 0x04002661 RID: 9825
	public Vector3 MousePrevious;

	// Token: 0x04002662 RID: 9826
	public Vector3 MouseDelta;

	// Token: 0x04002663 RID: 9827
	public float Horizontal;

	// Token: 0x04002664 RID: 9828
	public float Vertical;

	// Token: 0x04002665 RID: 9829
	public string[] joystickNames;
}
