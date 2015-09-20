using UnityEngine;
using System.Collections;

public class Physics : MonoBehaviour {
	// Use this for initialization
    public float eVal = 1f;
    public Vector3 normal = new Vector3(0,1,0);
	void Start () {
        if(this.gameObject.name == "S1")
        this.GetComponent<Rigidbody>().AddForce((Vector3.right + Vector3.down) * 3000f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other){
        //SimpleElasticCollision(other);                                
        //other.contacts[0].
        ImpuslsiveCollision(other);
  
    }

    void SimpleElasticCollision(Collision other)
    {
        Vector3 _vel1 = other.rigidbody.velocity;
        Vector3 _vel2 = this.GetComponent<Rigidbody>().velocity;

        float mass1 = other.rigidbody.mass;
        float mass2 = this.GetComponent<Rigidbody>().mass;

        Vector3 _delV1 = ((mass1 - mass2) * _vel1 + 2 * (mass2 * _vel2)) / (mass1 + mass2);
        Vector3 _delV2 = ((mass2 - mass1) * _vel2 + 2 * (mass1 * _vel1)) / (mass1 + mass2);
        _delV2 = new Vector3(_delV2.x, -_delV2.y, _delV2.z);
        other.rigidbody.velocity = _delV2;
        this.GetComponent<Rigidbody>().velocity = _delV1;

        Debug.Log("Check");

    }

    void ImpuslsiveCollision(Collision other)
    {
        Vector3 _vel1 = other.rigidbody.velocity;
        Vector3 _vel2 = this.GetComponent<Rigidbody>().velocity;
       // other.rigidbody.useGravity = false;

        float mass1 = other.rigidbody.mass;
        float invmass1 = 1 / mass1;
        float invmass2 = 0;
        float mass2 = this.GetComponent<Rigidbody>().mass;
        Vector3 rVel = _vel1 - _vel2;

        float numer = Vector3.Dot(((eVal + 1) * rVel), normal);
        float denom = Vector3.Dot(((invmass1 + invmass2) * normal), normal);
        float k1 = numer / denom;

        _vel2 = _vel2 + (k1 * normal) * invmass2;
        _vel1 = _vel1 - (k1 * normal) * invmass1;
        this.gameObject.GetComponent<Rigidbody>().velocity = _vel2;
        other.gameObject.GetComponent<Rigidbody>().velocity = _vel1;
        Debug.Log(k1 + "K1");
      
  
    }


}
