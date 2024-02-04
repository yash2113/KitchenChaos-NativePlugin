using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectsSO kitchenObjectSO;
    }


    [SerializeField]
    private List<KitchenObjectsSO> validKitchenObjectSOList;

    private List<KitchenObjectsSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectsSO>();
    }

    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {
        if(!validKitchenObjectSOList.Contains(kitchenObjectsSO))
        {
            //Not a valid Ingredient
            return false;
        }

        if (kitchenObjectSOList.Contains(kitchenObjectsSO))
        {
            //Already has this type
            //to make game simple and remove duplicate items
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectsSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectsSO
            });
            return true;
        
        }
    }

    public List<KitchenObjectsSO> GetKitchenObjectsSOList()
    {
        return kitchenObjectSOList;
    }

}
