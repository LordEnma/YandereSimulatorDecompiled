using System;
using UnityEngine;

// Token: 0x020001B1 RID: 433
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Earth Quake")]
public class CameraFilterPack_FX_EarthQuake : MonoBehaviour
{
	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x0007BF67 File Offset: 0x0007A167
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

	// Token: 0x06000EE6 RID: 3814 RVA: 0x0007BF9B File Offset: 0x0007A19B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_EarthQuake");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EE7 RID: 3815 RVA: 0x0007BFBC File Offset: 0x0007A1BC
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
			this.material.SetFloat("_Value2", this.X);
			this.material.SetFloat("_Value3", this.Y);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EE8 RID: 3816 RVA: 0x0007C0B4 File Offset: 0x0007A2B4
	private void Update()
	{
	}

	// Token: 0x06000EE9 RID: 3817 RVA: 0x0007C0B6 File Offset: 0x0007A2B6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400133A RID: 4922
	public Shader SCShader;

	// Token: 0x0400133B RID: 4923
	private float TimeX = 1f;

	// Token: 0x0400133C RID: 4924
	private Material SCMaterial;

	// Token: 0x0400133D RID: 4925
	[Range(0f, 100f)]
	public float Speed = 15f;

	// Token: 0x0400133E RID: 4926
	[Range(0f, 0.2f)]
	public float X = 0.008f;

	// Token: 0x0400133F RID: 4927
	[Range(0f, 0.2f)]
	public float Y = 0.008f;

	// Token: 0x04001340 RID: 4928
	[Range(0f, 0.2f)]
	private float Value4 = 1f;
}
