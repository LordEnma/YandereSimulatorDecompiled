using System;
using UnityEngine;

// Token: 0x02000134 RID: 308
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Hue")]
public class CameraFilterPack_Blend2Camera_Hue : MonoBehaviour
{
	// Token: 0x17000238 RID: 568
	// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0006EB1B File Offset: 0x0006CD1B
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

	// Token: 0x06000BD1 RID: 3025 RVA: 0x0006EB50 File Offset: 0x0006CD50
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

	// Token: 0x06000BD2 RID: 3026 RVA: 0x0006EBB4 File Offset: 0x0006CDB4
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

	// Token: 0x06000BD3 RID: 3027 RVA: 0x0006ECA4 File Offset: 0x0006CEA4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x0006ECDC File Offset: 0x0006CEDC
	private void Update()
	{
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x0006ECDE File Offset: 0x0006CEDE
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x0006ED16 File Offset: 0x0006CF16
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

	// Token: 0x04001007 RID: 4103
	private string ShaderName = "CameraFilterPack/Blend2Camera_Hue";

	// Token: 0x04001008 RID: 4104
	public Shader SCShader;

	// Token: 0x04001009 RID: 4105
	public Camera Camera2;

	// Token: 0x0400100A RID: 4106
	private float TimeX = 1f;

	// Token: 0x0400100B RID: 4107
	private Material SCMaterial;

	// Token: 0x0400100C RID: 4108
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400100D RID: 4109
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400100E RID: 4110
	private RenderTexture Camera2tex;
}
