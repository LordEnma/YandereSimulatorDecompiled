using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000533 RID: 1331
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021F0 RID: 8688 RVA: 0x001ECEFC File Offset: 0x001EB0FC
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001ECF84 File Offset: 0x001EB184
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001ED01C File Offset: 0x001EB21C
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

		// Token: 0x04004A12 RID: 18962
		public Color minColour;

		// Token: 0x04004A13 RID: 18963
		private AeroplaneController m_Jet;

		// Token: 0x04004A14 RID: 18964
		private ParticleSystem m_System;

		// Token: 0x04004A15 RID: 18965
		private float m_OriginalStartSize;

		// Token: 0x04004A16 RID: 18966
		private float m_OriginalLifetime;

		// Token: 0x04004A17 RID: 18967
		private Color m_OriginalStartColor;
	}
}
