using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Simple")]
public class CameraFilterPack_Broken_Simple : MonoBehaviour
{
	// Token: 0x1700025C RID: 604
	// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x0007331E File Offset: 0x0007151E
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

	// Token: 0x06000CCA RID: 3274 RVA: 0x00073352 File Offset: 0x00071552
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Broken_Simple");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x00073374 File Offset: 0x00071574
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
			this.material.SetFloat("_Speed", this.__Speed);
			this.material.SetFloat("Broke1", this._Broke1);
			this.material.SetFloat("Broke2", this._Broke2);
			this.material.SetFloat("PosX", this._PosX);
			this.material.SetFloat("PosY", this._PosY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CCC RID: 3276 RVA: 0x00073482 File Offset: 0x00071682
	private void Update()
	{
	}

	// Token: 0x06000CCD RID: 3277 RVA: 0x00073484 File Offset: 0x00071684
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001112 RID: 4370
	public Shader SCShader;

	// Token: 0x04001113 RID: 4371
	private float TimeX = 1f;

	// Token: 0x04001114 RID: 4372
	private Material SCMaterial;

	// Token: 0x04001115 RID: 4373
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x04001116 RID: 4374
	[Range(0f, 1f)]
	public float _Broke1 = 1f;

	// Token: 0x04001117 RID: 4375
	[Range(0f, 1f)]
	public float _Broke2 = 1f;

	// Token: 0x04001118 RID: 4376
	[Range(0f, 1f)]
	public float _PosX = 0.5f;

	// Token: 0x04001119 RID: 4377
	[Range(0f, 1f)]
	public float _PosY = 0.5f;
}
