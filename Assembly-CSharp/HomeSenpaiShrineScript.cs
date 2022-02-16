using System;
using UnityEngine;

// Token: 0x02000324 RID: 804
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x06001898 RID: 6296 RVA: 0x000F1888 File Offset: 0x000EFA88
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

	// Token: 0x06001899 RID: 6297 RVA: 0x000F18C4 File Offset: 0x000EFAC4
	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	// Token: 0x0600189A RID: 6298 RVA: 0x000F18CF File Offset: 0x000EFACF
	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x000F18F8 File Offset: 0x000EFAF8
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

	// Token: 0x0600189C RID: 6300 RVA: 0x000F1CA8 File Offset: 0x000EFEA8
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

	// Token: 0x04002550 RID: 9552
	public InputManagerScript InputManager;

	// Token: 0x04002551 RID: 9553
	public PauseScreenScript PauseScreen;

	// Token: 0x04002552 RID: 9554
	public HomeYandereScript HomeYandere;

	// Token: 0x04002553 RID: 9555
	public HomeCameraScript HomeCamera;

	// Token: 0x04002554 RID: 9556
	public HomeWindowScript HomeWindow;

	// Token: 0x04002555 RID: 9557
	public GameObject[] Collectibles;

	// Token: 0x04002556 RID: 9558
	public Transform[] Destinations;

	// Token: 0x04002557 RID: 9559
	public Transform[] Targets;

	// Token: 0x04002558 RID: 9560
	public Transform RightDoor;

	// Token: 0x04002559 RID: 9561
	public Transform LeftDoor;

	// Token: 0x0400255A RID: 9562
	public UILabel NameLabel;

	// Token: 0x0400255B RID: 9563
	public UILabel DescLabel;

	// Token: 0x0400255C RID: 9564
	public string[] Names;

	// Token: 0x0400255D RID: 9565
	public string[] Descs;

	// Token: 0x0400255E RID: 9566
	public float Rotation;

	// Token: 0x0400255F RID: 9567
	private int Rows = 5;

	// Token: 0x04002560 RID: 9568
	private int Columns = 3;

	// Token: 0x04002561 RID: 9569
	private int X = 1;

	// Token: 0x04002562 RID: 9570
	private int Y = 3;

	// Token: 0x04002563 RID: 9571
	public bool Open;
}
