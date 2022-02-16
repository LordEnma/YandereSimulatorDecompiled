using System;
using UnityEngine;

// Token: 0x020001DC RID: 476
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Water2")]
public class CameraFilterPack_Light_Water2 : MonoBehaviour
{
	// Token: 0x170002E0 RID: 736
	// (get) Token: 0x06000FE8 RID: 4072 RVA: 0x00080728 File Offset: 0x0007E928
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

	// Token: 0x06000FE9 RID: 4073 RVA: 0x0008075C File Offset: 0x0007E95C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Water2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FEA RID: 4074 RVA: 0x00080780 File Offset: 0x0007E980
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Speed_X);
			this.material.SetFloat("_Value3", this.Speed_Y);
			this.material.SetFloat("_Value4", this.Intensity);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FEB RID: 4075 RVA: 0x00080878 File Offset: 0x0007EA78
	private void Update()
	{
	}

	// Token: 0x06000FEC RID: 4076 RVA: 0x0008087A File Offset: 0x0007EA7A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400145A RID: 5210
	public Shader SCShader;

	// Token: 0x0400145B RID: 5211
	private float TimeX = 1f;

	// Token: 0x0400145C RID: 5212
	private Material SCMaterial;

	// Token: 0x0400145D RID: 5213
	[Range(0f, 10f)]
	public float Speed = 0.2f;

	// Token: 0x0400145E RID: 5214
	[Range(0f, 10f)]
	public float Speed_X = 0.2f;

	// Token: 0x0400145F RID: 5215
	[Range(0f, 1f)]
	public float Speed_Y = 0.3f;

	// Token: 0x04001460 RID: 5216
	[Range(0f, 10f)]
	public float Intensity = 2.4f;
}
