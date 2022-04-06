using System;
using UnityEngine;

// Token: 0x02000202 RID: 514
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/50s")]
public class CameraFilterPack_TV_50 : MonoBehaviour
{
	// Token: 0x17000306 RID: 774
	// (get) Token: 0x060010F1 RID: 4337 RVA: 0x00086317 File Offset: 0x00084517
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

	// Token: 0x060010F2 RID: 4338 RVA: 0x0008634B File Offset: 0x0008454B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_50");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010F3 RID: 4339 RVA: 0x0008636C File Offset: 0x0008456C
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010F4 RID: 4340 RVA: 0x00086422 File Offset: 0x00084622
	private void Update()
	{
	}

	// Token: 0x060010F5 RID: 4341 RVA: 0x00086424 File Offset: 0x00084624
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400158F RID: 5519
	public Shader SCShader;

	// Token: 0x04001590 RID: 5520
	private float TimeX = 1f;

	// Token: 0x04001591 RID: 5521
	private Material SCMaterial;

	// Token: 0x04001592 RID: 5522
	[Range(0f, 1f)]
	public float Fade = 1f;
}
