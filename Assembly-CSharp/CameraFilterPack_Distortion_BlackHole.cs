using System;
using UnityEngine;

// Token: 0x02000175 RID: 373
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/BlackHole")]
public class CameraFilterPack_Distortion_BlackHole : MonoBehaviour
{
	// Token: 0x17000279 RID: 633
	// (get) Token: 0x06000D7F RID: 3455 RVA: 0x00076CE9 File Offset: 0x00074EE9
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

	// Token: 0x06000D80 RID: 3456 RVA: 0x00076D1D File Offset: 0x00074F1D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_BlackHole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x00076D40 File Offset: 0x00074F40
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

	// Token: 0x06000D82 RID: 3458 RVA: 0x00076E31 File Offset: 0x00075031
	private void Update()
	{
	}

	// Token: 0x06000D83 RID: 3459 RVA: 0x00076E33 File Offset: 0x00075033
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011D6 RID: 4566
	public Shader SCShader;

	// Token: 0x040011D7 RID: 4567
	private float TimeX = 1f;

	// Token: 0x040011D8 RID: 4568
	private Material SCMaterial;

	// Token: 0x040011D9 RID: 4569
	[Range(-1f, 1f)]
	public float PositionX;

	// Token: 0x040011DA RID: 4570
	[Range(-1f, 1f)]
	public float PositionY;

	// Token: 0x040011DB RID: 4571
	[Range(-5f, 5f)]
	public float Size = 0.05f;

	// Token: 0x040011DC RID: 4572
	[Range(0f, 180f)]
	public float Distortion = 30f;
}
