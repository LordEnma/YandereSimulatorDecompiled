using System;
using UnityEngine;

// Token: 0x02000212 RID: 530
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old_Movie")]
public class CameraFilterPack_TV_Old_Movie : MonoBehaviour
{
	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06001151 RID: 4433 RVA: 0x00087478 File Offset: 0x00085678
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

	// Token: 0x06001152 RID: 4434 RVA: 0x000874AC File Offset: 0x000856AC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old_Movie");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001153 RID: 4435 RVA: 0x000874D0 File Offset: 0x000856D0
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

	// Token: 0x06001154 RID: 4436 RVA: 0x00087556 File Offset: 0x00085756
	private void Update()
	{
	}

	// Token: 0x06001155 RID: 4437 RVA: 0x00087558 File Offset: 0x00085758
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
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015E3 RID: 5603
	private Material SCMaterial;
}
