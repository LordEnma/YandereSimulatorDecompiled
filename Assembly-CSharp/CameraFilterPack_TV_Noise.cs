using System;
using UnityEngine;

// Token: 0x02000211 RID: 529
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Noise")]
public class CameraFilterPack_TV_Noise : MonoBehaviour
{
	// Token: 0x17000315 RID: 789
	// (get) Token: 0x06001149 RID: 4425 RVA: 0x00087674 File Offset: 0x00085874
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

	// Token: 0x0600114A RID: 4426 RVA: 0x000876A8 File Offset: 0x000858A8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600114B RID: 4427 RVA: 0x000876CC File Offset: 0x000858CC
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

	// Token: 0x0600114C RID: 4428 RVA: 0x00087782 File Offset: 0x00085982
	private void Update()
	{
	}

	// Token: 0x0600114D RID: 4429 RVA: 0x00087784 File Offset: 0x00085984
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015E0 RID: 5600
	public Shader SCShader;

	// Token: 0x040015E1 RID: 5601
	private float TimeX = 1f;

	// Token: 0x040015E2 RID: 5602
	private Material SCMaterial;

	// Token: 0x040015E3 RID: 5603
	[Range(0.0001f, 1f)]
	public float Fade = 0.01f;
}
