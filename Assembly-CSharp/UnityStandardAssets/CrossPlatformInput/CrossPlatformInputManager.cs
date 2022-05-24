using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000545 RID: 1349
	public static class CrossPlatformInputManager
	{
		// Token: 0x06002260 RID: 8800 RVA: 0x001F6161 File Offset: 0x001F4361
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001F6181 File Offset: 0x001F4381
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

		// Token: 0x06002262 RID: 8802 RVA: 0x001F61A0 File Offset: 0x001F43A0
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001F61AD File Offset: 0x001F43AD
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001F61BA File Offset: 0x001F43BA
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x001F61C7 File Offset: 0x001F43C7
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x001F61D4 File Offset: 0x001F43D4
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001F61EF File Offset: 0x001F43EF
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001F61FC File Offset: 0x001F43FC
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x001F6209 File Offset: 0x001F4409
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001F6212 File Offset: 0x001F4412
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001F621B File Offset: 0x001F441B
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001F6229 File Offset: 0x001F4429
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001F6236 File Offset: 0x001F4436
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001F6243 File Offset: 0x001F4443
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x001F6250 File Offset: 0x001F4450
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x001F625D File Offset: 0x001F445D
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x001F626A File Offset: 0x001F446A
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x001F6277 File Offset: 0x001F4477
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x001F6284 File Offset: 0x001F4484
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x001F6291 File Offset: 0x001F4491
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06002275 RID: 8821 RVA: 0x001F629F File Offset: 0x001F449F
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x001F62AB File Offset: 0x001F44AB
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x001F62B8 File Offset: 0x001F44B8
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002278 RID: 8824 RVA: 0x001F62C5 File Offset: 0x001F44C5
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004B3F RID: 19263
		private static VirtualInput activeInput;

		// Token: 0x04004B40 RID: 19264
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004B41 RID: 19265
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000693 RID: 1683
		public enum ActiveInputMethod
		{
			// Token: 0x04005102 RID: 20738
			Hardware,
			// Token: 0x04005103 RID: 20739
			Touch
		}

		// Token: 0x02000694 RID: 1684
		public class VirtualAxis
		{
			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x0600274C RID: 10060 RVA: 0x002098D3 File Offset: 0x00207AD3
			// (set) Token: 0x0600274D RID: 10061 RVA: 0x002098DB File Offset: 0x00207ADB
			public string name { get; private set; }

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x0600274E RID: 10062 RVA: 0x002098E4 File Offset: 0x00207AE4
			// (set) Token: 0x0600274F RID: 10063 RVA: 0x002098EC File Offset: 0x00207AEC
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002750 RID: 10064 RVA: 0x002098F5 File Offset: 0x00207AF5
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x06002751 RID: 10065 RVA: 0x002098FF File Offset: 0x00207AFF
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002752 RID: 10066 RVA: 0x00209915 File Offset: 0x00207B15
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x06002753 RID: 10067 RVA: 0x00209922 File Offset: 0x00207B22
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x06002754 RID: 10068 RVA: 0x0020992B File Offset: 0x00207B2B
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x06002755 RID: 10069 RVA: 0x00209933 File Offset: 0x00207B33
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04005105 RID: 20741
			private float m_Value;
		}

		// Token: 0x02000695 RID: 1685
		public class VirtualButton
		{
			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06002756 RID: 10070 RVA: 0x0020993B File Offset: 0x00207B3B
			// (set) Token: 0x06002757 RID: 10071 RVA: 0x00209943 File Offset: 0x00207B43
			public string name { get; private set; }

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002758 RID: 10072 RVA: 0x0020994C File Offset: 0x00207B4C
			// (set) Token: 0x06002759 RID: 10073 RVA: 0x00209954 File Offset: 0x00207B54
			public bool matchWithInputManager { get; private set; }

			// Token: 0x0600275A RID: 10074 RVA: 0x0020995D File Offset: 0x00207B5D
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x0600275B RID: 10075 RVA: 0x00209967 File Offset: 0x00207B67
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x0600275C RID: 10076 RVA: 0x0020998D File Offset: 0x00207B8D
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x0600275D RID: 10077 RVA: 0x002099AA File Offset: 0x00207BAA
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x0600275E RID: 10078 RVA: 0x002099BE File Offset: 0x00207BBE
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600275F RID: 10079 RVA: 0x002099CB File Offset: 0x00207BCB
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x06002760 RID: 10080 RVA: 0x002099D3 File Offset: 0x00207BD3
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x06002761 RID: 10081 RVA: 0x002099E4 File Offset: 0x00207BE4
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04005109 RID: 20745
			private int m_LastPressedFrame = -5;

			// Token: 0x0400510A RID: 20746
			private int m_ReleasedFrame = -5;

			// Token: 0x0400510B RID: 20747
			private bool m_Pressed;
		}
	}
}
