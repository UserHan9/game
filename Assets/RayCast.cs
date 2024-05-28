using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public class RayCast : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float fireCooldown;
    public bool automatic;
    public float CurretnCooldown;

    private void Start()
    {
        CurretnCooldown = fireCooldown;
    }


    private void Update()
    {
        if (automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if(CurretnCooldown <= 0)
                {
                    OnGunShoot?.Invoke();
                    CurretnCooldown = fireCooldown;
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown (0)) { 
            if(CurretnCooldown<= 0) {
                    OnGunShoot?.Invoke();
                    CurretnCooldown =fireCooldown;
                
                }

            }
        }
        CurretnCooldown -= Time.deltaTime;
    }


}
