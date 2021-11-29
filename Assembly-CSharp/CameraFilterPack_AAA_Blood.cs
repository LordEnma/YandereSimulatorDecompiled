using System;
using UnityEngine;

// Token: 0x02000116 RID: 278
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood")]
public class CameraFilterPack_AAA_Blood : MonoBehaviour
{
	// Token: 0x1700021B RID: 539
	// (get) Token: 0x06000B04 RID: 2820 RVA: 0x0006A432 File Offset: 0x00068632
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

	// Token: 0x06000B05 RID: 2821 RVA: 0x0006A466 File Offset: 0x00068666
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_AAA_Blood1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B06 RID: 2822 RVA: 0x0006A49C File Offset: 0x0006869C
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
			this.material.SetFloat("_Value", this.LightReflect);
			this.material.SetFloat("_Value2", this.Blood1);
			this.material.SetFloat("_Value3", this.Blood2);
			this.material.SetFloat("_Value4", this.Blood3);
			this.material.SetFloat("_Value5", this.Blood4);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B07 RID: 2823 RVA: 0x0006A593 File Offset: 0x00068793
	private void Update()
	{
	}

	// Token: 0x06000B08 RID: 2824 RVA: 0x0006A595 File Offset: 0x00068795
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EDC RID: 3804
	public Shader SCShader;

	// Token: 0x04000EDD RID: 3805
	private float TimeX = 1f;

	// Token: 0x04000EDE RID: 3806
	[Range(0f, 128f)]
	public float Blood1;

	// Token: 0x04000EDF RID: 3807
	[Range(0f, 128f)]
	public float Blood2;

	// Token: 0x04000EE0 RID: 3808
	[Range(0f, 128f)]
	public float Blood3;

	// Token: 0x04000EE1 RID: 3809
	[Range(0f, 128f)]
	public float Blood4 = 1f;

	// Token: 0x04000EE2 RID: 3810
	[Range(0f, 0.004f)]
	public float LightReflect = 0.002f;

	// Token: 0x04000EE3 RID: 3811
	private Material SCMaterial;

	// Token: 0x04000EE4 RID: 3812
	private Texture2D Texture2;
}
