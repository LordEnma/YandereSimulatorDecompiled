using System;
using UnityEngine;

// Token: 0x02000174 RID: 372
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/BigFace")]
public class CameraFilterPack_Distortion_BigFace : MonoBehaviour
{
	// Token: 0x17000278 RID: 632
	// (get) Token: 0x06000D76 RID: 3446 RVA: 0x00076359 File Offset: 0x00074559
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

	// Token: 0x06000D77 RID: 3447 RVA: 0x0007638D File Offset: 0x0007458D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_BigFace");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D78 RID: 3448 RVA: 0x000763B0 File Offset: 0x000745B0
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

	// Token: 0x06000D79 RID: 3449 RVA: 0x0007647C File Offset: 0x0007467C
	private void Update()
	{
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x0007647E File Offset: 0x0007467E
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
	private float TimeX = 6.5f;

	// Token: 0x040011C0 RID: 4544
	private Material SCMaterial;

	// Token: 0x040011C1 RID: 4545
	public float _Size = 5f;

	// Token: 0x040011C2 RID: 4546
	[Range(2f, 10f)]
	public float Distortion = 2.5f;
}
