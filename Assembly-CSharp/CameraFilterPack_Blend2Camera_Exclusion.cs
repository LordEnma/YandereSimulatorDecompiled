using System;
using UnityEngine;

// Token: 0x0200012F RID: 303
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Exclusion")]
public class CameraFilterPack_Blend2Camera_Exclusion : MonoBehaviour
{
	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06000BAD RID: 2989 RVA: 0x0006DD27 File Offset: 0x0006BF27
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

	// Token: 0x06000BAE RID: 2990 RVA: 0x0006DD5C File Offset: 0x0006BF5C
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x0006DDC0 File Offset: 0x0006BFC0
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x0006DEB0 File Offset: 0x0006C0B0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x0006DEE8 File Offset: 0x0006C0E8
	private void Update()
	{
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x0006DEEA File Offset: 0x0006C0EA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x0006DF22 File Offset: 0x0006C122
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000FD9 RID: 4057
	private string ShaderName = "CameraFilterPack/Blend2Camera_Exclusion";

	// Token: 0x04000FDA RID: 4058
	public Shader SCShader;

	// Token: 0x04000FDB RID: 4059
	public Camera Camera2;

	// Token: 0x04000FDC RID: 4060
	private float TimeX = 1f;

	// Token: 0x04000FDD RID: 4061
	private Material SCMaterial;

	// Token: 0x04000FDE RID: 4062
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FDF RID: 4063
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FE0 RID: 4064
	private RenderTexture Camera2tex;
}
