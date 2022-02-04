using System;
using UnityEngine;

// Token: 0x0200021F RID: 543
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vintage")]
public class CameraFilterPack_TV_Vintage : MonoBehaviour
{
	// Token: 0x17000323 RID: 803
	// (get) Token: 0x0600119C RID: 4508 RVA: 0x00088708 File Offset: 0x00086908
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

	// Token: 0x0600119D RID: 4509 RVA: 0x0008873C File Offset: 0x0008693C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vintage");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600119E RID: 4510 RVA: 0x00088760 File Offset: 0x00086960
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

	// Token: 0x0600119F RID: 4511 RVA: 0x000887E6 File Offset: 0x000869E6
	private void Update()
	{
	}

	// Token: 0x060011A0 RID: 4512 RVA: 0x000887E8 File Offset: 0x000869E8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001626 RID: 5670
	public Shader SCShader;

	// Token: 0x04001627 RID: 5671
	private float TimeX = 1f;

	// Token: 0x04001628 RID: 5672
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x04001629 RID: 5673
	private Material SCMaterial;
}
