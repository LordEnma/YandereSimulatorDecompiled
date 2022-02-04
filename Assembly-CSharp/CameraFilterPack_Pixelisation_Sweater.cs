using System;
using UnityEngine;

// Token: 0x020001FC RID: 508
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Pixelisation_Sweater")]
public class CameraFilterPack_Pixelisation_Sweater : MonoBehaviour
{
	// Token: 0x17000300 RID: 768
	// (get) Token: 0x060010C9 RID: 4297 RVA: 0x00084F7C File Offset: 0x0008317C
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

	// Token: 0x060010CA RID: 4298 RVA: 0x00084FB0 File Offset: 0x000831B0
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Sweater") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_Sweater");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010CB RID: 4299 RVA: 0x00084FE8 File Offset: 0x000831E8
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
			this.material.SetFloat("_SweaterSize", this.SweaterSize);
			this.material.SetFloat("_Intensity", this._Intensity);
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010CC RID: 4300 RVA: 0x000850B3 File Offset: 0x000832B3
	private void Update()
	{
	}

	// Token: 0x060010CD RID: 4301 RVA: 0x000850B5 File Offset: 0x000832B5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001551 RID: 5457
	public Shader SCShader;

	// Token: 0x04001552 RID: 5458
	private float TimeX = 1f;

	// Token: 0x04001553 RID: 5459
	private Material SCMaterial;

	// Token: 0x04001554 RID: 5460
	[Range(16f, 128f)]
	public float SweaterSize = 64f;

	// Token: 0x04001555 RID: 5461
	[Range(0f, 2f)]
	public float _Intensity = 1.4f;

	// Token: 0x04001556 RID: 5462
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001557 RID: 5463
	private Texture2D Texture2;
}
