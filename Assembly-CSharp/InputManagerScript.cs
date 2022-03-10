using System;
using UnityEngine;

// Token: 0x02000336 RID: 822
public class InputManagerScript : MonoBehaviour
{
	// Token: 0x060018DF RID: 6367 RVA: 0x000F5B78 File Offset: 0x000F3D78
	private void Update()
	{
		this.TappedUp = false;
		this.TappedDown = false;
		this.TappedRight = false;
		this.TappedLeft = false;
		if (Input.GetAxisRaw("DpadY") > 0.5f)
		{
			this.TappedUp = !this.DPadUp;
			this.DPadUp = true;
		}
		else if (Input.GetAxisRaw("DpadY") < -0.5f)
		{
			this.TappedDown = !this.DPadDown;
			this.DPadDown = true;
		}
		else
		{
			this.DPadUp = false;
			this.DPadDown = false;
		}
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
		{
			if (Input.GetAxisRaw("Vertical") > 0.5f)
			{
				this.TappedUp = !this.StickUp;
				this.StickUp = !this.TappedDown;
			}
			else if (Input.GetAxisRaw("Vertical") < -0.5f)
			{
				this.TappedDown = !this.StickDown;
				this.StickDown = !this.TappedUp;
			}
			else
			{
				this.StickUp = false;
				this.StickDown = false;
			}
		}
		if (Input.GetAxisRaw("DpadX") > 0.5f)
		{
			this.TappedRight = !this.DPadRight;
			this.DPadRight = true;
		}
		else if (Input.GetAxisRaw("DpadX") < -0.5f)
		{
			this.TappedLeft = !this.DPadLeft;
			this.DPadLeft = true;
		}
		else
		{
			this.DPadRight = false;
			this.DPadLeft = false;
		}
		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			if (Input.GetAxisRaw("Horizontal") > 0.5f)
			{
				this.TappedRight = !this.StickRight;
				this.StickRight = true;
			}
			else if (Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				this.TappedLeft = !this.StickLeft;
				this.StickLeft = true;
			}
			else
			{
				this.StickRight = false;
				this.StickLeft = false;
			}
		}
		if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f && Input.GetAxisRaw("DpadX") < 0.5f && Input.GetAxisRaw("DpadX") > -0.5f)
		{
			this.TappedRight = false;
			this.TappedLeft = false;
		}
		if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f && Input.GetAxisRaw("DpadY") < 0.5f && Input.GetAxisRaw("DpadY") > -0.5f)
		{
			this.TappedUp = false;
			this.TappedDown = false;
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.TappedUp = true;
			this.NoStick();
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.TappedDown = true;
			this.NoStick();
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			this.TappedLeft = true;
			this.NoStick();
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			this.TappedRight = true;
			this.NoStick();
		}
	}

	// Token: 0x060018E0 RID: 6368 RVA: 0x000F5E81 File Offset: 0x000F4081
	private void NoStick()
	{
		this.StickUp = false;
		this.StickDown = false;
		this.StickLeft = false;
		this.StickRight = false;
	}

	// Token: 0x04002632 RID: 9778
	public bool TappedUp;

	// Token: 0x04002633 RID: 9779
	public bool TappedDown;

	// Token: 0x04002634 RID: 9780
	public bool TappedRight;

	// Token: 0x04002635 RID: 9781
	public bool TappedLeft;

	// Token: 0x04002636 RID: 9782
	public bool DPadUp;

	// Token: 0x04002637 RID: 9783
	public bool DPadDown;

	// Token: 0x04002638 RID: 9784
	public bool DPadRight;

	// Token: 0x04002639 RID: 9785
	public bool DPadLeft;

	// Token: 0x0400263A RID: 9786
	public bool StickUp;

	// Token: 0x0400263B RID: 9787
	public bool StickDown;

	// Token: 0x0400263C RID: 9788
	public bool StickRight;

	// Token: 0x0400263D RID: 9789
	public bool StickLeft;
}
