using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player player;
    private float footStepTimer;
    private float footStepTimeerMax = 0.1f;//10 times per second

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footStepTimer -= Time.deltaTime;
        if(footStepTimer < 0f)
        {
            footStepTimer = footStepTimeerMax;


            if(player.IsWalking())
            {
                float volume = 1f;
                SoundManager.Instance.PlayFootStepsSound(player.transform.position, volume);
            }
            
        }
    }

}
