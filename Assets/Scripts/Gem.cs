using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class Gem : MonoBehaviour
{
    [SerializeField] private int _gemID; // 0 = red, 1 = green, 2 = blue
    [SerializeField] private ARSelectionInteractable _selection;

    private bool _pressed = false;
    
    Material _gemMaterial;
    Color _emissiveColor;

    private void OnEnable()
    {
        BoxManager.correctOrder += BoxOpened;
        BoxManager.incorrectOrder += ResetEmission;
    }

    void Start()
    {
        _gemMaterial = GetComponent<MeshRenderer>().material;
        _emissiveColor = _gemMaterial.GetColor("_EmissionColor");
        ResetEmission();
    }

    public void Pressed()
    {
        if (!_pressed)
        {
            _pressed = true;
            _gemMaterial.SetColor("_EmissionColor", _emissiveColor);
            BoxManager.Instance.GemPressed(_gemID);
        }
    }

    private void BoxOpened()
    {
        _selection.enabled = false;
    }

    private void ResetEmission()
    {
        _gemMaterial.SetColor("_EmissionColor", Color.black);
        _pressed = false;
    }

    private void OnDisable()
    {
        BoxManager.correctOrder -= BoxOpened;
        BoxManager.incorrectOrder -= ResetEmission;
    }
}
