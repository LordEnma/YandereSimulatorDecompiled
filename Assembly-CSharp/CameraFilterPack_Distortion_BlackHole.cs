using System;
using UnityEngine;

// Token: 0x02000175 RID: 373
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/BlackHole")]
public class CameraFilterPack_Distortion_BlackHole : MonoBehaviour
{
	// Token: 0x17000279 RID: 633
	// (get) Token: 0x06000D7C RID: 3452 RVA: 0x000764C1 File Offset: 0x000746C1
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

	// Token: 0x06000D7D RID: 3453 RVA: 0x000764F5 File Offset: 0x000746F5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_BlackHole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x00076518 File Offset: 0x00074718
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

	// Token: 0x06000D7F RID: 3455 RVA: 0x00076609 File Offset: 0x00074809
	private void Update()
	{
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x0007660B File Offset: 0x0007480B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011C3 RID: 4547
	public Shader SCShader;

	// Token: 0x040011C4 RID: 4548
	private float TimeX = 1f;

	// Token: 0x040011C5 RID: 4549
	private Material SCMaterial;

	// Token: 0x040011C6 RID: 4550
	[Range(-1f, 1f)]
	public float PositionX;

	// Token: 0x040011C7 RID: 4551
	[Range(-1f, 1f)]
	public float PositionY;

	// Token: 0x040011C8 RID: 4552
	[Range(-5f, 5f)]
	public float Size = 0.05f;

	// Token: 0x040011C9 RID: 4553
	[Range(0f, 180f)]
	public float Distortion = 30f;
}
