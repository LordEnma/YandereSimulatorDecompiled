using System;
using UnityEngine;

// Token: 0x02000213 RID: 531
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old_Movie")]
public class CameraFilterPack_TV_Old_Movie : MonoBehaviour
{
	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06001154 RID: 4436 RVA: 0x00087670 File Offset: 0x00085870
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

	// Token: 0x06001155 RID: 4437 RVA: 0x000876A4 File Offset: 0x000858A4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old_Movie");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001156 RID: 4438 RVA: 0x000876C8 File Offset: 0x000858C8
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
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001157 RID: 4439 RVA: 0x0008774E File Offset: 0x0008594E
	private void Update()
	{
	}

	// Token: 0x06001158 RID: 4440 RVA: 0x00087750 File Offset: 0x00085950
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015E5 RID: 5605
	public Shader SCShader;

	// Token: 0x040015E6 RID: 5606
	private float TimeX = 1f;

	// Token: 0x040015E7 RID: 5607
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015E8 RID: 5608
	private Material SCMaterial;
}
