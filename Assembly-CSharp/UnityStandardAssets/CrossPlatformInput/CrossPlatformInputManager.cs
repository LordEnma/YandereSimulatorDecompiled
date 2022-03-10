using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	public static class CrossPlatformInputManager
	{
		// Token: 0x06002214 RID: 8724 RVA: 0x001EE8BD File Offset: 0x001ECABD
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001EE8DD File Offset: 0x001ECADD
		public static void SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod activeInputMethod)
		{
			if (activeInputMethod == CrossPlatformInputManager.ActiveInputMethod.Hardware)
			{
				CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
				return;
			}
			if (activeInputMethod != CrossPlatformInputManager.ActiveInputMethod.Touch)
			{
				return;
			}
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_TouchInput;
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x001EE8FC File Offset: 0x001ECAFC
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001EE909 File Offset: 0x001ECB09
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001EE916 File Offset: 0x001ECB16
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x001EE923 File Offset: 0x001ECB23
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x0600221A RID: 8730 RVA: 0x001EE930 File Offset: 0x001ECB30
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001EE94B File Offset: 0x001ECB4B
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001EE958 File Offset: 0x001ECB58
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001EE965 File Offset: 0x001ECB65
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x0600221E RID: 8734 RVA: 0x001EE96E File Offset: 0x001ECB6E
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001EE977 File Offset: 0x001ECB77
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001EE985 File Offset: 0x001ECB85
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x001EE992 File Offset: 0x001ECB92
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x001EE99F File Offset: 0x001ECB9F
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x06002223 RID: 8739 RVA: 0x001EE9AC File Offset: 0x001ECBAC
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001EE9B9 File Offset: 0x001ECBB9
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x001EE9C6 File Offset: 0x001ECBC6
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x001EE9D3 File Offset: 0x001ECBD3
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002227 RID: 8743 RVA: 0x001EE9E0 File Offset: 0x001ECBE0
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x001EE9ED File Offset: 0x001ECBED
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002229 RID: 8745 RVA: 0x001EE9FB File Offset: 0x001ECBFB
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x0600222A RID: 8746 RVA: 0x001EEA07 File Offset: 0x001ECC07
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x0600222B RID: 8747 RVA: 0x001EEA14 File Offset: 0x001ECC14
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001EEA21 File Offset: 0x001ECC21
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004A52 RID: 19026
		private static VirtualInput activeInput;

		// Token: 0x04004A53 RID: 19027
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004A54 RID: 19028
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000687 RID: 1671
		public enum ActiveInputMethod
		{
			// Token: 0x0400500D RID: 20493
			Hardware,
			// Token: 0x0400500E RID: 20494
			Touch
		}

		// Token: 0x02000688 RID: 1672
		public class VirtualAxis
		{
			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x06002700 RID: 9984 RVA: 0x00201DA3 File Offset: 0x001FFFA3
			// (set) Token: 0x06002701 RID: 9985 RVA: 0x00201DAB File Offset: 0x001FFFAB
			public string name { get; private set; }

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x06002702 RID: 9986 RVA: 0x00201DB4 File Offset: 0x001FFFB4
			// (set) Token: 0x06002703 RID: 9987 RVA: 0x00201DBC File Offset: 0x001FFFBC
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002704 RID: 9988 RVA: 0x00201DC5 File Offset: 0x001FFFC5
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x06002705 RID: 9989 RVA: 0x00201DCF File Offset: 0x001FFFCF
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002706 RID: 9990 RVA: 0x00201DE5 File Offset: 0x001FFFE5
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x06002707 RID: 9991 RVA: 0x00201DF2 File Offset: 0x001FFFF2
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x06002708 RID: 9992 RVA: 0x00201DFB File Offset: 0x001FFFFB
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06002709 RID: 9993 RVA: 0x00201E03 File Offset: 0x00200003
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04005010 RID: 20496
			private float m_Value;
		}

		// Token: 0x02000689 RID: 1673
		public class VirtualButton
		{
			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x0600270A RID: 9994 RVA: 0x00201E0B File Offset: 0x0020000B
			// (set) Token: 0x0600270B RID: 9995 RVA: 0x00201E13 File Offset: 0x00200013
			public string name { get; private set; }

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x0600270C RID: 9996 RVA: 0x00201E1C File Offset: 0x0020001C
			// (set) Token: 0x0600270D RID: 9997 RVA: 0x00201E24 File Offset: 0x00200024
			public bool matchWithInputManager { get; private set; }

			// Token: 0x0600270E RID: 9998 RVA: 0x00201E2D File Offset: 0x0020002D
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x0600270F RID: 9999 RVA: 0x00201E37 File Offset: 0x00200037
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002710 RID: 10000 RVA: 0x00201E5D File Offset: 0x0020005D
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x06002711 RID: 10001 RVA: 0x00201E7A File Offset: 0x0020007A
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x06002712 RID: 10002 RVA: 0x00201E8E File Offset: 0x0020008E
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x06002713 RID: 10003 RVA: 0x00201E9B File Offset: 0x0020009B
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06002714 RID: 10004 RVA: 0x00201EA3 File Offset: 0x002000A3
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002715 RID: 10005 RVA: 0x00201EB4 File Offset: 0x002000B4
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04005014 RID: 20500
			private int m_LastPressedFrame = -5;

			// Token: 0x04005015 RID: 20501
			private int m_ReleasedFrame = -5;

			// Token: 0x04005016 RID: 20502
			private bool m_Pressed;
		}
	}
}
