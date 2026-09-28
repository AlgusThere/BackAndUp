using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    PlayerInput playerInput;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        
    }
}
