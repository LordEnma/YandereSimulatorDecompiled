using System;
using UnityEngine;

// Token: 0x02000174 RID: 372
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/BigFace")]
public class CameraFilterPack_Distortion_BigFace : MonoBehaviour
{
	// Token: 0x17000278 RID: 632
	// (get) Token: 0x06000D77 RID: 3447 RVA: 0x000765BD File Offset: 0x000747BD
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

	// Token: 0x06000D78 RID: 3448 RVA: 0x000765F1 File Offset: 0x000747F1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_BigFace");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D79 RID: 3449 RVA: 0x00076614 File Offset: 0x00074814
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_Size", this._Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x000766E0 File Offset: 0x000748E0
	private void Update()
	{
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x000766E2 File Offset: 0x000748E2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011C1 RID: 4545
	public Shader SCShader;

	// Token: 0x040011C2 RID: 4546
	private float TimeX = 6.5f;

	// Token: 0x040011C3 RID: 4547
	private Material SCMaterial;

	// Token: 0x040011C4 RID: 4548
	public float _Size = 5f;

	// Token: 0x040011C5 RID: 4549
	[Range(2f, 10f)]
	public float Distortion = 2.5f;
}
