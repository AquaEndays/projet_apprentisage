using UnityEngine;
public class CodeMouvement : MonoBehaviour
{
    
    public CharacterController moteurDeDeplacement;
    public Animator monAnimateur;
    private float vitesseVerticale = 0f;
    public float forceDeSaut = 6f;
    public float gravite = -9.81f;
    float vitesse = 4f;

    void Start()
    {
        if (monAnimateur == null)
        {
            monAnimateur = GetComponent<Animator>();
        }
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);
        if (move.magnitude > 0)
        {
            transform.forward = move;
            moteurDeDeplacement.Move(move *vitesse* Time.deltaTime);
            // Prends 0.15 seconde pour faire grimper la valeur proprement
            monAnimateur.SetFloat("Speed", z, 0.05f, Time.deltaTime);
            //monAnimateur.SetFloat("Direction", x, 0.15f, Time.deltaTime);
        }
        else
        {
            monAnimateur.SetFloat("Speed", 0, 0.15f, Time.deltaTime);
            //monAnimateur.SetFloat("Direction", 0, 0.15f, Time.deltaTime);
        }

        if (moteurDeDeplacement.isGrounded)
        {
            vitesseVerticale = -2f;
            if(Input.GetButtonDown("Jump"))
            {
                vitesseVerticale = forceDeSaut;
                monAnimateur.SetTrigger("Jump");
            }
        }else
        {
            vitesseVerticale += gravite * Time.deltaTime;
        }
        Vector3 saut = new Vector3(0, vitesseVerticale, 0);
        moteurDeDeplacement.Move(saut * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftControl) && move.magnitude > 0)
        {
            monAnimateur.SetTrigger("Slide");
        }


 
    }

}
