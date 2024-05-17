using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class Gem : MonoBehaviour
{
    [SerializeField] private int _gemID; // 0 = red, 1 = green, 2 = blue
    [SerializeField] private ARSelectionInteractable _selection;

    private void OnEnable()
    {
        BoxManager.correctOrder += BoxOpened;
        BoxManager.incorrectOrder += ResetEmission;
    }

    public void Pressed()
    {
        BoxManager.Instance.GemPressed(_gemID);
    }

    private void BoxOpened()
    {
        _selection.enabled = false;
    }

    private void ResetEmission()
    {
        //reset emission here
    }

    private void OnDisable()
    {
        BoxManager.correctOrder -= BoxOpened;
        BoxManager.incorrectOrder -= ResetEmission;
    }
}
