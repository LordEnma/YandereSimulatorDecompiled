using System;
using UnityEngine;

// Token: 0x020000E8 RID: 232
public class BloodPoolScript : MonoBehaviour
{
	// Token: 0x06000A35 RID: 2613 RVA: 0x0005A7EC File Offset: 0x000589EC
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
	}

	// Token: 0x06000A36 RID: 2614 RVA: 0x0005A8FC File Offset: 0x00058AFC
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

	// Token: 0x06000A37 RID: 2615 RVA: 0x0005A96D File Offset: 0x00058B6D
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodSpawner")
		{
			this.Grow = true;
		}
	}

	// Token: 0x04000B95 RID: 2965
	public float TargetSize;

	// Token: 0x04000B96 RID: 2966
	public bool Blood = true;

	// Token: 0x04000B97 RID: 2967
	public bool Grow;

	// Token: 0x04000B98 RID: 2968
	public Renderer MyRenderer;

	// Token: 0x04000B99 RID: 2969
	public Material BloodPool;

	// Token: 0x04000B9A RID: 2970
	public Material Flower;
}
