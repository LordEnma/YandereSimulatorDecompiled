using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomePantyChangerScript : MonoBehaviour
{
	// Token: 0x060018B3 RID: 6323 RVA: 0x000F1D2C File Offset: 0x000EFF2C
	private void Start()
	{
		for (int i = 0; i < this.TotalPanties; i++)
		{
			this.NewPanties = UnityEngine.Object.Instantiate<GameObject>(this.PantyModels[i], new Vector3(base.transform.position.x, base.transform.position.y - 0.85f, base.transform.position.z - 1f), Quaternion.identity);
			this.NewPanties.transform.parent = this.PantyParent;
			this.NewPanties.GetComponent<HomePantiesScript>().PantyChanger = this;
			this.NewPanties.GetComponent<HomePantiesScript>().ID = i;
			this.PantyParent.transform.localEulerAngles = new Vector3(this.PantyParent.transform.localEulerAngles.x, this.PantyParent.transform.localEulerAngles.y + 360f / (float)this.TotalPanties, this.PantyParent.transform.localEulerAngles.z);
		}
		this.PantyParent.transform.localEulerAngles = new Vector3(this.PantyParent.transform.localEulerAngles.x, 0f, this.PantyParent.transform.localEulerAngles.z);
		this.PantyParent.transform.localPosition = new Vector3(this.PantyParent.transform.localPosition.x, this.PantyParent.transform.localPosition.y, 1.8f);
		this.UpdatePantyLabels();
		this.PantyParent.transform.localScale = Vector3.zero;
		this.PantyParent.gameObject.SetActive(false);
	}

	// Token: 0x060018B4 RID: 6324 RVA: 0x000F1EF8 File Offset: 0x000F00F8
	private void Update()
	{
		if (this.HomeWindow.Show)
		{
			this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.PantyParent.gameObject.SetActive(true);
			if (this.InputManager.TappedRight)
			{
				this.DestinationReached = false;
				this.TargetRotation += 360f / (float)this.TotalPanties;
				this.Selected++;
				if (this.Selected > this.TotalPanties - 1)
				{
					this.Selected = 0;
				}
				AudioSource.PlayClipAtPoint(this.ChangeSelection, base.transform.position);
				this.UpdatePantyLabels();
			}
			if (this.InputManager.TappedLeft)
			{
				this.DestinationReached = false;
				this.TargetRotation -= 360f / (float)this.TotalPanties;
				this.Selected--;
				if (this.Selected < 0)
				{
					this.Selected = this.TotalPanties - 1;
				}
				AudioSource.PlayClipAtPoint(this.ChangeSelection, base.transform.position);
				this.UpdatePantyLabels();
			}
			this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 10f);
			this.PantyParent.localEulerAngles = new Vector3(this.PantyParent.localEulerAngles.x, this.Rotation, this.PantyParent.localEulerAngles.z);
			if (Input.GetButtonDown("A"))
			{
				if (this.Selected == 0 || CollectibleGlobals.GetPantyPurchased(this.Selected))
				{
					PlayerGlobals.PantiesEquipped = this.Selected;
					Debug.Log("Yandere-chan should now be equipped with Panties #" + PlayerGlobals.PantiesEquipped.ToString());
					AudioSource.PlayClipAtPoint(this.MakeSelection, base.transform.position);
				}
				else
				{
					Debug.Log("Yandere-chan doesn't own those panties.");
				}
				this.UpdatePantyLabels();
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeYandere.CanMove = true;
				this.HomeWindow.Show = false;
				AudioSource.PlayClipAtPoint(this.CloseDrawer, base.transform.position);
				return;
			}
		}
		else
		{
			this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, Vector3.zero, Time.deltaTime * 10f);
			if (this.PantyParent.localScale.x < 0.01f)
			{
				this.PantyParent.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x060018B5 RID: 6325 RVA: 0x000F21C8 File Offset: 0x000F03C8
	private void UpdatePantyLabels()
	{
		if (this.Selected == 0 || CollectibleGlobals.GetPantyPurchased(this.Selected))
		{
			this.PantyNameLabel.text = this.PantyNames[this.Selected];
			this.PantyDescLabel.text = this.PantyDescs[this.Selected];
			this.PantyBuffLabel.text = this.PantyBuffs[this.Selected];
		}
		else
		{
			this.PantyNameLabel.text = "?????";
			this.PantyBuffLabel.text = "?????";
			if (this.Selected < 11)
			{
				this.PantyDescLabel.text = "Unlock these panties by going shopping in town at night!";
			}
			else
			{
				this.PantyDescLabel.text = "Unlock these panties by locating them and picking them up!";
			}
		}
		if (this.Selected == 0 || CollectibleGlobals.GetPantyPurchased(this.Selected))
		{
			this.ButtonLabel.text = ((this.Selected == PlayerGlobals.PantiesEquipped) ? "Equipped" : "Wear");
			return;
		}
		this.ButtonLabel.text = "Unavailable";
	}

	// Token: 0x0400254E RID: 9550
	public InputManagerScript InputManager;

	// Token: 0x0400254F RID: 9551
	public HomeYandereScript HomeYandere;

	// Token: 0x04002550 RID: 9552
	public HomeCameraScript HomeCamera;

	// Token: 0x04002551 RID: 9553
	public HomeWindowScript HomeWindow;

	// Token: 0x04002552 RID: 9554
	private GameObject NewPanties;

	// Token: 0x04002553 RID: 9555
	public UILabel PantyNameLabel;

	// Token: 0x04002554 RID: 9556
	public UILabel PantyDescLabel;

	// Token: 0x04002555 RID: 9557
	public UILabel PantyBuffLabel;

	// Token: 0x04002556 RID: 9558
	public UILabel ButtonLabel;

	// Token: 0x04002557 RID: 9559
	public Transform PantyParent;

	// Token: 0x04002558 RID: 9560
	public bool DestinationReached;

	// Token: 0x04002559 RID: 9561
	public float TargetRotation;

	// Token: 0x0400255A RID: 9562
	public float Rotation;

	// Token: 0x0400255B RID: 9563
	public int TotalPanties;

	// Token: 0x0400255C RID: 9564
	public int Selected;

	// Token: 0x0400255D RID: 9565
	public GameObject[] PantyModels;

	// Token: 0x0400255E RID: 9566
	public string[] PantyNames;

	// Token: 0x0400255F RID: 9567
	public string[] PantyDescs;

	// Token: 0x04002560 RID: 9568
	public string[] PantyBuffs;

	// Token: 0x04002561 RID: 9569
	public AudioClip ChangeSelection;

	// Token: 0x04002562 RID: 9570
	public AudioClip MakeSelection;

	// Token: 0x04002563 RID: 9571
	public AudioClip CloseDrawer;
}
