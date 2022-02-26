using System;
using UnityEngine;

// Token: 0x02000122 RID: 290
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Rain")]
public class CameraFilterPack_Atmosphere_Rain : MonoBehaviour
{
	// Token: 0x17000226 RID: 550
	// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0006BF9B File Offset: 0x0006A19B
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

	// Token: 0x06000B4B RID: 2891 RVA: 0x0006BFCF File Offset: 0x0006A1CF
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Atmosphere_Rain_FX") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Atmosphere_Rain");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B4C RID: 2892 RVA: 0x0006C008 File Offset: 0x0006A208
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B4D RID: 2893 RVA: 0x0006C158 File Offset: 0x0006A358
	private void Update()
	{
	}

	// Token: 0x06000B4E RID: 2894 RVA: 0x0006C15A File Offset: 0x0006A35A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F52 RID: 3922
	public Shader SCShader;

	// Token: 0x04000F53 RID: 3923
	private float TimeX = 1f;

	// Token: 0x04000F54 RID: 3924
	private Material SCMaterial;

	// Token: 0x04000F55 RID: 3925
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F56 RID: 3926
	[Range(0f, 2f)]
	public float Intensity = 0.5f;

	// Token: 0x04000F57 RID: 3927
	[Range(-0.25f, 0.25f)]
	public float DirectionX = 0.12f;

	// Token: 0x04000F58 RID: 3928
	[Range(0.4f, 2f)]
	public float Size = 1.5f;

	// Token: 0x04000F59 RID: 3929
	[Range(0f, 0.5f)]
	public float Speed = 0.275f;

	// Token: 0x04000F5A RID: 3930
	[Range(0f, 0.5f)]
	public float Distortion = 0.05f;

	// Token: 0x04000F5B RID: 3931
	[Range(0f, 1f)]
	public float StormFlashOnOff = 1f;

	// Token: 0x04000F5C RID: 3932
	private Texture2D Texture2;
}
