using System;
using UnityEngine;

// Token: 0x02000322 RID: 802
public class HomePantyChangerScript : MonoBehaviour
{
	// Token: 0x06001895 RID: 6293 RVA: 0x000F0410 File Offset: 0x000EE610
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

	// Token: 0x06001896 RID: 6294 RVA: 0x000F05DC File Offset: 0x000EE7DC
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

	// Token: 0x06001897 RID: 6295 RVA: 0x000F08AC File Offset: 0x000EEAAC
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

	// Token: 0x040024F7 RID: 9463
	public InputManagerScript InputManager;

	// Token: 0x040024F8 RID: 9464
	public HomeYandereScript HomeYandere;

	// Token: 0x040024F9 RID: 9465
	public HomeCameraScript HomeCamera;

	// Token: 0x040024FA RID: 9466
	public HomeWindowScript HomeWindow;

	// Token: 0x040024FB RID: 9467
	private GameObject NewPanties;

	// Token: 0x040024FC RID: 9468
	public UILabel PantyNameLabel;

	// Token: 0x040024FD RID: 9469
	public UILabel PantyDescLabel;

	// Token: 0x040024FE RID: 9470
	public UILabel PantyBuffLabel;

	// Token: 0x040024FF RID: 9471
	public UILabel ButtonLabel;

	// Token: 0x04002500 RID: 9472
	public Transform PantyParent;

	// Token: 0x04002501 RID: 9473
	public bool DestinationReached;

	// Token: 0x04002502 RID: 9474
	public float TargetRotation;

	// Token: 0x04002503 RID: 9475
	public float Rotation;

	// Token: 0x04002504 RID: 9476
	public int TotalPanties;

	// Token: 0x04002505 RID: 9477
	public int Selected;

	// Token: 0x04002506 RID: 9478
	public GameObject[] PantyModels;

	// Token: 0x04002507 RID: 9479
	public string[] PantyNames;

	// Token: 0x04002508 RID: 9480
	public string[] PantyDescs;

	// Token: 0x04002509 RID: 9481
	public string[] PantyBuffs;

	// Token: 0x0400250A RID: 9482
	public AudioClip ChangeSelection;

	// Token: 0x0400250B RID: 9483
	public AudioClip MakeSelection;

	// Token: 0x0400250C RID: 9484
	public AudioClip CloseDrawer;
}
