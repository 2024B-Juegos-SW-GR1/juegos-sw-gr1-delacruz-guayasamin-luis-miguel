using UnityEngine;

public class Follow : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private GameObject cosaASeguir; 
    void LateUpdate()
    {
        transform.position = cosaASeguir.transform.position + new Vector3(0, 0, -10);
    }
}