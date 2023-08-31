using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace J_Hooking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            hookProc = HookProc;

            Controls.Add(label = new Label
            {
                Dock = DockStyle.Fill,

            });
            label.Text = string.Empty;

            Load += (s, e) => // 폼로드 이벤트
            {
                IsPressed = false;
                IntPtr hInstance = LoadLibrary("User32");

                // Start Hook
                hHook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, hInstance, 0);
            };

            // 폼종료 이벤트 : Stop Hook
            FormClosing += (s, e) => UnhookWindowsHookEx(hHook);
        }

        public static IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            if (vkCode != A_KEY)
                CallNextHookEx(hHook, code, (int)wParam, lParam);

            switch (vkCode)
            {
                case F1_KEY: // F1
                    {
                        IsPressed = true;
                        return (IntPtr)1; // 표준 단축키 기능 중지
                    };
                case F2_KEY: // F2
                    {
                        IsPressed = false;
                        return (IntPtr)1; // 표준 단축키 기능 중지
                    };
            }

            switch (vkCode)
            {
                case A_KEY:
                    {
                        if (IsPressed)
                        {
                            // TODO : A 키 단축키 이벤트 설정하기
                            label.Text += (Keys)vkCode;

                            return (IntPtr)1;
                        }
                        break;
                    };

                // 일반키 정상처리
                default: CallNextHookEx(hHook, code, (int)wParam, lParam); break;
            }

            // 일반키 정상처리
            return CallNextHookEx(hHook, code, (int)wParam, lParam);
        }

        /// <summary>
        /// F1 (true) or F2 (false) 키 상태저장
        /// </summary>
        private static bool isPressed;
        public static bool IsPressed
        {
            get => isPressed;
            set => isPressed = value;
        }

        const int WH_KEYBOARD_LL = 13;  // 키보드 입력 이벤트
        const int F1_KEY = 0x70;        // F1
        const int F2_KEY = 0x71;        // F2
        const int A_KEY = 0x41;         // A key

        private readonly LowLevelKeyboardProc hookProc;
        private static IntPtr hHook = IntPtr.Zero;
        public static Label label;

        #region API
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        #endregion

    }
    public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
}

