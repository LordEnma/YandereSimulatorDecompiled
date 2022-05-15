using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x060018BF RID: 6335 RVA: 0x000F3B24 File Offset: 0x000F1D24
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

	// Token: 0x060018C0 RID: 6336 RVA: 0x000F3B60 File Offset: 0x000F1D60
	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	// Token: 0x060018C1 RID: 6337 RVA: 0x000F3B6B File Offset: 0x000F1D6B
	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
	}

	// Token: 0x060018C2 RID: 6338 RVA: 0x000F3B94 File Offset: 0x000F1D94
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

	// Token: 0x060018C3 RID: 6339 RVA: 0x000F3F44 File Offset: 0x000F2144
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

	// Token: 0x040025B6 RID: 9654
	public InputManagerScript InputManager;

	// Token: 0x040025B7 RID: 9655
	public PauseScreenScript PauseScreen;

	// Token: 0x040025B8 RID: 9656
	public HomeYandereScript HomeYandere;

	// Token: 0x040025B9 RID: 9657
	public HomeCameraScript HomeCamera;

	// Token: 0x040025BA RID: 9658
	public HomeWindowScript HomeWindow;

	// Token: 0x040025BB RID: 9659
	public GameObject[] Collectibles;

	// Token: 0x040025BC RID: 9660
	public Transform[] Destinations;

	// Token: 0x040025BD RID: 9661
	public Transform[] Targets;

	// Token: 0x040025BE RID: 9662
	public Transform RightDoor;

	// Token: 0x040025BF RID: 9663
	public Transform LeftDoor;

	// Token: 0x040025C0 RID: 9664
	public UILabel NameLabel;

	// Token: 0x040025C1 RID: 9665
	public UILabel DescLabel;

	// Token: 0x040025C2 RID: 9666
	public string[] Names;

	// Token: 0x040025C3 RID: 9667
	public string[] Descs;

	// Token: 0x040025C4 RID: 9668
	public float Rotation;

	// Token: 0x040025C5 RID: 9669
	private int Rows = 5;

	// Token: 0x040025C6 RID: 9670
	private int Columns = 3;

	// Token: 0x040025C7 RID: 9671
	private int X = 1;

	// Token: 0x040025C8 RID: 9672
	private int Y = 3;

	// Token: 0x040025C9 RID: 9673
	public bool Open;
}
