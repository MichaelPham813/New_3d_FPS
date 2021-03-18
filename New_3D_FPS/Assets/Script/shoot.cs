
using UnityEngine;
using TMPro;

public class shoot : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public GameObject bullet;
    public float shootForce;

    //Graphics
    public GameObject muzzleFlash;
    //public CamShake camShake;
    // public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    public Animator anim;
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        MyInput();
        //SetText
        text.SetText(bulletsLeft.ToString());
        //OnDrawGizmosSelected();
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) {
            Reload();
            anim.SetTrigger("Reload");
            }

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = bulletsPerTap;
            Shoot();
            
        }
    }
  
    // public LineRenderer laser;
    // private void OnDrawGizmosSelected()
    // {
    //     Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
    //     RaycastHit hit; 
        
    //     if(Physics.Raycast(ray,out hit)){
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawLine(attackPoint.position,hit.point);
    //         // laser.SetColors(Color.green,Color.green);
    //         // laser.SetPosition(0,attackPoint.position);
    //         // laser.SetPosition(1,hit.point);
    //     }
    //     else    {
    //         Gizmos.color = Color.green;
    //         Gizmos.DrawLine(attackPoint.position,ray.GetPoint(75));     
    //         // laser.SetColors(Color.green,Color.green);
    //         // laser.SetPosition(0,attackPoint.position);
    //         // laser.SetPosition(1,ray.GetPoint(75));  
    //     }
    // }

	

    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit; 

        

        Vector3 targetPoint = ray.GetPoint(75);
        // if(Physics.Raycast(ray,out hit))
        //     targetPoint = hit.point;
        //     else    targetPoint = ray.GetPoint(75);

        Vector3 direction = (targetPoint - new Vector3(x, y, 0) ) - attackPoint.position ;
{
//shoot by Raycast
        //Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);
        //RayCast
        // if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        // {
        //     Debug.Log(rayHit.collider.name);

        //     if (rayHit.collider.CompareTag("Enemy"))
        //         rayHit.collider.GetComponent<TakeDamage>().TakeDamages(damage);
        // }

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        // Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
}

//Muzzle control
        // if(allowButtonHold){
        //     muzzleFlash.GetComponent<ParticleSystem>().loop = true;
        //     muzzleFlash.GetComponent<ParticleSystem>().Play();
        // }else{
        //     muzzleFlash.GetComponent<ParticleSystem>().loop = false;
        //     muzzleFlash.GetComponent<ParticleSystem>().Play();
        // }
        muzzleFlash.GetComponent<ParticleSystem>().Play();
        GameObject curBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        curBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce,ForceMode.Impulse);

        gameObject.GetComponent<AudioSource>().Play();
        anim.SetTrigger("Shoot");

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}