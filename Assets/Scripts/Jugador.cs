using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject Bala;
    [SerializeField] GameObject SuperBala;
   
    [SerializeField] bool TipoBala;
    [SerializeField] float NextFire;
    
    [SerializeField] float Carga;

    float minX, maxX, minY, maxY, tamX, tamY, canFire;

    // Start is called before the first frame update
    void Start()
    {
        tamX = (GetComponent<SpriteRenderer>()).bounds.size.x;
        tamY = (GetComponent<SpriteRenderer>()).bounds.size.y;

        Vector2 EsquinaSD = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = EsquinaSD.x - tamX/2;
        maxY = EsquinaSD.y - tamY/2;

        Vector2 EsquinaII = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = EsquinaII.x + tamX/2;
        minY = EsquinaII.y + 7;

     
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Disparo();
    }

    void Movimiento()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed));


        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y, minY, maxY);


        transform.position = new Vector2(newX, newY);
    }

    void Disparo()
    {
        if(Input.GetKeyUp(KeyCode.Z) && TipoBala==true)
        {
            TipoBala = false;
        }
        else if(Input.GetKeyUp(KeyCode.Z) && TipoBala == false)
        {
            TipoBala = true;
        }

        if(Input.GetKey(KeyCode.Space))
        {
                Carga++ ;
           
        }
        else if (Carga < 200)
        {
            Carga = 0;
        }

      

        if (TipoBala==true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= canFire)
            {
                Instantiate(Bala, transform.position - new Vector3(0, tamY / 2, 0), transform.rotation);
                canFire = Time.time + NextFire;
            }
        }
        else if(TipoBala == false)
        {

            if (Input.GetKeyUp(KeyCode.Space) && Carga >= 200)
            {
                Instantiate(SuperBala, transform.position - new Vector3(0, tamY / 2, 0), transform.rotation);
                
                Carga = 0;
                

            }
            
         }

        }

    }

