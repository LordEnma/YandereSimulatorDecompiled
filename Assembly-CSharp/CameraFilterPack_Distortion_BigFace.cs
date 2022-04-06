using System;
using UnityEngine;

// Token: 0x02000174 RID: 372
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/BigFace")]
public class CameraFilterPack_Distortion_BigFace : MonoBehaviour
{
	// Token: 0x17000278 RID: 632
	// (get) Token: 0x06000D79 RID: 3449 RVA: 0x00076B81 File Offset: 0x00074D81
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

	// Token: 0x06000D7A RID: 3450 RVA: 0x00076BB5 File Offset: 0x00074DB5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_BigFace");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x00076BD8 File Offset: 0x00074DD8
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

	// Token: 0x06000D7C RID: 3452 RVA: 0x00076CA4 File Offset: 0x00074EA4
	private void Update()
	{
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x00076CA6 File Offset: 0x00074EA6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011D1 RID: 4561
	public Shader SCShader;

	// Token: 0x040011D2 RID: 4562
	private float TimeX = 6.5f;

	// Token: 0x040011D3 RID: 4563
	private Material SCMaterial;

	// Token: 0x040011D4 RID: 4564
	public float _Size = 5f;

	// Token: 0x040011D5 RID: 4565
	[Range(2f, 10f)]
	public float Distortion = 2.5f;
}
