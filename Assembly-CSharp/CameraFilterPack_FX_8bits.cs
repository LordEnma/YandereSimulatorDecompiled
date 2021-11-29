using System;
using UnityEngine;

// Token: 0x020001A7 RID: 423
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits")]
public class CameraFilterPack_FX_8bits : MonoBehaviour
{
	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06000EAC RID: 3756 RVA: 0x0007AEB0 File Offset: 0x000790B0
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

	// Token: 0x06000EAD RID: 3757 RVA: 0x0007AEE4 File Offset: 0x000790E4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EAE RID: 3758 RVA: 0x0007AF08 File Offset: 0x00079108
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
			if (this.Brightness == 0f)
			{
				this.Brightness = 0.001f;
			}
			this.material.SetFloat("_Distortion", this.Brightness);
			RenderTexture temporary = RenderTexture.GetTemporary(this.ResolutionX, this.ResolutionY, 0);
			Graphics.Blit(sourceTexture, temporary, this.material);
			temporary.filterMode = FilterMode.Point;
			Graphics.Blit(temporary, destTexture);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EAF RID: 3759 RVA: 0x0007AFD0 File Offset: 0x000791D0
	private void Update()
	{
	}

	// Token: 0x06000EB0 RID: 3760 RVA: 0x0007AFD2 File Offset: 0x000791D2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012F6 RID: 4854
	public Shader SCShader;

	// Token: 0x040012F7 RID: 4855
	private float TimeX = 1f;

	// Token: 0x040012F8 RID: 4856
	private Material SCMaterial;

	// Token: 0x040012F9 RID: 4857
	[Range(-1f, 1f)]
	public float Brightness;

	// Token: 0x040012FA RID: 4858
	[Range(80f, 640f)]
	public int ResolutionX = 160;

	// Token: 0x040012FB RID: 4859
	[Range(60f, 480f)]
	public int ResolutionY = 240;
}
