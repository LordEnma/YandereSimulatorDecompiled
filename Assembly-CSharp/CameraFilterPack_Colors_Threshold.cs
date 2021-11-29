using System;
using UnityEngine;

// Token: 0x02000170 RID: 368
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Threshold")]
public class CameraFilterPack_Colors_Threshold : MonoBehaviour
{
	// Token: 0x17000275 RID: 629
	// (get) Token: 0x06000D61 RID: 3425 RVA: 0x00075DAF File Offset: 0x00073FAF
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

	// Token: 0x06000D62 RID: 3426 RVA: 0x00075DE3 File Offset: 0x00073FE3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Threshold");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x00075E04 File Offset: 0x00074004
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
			this.material.SetFloat("_Distortion", this.Threshold);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x00075E8A File Offset: 0x0007408A
	private void Update()
	{
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x00075E8C File Offset: 0x0007408C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011AA RID: 4522
	public Shader SCShader;

	// Token: 0x040011AB RID: 4523
	private float TimeX = 1f;

	// Token: 0x040011AC RID: 4524
	[Range(0f, 1f)]
	public float Threshold = 0.3f;

	// Token: 0x040011AD RID: 4525
	private Material SCMaterial;
}
