using UnityEngine;

public class playerOnDeath : OnDeath
{
    public GameObject playerObj;
    public playerScript player;
    public RespawnScript respawner;


    private void Reset()
    {
    }

    private void Update()
    {
    }

    public void AnimationDoneAction()
    {
        player.dead = true;
        playerObj.SetActive(false);
        respawner.TriggerRespawn();
    }

    public override void killEntity()
    {
        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.player_die);
        player.dying = true;
        player.rb.linearVelocity = new Vector2(0, 0);
        player.rb.gravityScale = 0;
    }
}
