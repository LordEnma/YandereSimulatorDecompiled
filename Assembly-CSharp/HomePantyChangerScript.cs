using System;
using UnityEngine;

// Token: 0x02000322 RID: 802
public class HomePantyChangerScript : MonoBehaviour
{
	// Token: 0x0600189A RID: 6298 RVA: 0x000F0C08 File Offset: 0x000EEE08
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

	// Token: 0x0600189B RID: 6299 RVA: 0x000F0DD4 File Offset: 0x000EEFD4
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

	// Token: 0x0600189C RID: 6300 RVA: 0x000F10A4 File Offset: 0x000EF2A4
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

	// Token: 0x0400251C RID: 9500
	public InputManagerScript InputManager;

	// Token: 0x0400251D RID: 9501
	public HomeYandereScript HomeYandere;

	// Token: 0x0400251E RID: 9502
	public HomeCameraScript HomeCamera;

	// Token: 0x0400251F RID: 9503
	public HomeWindowScript HomeWindow;

	// Token: 0x04002520 RID: 9504
	private GameObject NewPanties;

	// Token: 0x04002521 RID: 9505
	public UILabel PantyNameLabel;

	// Token: 0x04002522 RID: 9506
	public UILabel PantyDescLabel;

	// Token: 0x04002523 RID: 9507
	public UILabel PantyBuffLabel;

	// Token: 0x04002524 RID: 9508
	public UILabel ButtonLabel;

	// Token: 0x04002525 RID: 9509
	public Transform PantyParent;

	// Token: 0x04002526 RID: 9510
	public bool DestinationReached;

	// Token: 0x04002527 RID: 9511
	public float TargetRotation;

	// Token: 0x04002528 RID: 9512
	public float Rotation;

	// Token: 0x04002529 RID: 9513
	public int TotalPanties;

	// Token: 0x0400252A RID: 9514
	public int Selected;

	// Token: 0x0400252B RID: 9515
	public GameObject[] PantyModels;

	// Token: 0x0400252C RID: 9516
	public string[] PantyNames;

	// Token: 0x0400252D RID: 9517
	public string[] PantyDescs;

	// Token: 0x0400252E RID: 9518
	public string[] PantyBuffs;

	// Token: 0x0400252F RID: 9519
	public AudioClip ChangeSelection;

	// Token: 0x04002530 RID: 9520
	public AudioClip MakeSelection;

	// Token: 0x04002531 RID: 9521
	public AudioClip CloseDrawer;
}
