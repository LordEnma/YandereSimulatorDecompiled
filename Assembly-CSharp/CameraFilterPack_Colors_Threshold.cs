using System;
using UnityEngine;

// Token: 0x02000171 RID: 369
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Threshold")]
public class CameraFilterPack_Colors_Threshold : MonoBehaviour
{
	// Token: 0x17000275 RID: 629
	// (get) Token: 0x06000D67 RID: 3431 RVA: 0x000767CF File Offset: 0x000749CF
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

	// Token: 0x06000D68 RID: 3432 RVA: 0x00076803 File Offset: 0x00074A03
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Threshold");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x00076824 File Offset: 0x00074A24
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

	// Token: 0x06000D6A RID: 3434 RVA: 0x000768AA File Offset: 0x00074AAA
	private void Update()
	{
	}

	// Token: 0x06000D6B RID: 3435 RVA: 0x000768AC File Offset: 0x00074AAC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011C2 RID: 4546
	public Shader SCShader;

	// Token: 0x040011C3 RID: 4547
	private float TimeX = 1f;

	// Token: 0x040011C4 RID: 4548
	[Range(0f, 1f)]
	public float Threshold = 0.3f;

	// Token: 0x040011C5 RID: 4549
	private Material SCMaterial;
}
