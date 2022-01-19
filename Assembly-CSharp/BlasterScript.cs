using System;
using UnityEngine;

// Token: 0x020000E4 RID: 228
public class BlasterScript : MonoBehaviour
{
	// Token: 0x06000A2A RID: 2602 RVA: 0x0005A2EF File Offset: 0x000584EF
	private void Start()
	{
		this.Skull.localScale = Vector3.zero;
		this.Beam.localScale = Vector3.zero;
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x0005A314 File Offset: 0x00058514
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

	// Token: 0x06000A2C RID: 2604 RVA: 0x0005A3BC File Offset: 0x000585BC
	private void LateUpdate()
	{
		AnimationState animationState = base.GetComponent<Animation>()["Blast"];
		this.Size = ((animationState.time < 1.5f) ? Mathf.Lerp(this.Size, 2f, Time.deltaTime * 5f) : Mathf.Lerp(this.Size, 0f, Time.deltaTime * 10f));
		this.Skull.localScale = new Vector3(this.Size, this.Size, this.Size);
	}

	// Token: 0x04000B7E RID: 2942
	public Transform Skull;

	// Token: 0x04000B7F RID: 2943
	public Renderer Eyes;

	// Token: 0x04000B80 RID: 2944
	public Transform Beam;

	// Token: 0x04000B81 RID: 2945
	public float Size;
}
