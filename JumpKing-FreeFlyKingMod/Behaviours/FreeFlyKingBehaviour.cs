using JumpKing.API;
using JumpKing.BodyCompBehaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JumpKing_FreeFlyKingMod.Behaviours
{
    public class FreeFlyKingBehaviour : IBodyCompBehaviour
    {
        private bool isActive = false;
        private bool freeFlyingToggleCooldown = false;

        private const Keys toggleKey = Keys.H;

        public bool ExecuteBehaviour(BehaviourContext behaviourContext)
        {
            KeyboardState state = Keyboard.GetState();
            
            if (state.IsKeyDown(toggleKey) && !freeFlyingToggleCooldown)
            {
                isActive = !isActive;
                freeFlyingToggleCooldown = true;
            }
            else if (state.IsKeyUp(toggleKey) && freeFlyingToggleCooldown)
            {
                freeFlyingToggleCooldown = false;
            }

            if (isActive)
            {
                Vector2 velocity = behaviourContext.BodyComp.Velocity;
                float curX = 0;
                float curY = 0;

                if (state.IsKeyDown(Keys.W))
                {
                    curY -= 3;
                }
                if (state.IsKeyDown(Keys.A))
                {
                    curX -= 3;
                }
                if (state.IsKeyDown(Keys.D))
                {
                    curX += 3;
                }
                if (state.IsKeyDown(Keys.S))
                {
                    curY += 3;
                }

                velocity.X = curX;
                velocity.Y = curY;

                behaviourContext.BodyComp.Velocity = velocity;
            }

            return true;
        }
    }
}
