using System;

namespace CGAME
{
    class ComputerInput : IInput
    {
        public override float HorizontalMovement { get => throw new NotImplementedException(); }
        public override float VerticalMovement { get => throw new NotImplementedException(); }
        public override bool IsAttack { get => throw new NotImplementedException(); }

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
