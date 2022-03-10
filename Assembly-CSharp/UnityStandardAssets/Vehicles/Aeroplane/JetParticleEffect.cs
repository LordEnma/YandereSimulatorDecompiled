using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000535 RID: 1333
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021FF RID: 8703 RVA: 0x001EE4B4 File Offset: 0x001EC6B4
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001EE53C File Offset: 0x001EC73C
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001EE5D4 File Offset: 0x001EC7D4
		private AeroplaneController FindAeroplaneParent()
		{
			Transform transform = base.transform;
			while (transform != null)
			{
				AeroplaneController component = transform.GetComponent<AeroplaneController>();
				if (!(component == null))
				{
					return component;
				}
				transform = transform.parent;
			}
			throw new Exception(" AeroplaneContoller not found in object hierarchy");
		}

		// Token: 0x04004A3F RID: 19007
		public Color minColour;

		// Token: 0x04004A40 RID: 19008
		private AeroplaneController m_Jet;

		// Token: 0x04004A41 RID: 19009
		private ParticleSystem m_System;

		// Token: 0x04004A42 RID: 19010
		private float m_OriginalStartSize;

		// Token: 0x04004A43 RID: 19011
		private float m_OriginalLifetime;

		// Token: 0x04004A44 RID: 19012
		private Color m_OriginalStartColor;
	}
}
