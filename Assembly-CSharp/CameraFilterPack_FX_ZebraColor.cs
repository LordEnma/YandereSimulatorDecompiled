using System;
using UnityEngine;

// Token: 0x020001C1 RID: 449
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/ZebraColor")]
public class CameraFilterPack_FX_ZebraColor : MonoBehaviour
{
	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x06000F48 RID: 3912 RVA: 0x0007DD2B File Offset: 0x0007BF2B
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

	// Token: 0x06000F49 RID: 3913 RVA: 0x0007DD5F File Offset: 0x0007BF5F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_ZebraColor");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F4A RID: 3914 RVA: 0x0007DD80 File Offset: 0x0007BF80
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F4B RID: 3915 RVA: 0x0007DE36 File Offset: 0x0007C036
	private void Update()
	{
	}

	// Token: 0x06000F4C RID: 3916 RVA: 0x0007DE38 File Offset: 0x0007C038
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001399 RID: 5017
	public Shader SCShader;

	// Token: 0x0400139A RID: 5018
	private float TimeX = 1f;

	// Token: 0x0400139B RID: 5019
	private Material SCMaterial;

	// Token: 0x0400139C RID: 5020
	[Range(1f, 10f)]
	public float Value = 3f;
}
