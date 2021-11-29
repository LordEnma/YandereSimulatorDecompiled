using System;
using UnityEngine;

// Token: 0x02000207 RID: 519
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Broken Glass")]
public class CameraFilterPack_TV_BrokenGlass : MonoBehaviour
{
	// Token: 0x1700030C RID: 780
	// (get) Token: 0x0600110F RID: 4367 RVA: 0x000861F7 File Offset: 0x000843F7
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

	// Token: 0x06001110 RID: 4368 RVA: 0x0008622B File Offset: 0x0008442B
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

	// Token: 0x06001111 RID: 4369 RVA: 0x00086264 File Offset: 0x00084464
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

	// Token: 0x06001112 RID: 4370 RVA: 0x0008635B File Offset: 0x0008455B
	private void Update()
	{
	}

	// Token: 0x06001113 RID: 4371 RVA: 0x0008635D File Offset: 0x0008455D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001599 RID: 5529
	public Shader SCShader;

	// Token: 0x0400159A RID: 5530
	private float TimeX = 1f;

	// Token: 0x0400159B RID: 5531
	[Range(0f, 128f)]
	public float Broken_Small;

	// Token: 0x0400159C RID: 5532
	[Range(0f, 128f)]
	public float Broken_Medium;

	// Token: 0x0400159D RID: 5533
	[Range(0f, 128f)]
	public float Broken_High;

	// Token: 0x0400159E RID: 5534
	[Range(0f, 128f)]
	public float Broken_Big = 1f;

	// Token: 0x0400159F RID: 5535
	[Range(0f, 0.004f)]
	public float LightReflect = 0.002f;

	// Token: 0x040015A0 RID: 5536
	private Material SCMaterial;

	// Token: 0x040015A1 RID: 5537
	private Texture2D Texture2;
}
