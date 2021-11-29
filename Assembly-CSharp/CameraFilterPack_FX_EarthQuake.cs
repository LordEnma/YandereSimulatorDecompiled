using System;
using UnityEngine;

// Token: 0x020001B0 RID: 432
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Earth Quake")]
public class CameraFilterPack_FX_EarthQuake : MonoBehaviour
{
	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x0007BD6F File Offset: 0x00079F6F
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

	// Token: 0x06000EE3 RID: 3811 RVA: 0x0007BDA3 File Offset: 0x00079FA3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_EarthQuake");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x0007BDC4 File Offset: 0x00079FC4
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

	// Token: 0x06000EE5 RID: 3813 RVA: 0x0007BEBC File Offset: 0x0007A0BC
	private void Update()
	{
	}

	// Token: 0x06000EE6 RID: 3814 RVA: 0x0007BEBE File Offset: 0x0007A0BE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001335 RID: 4917
	public Shader SCShader;

	// Token: 0x04001336 RID: 4918
	private float TimeX = 1f;

	// Token: 0x04001337 RID: 4919
	private Material SCMaterial;

	// Token: 0x04001338 RID: 4920
	[Range(0f, 100f)]
	public float Speed = 15f;

	// Token: 0x04001339 RID: 4921
	[Range(0f, 0.2f)]
	public float X = 0.008f;

	// Token: 0x0400133A RID: 4922
	[Range(0f, 0.2f)]
	public float Y = 0.008f;

	// Token: 0x0400133B RID: 4923
	[Range(0f, 0.2f)]
	private float Value4 = 1f;
}
