using System;
using UnityEngine;

// Token: 0x020000E9 RID: 233
public class BloodPoolScript : MonoBehaviour
{
	// Token: 0x06000A38 RID: 2616 RVA: 0x0005AB84 File Offset: 0x00058D84
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

	// Token: 0x06000A39 RID: 2617 RVA: 0x0005ACA8 File Offset: 0x00058EA8
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

	// Token: 0x06000A3A RID: 2618 RVA: 0x0005AD4C File Offset: 0x00058F4C
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

	// Token: 0x04000BA3 RID: 2979
	public float TargetSize;

	// Token: 0x04000BA4 RID: 2980
	public bool Gasoline;

	// Token: 0x04000BA5 RID: 2981
	public bool Brown;

	// Token: 0x04000BA6 RID: 2982
	public bool Water;

	// Token: 0x04000BA7 RID: 2983
	public bool Blood = true;

	// Token: 0x04000BA8 RID: 2984
	public bool Grow;

	// Token: 0x04000BA9 RID: 2985
	public GameObject Electricity;

	// Token: 0x04000BAA RID: 2986
	public Renderer MyRenderer;

	// Token: 0x04000BAB RID: 2987
	public Material BloodPool;

	// Token: 0x04000BAC RID: 2988
	public Material Flower;

	// Token: 0x04000BAD RID: 2989
	public float ElectroTimer;
}
