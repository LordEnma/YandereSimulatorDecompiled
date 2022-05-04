using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x060018BA RID: 6330 RVA: 0x000F3824 File Offset: 0x000F1A24
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

	// Token: 0x060018BB RID: 6331 RVA: 0x000F3860 File Offset: 0x000F1A60
	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	// Token: 0x060018BC RID: 6332 RVA: 0x000F386B File Offset: 0x000F1A6B
	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
	}

	// Token: 0x060018BD RID: 6333 RVA: 0x000F3894 File Offset: 0x000F1A94
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

	// Token: 0x060018BE RID: 6334 RVA: 0x000F3C44 File Offset: 0x000F1E44
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

	// Token: 0x040025AB RID: 9643
	public InputManagerScript InputManager;

	// Token: 0x040025AC RID: 9644
	public PauseScreenScript PauseScreen;

	// Token: 0x040025AD RID: 9645
	public HomeYandereScript HomeYandere;

	// Token: 0x040025AE RID: 9646
	public HomeCameraScript HomeCamera;

	// Token: 0x040025AF RID: 9647
	public HomeWindowScript HomeWindow;

	// Token: 0x040025B0 RID: 9648
	public GameObject[] Collectibles;

	// Token: 0x040025B1 RID: 9649
	public Transform[] Destinations;

	// Token: 0x040025B2 RID: 9650
	public Transform[] Targets;

	// Token: 0x040025B3 RID: 9651
	public Transform RightDoor;

	// Token: 0x040025B4 RID: 9652
	public Transform LeftDoor;

	// Token: 0x040025B5 RID: 9653
	public UILabel NameLabel;

	// Token: 0x040025B6 RID: 9654
	public UILabel DescLabel;

	// Token: 0x040025B7 RID: 9655
	public string[] Names;

	// Token: 0x040025B8 RID: 9656
	public string[] Descs;

	// Token: 0x040025B9 RID: 9657
	public float Rotation;

	// Token: 0x040025BA RID: 9658
	private int Rows = 5;

	// Token: 0x040025BB RID: 9659
	private int Columns = 3;

	// Token: 0x040025BC RID: 9660
	private int X = 1;

	// Token: 0x040025BD RID: 9661
	private int Y = 3;

	// Token: 0x040025BE RID: 9662
	public bool Open;
}
