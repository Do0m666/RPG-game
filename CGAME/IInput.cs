

namespace CGAME
{
    enum InputType
    {
        PLAYER,
        COMPUTER
    }

    abstract class IInput
    {
        public int m_ID = -1;

        public InputType inputType;

        public abstract float HorizontalMovement { get; }
        public abstract float VerticalMovement { get; }

        public abstract bool IsAttack { get; }

        public abstract void Update();

        public abstract void Destroy();
    }
}
