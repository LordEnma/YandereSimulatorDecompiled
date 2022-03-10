using System;
using UnityEngine;

// Token: 0x0200021F RID: 543
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vintage")]
public class CameraFilterPack_TV_Vintage : MonoBehaviour
{
	// Token: 0x17000323 RID: 803
	// (get) Token: 0x0600119D RID: 4509 RVA: 0x00088AB4 File Offset: 0x00086CB4
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x0600119E RID: 4510 RVA: 0x00088AE8 File Offset: 0x00086CE8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vintage");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600119F RID: 4511 RVA: 0x00088B0C File Offset: 0x00086D0C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Distortion", this.Distortion);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011A0 RID: 4512 RVA: 0x00088B92 File Offset: 0x00086D92
	private void Update()
	{
	}

	// Token: 0x060011A1 RID: 4513 RVA: 0x00088B94 File Offset: 0x00086D94
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001632 RID: 5682
	public Shader SCShader;

	// Token: 0x04001633 RID: 5683
	private float TimeX = 1f;

	// Token: 0x04001634 RID: 5684
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x04001635 RID: 5685
	private Material SCMaterial;
}
