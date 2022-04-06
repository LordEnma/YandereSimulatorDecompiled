using System;
using UnityEngine;

// Token: 0x02000122 RID: 290
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Rain")]
public class CameraFilterPack_Atmosphere_Rain : MonoBehaviour
{
	// Token: 0x17000226 RID: 550
	// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0006C55F File Offset: 0x0006A75F
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

	// Token: 0x06000B4D RID: 2893 RVA: 0x0006C593 File Offset: 0x0006A793
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

	// Token: 0x06000B4E RID: 2894 RVA: 0x0006C5CC File Offset: 0x0006A7CC
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

	// Token: 0x06000B4F RID: 2895 RVA: 0x0006C71C File Offset: 0x0006A91C
	private void Update()
	{
	}

	// Token: 0x06000B50 RID: 2896 RVA: 0x0006C71E File Offset: 0x0006A91E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F62 RID: 3938
	public Shader SCShader;

	// Token: 0x04000F63 RID: 3939
	private float TimeX = 1f;

	// Token: 0x04000F64 RID: 3940
	private Material SCMaterial;

	// Token: 0x04000F65 RID: 3941
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F66 RID: 3942
	[Range(0f, 2f)]
	public float Intensity = 0.5f;

	// Token: 0x04000F67 RID: 3943
	[Range(-0.25f, 0.25f)]
	public float DirectionX = 0.12f;

	// Token: 0x04000F68 RID: 3944
	[Range(0.4f, 2f)]
	public float Size = 1.5f;

	// Token: 0x04000F69 RID: 3945
	[Range(0f, 0.5f)]
	public float Speed = 0.275f;

	// Token: 0x04000F6A RID: 3946
	[Range(0f, 0.5f)]
	public float Distortion = 0.05f;

	// Token: 0x04000F6B RID: 3947
	[Range(0f, 1f)]
	public float StormFlashOnOff = 1f;

	// Token: 0x04000F6C RID: 3948
	private Texture2D Texture2;
}
