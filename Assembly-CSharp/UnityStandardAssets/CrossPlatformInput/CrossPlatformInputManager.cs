using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000543 RID: 1347
	public static class CrossPlatformInputManager
	{
		// Token: 0x06002244 RID: 8772 RVA: 0x001F25C5 File Offset: 0x001F07C5
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x001F25E5 File Offset: 0x001F07E5
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

		// Token: 0x06002246 RID: 8774 RVA: 0x001F2604 File Offset: 0x001F0804
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001F2611 File Offset: 0x001F0811
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x001F261E File Offset: 0x001F081E
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001F262B File Offset: 0x001F082B
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001F2638 File Offset: 0x001F0838
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001F2653 File Offset: 0x001F0853
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001F2660 File Offset: 0x001F0860
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x001F266D File Offset: 0x001F086D
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001F2676 File Offset: 0x001F0876
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001F267F File Offset: 0x001F087F
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001F268D File Offset: 0x001F088D
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x001F269A File Offset: 0x001F089A
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001F26A7 File Offset: 0x001F08A7
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001F26B4 File Offset: 0x001F08B4
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001F26C1 File Offset: 0x001F08C1
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x001F26CE File Offset: 0x001F08CE
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001F26DB File Offset: 0x001F08DB
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001F26E8 File Offset: 0x001F08E8
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001F26F5 File Offset: 0x001F08F5
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002259 RID: 8793 RVA: 0x001F2703 File Offset: 0x001F0903
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001F270F File Offset: 0x001F090F
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001F271C File Offset: 0x001F091C
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001F2729 File Offset: 0x001F0929
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004AE7 RID: 19175
		private static VirtualInput activeInput;

		// Token: 0x04004AE8 RID: 19176
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004AE9 RID: 19177
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000691 RID: 1681
		public enum ActiveInputMethod
		{
			// Token: 0x040050A2 RID: 20642
			Hardware,
			// Token: 0x040050A3 RID: 20643
			Touch
		}

		// Token: 0x02000692 RID: 1682
		public class VirtualAxis
		{
			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x06002730 RID: 10032 RVA: 0x00205BFB File Offset: 0x00203DFB
			// (set) Token: 0x06002731 RID: 10033 RVA: 0x00205C03 File Offset: 0x00203E03
			public string name { get; private set; }

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x06002732 RID: 10034 RVA: 0x00205C0C File Offset: 0x00203E0C
			// (set) Token: 0x06002733 RID: 10035 RVA: 0x00205C14 File Offset: 0x00203E14
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002734 RID: 10036 RVA: 0x00205C1D File Offset: 0x00203E1D
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x06002735 RID: 10037 RVA: 0x00205C27 File Offset: 0x00203E27
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002736 RID: 10038 RVA: 0x00205C3D File Offset: 0x00203E3D
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x06002737 RID: 10039 RVA: 0x00205C4A File Offset: 0x00203E4A
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06002738 RID: 10040 RVA: 0x00205C53 File Offset: 0x00203E53
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x06002739 RID: 10041 RVA: 0x00205C5B File Offset: 0x00203E5B
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x040050A5 RID: 20645
			private float m_Value;
		}

		// Token: 0x02000693 RID: 1683
		public class VirtualButton
		{
			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x0600273A RID: 10042 RVA: 0x00205C63 File Offset: 0x00203E63
			// (set) Token: 0x0600273B RID: 10043 RVA: 0x00205C6B File Offset: 0x00203E6B
			public string name { get; private set; }

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x0600273C RID: 10044 RVA: 0x00205C74 File Offset: 0x00203E74
			// (set) Token: 0x0600273D RID: 10045 RVA: 0x00205C7C File Offset: 0x00203E7C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x0600273E RID: 10046 RVA: 0x00205C85 File Offset: 0x00203E85
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x0600273F RID: 10047 RVA: 0x00205C8F File Offset: 0x00203E8F
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002740 RID: 10048 RVA: 0x00205CB5 File Offset: 0x00203EB5
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x06002741 RID: 10049 RVA: 0x00205CD2 File Offset: 0x00203ED2
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x06002742 RID: 10050 RVA: 0x00205CE6 File Offset: 0x00203EE6
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06002743 RID: 10051 RVA: 0x00205CF3 File Offset: 0x00203EF3
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002744 RID: 10052 RVA: 0x00205CFB File Offset: 0x00203EFB
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x06002745 RID: 10053 RVA: 0x00205D0C File Offset: 0x00203F0C
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x040050A9 RID: 20649
			private int m_LastPressedFrame = -5;

			// Token: 0x040050AA RID: 20650
			private int m_ReleasedFrame = -5;

			// Token: 0x040050AB RID: 20651
			private bool m_Pressed;
		}
	}
}
