using System;
using UnityEngine;

// Token: 0x020001DB RID: 475
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Water")]
public class CameraFilterPack_Light_Water : MonoBehaviour
{
	// Token: 0x170002DF RID: 735
	// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x000807E8 File Offset: 0x0007E9E8
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

	// Token: 0x06000FE3 RID: 4067 RVA: 0x0008081C File Offset: 0x0007EA1C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Water");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FE4 RID: 4068 RVA: 0x00080840 File Offset: 0x0007EA40
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime * this.Speed;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Alpha", this.Alpha);
			this.material.SetFloat("_Distance", this.Distance);
			this.material.SetFloat("_Size", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FE5 RID: 4069 RVA: 0x00080929 File Offset: 0x0007EB29
	private void Update()
	{
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x0008092B File Offset: 0x0007EB2B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400145C RID: 5212
	public Shader SCShader;

	// Token: 0x0400145D RID: 5213
	private float TimeX = 1f;

	// Token: 0x0400145E RID: 5214
	private Material SCMaterial;

	// Token: 0x0400145F RID: 5215
	[Range(0f, 1f)]
	public float Size = 4f;

	// Token: 0x04001460 RID: 5216
	[Range(0f, 2f)]
	public float Alpha = 0.07f;

	// Token: 0x04001461 RID: 5217
	[Range(0f, 32f)]
	public float Distance = 10f;

	// Token: 0x04001462 RID: 5218
	[Range(-2f, 2f)]
	public float Speed = 0.4f;
}
