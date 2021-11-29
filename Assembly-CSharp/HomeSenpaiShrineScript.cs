using System;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x06001881 RID: 6273 RVA: 0x000F0290 File Offset: 0x000EE490
	public void Start()
	{
		this.UpdateText(this.GetCurrentIndex());
		for (int i = 1; i < 11; i++)
		{
			if (PlayerGlobals.GetShrineCollectible(i))
			{
				this.Collectibles[i].SetActive(true);
			}
		}
	}

	// Token: 0x06001882 RID: 6274 RVA: 0x000F02CC File Offset: 0x000EE4CC
	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	// Token: 0x06001883 RID: 6275 RVA: 0x000F02D7 File Offset: 0x000EE4D7
	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
	}

	// Token: 0x06001884 RID: 6276 RVA: 0x000F0300 File Offset: 0x000EE500
	private void Update()
	{
		if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
		{
			if (this.HomeCamera.ID == 6)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 135f, Time.deltaTime * 10f);
				this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
				this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, -this.Rotation, this.LeftDoor.localEulerAngles.z);
				if (this.InputManager.TappedUp)
				{
					this.Y = ((this.Y > 0) ? (this.Y - 1) : (this.Rows - 1));
				}
				if (this.InputManager.TappedDown)
				{
					this.Y = ((this.Y < this.Rows - 1) ? (this.Y + 1) : 0);
				}
				if (this.InputManager.TappedRight && !this.InUpperHalf())
				{
					this.X = ((this.X < this.Columns - 1) ? (this.X + 1) : 0);
				}
				if (this.InputManager.TappedLeft && !this.InUpperHalf())
				{
					this.X = ((this.X > 0) ? (this.X - 1) : (this.Columns - 1));
				}
				if (this.InUpperHalf())
				{
					this.X = 1;
				}
				int currentIndex = this.GetCurrentIndex();
				this.HomeCamera.Destination = this.Destinations[currentIndex];
				this.HomeCamera.Target = this.Targets[currentIndex];
				if (this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight || this.InputManager.TappedLeft)
				{
					this.UpdateText(currentIndex - 1);
				}
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeYandere.CanMove = true;
					this.HomeYandere.gameObject.SetActive(true);
					this.HomeWindow.Show = false;
				}
			}
		}
		else if (!this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
			this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
			this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, this.Rotation, this.LeftDoor.localEulerAngles.z);
		}
		if (this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 135f, Time.deltaTime * 10f);
			this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
			this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, -this.Rotation, this.LeftDoor.localEulerAngles.z);
		}
	}

	// Token: 0x06001885 RID: 6277 RVA: 0x000F06B0 File Offset: 0x000EE8B0
	private void UpdateText(int newIndex)
	{
		if (newIndex == -1)
		{
			newIndex = 10;
		}
		if (newIndex == 0)
		{
			this.NameLabel.text = this.Names[newIndex];
			this.DescLabel.text = this.Descs[newIndex];
			return;
		}
		if (PlayerGlobals.GetShrineCollectible(newIndex))
		{
			this.NameLabel.text = this.Names[newIndex];
			this.DescLabel.text = this.Descs[newIndex];
			return;
		}
		this.NameLabel.text = "???";
		this.DescLabel.text = "I'd like to find something that Senpai touched and keep it here...";
	}

	// Token: 0x04002516 RID: 9494
	public InputManagerScript InputManager;

	// Token: 0x04002517 RID: 9495
	public PauseScreenScript PauseScreen;

	// Token: 0x04002518 RID: 9496
	public HomeYandereScript HomeYandere;

	// Token: 0x04002519 RID: 9497
	public HomeCameraScript HomeCamera;

	// Token: 0x0400251A RID: 9498
	public HomeWindowScript HomeWindow;

	// Token: 0x0400251B RID: 9499
	public GameObject[] Collectibles;

	// Token: 0x0400251C RID: 9500
	public Transform[] Destinations;

	// Token: 0x0400251D RID: 9501
	public Transform[] Targets;

	// Token: 0x0400251E RID: 9502
	public Transform RightDoor;

	// Token: 0x0400251F RID: 9503
	public Transform LeftDoor;

	// Token: 0x04002520 RID: 9504
	public UILabel NameLabel;

	// Token: 0x04002521 RID: 9505
	public UILabel DescLabel;

	// Token: 0x04002522 RID: 9506
	public string[] Names;

	// Token: 0x04002523 RID: 9507
	public string[] Descs;

	// Token: 0x04002524 RID: 9508
	public float Rotation;

	// Token: 0x04002525 RID: 9509
	private int Rows = 5;

	// Token: 0x04002526 RID: 9510
	private int Columns = 3;

	// Token: 0x04002527 RID: 9511
	private int X = 1;

	// Token: 0x04002528 RID: 9512
	private int Y = 3;

	// Token: 0x04002529 RID: 9513
	public bool Open;
}
