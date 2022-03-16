using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x060018A6 RID: 6310 RVA: 0x000F2964 File Offset: 0x000F0B64
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

	// Token: 0x060018A7 RID: 6311 RVA: 0x000F29A0 File Offset: 0x000F0BA0
	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x000F29AB File Offset: 0x000F0BAB
	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
	}

	// Token: 0x060018A9 RID: 6313 RVA: 0x000F29D4 File Offset: 0x000F0BD4
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

	// Token: 0x060018AA RID: 6314 RVA: 0x000F2D84 File Offset: 0x000F0F84
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

	// Token: 0x04002584 RID: 9604
	public InputManagerScript InputManager;

	// Token: 0x04002585 RID: 9605
	public PauseScreenScript PauseScreen;

	// Token: 0x04002586 RID: 9606
	public HomeYandereScript HomeYandere;

	// Token: 0x04002587 RID: 9607
	public HomeCameraScript HomeCamera;

	// Token: 0x04002588 RID: 9608
	public HomeWindowScript HomeWindow;

	// Token: 0x04002589 RID: 9609
	public GameObject[] Collectibles;

	// Token: 0x0400258A RID: 9610
	public Transform[] Destinations;

	// Token: 0x0400258B RID: 9611
	public Transform[] Targets;

	// Token: 0x0400258C RID: 9612
	public Transform RightDoor;

	// Token: 0x0400258D RID: 9613
	public Transform LeftDoor;

	// Token: 0x0400258E RID: 9614
	public UILabel NameLabel;

	// Token: 0x0400258F RID: 9615
	public UILabel DescLabel;

	// Token: 0x04002590 RID: 9616
	public string[] Names;

	// Token: 0x04002591 RID: 9617
	public string[] Descs;

	// Token: 0x04002592 RID: 9618
	public float Rotation;

	// Token: 0x04002593 RID: 9619
	private int Rows = 5;

	// Token: 0x04002594 RID: 9620
	private int Columns = 3;

	// Token: 0x04002595 RID: 9621
	private int X = 1;

	// Token: 0x04002596 RID: 9622
	private int Y = 3;

	// Token: 0x04002597 RID: 9623
	public bool Open;
}
