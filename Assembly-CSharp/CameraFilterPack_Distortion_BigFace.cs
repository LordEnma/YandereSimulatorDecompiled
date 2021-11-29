using System;
using UnityEngine;

// Token: 0x02000173 RID: 371
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/BigFace")]
public class CameraFilterPack_Distortion_BigFace : MonoBehaviour
{
	// Token: 0x17000278 RID: 632
	// (get) Token: 0x06000D73 RID: 3443 RVA: 0x00076161 File Offset: 0x00074361
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

	// Token: 0x06000D74 RID: 3444 RVA: 0x00076195 File Offset: 0x00074395
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_BigFace");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x000761B8 File Offset: 0x000743B8
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

	// Token: 0x06000D76 RID: 3446 RVA: 0x00076284 File Offset: 0x00074484
	private void Update()
	{
	}

	// Token: 0x06000D77 RID: 3447 RVA: 0x00076286 File Offset: 0x00074486
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011B9 RID: 4537
	public Shader SCShader;

	// Token: 0x040011BA RID: 4538
	private float TimeX = 6.5f;

	// Token: 0x040011BB RID: 4539
	private Material SCMaterial;

	// Token: 0x040011BC RID: 4540
	public float _Size = 5f;

	// Token: 0x040011BD RID: 4541
	[Range(2f, 10f)]
	public float Distortion = 2.5f;
}
