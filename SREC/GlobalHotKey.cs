using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GlobalHotKey
{
    internal static class WinApi
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    public enum Modifiers { Alt = 1, Control = 2, Shift = 4, Win = 8 }

    public delegate void HotKeyCallBackHanlder();

    public static class HotKeyManager
    {
        private static IntPtr handle;
        private static int keyid = 0;
        private static Dictionary<int, HotKeyCallBackHanlder> keyMap = new Dictionary<int, HotKeyCallBackHanlder>();

        public static void Init(IntPtr handle)
        {
            HotKeyManager.handle = handle;
        }

        public static HotKey Register(Keys key, Modifiers modifiers, HotKeyCallBackHanlder callBack)
        {
            HotKey hotKey = new HotKey(key, modifiers, ++keyid);

            if (!WinApi.RegisterHotKey(handle, keyid, (uint)modifiers, (uint)key))
            {
                throw new Exception("Global Hotkey Registration Failed!");
            }

            keyMap[keyid] = callBack;

            return hotKey;
        }

        public static bool Unregister(HotKey hotKey)
        {
            keyMap.Remove(hotKey.id);
            return WinApi.UnregisterHotKey(handle, hotKey.id);
        }

        public static void ProcessHotKey(ref Message m)
        {
            if (m.Msg == 0x312)
            {
                int id = m.WParam.ToInt32();
                HotKeyCallBackHanlder callBack;
                if (keyMap.TryGetValue(id, out callBack)) { callBack(); }
            }
        }
    }

    public class HotKey
    {
        public int id;
        public Keys key;
        public Modifiers modifiers;

        public HotKey(Keys key, Modifiers modifiers, int id)
        {
            this.id = id;
            this.key = key;
            this.modifiers = modifiers;
        }
    }
}
