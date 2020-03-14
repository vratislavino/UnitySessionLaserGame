using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityController : MonoBehaviour
{
    public Text gravityText;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Physics.gravity = new Vector3(0, Physics.gravity.y + 0.1f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Physics.gravity = new Vector3(0, Physics.gravity.y - 0.1f, 0);
        }
        gravityText.text = "Gravitace: " + Physics.gravity.y;
    }

}
