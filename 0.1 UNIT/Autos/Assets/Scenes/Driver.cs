using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 5f;
    [SerializeField] float moveSpeed = 5f;
// Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(0,0,45); //solo se mueve al iniciar
    }
    
    
    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed *Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    
   



}
