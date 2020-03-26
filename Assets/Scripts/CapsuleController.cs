using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    private Perk perk;
    public float standardMoveSpeed = 5f;
    public float rotateSpeed = 550f;
    public float jumpHeigth = 1000f;
    public float gravityForce = 98f;

    private float moveSpeed;
    private Rigidbody Rigidbody;
    private Renderer Renderer;


    public void PowerUp() {
        perk.activate();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
        perk = new Perk();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = perk.speedMultiplier() * standardMoveSpeed;
        if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            
        if(Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            
        if(Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            
        if(Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space)) {
            Rigidbody.AddForce(new Vector3(0, jumpHeigth, 0));
        }
            
        if(Input.GetKey(KeyCode.Q))
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
            
        if(Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    
        Renderer.material.color = perk.tick(Time.deltaTime);
        Rigidbody.AddForce(new Vector3(0, -gravityForce, 0) );
    }
}

class Perk {
    public static int ON = 1;
    public static int OFF = 0;
    public static int speedMultiplVal = 3;

    private int state = Perk.OFF;
    private float duration;
    private float interchange;
    private float currentTime;
    private Color defaultCol {set;get;}
    private Color[] colors;

    public Perk(float duration=2f, float interchange=0.05f) {
        this.defaultCol = new Color(255,255,255);
        this.currentTime = 0f;
        this.duration = duration;
        this.interchange = interchange;
        colors = new Color[]{
            new Color(150, 150, 0),
            new Color(0, 150, 150),
            new Color(150, 0, 150)
        };
    }

    public void activate() {
        state = Perk.ON;
        currentTime = 0;
    }

    public Color tick(float deltaTime) {
        if(state == Perk.OFF)
            return defaultCol;

        currentTime += deltaTime;
        if(currentTime > duration) {
            state = Perk.OFF;
            return defaultCol;
        }
        
        int index = ((int)(currentTime/interchange))%colors.Length;
        return colors[index];
    }

    public int speedMultiplier() {
        if(state == Perk.ON) 
            return Perk.speedMultiplVal;
        return 1;
    }
}