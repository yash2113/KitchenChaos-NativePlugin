using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter,    IKitchenObjectParent
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField]
    private KitchenObjectsSO KitchenObjectsSO;



    public override void Interact(Player player)
    {   
        if(!player.HasKitchenObject())
        {
            KitchenObject.SpawnKitchenObject(KitchenObjectsSO, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
      
    }



}
