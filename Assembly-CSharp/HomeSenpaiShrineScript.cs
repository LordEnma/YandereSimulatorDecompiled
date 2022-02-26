using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x060018A1 RID: 6305 RVA: 0x000F216C File Offset: 0x000F036C
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

	// Token: 0x060018A2 RID: 6306 RVA: 0x000F21A8 File Offset: 0x000F03A8
	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x000F21B3 File Offset: 0x000F03B3
	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000F21DC File Offset: 0x000F03DC
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

	// Token: 0x060018A5 RID: 6309 RVA: 0x000F258C File Offset: 0x000F078C
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

	// Token: 0x0400255F RID: 9567
	public InputManagerScript InputManager;

	// Token: 0x04002560 RID: 9568
	public PauseScreenScript PauseScreen;

	// Token: 0x04002561 RID: 9569
	public HomeYandereScript HomeYandere;

	// Token: 0x04002562 RID: 9570
	public HomeCameraScript HomeCamera;

	// Token: 0x04002563 RID: 9571
	public HomeWindowScript HomeWindow;

	// Token: 0x04002564 RID: 9572
	public GameObject[] Collectibles;

	// Token: 0x04002565 RID: 9573
	public Transform[] Destinations;

	// Token: 0x04002566 RID: 9574
	public Transform[] Targets;

	// Token: 0x04002567 RID: 9575
	public Transform RightDoor;

	// Token: 0x04002568 RID: 9576
	public Transform LeftDoor;

	// Token: 0x04002569 RID: 9577
	public UILabel NameLabel;

	// Token: 0x0400256A RID: 9578
	public UILabel DescLabel;

	// Token: 0x0400256B RID: 9579
	public string[] Names;

	// Token: 0x0400256C RID: 9580
	public string[] Descs;

	// Token: 0x0400256D RID: 9581
	public float Rotation;

	// Token: 0x0400256E RID: 9582
	private int Rows = 5;

	// Token: 0x0400256F RID: 9583
	private int Columns = 3;

	// Token: 0x04002570 RID: 9584
	private int X = 1;

	// Token: 0x04002571 RID: 9585
	private int Y = 3;

	// Token: 0x04002572 RID: 9586
	public bool Open;
}
