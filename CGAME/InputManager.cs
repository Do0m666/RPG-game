
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CGAME
{
    enum Action
    {
        MOVE_UP = Key.W,
        MOVE_DOWN = Key.S,
        MOVE_LEFT = Key.A,
        MOVE_RIGHT = Key.D,
        ATTACK = Key.F
    }

    struct KeyAction
    {
        public bool prev_keyPress; 
        //
        public bool keyPress;
        public bool keyDown;
        public bool keyUp;

        public KeyAction(bool _startState)
        {
            prev_keyPress = _startState;
            keyPress = _startState;
            keyDown = _startState;
            keyUp = _startState;
        }
    }

    static class InputManager
    {
        static Dictionary<int, KeyAction> keyActionDict = new Dictionary<int, KeyAction>();

        static InputManager()
        {
            keyActionDict.Add((int)Action.MOVE_RIGHT, new KeyAction(false));
            keyActionDict.Add((int)Action.MOVE_LEFT, new KeyAction(false));
            keyActionDict.Add((int)Action.MOVE_UP, new KeyAction(false));
            keyActionDict.Add((int)Action.MOVE_DOWN, new KeyAction(false));
            keyActionDict.Add((int)Action.ATTACK, new KeyAction(false));
        }

        private static KeyAction currentKeyAction;

        private static KeyValuePair<int, KeyAction> pair;

        public static void Update()
        {
            for (int index = 0; index < keyActionDict.Count; index++)
            {
                pair = keyActionDict.ElementAt(index);

                currentKeyAction = keyActionDict[pair.Key];

                if (currentKeyAction.prev_keyPress)
                {
                    currentKeyAction.keyDown = false;
                }

                if (GetButtonTest((Action)pair.Key))
                {
                    if (!currentKeyAction.prev_keyPress)
                    {
                        currentKeyAction.keyDown = true;
                    }

                    currentKeyAction.keyPress = true;

                    currentKeyAction.prev_keyPress = true;
                }
                else
                {
                    if (currentKeyAction.prev_keyPress)
                    {
                        currentKeyAction.keyUp = true;
                        //
                        currentKeyAction.keyDown = false;
                        currentKeyAction.keyPress = false;
                    }
                    else
                    {
                        currentKeyAction.keyUp = false;
                    }

                    currentKeyAction.prev_keyPress = false;
                }

                keyActionDict[pair.Key] = currentKeyAction;
            }
        }

        public static bool GetButton(Action action)
        {
            return keyActionDict[(int)action].keyPress;
        }

        public static bool GetButtonTest(Action action)
        {
            return Keyboard.IsKeyDown((Key)action);
        }

        public static bool GetButtonDown(Action action)
        {
            return keyActionDict[(int)action].keyDown;
        }

        public static bool GetButtonUp(Action action)
        {
            return keyActionDict[(int)action].keyUp;
        }
    }
}
