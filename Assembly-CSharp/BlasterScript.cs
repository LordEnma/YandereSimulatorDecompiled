using System;
using UnityEngine;

// Token: 0x020000E3 RID: 227
public class BlasterScript : MonoBehaviour
{
	// Token: 0x06000A27 RID: 2599 RVA: 0x0005A157 File Offset: 0x00058357
	private void Start()
	{
		this.Skull.localScale = Vector3.zero;
		this.Beam.localScale = Vector3.zero;
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x0005A17C File Offset: 0x0005837C
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

	// Token: 0x06000A29 RID: 2601 RVA: 0x0005A224 File Offset: 0x00058424
	private void LateUpdate()
	{
		AnimationState animationState = base.GetComponent<Animation>()["Blast"];
		this.Size = ((animationState.time < 1.5f) ? Mathf.Lerp(this.Size, 2f, Time.deltaTime * 5f) : Mathf.Lerp(this.Size, 0f, Time.deltaTime * 10f));
		this.Skull.localScale = new Vector3(this.Size, this.Size, this.Size);
	}

	// Token: 0x04000B7B RID: 2939
	public Transform Skull;

	// Token: 0x04000B7C RID: 2940
	public Renderer Eyes;

	// Token: 0x04000B7D RID: 2941
	public Transform Beam;

	// Token: 0x04000B7E RID: 2942
	public float Size;
}
