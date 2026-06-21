using UnityEngine;
public class CodeMouvement : MonoBehaviour
{
    
    public CharacterController moteurDeDeplacement;
    public Animator monAnimateur;
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
        moteurDeDeplacement.Move(move *vitesse* Time.deltaTime);
// Prends 0.15 seconde pour faire grimper la valeur proprement
monAnimateur.SetFloat("Speed", z, 0.15f, Time.deltaTime);
monAnimateur.SetFloat("Direction", x, 0.15f, Time.deltaTime);
    }

}
