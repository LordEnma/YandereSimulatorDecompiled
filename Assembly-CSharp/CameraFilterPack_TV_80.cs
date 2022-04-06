using System;
using UnityEngine;

// Token: 0x02000203 RID: 515
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/80s")]
public class CameraFilterPack_TV_80 : MonoBehaviour
{
	// Token: 0x17000307 RID: 775
	// (get) Token: 0x060010F7 RID: 4343 RVA: 0x0008645C File Offset: 0x0008465C
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

	// Token: 0x060010F8 RID: 4344 RVA: 0x00086490 File Offset: 0x00084690
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_80");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x000864B4 File Offset: 0x000846B4
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010FA RID: 4346 RVA: 0x0008656A File Offset: 0x0008476A
	private void Update()
	{
	}

	// Token: 0x060010FB RID: 4347 RVA: 0x0008656C File Offset: 0x0008476C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001593 RID: 5523
	public Shader SCShader;

	// Token: 0x04001594 RID: 5524
	private float TimeX = 1f;

	// Token: 0x04001595 RID: 5525
	private Material SCMaterial;

	// Token: 0x04001596 RID: 5526
	[Range(0f, 1f)]
	public float Fade = 1f;
}
