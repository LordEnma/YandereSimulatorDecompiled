using System;
using UnityEngine;

// Token: 0x02000208 RID: 520
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Broken Glass")]
public class CameraFilterPack_TV_BrokenGlass : MonoBehaviour
{
	// Token: 0x1700030C RID: 780
	// (get) Token: 0x06001115 RID: 4373 RVA: 0x00086C17 File Offset: 0x00084E17
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

	// Token: 0x06001116 RID: 4374 RVA: 0x00086C4B File Offset: 0x00084E4B
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

	// Token: 0x06001117 RID: 4375 RVA: 0x00086C84 File Offset: 0x00084E84
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

	// Token: 0x06001118 RID: 4376 RVA: 0x00086D7B File Offset: 0x00084F7B
	private void Update()
	{
	}

	// Token: 0x06001119 RID: 4377 RVA: 0x00086D7D File Offset: 0x00084F7D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015B1 RID: 5553
	public Shader SCShader;

	// Token: 0x040015B2 RID: 5554
	private float TimeX = 1f;

	// Token: 0x040015B3 RID: 5555
	[Range(0f, 128f)]
	public float Broken_Small;

	// Token: 0x040015B4 RID: 5556
	[Range(0f, 128f)]
	public float Broken_Medium;

	// Token: 0x040015B5 RID: 5557
	[Range(0f, 128f)]
	public float Broken_High;

	// Token: 0x040015B6 RID: 5558
	[Range(0f, 128f)]
	public float Broken_Big = 1f;

	// Token: 0x040015B7 RID: 5559
	[Range(0f, 0.004f)]
	public float LightReflect = 0.002f;

	// Token: 0x040015B8 RID: 5560
	private Material SCMaterial;

	// Token: 0x040015B9 RID: 5561
	private Texture2D Texture2;
}
