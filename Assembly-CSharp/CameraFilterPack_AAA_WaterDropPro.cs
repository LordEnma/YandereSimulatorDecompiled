using System;
using UnityEngine;

// Token: 0x0200011E RID: 286
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/WaterDropPro")]
public class CameraFilterPack_AAA_WaterDropPro : MonoBehaviour
{
	// Token: 0x17000222 RID: 546
	// (get) Token: 0x06000B34 RID: 2868 RVA: 0x0006BF04 File Offset: 0x0006A104
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

	// Token: 0x06000B35 RID: 2869 RVA: 0x0006BF38 File Offset: 0x0006A138
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_WaterDrop") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_WaterDropPro");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x0006BF70 File Offset: 0x0006A170
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_SizeX", this.SizeX);
			this.material.SetFloat("_SizeY", this.SizeY);
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B37 RID: 2871 RVA: 0x0006C051 File Offset: 0x0006A251
	private void Update()
	{
	}

	// Token: 0x06000B38 RID: 2872 RVA: 0x0006C053 File Offset: 0x0006A253
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F47 RID: 3911
	public Shader SCShader;

	// Token: 0x04000F48 RID: 3912
	private float TimeX = 1f;

	// Token: 0x04000F49 RID: 3913
	[Range(8f, 64f)]
	public float Distortion = 8f;

	// Token: 0x04000F4A RID: 3914
	[Range(0f, 7f)]
	public float SizeX = 1f;

	// Token: 0x04000F4B RID: 3915
	[Range(0f, 7f)]
	public float SizeY = 0.5f;

	// Token: 0x04000F4C RID: 3916
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04000F4D RID: 3917
	private Material SCMaterial;

	// Token: 0x04000F4E RID: 3918
	private Texture2D Texture2;
}
