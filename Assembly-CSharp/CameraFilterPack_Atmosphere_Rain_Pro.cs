using System;
using UnityEngine;

// Token: 0x02000123 RID: 291
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Rain_Pro")]
public class CameraFilterPack_Atmosphere_Rain_Pro : MonoBehaviour
{
	// Token: 0x17000227 RID: 551
	// (get) Token: 0x06000B50 RID: 2896 RVA: 0x0006C1DF File Offset: 0x0006A3DF
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

	// Token: 0x06000B51 RID: 2897 RVA: 0x0006C213 File Offset: 0x0006A413
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Atmosphere_Rain_FX") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Atmosphere_Rain_Pro");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B52 RID: 2898 RVA: 0x0006C24C File Offset: 0x0006A44C
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
			this.material.SetFloat("_Value", this.Fade);
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value3", this.DirectionX);
			this.material.SetFloat("_Value4", this.Speed);
			this.material.SetFloat("_Value5", this.Size);
			this.material.SetFloat("_Value6", this.Distortion);
			this.material.SetFloat("_Value7", this.StormFlashOnOff);
			this.material.SetFloat("_Value8", this.DropOnOff);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B53 RID: 2899 RVA: 0x0006C3B2 File Offset: 0x0006A5B2
	private void Update()
	{
	}

	// Token: 0x06000B54 RID: 2900 RVA: 0x0006C3B4 File Offset: 0x0006A5B4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F5D RID: 3933
	public Shader SCShader;

	// Token: 0x04000F5E RID: 3934
	private float TimeX = 1f;

	// Token: 0x04000F5F RID: 3935
	private Material SCMaterial;

	// Token: 0x04000F60 RID: 3936
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F61 RID: 3937
	[Range(0f, 2f)]
	public float Intensity = 0.5f;

	// Token: 0x04000F62 RID: 3938
	[Range(-0.25f, 0.25f)]
	public float DirectionX = 0.12f;

	// Token: 0x04000F63 RID: 3939
	[Range(0.4f, 2f)]
	public float Size = 1.5f;

	// Token: 0x04000F64 RID: 3940
	[Range(0f, 0.5f)]
	public float Speed = 0.275f;

	// Token: 0x04000F65 RID: 3941
	[Range(0f, 0.5f)]
	public float Distortion = 0.025f;

	// Token: 0x04000F66 RID: 3942
	[Range(0f, 1f)]
	public float StormFlashOnOff = 1f;

	// Token: 0x04000F67 RID: 3943
	[Range(0f, 1f)]
	public float DropOnOff = 1f;

	// Token: 0x04000F68 RID: 3944
	private Texture2D Texture2;
}
