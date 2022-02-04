using System;
using UnityEngine;

// Token: 0x02000135 RID: 309
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Lighten")]
public class CameraFilterPack_Blend2Camera_Lighten : MonoBehaviour
{
	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x0006EB0F File Offset: 0x0006CD0F
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

	// Token: 0x06000BD8 RID: 3032 RVA: 0x0006EB44 File Offset: 0x0006CD44
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

	// Token: 0x06000BD9 RID: 3033 RVA: 0x0006EBA8 File Offset: 0x0006CDA8
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

	// Token: 0x06000BDA RID: 3034 RVA: 0x0006EC98 File Offset: 0x0006CE98
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BDB RID: 3035 RVA: 0x0006ECD0 File Offset: 0x0006CED0
	private void Update()
	{
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x0006ECD2 File Offset: 0x0006CED2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x0006ED0A File Offset: 0x0006CF0A
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

	// Token: 0x0400100C RID: 4108
	private string ShaderName = "CameraFilterPack/Blend2Camera_Lighten";

	// Token: 0x0400100D RID: 4109
	public Shader SCShader;

	// Token: 0x0400100E RID: 4110
	public Camera Camera2;

	// Token: 0x0400100F RID: 4111
	private float TimeX = 1f;

	// Token: 0x04001010 RID: 4112
	private Material SCMaterial;

	// Token: 0x04001011 RID: 4113
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001012 RID: 4114
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001013 RID: 4115
	private RenderTexture Camera2tex;
}
