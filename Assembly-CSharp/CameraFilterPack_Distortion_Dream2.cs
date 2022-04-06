using System;
using UnityEngine;

// Token: 0x02000178 RID: 376
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dream2")]
public class CameraFilterPack_Distortion_Dream2 : MonoBehaviour
{
	// Token: 0x1700027C RID: 636
	// (get) Token: 0x06000D91 RID: 3473 RVA: 0x00077134 File Offset: 0x00075334
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

	// Token: 0x06000D92 RID: 3474 RVA: 0x00077168 File Offset: 0x00075368
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dream2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D93 RID: 3475 RVA: 0x0007718C File Offset: 0x0007538C
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
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D94 RID: 3476 RVA: 0x00077258 File Offset: 0x00075458
	private void Update()
	{
	}

	// Token: 0x06000D95 RID: 3477 RVA: 0x0007725A File Offset: 0x0007545A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011E8 RID: 4584
	public Shader SCShader;

	// Token: 0x040011E9 RID: 4585
	private float TimeX = 1f;

	// Token: 0x040011EA RID: 4586
	private Material SCMaterial;

	// Token: 0x040011EB RID: 4587
	[Range(0f, 100f)]
	public float Distortion = 6f;

	// Token: 0x040011EC RID: 4588
	[Range(0f, 32f)]
	public float Speed = 5f;
}
