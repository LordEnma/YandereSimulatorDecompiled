using System;
using UnityEngine;

// Token: 0x02000208 RID: 520
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Broken Glass")]
public class CameraFilterPack_TV_BrokenGlass : MonoBehaviour
{
	// Token: 0x1700030C RID: 780
	// (get) Token: 0x06001113 RID: 4371 RVA: 0x0008653F File Offset: 0x0008473F
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

	// Token: 0x06001114 RID: 4372 RVA: 0x00086573 File Offset: 0x00084773
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_BrokenGlass1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/TV_BrokenGlass");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001115 RID: 4373 RVA: 0x000865AC File Offset: 0x000847AC
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
			this.material.SetFloat("_Value2", this.Broken_Small);
			this.material.SetFloat("_Value3", this.Broken_Medium);
			this.material.SetFloat("_Value4", this.Broken_High);
			this.material.SetFloat("_Value5", this.Broken_Big);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001116 RID: 4374 RVA: 0x000866A3 File Offset: 0x000848A3
	private void Update()
	{
	}

	// Token: 0x06001117 RID: 4375 RVA: 0x000866A5 File Offset: 0x000848A5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015A1 RID: 5537
	public Shader SCShader;

	// Token: 0x040015A2 RID: 5538
	private float TimeX = 1f;

	// Token: 0x040015A3 RID: 5539
	[Range(0f, 128f)]
	public float Broken_Small;

	// Token: 0x040015A4 RID: 5540
	[Range(0f, 128f)]
	public float Broken_Medium;

	// Token: 0x040015A5 RID: 5541
	[Range(0f, 128f)]
	public float Broken_High;

	// Token: 0x040015A6 RID: 5542
	[Range(0f, 128f)]
	public float Broken_Big = 1f;

	// Token: 0x040015A7 RID: 5543
	[Range(0f, 0.004f)]
	public float LightReflect = 0.002f;

	// Token: 0x040015A8 RID: 5544
	private Material SCMaterial;

	// Token: 0x040015A9 RID: 5545
	private Texture2D Texture2;
}
