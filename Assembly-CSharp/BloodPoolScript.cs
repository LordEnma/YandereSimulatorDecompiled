using System;
using UnityEngine;

// Token: 0x020000E9 RID: 233
public class BloodPoolScript : MonoBehaviour
{
	// Token: 0x06000A38 RID: 2616 RVA: 0x0005AAC0 File Offset: 0x00058CC0
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

	// Token: 0x06000A39 RID: 2617 RVA: 0x0005ABE4 File Offset: 0x00058DE4
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
	}

	// Token: 0x06000A3A RID: 2618 RVA: 0x0005AC55 File Offset: 0x00058E55
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodSpawner")
		{
			this.Grow = true;
		}
	}

	// Token: 0x04000BA2 RID: 2978
	public float TargetSize;

	// Token: 0x04000BA3 RID: 2979
	public bool Blood = true;

	// Token: 0x04000BA4 RID: 2980
	public bool Grow;

	// Token: 0x04000BA5 RID: 2981
	public Renderer MyRenderer;

	// Token: 0x04000BA6 RID: 2982
	public Material BloodPool;

	// Token: 0x04000BA7 RID: 2983
	public Material Flower;
}
