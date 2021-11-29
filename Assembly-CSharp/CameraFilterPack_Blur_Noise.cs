using System;
using UnityEngine;

// Token: 0x0200014E RID: 334
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Noise")]
public class CameraFilterPack_Blur_Noise : MonoBehaviour
{
	// Token: 0x17000253 RID: 595
	// (get) Token: 0x06000C93 RID: 3219 RVA: 0x000722D6 File Offset: 0x000704D6
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

	// Token: 0x06000C94 RID: 3220 RVA: 0x0007230A File Offset: 0x0007050A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x0007232C File Offset: 0x0007052C
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
			this.material.SetFloat("_Level", (float)this.Level);
			this.material.SetVector("_Distance", this.Distance);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C96 RID: 3222 RVA: 0x000723FE File Offset: 0x000705FE
	private void Update()
	{
	}

	// Token: 0x06000C97 RID: 3223 RVA: 0x00072400 File Offset: 0x00070600
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010D6 RID: 4310
	public Shader SCShader;

	// Token: 0x040010D7 RID: 4311
	private float TimeX = 1f;

	// Token: 0x040010D8 RID: 4312
	private Material SCMaterial;

	// Token: 0x040010D9 RID: 4313
	[Range(2f, 16f)]
	public int Level = 4;

	// Token: 0x040010DA RID: 4314
	public Vector2 Distance = new Vector2(30f, 0f);
}
