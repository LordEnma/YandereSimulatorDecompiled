using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
	public bool TappedUp;

	public bool TappedDown;

	public bool TappedRight;

	public bool TappedLeft;

	public bool DPadUp;

	public bool DPadDown;

	public bool DPadRight;

	public bool DPadLeft;

	public bool StickUp;

	public bool StickDown;

	public bool StickRight;

	public bool StickLeft;

	private void Update()
	{
		TappedUp = false;
		TappedDown = false;
		TappedRight = false;
		TappedLeft = false;
		if (Input.GetAxisRaw("DpadY") > 0.5f)
		{
			TappedUp = !DPadUp;
			DPadUp = true;
		}
		else if (Input.GetAxisRaw("DpadY") < -0.5f)
		{
			TappedDown = !DPadDown;
			DPadDown = true;
		}
		else
		{
			DPadUp = false;
			DPadDown = false;
		}
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
		{
			if (Input.GetAxisRaw("Vertical") > 0.5f)
			{
				TappedUp = !StickUp;
				StickUp = !TappedDown;
			}
			else if (Input.GetAxisRaw("Vertical") < -0.5f)
			{
				TappedDown = !StickDown;
				StickDown = !TappedUp;
			}
			else
			{
				StickUp = false;
				StickDown = false;
			}
		}
		if (Input.GetAxisRaw("DpadX") > 0.5f)
		{
			TappedRight = !DPadRight;
			DPadRight = true;
		}
		else if (Input.GetAxisRaw("DpadX") < -0.5f)
		{
			TappedLeft = !DPadLeft;
			DPadLeft = true;
		}
		else
		{
			DPadRight = false;
			DPadLeft = false;
		}
		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			if (Input.GetAxisRaw("Horizontal") > 0.5f)
			{
				TappedRight = !StickRight;
				StickRight = true;
			}
			else if (Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				TappedLeft = !StickLeft;
				StickLeft = true;
			}
			else
			{
				StickRight = false;
				StickLeft = false;
			}
		}
		if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f && Input.GetAxisRaw("DpadX") < 0.5f && Input.GetAxisRaw("DpadX") > -0.5f)
		{
			TappedRight = false;
			TappedLeft = false;
		}
		if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f && Input.GetAxisRaw("DpadY") < 0.5f && Input.GetAxisRaw("DpadY") > -0.5f)
		{
			TappedUp = false;
			TappedDown = false;
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			TappedUp = true;
			NoStick();
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			TappedDown = true;
			NoStick();
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			TappedLeft = true;
			NoStick();
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			TappedRight = true;
			NoStick();
		}
	}

	private void NoStick()
	{
		StickUp = false;
		StickDown = false;
		StickLeft = false;
		StickRight = false;
	}
}
