using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x060018A1 RID: 6305 RVA: 0x000F24A4 File Offset: 0x000F06A4
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

	// Token: 0x060018A2 RID: 6306 RVA: 0x000F24E0 File Offset: 0x000F06E0
	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x000F24EB File Offset: 0x000F06EB
	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000F2514 File Offset: 0x000F0714
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

	// Token: 0x060018A5 RID: 6309 RVA: 0x000F28C4 File Offset: 0x000F0AC4
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

	// Token: 0x04002573 RID: 9587
	public InputManagerScript InputManager;

	// Token: 0x04002574 RID: 9588
	public PauseScreenScript PauseScreen;

	// Token: 0x04002575 RID: 9589
	public HomeYandereScript HomeYandere;

	// Token: 0x04002576 RID: 9590
	public HomeCameraScript HomeCamera;

	// Token: 0x04002577 RID: 9591
	public HomeWindowScript HomeWindow;

	// Token: 0x04002578 RID: 9592
	public GameObject[] Collectibles;

	// Token: 0x04002579 RID: 9593
	public Transform[] Destinations;

	// Token: 0x0400257A RID: 9594
	public Transform[] Targets;

	// Token: 0x0400257B RID: 9595
	public Transform RightDoor;

	// Token: 0x0400257C RID: 9596
	public Transform LeftDoor;

	// Token: 0x0400257D RID: 9597
	public UILabel NameLabel;

	// Token: 0x0400257E RID: 9598
	public UILabel DescLabel;

	// Token: 0x0400257F RID: 9599
	public string[] Names;

	// Token: 0x04002580 RID: 9600
	public string[] Descs;

	// Token: 0x04002581 RID: 9601
	public float Rotation;

	// Token: 0x04002582 RID: 9602
	private int Rows = 5;

	// Token: 0x04002583 RID: 9603
	private int Columns = 3;

	// Token: 0x04002584 RID: 9604
	private int X = 1;

	// Token: 0x04002585 RID: 9605
	private int Y = 3;

	// Token: 0x04002586 RID: 9606
	public bool Open;
}
