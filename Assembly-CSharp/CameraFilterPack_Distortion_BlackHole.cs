using System;
using UnityEngine;

// Token: 0x02000175 RID: 373
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/BlackHole")]
public class CameraFilterPack_Distortion_BlackHole : MonoBehaviour
{
	// Token: 0x17000279 RID: 633
	// (get) Token: 0x06000D7D RID: 3453 RVA: 0x0007686D File Offset: 0x00074A6D
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

	// Token: 0x06000D7E RID: 3454 RVA: 0x000768A1 File Offset: 0x00074AA1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_BlackHole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x000768C4 File Offset: 0x00074AC4
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
			this.material.SetFloat("_PositionX", this.PositionX);
			this.material.SetFloat("_PositionY", this.PositionY);
			this.material.SetFloat("_Distortion", this.Size);
			this.material.SetFloat("_Distortion2", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x000769B5 File Offset: 0x00074BB5
	private void Update()
	{
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x000769B7 File Offset: 0x00074BB7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011CF RID: 4559
	public Shader SCShader;

	// Token: 0x040011D0 RID: 4560
	private float TimeX = 1f;

	// Token: 0x040011D1 RID: 4561
	private Material SCMaterial;

	// Token: 0x040011D2 RID: 4562
	[Range(-1f, 1f)]
	public float PositionX;

	// Token: 0x040011D3 RID: 4563
	[Range(-1f, 1f)]
	public float PositionY;

	// Token: 0x040011D4 RID: 4564
	[Range(-5f, 5f)]
	public float Size = 0.05f;

	// Token: 0x040011D5 RID: 4565
	[Range(0f, 180f)]
	public float Distortion = 30f;
}
