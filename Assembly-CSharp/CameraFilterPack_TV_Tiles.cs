using System;
using UnityEngine;

// Token: 0x02000218 RID: 536
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Tiles")]
public class CameraFilterPack_TV_Tiles : MonoBehaviour
{
	// Token: 0x1700031C RID: 796
	// (get) Token: 0x06001175 RID: 4469 RVA: 0x00088558 File Offset: 0x00086758
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

	// Token: 0x06001176 RID: 4470 RVA: 0x0008858C File Offset: 0x0008678C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Tiles");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x000885B0 File Offset: 0x000867B0
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001178 RID: 4472 RVA: 0x000886BE File Offset: 0x000868BE
	private void Update()
	{
	}

	// Token: 0x06001179 RID: 4473 RVA: 0x000886C0 File Offset: 0x000868C0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001612 RID: 5650
	public Shader SCShader;

	// Token: 0x04001613 RID: 5651
	private float TimeX = 1f;

	// Token: 0x04001614 RID: 5652
	private Material SCMaterial;

	// Token: 0x04001615 RID: 5653
	[Range(0.5f, 2f)]
	public float Size = 1f;

	// Token: 0x04001616 RID: 5654
	[Range(0f, 10f)]
	public float Intensity = 4f;

	// Token: 0x04001617 RID: 5655
	[Range(0f, 1f)]
	public float StretchX = 0.6f;

	// Token: 0x04001618 RID: 5656
	[Range(0f, 1f)]
	public float StretchY = 0.4f;

	// Token: 0x04001619 RID: 5657
	[Range(0f, 1f)]
	public float Fade = 0.6f;
}
