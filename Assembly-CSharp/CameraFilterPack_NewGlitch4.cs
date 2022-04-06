using System;
using UnityEngine;

// Token: 0x020001E7 RID: 487
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch4")]
public class CameraFilterPack_NewGlitch4 : MonoBehaviour
{
	// Token: 0x170002EB RID: 747
	// (get) Token: 0x06001048 RID: 4168 RVA: 0x00082E3D File Offset: 0x0008103D
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

	// Token: 0x06001049 RID: 4169 RVA: 0x00082E71 File Offset: 0x00081071
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch4");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600104A RID: 4170 RVA: 0x00082E94 File Offset: 0x00081094
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
			this.material.SetFloat("Fade", this._Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600104B RID: 4171 RVA: 0x00082F60 File Offset: 0x00081160
	private void Update()
	{
	}

	// Token: 0x0600104C RID: 4172 RVA: 0x00082F62 File Offset: 0x00081162
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014C7 RID: 5319
	public Shader SCShader;

	// Token: 0x040014C8 RID: 5320
	private float TimeX = 1f;

	// Token: 0x040014C9 RID: 5321
	private Material SCMaterial;

	// Token: 0x040014CA RID: 5322
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014CB RID: 5323
	[Range(0f, 1f)]
	public float _Fade = 1f;
}
