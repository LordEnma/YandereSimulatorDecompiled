using System;
using UnityEngine;

// Token: 0x02000123 RID: 291
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Rain_Pro")]
public class CameraFilterPack_Atmosphere_Rain_Pro : MonoBehaviour
{
	// Token: 0x17000227 RID: 551
	// (get) Token: 0x06000B52 RID: 2898 RVA: 0x0006C7A3 File Offset: 0x0006A9A3
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

	// Token: 0x06000B53 RID: 2899 RVA: 0x0006C7D7 File Offset: 0x0006A9D7
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

	// Token: 0x06000B54 RID: 2900 RVA: 0x0006C810 File Offset: 0x0006AA10
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

	// Token: 0x06000B55 RID: 2901 RVA: 0x0006C976 File Offset: 0x0006AB76
	private void Update()
	{
	}

	// Token: 0x06000B56 RID: 2902 RVA: 0x0006C978 File Offset: 0x0006AB78
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F6D RID: 3949
	public Shader SCShader;

	// Token: 0x04000F6E RID: 3950
	private float TimeX = 1f;

	// Token: 0x04000F6F RID: 3951
	private Material SCMaterial;

	// Token: 0x04000F70 RID: 3952
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F71 RID: 3953
	[Range(0f, 2f)]
	public float Intensity = 0.5f;

	// Token: 0x04000F72 RID: 3954
	[Range(-0.25f, 0.25f)]
	public float DirectionX = 0.12f;

	// Token: 0x04000F73 RID: 3955
	[Range(0.4f, 2f)]
	public float Size = 1.5f;

	// Token: 0x04000F74 RID: 3956
	[Range(0f, 0.5f)]
	public float Speed = 0.275f;

	// Token: 0x04000F75 RID: 3957
	[Range(0f, 0.5f)]
	public float Distortion = 0.025f;

	// Token: 0x04000F76 RID: 3958
	[Range(0f, 1f)]
	public float StormFlashOnOff = 1f;

	// Token: 0x04000F77 RID: 3959
	[Range(0f, 1f)]
	public float DropOnOff = 1f;

	// Token: 0x04000F78 RID: 3960
	private Texture2D Texture2;
}
