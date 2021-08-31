using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool direccion;

    [SerializeField] GameObject CorazonesLlenos;

    [SerializeField] Sprite CorazonesVacios;
    [SerializeField] int Vida;



    private float minX;
    private float maxX;



    // Start is called before the first frame update
    void Start()
    {
        Vector2 EsquinaID = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        maxX = EsquinaID.x;

        Vector2 EsquinaII = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = EsquinaII.x;
       GeneracionCorazones();

    }

    // Update is called once per frame
    void Update()
    {

        

        if (direccion)
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if (transform.position.x >= maxX)
            direccion = false;
        else if (transform.position.x <= minX)
            direccion = true;


    } 
  
    void GeneracionCorazones()
    {
        if (Vida >= 0)
        {
            for (int i = 0; i < Vida; i++)
           {
                float h = i;
                GameObject Cor = Instantiate(CorazonesLlenos,transform.position + new Vector3(h*0.2f-0.5f,1f,0),Quaternion.identity );

                Cor.transform.parent = transform;
            }
            
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Proyectil"))
        {
            if(Vida<=1)
            {
                Destroy(this.gameObject);
            }else
            {
                this.gameObject.transform.GetChild(Vida - 1).GetComponent<SpriteRenderer>().sprite = CorazonesVacios;
                Vida -= 1;
            }
        }
        else if (collision.gameObject.CompareTag("SuperProyectil"))
        {
            if (Vida <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                for (int j=0; j<2;j++)
                {
                    this.gameObject.transform.GetChild(Vida - 1).GetComponent<SpriteRenderer>().sprite = CorazonesVacios;
                    Vida -= 1;
                }
            }
        }
    }
}
