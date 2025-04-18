using UnityEngine;

public class AirState : PlayerState
{
    public JumpState jumpState;
    public DashState dashState;

    public EffectGenerator landGenerator;

    public override void Do()
    {
        Set(jumpState);

        if (groundSens.isGrounded) {
            isComplete = true;
        }
    }


    public override void Exit()
    {
        base.Exit();
        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.land);
        landGenerator.generate();
    }
}
