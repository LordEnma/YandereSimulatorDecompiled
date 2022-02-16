using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public static class CrossPlatformInputManager
	{
		// Token: 0x06002205 RID: 8709 RVA: 0x001ED305 File Offset: 0x001EB505
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x001ED325 File Offset: 0x001EB525
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

		// Token: 0x06002207 RID: 8711 RVA: 0x001ED344 File Offset: 0x001EB544
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001ED351 File Offset: 0x001EB551
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001ED35E File Offset: 0x001EB55E
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001ED36B File Offset: 0x001EB56B
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001ED378 File Offset: 0x001EB578
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x001ED393 File Offset: 0x001EB593
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001ED3A0 File Offset: 0x001EB5A0
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x001ED3AD File Offset: 0x001EB5AD
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001ED3B6 File Offset: 0x001EB5B6
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x001ED3BF File Offset: 0x001EB5BF
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001ED3CD File Offset: 0x001EB5CD
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x001ED3DA File Offset: 0x001EB5DA
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x001ED3E7 File Offset: 0x001EB5E7
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x001ED3F4 File Offset: 0x001EB5F4
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001ED401 File Offset: 0x001EB601
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x001ED40E File Offset: 0x001EB60E
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001ED41B File Offset: 0x001EB61B
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001ED428 File Offset: 0x001EB628
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x001ED435 File Offset: 0x001EB635
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x0600221A RID: 8730 RVA: 0x001ED443 File Offset: 0x001EB643
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001ED44F File Offset: 0x001EB64F
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001ED45C File Offset: 0x001EB65C
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001ED469 File Offset: 0x001EB669
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004A25 RID: 18981
		private static VirtualInput activeInput;

		// Token: 0x04004A26 RID: 18982
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004A27 RID: 18983
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000683 RID: 1667
		public enum ActiveInputMethod
		{
			// Token: 0x04004FDB RID: 20443
			Hardware,
			// Token: 0x04004FDC RID: 20444
			Touch
		}

		// Token: 0x02000684 RID: 1668
		public class VirtualAxis
		{
			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026E8 RID: 9960 RVA: 0x00200723 File Offset: 0x001FE923
			// (set) Token: 0x060026E9 RID: 9961 RVA: 0x0020072B File Offset: 0x001FE92B
			public string name { get; private set; }

			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026EA RID: 9962 RVA: 0x00200734 File Offset: 0x001FE934
			// (set) Token: 0x060026EB RID: 9963 RVA: 0x0020073C File Offset: 0x001FE93C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026EC RID: 9964 RVA: 0x00200745 File Offset: 0x001FE945
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026ED RID: 9965 RVA: 0x0020074F File Offset: 0x001FE94F
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026EE RID: 9966 RVA: 0x00200765 File Offset: 0x001FE965
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026EF RID: 9967 RVA: 0x00200772 File Offset: 0x001FE972
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026F0 RID: 9968 RVA: 0x0020077B File Offset: 0x001FE97B
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026F1 RID: 9969 RVA: 0x00200783 File Offset: 0x001FE983
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FDE RID: 20446
			private float m_Value;
		}

		// Token: 0x02000685 RID: 1669
		public class VirtualButton
		{
			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026F2 RID: 9970 RVA: 0x0020078B File Offset: 0x001FE98B
			// (set) Token: 0x060026F3 RID: 9971 RVA: 0x00200793 File Offset: 0x001FE993
			public string name { get; private set; }

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060026F4 RID: 9972 RVA: 0x0020079C File Offset: 0x001FE99C
			// (set) Token: 0x060026F5 RID: 9973 RVA: 0x002007A4 File Offset: 0x001FE9A4
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026F6 RID: 9974 RVA: 0x002007AD File Offset: 0x001FE9AD
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026F7 RID: 9975 RVA: 0x002007B7 File Offset: 0x001FE9B7
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026F8 RID: 9976 RVA: 0x002007DD File Offset: 0x001FE9DD
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026F9 RID: 9977 RVA: 0x002007FA File Offset: 0x001FE9FA
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026FA RID: 9978 RVA: 0x0020080E File Offset: 0x001FEA0E
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x060026FB RID: 9979 RVA: 0x0020081B File Offset: 0x001FEA1B
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x060026FC RID: 9980 RVA: 0x00200823 File Offset: 0x001FEA23
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x060026FD RID: 9981 RVA: 0x00200834 File Offset: 0x001FEA34
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FE2 RID: 20450
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FE3 RID: 20451
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FE4 RID: 20452
			private bool m_Pressed;
		}
	}
}
