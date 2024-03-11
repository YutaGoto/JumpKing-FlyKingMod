using EntityComponent;
using JumpKing.Mods;
using JumpKing.Player;

namespace JumpKing_FreeFlyKingMod
{ 
    [JumpKingMod("YutaGoto.FreeFlyKingMod")]
    public class ModEntry
    {
        [OnLevelStart]
        public static void OnLevelStart()
        {
            PlayerEntity player = EntityManager.instance.Find<PlayerEntity>();
            if (player != null)
            {
                player.m_body.RegisterBehaviour(new Behaviours.FreeFlyKingBehaviour());
            }
        }
    }
}
