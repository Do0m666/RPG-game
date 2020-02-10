using System;

namespace CGAME
{
    class PlayerInput : IInput
    {
        public override float HorizontalMovement
        {
            get
            {
                if (InputManager.GetButtonDown(Action.MOVE_RIGHT) && InputManager.GetButtonDown(Action.MOVE_LEFT))
                    return 0f;
                else
                if (InputManager.GetButtonDown(Action.MOVE_RIGHT))
                    return 1f;
                else
                if (InputManager.GetButtonDown(Action.MOVE_LEFT))
                    return -1f;

                return 0f;
            }
        }

        public override float VerticalMovement
        {
            get
            {
                if (InputManager.GetButtonDown(Action.MOVE_UP) && InputManager.GetButtonDown(Action.MOVE_DOWN))
                    return 0f;
                else
                if (InputManager.GetButtonDown(Action.MOVE_UP))
                    return 1f;
                else
                if (InputManager.GetButtonDown(Action.MOVE_DOWN))
                    return -1f;

                return 0f;
            }
        }

        public override bool IsAttack { get { return InputManager.GetButtonDown(Action.ATTACK); } }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
