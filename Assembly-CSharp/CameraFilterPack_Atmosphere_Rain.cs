using System;
using UnityEngine;

// Token: 0x02000121 RID: 289
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Rain")]
public class CameraFilterPack_Atmosphere_Rain : MonoBehaviour
{
	// Token: 0x17000226 RID: 550
	// (get) Token: 0x06000B46 RID: 2886 RVA: 0x0006BB3F File Offset: 0x00069D3F
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

	// Token: 0x06000B47 RID: 2887 RVA: 0x0006BB73 File Offset: 0x00069D73
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

	// Token: 0x06000B48 RID: 2888 RVA: 0x0006BBAC File Offset: 0x00069DAC
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

	// Token: 0x06000B49 RID: 2889 RVA: 0x0006BCFC File Offset: 0x00069EFC
	private void Update()
	{
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x0006BCFE File Offset: 0x00069EFE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F4A RID: 3914
	public Shader SCShader;

	// Token: 0x04000F4B RID: 3915
	private float TimeX = 1f;

	// Token: 0x04000F4C RID: 3916
	private Material SCMaterial;

	// Token: 0x04000F4D RID: 3917
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F4E RID: 3918
	[Range(0f, 2f)]
	public float Intensity = 0.5f;

	// Token: 0x04000F4F RID: 3919
	[Range(-0.25f, 0.25f)]
	public float DirectionX = 0.12f;

	// Token: 0x04000F50 RID: 3920
	[Range(0.4f, 2f)]
	public float Size = 1.5f;

	// Token: 0x04000F51 RID: 3921
	[Range(0f, 0.5f)]
	public float Speed = 0.275f;

	// Token: 0x04000F52 RID: 3922
	[Range(0f, 0.5f)]
	public float Distortion = 0.05f;

	// Token: 0x04000F53 RID: 3923
	[Range(0f, 1f)]
	public float StormFlashOnOff = 1f;

	// Token: 0x04000F54 RID: 3924
	private Texture2D Texture2;
}
