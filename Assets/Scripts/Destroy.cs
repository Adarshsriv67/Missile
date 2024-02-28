using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    private float _time;

    void Start()
    {
        //_ time ka matlab is object ko destroy karo _time seconds baad
        Destroy(this.gameObject, _time);
    }
}
