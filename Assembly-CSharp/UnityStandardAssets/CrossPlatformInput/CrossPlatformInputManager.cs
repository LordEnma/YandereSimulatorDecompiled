using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000544 RID: 1348
	public static class CrossPlatformInputManager
	{
		// Token: 0x06002255 RID: 8789 RVA: 0x001F45A9 File Offset: 0x001F27A9
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001F45C9 File Offset: 0x001F27C9
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

		// Token: 0x06002257 RID: 8791 RVA: 0x001F45E8 File Offset: 0x001F27E8
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001F45F5 File Offset: 0x001F27F5
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001F4602 File Offset: 0x001F2802
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001F460F File Offset: 0x001F280F
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001F461C File Offset: 0x001F281C
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001F4637 File Offset: 0x001F2837
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001F4644 File Offset: 0x001F2844
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001F4651 File Offset: 0x001F2851
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001F465A File Offset: 0x001F285A
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001F4663 File Offset: 0x001F2863
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001F4671 File Offset: 0x001F2871
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001F467E File Offset: 0x001F287E
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001F468B File Offset: 0x001F288B
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001F4698 File Offset: 0x001F2898
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x001F46A5 File Offset: 0x001F28A5
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x001F46B2 File Offset: 0x001F28B2
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001F46BF File Offset: 0x001F28BF
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001F46CC File Offset: 0x001F28CC
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x001F46D9 File Offset: 0x001F28D9
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600226A RID: 8810 RVA: 0x001F46E7 File Offset: 0x001F28E7
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001F46F3 File Offset: 0x001F28F3
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001F4700 File Offset: 0x001F2900
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001F470D File Offset: 0x001F290D
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004B0F RID: 19215
		private static VirtualInput activeInput;

		// Token: 0x04004B10 RID: 19216
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004B11 RID: 19217
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000692 RID: 1682
		public enum ActiveInputMethod
		{
			// Token: 0x040050D2 RID: 20690
			Hardware,
			// Token: 0x040050D3 RID: 20691
			Touch
		}

		// Token: 0x02000693 RID: 1683
		public class VirtualAxis
		{
			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x06002741 RID: 10049 RVA: 0x00207CF3 File Offset: 0x00205EF3
			// (set) Token: 0x06002742 RID: 10050 RVA: 0x00207CFB File Offset: 0x00205EFB
			public string name { get; private set; }

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06002743 RID: 10051 RVA: 0x00207D04 File Offset: 0x00205F04
			// (set) Token: 0x06002744 RID: 10052 RVA: 0x00207D0C File Offset: 0x00205F0C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002745 RID: 10053 RVA: 0x00207D15 File Offset: 0x00205F15
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x06002746 RID: 10054 RVA: 0x00207D1F File Offset: 0x00205F1F
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002747 RID: 10055 RVA: 0x00207D35 File Offset: 0x00205F35
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x06002748 RID: 10056 RVA: 0x00207D42 File Offset: 0x00205F42
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x06002749 RID: 10057 RVA: 0x00207D4B File Offset: 0x00205F4B
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x0600274A RID: 10058 RVA: 0x00207D53 File Offset: 0x00205F53
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x040050D5 RID: 20693
			private float m_Value;
		}

		// Token: 0x02000694 RID: 1684
		public class VirtualButton
		{
			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x0600274B RID: 10059 RVA: 0x00207D5B File Offset: 0x00205F5B
			// (set) Token: 0x0600274C RID: 10060 RVA: 0x00207D63 File Offset: 0x00205F63
			public string name { get; private set; }

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x0600274D RID: 10061 RVA: 0x00207D6C File Offset: 0x00205F6C
			// (set) Token: 0x0600274E RID: 10062 RVA: 0x00207D74 File Offset: 0x00205F74
			public bool matchWithInputManager { get; private set; }

			// Token: 0x0600274F RID: 10063 RVA: 0x00207D7D File Offset: 0x00205F7D
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x06002750 RID: 10064 RVA: 0x00207D87 File Offset: 0x00205F87
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002751 RID: 10065 RVA: 0x00207DAD File Offset: 0x00205FAD
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x06002752 RID: 10066 RVA: 0x00207DCA File Offset: 0x00205FCA
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x06002753 RID: 10067 RVA: 0x00207DDE File Offset: 0x00205FDE
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002754 RID: 10068 RVA: 0x00207DEB File Offset: 0x00205FEB
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x06002755 RID: 10069 RVA: 0x00207DF3 File Offset: 0x00205FF3
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x06002756 RID: 10070 RVA: 0x00207E04 File Offset: 0x00206004
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x040050D9 RID: 20697
			private int m_LastPressedFrame = -5;

			// Token: 0x040050DA RID: 20698
			private int m_ReleasedFrame = -5;

			// Token: 0x040050DB RID: 20699
			private bool m_Pressed;
		}
	}
}
