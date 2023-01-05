using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelecter : MonoBehaviour
{
    public int CurrentCar;

    private void SelectionCar(int Index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == Index);
        }
    }

    public void ChangeCar(int change)
    {
        CurrentCar += change;
        SelectionCar(CurrentCar);
    }
}
