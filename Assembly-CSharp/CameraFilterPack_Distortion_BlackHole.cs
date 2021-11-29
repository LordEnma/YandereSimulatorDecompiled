using System;
using UnityEngine;

// Token: 0x02000174 RID: 372
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/BlackHole")]
public class CameraFilterPack_Distortion_BlackHole : MonoBehaviour
{
	// Token: 0x17000279 RID: 633
	// (get) Token: 0x06000D79 RID: 3449 RVA: 0x000762C9 File Offset: 0x000744C9
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

	// Token: 0x06000D7A RID: 3450 RVA: 0x000762FD File Offset: 0x000744FD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_BlackHole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x00076320 File Offset: 0x00074520
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

	// Token: 0x06000D7C RID: 3452 RVA: 0x00076411 File Offset: 0x00074611
	private void Update()
	{
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x00076413 File Offset: 0x00074613
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011BE RID: 4542
	public Shader SCShader;

	// Token: 0x040011BF RID: 4543
	private float TimeX = 1f;

	// Token: 0x040011C0 RID: 4544
	private Material SCMaterial;

	// Token: 0x040011C1 RID: 4545
	[Range(-1f, 1f)]
	public float PositionX;

	// Token: 0x040011C2 RID: 4546
	[Range(-1f, 1f)]
	public float PositionY;

	// Token: 0x040011C3 RID: 4547
	[Range(-5f, 5f)]
	public float Size = 0.05f;

	// Token: 0x040011C4 RID: 4548
	[Range(0f, 180f)]
	public float Distortion = 30f;
}
