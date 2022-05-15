using System;
using UnityEngine;

// Token: 0x020000E5 RID: 229
public class BlasterScript : MonoBehaviour
{
	// Token: 0x06000A2C RID: 2604 RVA: 0x0005A8C3 File Offset: 0x00058AC3
	private void Start()
	{
		this.Skull.localScale = Vector3.zero;
		this.Beam.localScale = Vector3.zero;
	}

	// Token: 0x06000A2D RID: 2605 RVA: 0x0005A8E8 File Offset: 0x00058AE8
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()["Blast"];
		if (animationState.time > 1f)
		{
			this.Beam.localScale = Vector3.Lerp(this.Beam.localScale, new Vector3(15f, 1f, 1f), Time.deltaTime * 10f);
			this.Eyes.material.color = new Color(1f, 0f, 0f, 1f);
		}
		if (animationState.time >= animationState.length)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06000A2E RID: 2606 RVA: 0x0005A990 File Offset: 0x00058B90
	private void LateUpdate()
	{
		AnimationState animationState = base.GetComponent<Animation>()["Blast"];
		this.Size = ((animationState.time < 1.5f) ? Mathf.Lerp(this.Size, 2f, Time.deltaTime * 5f) : Mathf.Lerp(this.Size, 0f, Time.deltaTime * 10f));
		this.Skull.localScale = new Vector3(this.Size, this.Size, this.Size);
	}

	// Token: 0x04000B8F RID: 2959
	public Transform Skull;

	// Token: 0x04000B90 RID: 2960
	public Renderer Eyes;

	// Token: 0x04000B91 RID: 2961
	public Transform Beam;

	// Token: 0x04000B92 RID: 2962
	public float Size;
}
