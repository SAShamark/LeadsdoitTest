using UnityEngine;

namespace Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string MoveButton = "Move";
        private const string StopButton = "Stop";
        public abstract Vector2 Axis { get; }
        
        public bool IsMove() => SimpleInput.GetButton(MoveButton);
        public bool IsStop() => SimpleInput.GetButton(StopButton);
        protected static Vector2 SimpleInputAxis() =>
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}