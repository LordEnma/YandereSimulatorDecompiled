using System;
using UnityEngine;

// Token: 0x020000EA RID: 234
public class BloodPoolScript : MonoBehaviour
{
	// Token: 0x06000A3A RID: 2618 RVA: 0x0005AF58 File Offset: 0x00059158
	private void Start()
	{
		if (PlayerGlobals.PantiesEquipped == 11 && this.Blood)
		{
			this.TargetSize *= 0.5f;
		}
		if (GameGlobals.CensorBlood)
		{
			this.MyRenderer.material = this.Flower;
		}
		if (GameGlobals.Eighties)
		{
			this.TargetSize = 1f;
		}
		base.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		Vector3 position = base.transform.position;
		if (position.x > 125f || position.x < -125f || position.z > 200f || position.z < -100f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (Application.loadedLevelName == "IntroScene" || Application.loadedLevelName == "NewIntroScene")
		{
			this.MyRenderer.material.SetColor("_TintColor", new Color(0.1f, 0.1f, 0.1f));
		}
		if (!this.Blood)
		{
			base.gameObject.layer = 2;
		}
	}

	// Token: 0x06000A3B RID: 2619 RVA: 0x0005B07C File Offset: 0x0005927C
	private void Update()
	{
		if (this.Grow)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(this.TargetSize, this.TargetSize, this.TargetSize), Time.deltaTime);
			if (base.transform.localScale.x > this.TargetSize * 0.99f)
			{
				this.Grow = false;
			}
		}
		if (this.Water && this.ElectroTimer > 0f)
		{
			this.ElectroTimer = Mathf.MoveTowards(this.ElectroTimer, 0f, Time.deltaTime);
		}
	}

	// Token: 0x06000A3C RID: 2620 RVA: 0x0005B120 File Offset: 0x00059320
	private void OnTriggerEnter(Collider other)
	{
		if (this.Water && this.ElectroTimer == 0f && other.gameObject.tag == "E")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Electricity, base.transform.position, Quaternion.identity);
			this.ElectroTimer = 1f;
			if (other.gameObject.name == "CarBattery")
			{
				UnityEngine.Object.Instantiate<GameObject>(other.gameObject.GetComponent<PickUpScript>().PuddleSparks, base.transform.position, Quaternion.identity);
				other.gameObject.GetComponent<PickUpScript>().Smoke.Play();
				other.gameObject.tag = "Untagged";
			}
		}
	}

	// Token: 0x04000BA9 RID: 2985
	public float TargetSize;

	// Token: 0x04000BAA RID: 2986
	public bool Gasoline;

	// Token: 0x04000BAB RID: 2987
	public bool Brown;

	// Token: 0x04000BAC RID: 2988
	public bool Water;

	// Token: 0x04000BAD RID: 2989
	public bool Blood = true;

	// Token: 0x04000BAE RID: 2990
	public bool Grow;

	// Token: 0x04000BAF RID: 2991
	public GameObject Electricity;

	// Token: 0x04000BB0 RID: 2992
	public Renderer MyRenderer;

	// Token: 0x04000BB1 RID: 2993
	public Material BloodPool;

	// Token: 0x04000BB2 RID: 2994
	public Material Flower;

	// Token: 0x04000BB3 RID: 2995
	public float ElectroTimer;

	// Token: 0x04000BB4 RID: 2996
	public int StudentBloodID;
}
