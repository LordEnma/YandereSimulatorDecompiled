using System;
using UnityEngine;

// Token: 0x02000128 RID: 296
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Color")]
public class CameraFilterPack_Blend2Camera_Color : MonoBehaviour
{
	// Token: 0x1700022C RID: 556
	// (get) Token: 0x06000B72 RID: 2930 RVA: 0x0006CE78 File Offset: 0x0006B078
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

	// Token: 0x06000B73 RID: 2931 RVA: 0x0006CEAC File Offset: 0x0006B0AC
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

	// Token: 0x06000B74 RID: 2932 RVA: 0x0006CF10 File Offset: 0x0006B110
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

	// Token: 0x06000B75 RID: 2933 RVA: 0x0006D000 File Offset: 0x0006B200
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x0006D038 File Offset: 0x0006B238
	private void Update()
	{
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x0006D03A File Offset: 0x0006B23A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x0006D072 File Offset: 0x0006B272
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

	// Token: 0x04000F9A RID: 3994
	private string ShaderName = "CameraFilterPack/Blend2Camera_Color";

	// Token: 0x04000F9B RID: 3995
	public Shader SCShader;

	// Token: 0x04000F9C RID: 3996
	public Camera Camera2;

	// Token: 0x04000F9D RID: 3997
	private float TimeX = 1f;

	// Token: 0x04000F9E RID: 3998
	private Material SCMaterial;

	// Token: 0x04000F9F RID: 3999
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FA0 RID: 4000
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FA1 RID: 4001
	private RenderTexture Camera2tex;
}
