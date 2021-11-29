using System;
using UnityEngine;

// Token: 0x0200031E RID: 798
public class HomePantyChangerScript : MonoBehaviour
{
	// Token: 0x06001875 RID: 6261 RVA: 0x000EE534 File Offset: 0x000EC734
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

	// Token: 0x06001876 RID: 6262 RVA: 0x000EE700 File Offset: 0x000EC900
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

	// Token: 0x06001877 RID: 6263 RVA: 0x000EE9D0 File Offset: 0x000ECBD0
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

	// Token: 0x040024AE RID: 9390
	public InputManagerScript InputManager;

	// Token: 0x040024AF RID: 9391
	public HomeYandereScript HomeYandere;

	// Token: 0x040024B0 RID: 9392
	public HomeCameraScript HomeCamera;

	// Token: 0x040024B1 RID: 9393
	public HomeWindowScript HomeWindow;

	// Token: 0x040024B2 RID: 9394
	private GameObject NewPanties;

	// Token: 0x040024B3 RID: 9395
	public UILabel PantyNameLabel;

	// Token: 0x040024B4 RID: 9396
	public UILabel PantyDescLabel;

	// Token: 0x040024B5 RID: 9397
	public UILabel PantyBuffLabel;

	// Token: 0x040024B6 RID: 9398
	public UILabel ButtonLabel;

	// Token: 0x040024B7 RID: 9399
	public Transform PantyParent;

	// Token: 0x040024B8 RID: 9400
	public bool DestinationReached;

	// Token: 0x040024B9 RID: 9401
	public float TargetRotation;

	// Token: 0x040024BA RID: 9402
	public float Rotation;

	// Token: 0x040024BB RID: 9403
	public int TotalPanties;

	// Token: 0x040024BC RID: 9404
	public int Selected;

	// Token: 0x040024BD RID: 9405
	public GameObject[] PantyModels;

	// Token: 0x040024BE RID: 9406
	public string[] PantyNames;

	// Token: 0x040024BF RID: 9407
	public string[] PantyDescs;

	// Token: 0x040024C0 RID: 9408
	public string[] PantyBuffs;

	// Token: 0x040024C1 RID: 9409
	public AudioClip ChangeSelection;

	// Token: 0x040024C2 RID: 9410
	public AudioClip MakeSelection;

	// Token: 0x040024C3 RID: 9411
	public AudioClip CloseDrawer;
}
