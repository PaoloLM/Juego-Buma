using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    public float velocidad = 2;
    public int puntaje = 0;

    public GameObject col;
    public GameObject piedra1;
    public GameObject piedra2;
    public GameObject arbol1;
    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    public GameObject treand;

    public GameObject puntuador;

    public Renderer fondo;

    public List<GameObject> cols;
    public List<GameObject> obstaculos;
    public List<GameObject> arboles1;
    public List<GameObject> arboles2;
    public List<GameObject> Enemigo1;

    public bool start = false;
    public bool gameOver = false;
    public bool sonidosalto = false;



    // Start is called before the first frame update
    void Start()
    {
        //Creando mapa
        for (int i = 0; i <= 21 ; i++) {
            cols.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity));
        }   

        //Crear Piedras
        obstaculos.Add(Instantiate(piedra1, new Vector2(5, -3), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(12, -3), Quaternion.identity));

        arboles1.Add(Instantiate(arbol1, new Vector2(-4, -2), Quaternion.identity));
        arboles1.Add(Instantiate(arbol1, new Vector2(0, -2), Quaternion.identity));
        arboles1.Add(Instantiate(arbol1, new Vector2(4, -2), Quaternion.identity));
        arboles1.Add(Instantiate(arbol1, new Vector2(8, -2), Quaternion.identity));

        arboles2.Add(Instantiate(arbol1, new Vector2(8, -2), Quaternion.identity));
        arboles2.Add(Instantiate(arbol1, new Vector2(12, -2), Quaternion.identity));
        arboles2.Add(Instantiate(arbol1, new Vector2(16, -2), Quaternion.identity));
        arboles2.Add(Instantiate(arbol1, new Vector2(20, -2), Quaternion.identity));

        Enemigo1.Add(Instantiate(treand, new Vector2(10, -2.6f), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false) {
            if(Input.GetKeyDown(KeyCode.X)) {            
                start = true;
            }
        }

        if (start == true && gameOver == true) {

            menuGameOver.SetActive(true);

            if(Input.GetKeyDown(KeyCode.X)) {    
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
            }
        }
        
        if (start == true && gameOver == false) {

            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.05f , 0) * Time.deltaTime;

            //Mover mapa
            for (int i = 0; i < cols.Count ; i++) {
                if(cols[i].transform.position.x <= -10){
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }
                if(puntaje > 100)
                {
                    cols[i].transform.position = cols[i].transform.position + new Vector3(-2.7f, 0, 0) * Time.deltaTime * velocidad;
                }
                else
                {
                    cols[i].transform.position = cols[i].transform.position + new Vector3(-2, 0, 0) * Time.deltaTime * velocidad;
                }
            }

            //Mover arboles 1
            for (int i = 0; i < arboles1.Count ; i++) {
                if(arboles1[i].transform.position.x <= -10){
                    float randomObs = Random.Range(12, 25);
                    arboles1[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                if (puntaje > 100)
                {
                    arboles1[i].transform.position = arboles1[i].transform.position + new Vector3(-2.1f, 0, 0) * Time.deltaTime * velocidad;
                }
                else
                {
                    arboles1[i].transform.position = arboles1[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                }
            }

            //Mover arboles 2
            for (int i = 0; i < arboles2.Count ; i++) {
                if(arboles2[i].transform.position.x <= -10){
                    float randomObs = Random.Range(24, 37);
                    arboles2[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                if (puntaje > 100)
                {
                    arboles2[i].transform.position = arboles2[i].transform.position + new Vector3(-2.1f, 0, 0) * Time.deltaTime * velocidad;
                }
                else
                {
                    arboles2[i].transform.position = arboles2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                }
            }

            //Mover obstaculos
            for (int i = 0; i < obstaculos.Count ; i++) {
                if(obstaculos[i].transform.position.x <= -10){
                    float randomObs = Random.Range(15, 20);
                    obstaculos[i].transform.position = new Vector3(randomObs, -3, 0);
                    puntaje += 10;
                }
                if (puntaje > 100)
                {
                    obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-2.7f, 0, 0) * Time.deltaTime * velocidad;
                }
                else
                {
                    obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-2, 0, 0) * Time.deltaTime * velocidad;
                }
            }

            //Mover enemigos
            for (int i = 0; i < Enemigo1.Count ; i++) {
                if(Enemigo1[i].transform.position.x <= -10){
                    float randomObs = Random.Range(15, 20);
                    Enemigo1[i].transform.position = new Vector3(randomObs, -2.6f, 0);
                    puntaje += 10;
                }
                if (puntaje > 100)
                {
                    Enemigo1[i].transform.position = Enemigo1[i].transform.position + new Vector3(-2.7f, 0, 0) * Time.deltaTime * velocidad;
                }
                else
                {
                    Enemigo1[i].transform.position = Enemigo1[i].transform.position + new Vector3(-2, 0, 0) * Time.deltaTime * velocidad;
                }
            }

            //PUNTAJE
            puntuador.GetComponent<UnityEngine.UI.Text>().text = puntaje.ToString();
        }        
    }
}
