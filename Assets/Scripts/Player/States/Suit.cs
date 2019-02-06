using UnityEngine;
using System.Collections;

public class Suit : MonoBehaviour
{
    [SerializeField] private MeshRenderer suitMesh;

    public Skill passive;
    public Skill basicAttack;
    public Skill ability1;
    public Skill ability2;

    private Controller controller;

    private void Start()
    {
        controller = Controller.instance;
    }

    private void OnEnable()
    {
        suitMesh.enabled = true;
    }

    public void OnSuitChange()
    {

    }

    private void OnDisable()
    {
        suitMesh.enabled = false;
    }
}