/*
상수,값,Description
VK_LBUTTON,0x01,왼쪽 마우스 단추
VK_RBUTTON,0x02,마우스 오른쪽 단추
VK_CANCEL,0x03,제어 중단 처리
VK_MBUTTON,0x04,가운데 마우스 단추(3개 단추 마우스)
VK_XBUTTON1,0x05,X1 마우스 단추
VK_XBUTTON2,0x06,X2 마우스 단추
-,0x07,정의되지 않음
VK_BACK,0x08,BACKSPACE 키
VK_TAB,0x09,Tab 키
-,0x0A-0B,예약됨
VK_CLEAR,0x0C,CLEAR 키
VK_RETURN,0x0D,Enter 키
-,0x0E-0F,정의되지 않음
VK_SHIFT,0x10,SHIFT 키
VK_CONTROL,0x11,Ctrl 키
VK_MENU,0x12,Alt 키
VK_PAUSE,0x13,PAUSE 키
VK_CAPITAL,0x14,CAPS LOCK 키
VK_KANA,0x15,IME 가나 모드
VK_HANGUEL,0x15,"IME 한글 모드(호환성을 위해 유지 관리됨, 사용 VK_HANGUL)"
VK_HANGUL,0x15,IME 한글 모드
VK_IME_ON,0x16,IME 켜기
VK_JUNJA,0x17,IME 전자 모드
VK_FINAL,0x18,IME 최종 모드
VK_HANJA,0x19,IME 한자 모드
VK_KANJI,0x19,IME 간지 모드
VK_IME_OFF,0x1A,IME 끄기
VK_ESCAPE,0x1B,ESC 키
VK_CONVERT,0x1C,IME 변환
VK_NONCONVERT,0x1D,IME 변환 안 함
VK_ACCEPT,0x1E,IME 수락
VK_MODECHANGE,0x1F,IME 모드 변경 요청
VK_SPACE,0x20,스페이스바
VK_PRIOR,0x21,PAGE UP 키
VK_NEXT,0x22,PAGE DOWN 키
VK_END,0x23,END 키
VK_HOME,0x24,HOME 키
VK_LEFT,0x25,왼쪽 화살표 키
VK_UP,0x26,위쪽 화살표 키
VK_RIGHT,0x27,오른쪽 화살표 키
VK_DOWN,0x28,아래쪽 화살표 키
VK_SELECT,0x29,SELECT 키
VK_PRINT,0x2A,PRINT 키
VK_EXECUTE,0x2B,EXECUTE 키
VK_SNAPSHOT,0x2C,인쇄 화면 키
VK_INSERT,0x2D,INS 키
VK_DELETE,0x2E,DEL 키
VK_HELP,0x2F,도움말 키
0x30,0 키,
0x31,키 1개,
0x32,키 2개,
0x33,키 3개,
0x34,4 키,
0x35,키 5개,
0x36,6개 키,
0x37,7 키,
0x38,8개 키,
0x39,9 키,
-,0x3A-40,정의되지 않음
0x41,A 키,
0x42,B 키,
0x43,C 키,
0x44,D 키,
0x45,E 키,
0x46,F 키,
0x47,G 키,
0x48,H 키,
0x49,I 키,
0x4A,J 키,
0x4B,K 키,
0x4C,L 키,
0x4D,M 키,
0x4E,N 키,
0x4F,O 키,
0x50,P 키,
0x51,Q 키,
0x52,R 키,
0x53,S 키,
0x54,T 키,
0x55,U 키,
0x56,V 키,
0x57,W 키,
0x58,X 키,
0x59,Y 키,
0x5A,Z 키,
VK_LWIN,0x5B,왼쪽 Windows 키(자연 키보드)
VK_RWIN,0x5C,오른쪽 Windows 키(자연 키보드)
VK_APPS,0x5D,애플리케이션 키(자연 키보드)
-,0x5E,예약됨
VK_SLEEP,0x5F,컴퓨터 절전 키
VK_NUMPAD0,0x60,숫자 키패드 0 키
VK_NUMPAD1,0x61,숫자 키패드 1 키
VK_NUMPAD2,0x62,숫자 키패드 2 키
VK_NUMPAD3,0x63,숫자 키패드 3 키
VK_NUMPAD4,0x64,숫자 키패드 4 키
VK_NUMPAD5,0x65,숫자 키패드 5 키
VK_NUMPAD6,0x66,숫자 키패드 6 키
VK_NUMPAD7,0x67,숫자 키패드 7 키
VK_NUMPAD8,0x68,숫자 키패드 8 키
VK_NUMPAD9,0x69,숫자 키패드 9 키
VK_MULTIPLY,0x6A,곱하기 키
VK_ADD,0x6B,키 추가
VK_SEPARATOR,0x6C,구분 기호 키
VK_SUBTRACT,0x6D,키 빼기
VK_DECIMAL,0x6E,10진수 키
VK_DIVIDE,0x6F,키 나누기
VK_F1,0x70,F1 키
VK_F2,0x71,F2 키
VK_F3,0x72,F3 키
VK_F4,0x73,F4 키
VK_F5,0x74,F5 키
VK_F6,0x75,F6 키
VK_F7,0x76,F7 키
VK_F8,0x77,F8 키
VK_F9,0x78,F9 키
VK_F10,0x79,F10 키
VK_F11,0x7A,F11 키
VK_F12,0x7B,F12 키
VK_F13,0x7C,F13 키
VK_F14,0x7D,F14 키
VK_F15,0x7e,F15 키
VK_F16,0x7F,F16 키
VK_F17,0x80,F17 키
VK_F18,0x81,F18 키
VK_F19,0x82,F19 키
VK_F20,0x83,F20 키
VK_F21,0x84,F21 키
VK_F22,0x85,F22 키
VK_F23,0x86,F23 키
VK_F24,0x87,F24 키
-,0x88-8F,할당되지 않음
VK_NUMLOCK,0x90,NUM LOCK 키
VK_SCROLL,0x91,SCROLL LOCK 키
0x92-96,OEM 관련,
-,0x97-9F,할당되지 않음
VK_LSHIFT,0xA0,왼쪽 Shift 키
VK_RSHIFT,0xA1,오른쪽 Shift 키
VK_LCONTROL,0xA2,왼쪽 Ctrl 키
VK_RCONTROL,0xA3,오른쪽 Ctrl 키
VK_LMENU,0xA4,왼쪽 ALT 키
VK_RMENU,0xA5,오른쪽 ALT 키
VK_BROWSER_BACK,0xA6,브라우저 뒤로 키
VK_BROWSER_FORWARD,0xA7,브라우저 앞으로 키
VK_BROWSER_REFRESH,0xA8,브라우저 새로 고침 키
VK_BROWSER_STOP,0xA9,브라우저 중지 키
VK_BROWSER_SEARCH,0xAA,브라우저 검색 키
VK_BROWSER_FAVORITES,0xAB,브라우저 즐겨찾기 키
VK_BROWSER_HOME,0xAC,브라우저 시작 및 홈 키
VK_VOLUME_MUTE,0xAD,볼륨 음소거 키
VK_VOLUME_DOWN,0xAE,볼륨 다운 키
VK_VOLUME_UP,0xAF,볼륨 업 키
VK_MEDIA_NEXT_TRACK,0xB0,다음 트랙 키
VK_MEDIA_PREV_TRACK,0xB1,이전 트랙 키
VK_MEDIA_STOP,0xB2,미디어 중지 키
VK_MEDIA_PLAY_PAUSE,0xB3,미디어 재생/일시 중지 키
VK_LAUNCH_MAIL,0xB4,시작 메일 키
VK_LAUNCH_MEDIA_SELECT,0xB5,미디어 키 선택
VK_LAUNCH_APP1,0xB6,애플리케이션 1 키 시작
VK_LAUNCH_APP2,0xB7,애플리케이션 2 키 시작
-,0xB8-B9,예약됨
VK_OEM_1,0xBA,기타 문자에 사용됩니다. 키보드에 따라 달라질 수 있습니다. 미국 표준 키보드의 경우 ';:' 키
VK_OEM_PLUS,0xBB,모든 국가/지역의 경우 '+' 키
VK_OEM_COMMA,0xBC,"모든 국가/지역의 경우 ',' 키"
VK_OEM_MINUS,0xBD,모든 국가/지역의 경우 '-' 키
VK_OEM_PERIOD,0xBE,모든 국가/지역의 경우 '.' 키
VK_OEM_2,0xBF,기타 문자에 사용됩니다. 키보드에 따라 달라질 수 있습니다. 미국 표준 키보드의 경우 '/?' key
VK_OEM_3,0xC0,기타 문자에 사용됩니다. 키보드에 따라 달라질 수 있습니다. 미국 표준 키보드의 경우 ''~' 키
-,0xC1-D7,예약됨
-,0xD8-DA,할당되지 않음
VK_OEM_4,0xDB,기타 문자에 사용됩니다. 키보드에 따라 달라질 수 있습니다. 미국 표준 키보드의 경우 '[{' 키
VK_OEM_5,0xDC,기타 문자에 사용됩니다. 키보드에 따라 달라질 수 있습니다. 미국 표준 키보드의 경우 '\|' 키
VK_OEM_6,0xDD,기타 문자에 사용됩니다. 키보드에 따라 달라질 수 있습니다. 미국 표준 키보드의 경우 ']}' 키
VK_OEM_7,0xDE,기타 문자에 사용됩니다. 키보드에 따라 달라질 수 있습니다. 미국 표준 키보드의 경우 '큰따옴표/큰따옴표' 키
VK_OEM_8,0xDF,기타 문자에 사용됩니다. 키보드에 따라 달라질 수 있습니다.
-,0xE0,예약됨
0xE1,OEM 관련,
VK_OEM_102,0xE2,<> 미국 표준 키보드의 키 또는 \\| 미국 이외의 102 키 키보드의 키
0xE3-E4,OEM 관련,
VK_PROCESSKEY,0xE5,IME 프로세스 키
0xE6,OEM 관련,
VK_PACKET,0xE7,유니코드 문자를 키 입력인 것처럼 전달할 때 사용합니다. 키는 VK_PACKET 키보드가 아닌 입력 메서드에 사용되는 32비트 가상 키 값의 소문자입니다. 자세한 내용은 다음에서 비고를 참조하세요.KEYBDINPUTSendInputWM_KEYDOWNWM_KEYUP
-,0xE8,할당되지 않음
0xE9-F5,OEM 관련,
VK_ATTN,0xF6,Attn 키
VK_CRSEL,0xF7,CrSel 키
VK_EXSEL,0xF8,ExSel 키
VK_EREOF,0xF9,EOF 키 지우기
VK_PLAY,0xFA,재생 키
VK_ZOOM,0xFB,확대/축소 키
VK_NONAME,0xFC,예약됨
VK_PA1,0xFD,PA1 키
VK_OEM_CLEAR,0xFE,키 지우기

 */
