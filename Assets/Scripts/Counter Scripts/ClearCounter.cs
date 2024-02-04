using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField]
    private KitchenObjectsSO  KitchenObjectsSO;
  


    public override void Interact(Player player)
    {   
        if(!HasKitchenObject())//there is no kitchen object on table 
        {
            //There is no KitchenObject here
            if(player.HasKitchenObject())//player has kitchen object on hand and table has no
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else//both table and player has no kitchen object
            {
                //Player not carrying anything
            }
        }
        else//kitchen object on table
        {
            //There is a KitchenObject here
            if(player.HasKitchenObject())//both player and table has kitchen object
            {
                //player is carrying something
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //Player is holding plate
                    if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectsSO()))
                    {
                        GetKitchenObject().DestroySelf();

                    }

                }
                else
                {
                    //Player is not carrying Plate but something else
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject))//checnk if plate is on counter
                    {
                        //Counter is holding Plate
                        if(plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectsSO()))//add the kitchen object to the plate on counter
                        {
                            player.GetKitchenObject().DestroySelf();//destroy kitchen object with player
                        }
                    }
                }

            }
            else//only table has kitchen object
            {
                //Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }    
    }

   

}
