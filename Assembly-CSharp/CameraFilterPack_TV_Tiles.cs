using System;
using UnityEngine;

// Token: 0x02000218 RID: 536
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Tiles")]
public class CameraFilterPack_TV_Tiles : MonoBehaviour
{
	// Token: 0x1700031C RID: 796
	// (get) Token: 0x06001173 RID: 4467 RVA: 0x000880DC File Offset: 0x000862DC
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

	// Token: 0x06001174 RID: 4468 RVA: 0x00088110 File Offset: 0x00086310
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Tiles");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001175 RID: 4469 RVA: 0x00088134 File Offset: 0x00086334
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001176 RID: 4470 RVA: 0x00088242 File Offset: 0x00086442
	private void Update()
	{
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x00088244 File Offset: 0x00086444
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400160B RID: 5643
	public Shader SCShader;

	// Token: 0x0400160C RID: 5644
	private float TimeX = 1f;

	// Token: 0x0400160D RID: 5645
	private Material SCMaterial;

	// Token: 0x0400160E RID: 5646
	[Range(0.5f, 2f)]
	public float Size = 1f;

	// Token: 0x0400160F RID: 5647
	[Range(0f, 10f)]
	public float Intensity = 4f;

	// Token: 0x04001610 RID: 5648
	[Range(0f, 1f)]
	public float StretchX = 0.6f;

	// Token: 0x04001611 RID: 5649
	[Range(0f, 1f)]
	public float StretchY = 0.4f;

	// Token: 0x04001612 RID: 5650
	[Range(0f, 1f)]
	public float Fade = 0.6f;
}
