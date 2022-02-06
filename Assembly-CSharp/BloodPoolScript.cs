using System;
using UnityEngine;

// Token: 0x020000E9 RID: 233
public class BloodPoolScript : MonoBehaviour
{
	// Token: 0x06000A38 RID: 2616 RVA: 0x0005A984 File Offset: 0x00058B84
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

	// Token: 0x06000A39 RID: 2617 RVA: 0x0005AA94 File Offset: 0x00058C94
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

	// Token: 0x06000A3A RID: 2618 RVA: 0x0005AB05 File Offset: 0x00058D05
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodSpawner")
		{
			this.Grow = true;
		}
	}

	// Token: 0x04000B99 RID: 2969
	public float TargetSize;

	// Token: 0x04000B9A RID: 2970
	public bool Blood = true;

	// Token: 0x04000B9B RID: 2971
	public bool Grow;

	// Token: 0x04000B9C RID: 2972
	public Renderer MyRenderer;

	// Token: 0x04000B9D RID: 2973
	public Material BloodPool;

	// Token: 0x04000B9E RID: 2974
	public Material Flower;
}
