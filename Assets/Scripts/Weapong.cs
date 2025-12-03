using UnityEngine;
using StarterAssets;
using Unity.Mathematics;

public class Weapong : MonoBehaviour
{
    StarterAssetsInputs starterAssetInputs;

    [SerializeField] int damageAmount = 1;

    [SerializeField] ParticleSystem muzzle;

    [SerializeField] Animator animator;

    [SerializeField] GameObject HitVfxPrefabs;

    string SHOOT_STRING = "Shoot";

    // Performans için kamerayı burada saklayalım
    private Camera _mainCamera;

    private void Awake()
    {
        // Script, PlayerArmature veya kök objede ise bu çalışır.
        starterAssetInputs = GetComponentInParent<StarterAssetsInputs>();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        // Eğer input null gelirse hata vermesin diye kontrol (Opsiyonel ama güvenli)
        if (starterAssetInputs == null) return;

        if (starterAssetInputs.shoot)
        {
            Shoot(); // Ateş etme işlemini fonksiyona ayırmak daha temizdir

            // ÖNEMLİ: Ateş ettikten sonra tetiği "kapatıyoruz".
            // Böylece update döngüsü tekrar başa döndüğünde sürekli ateş etmez.
            starterAssetInputs.shoot = false;
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        muzzle.Play();
        animator.Play(SHOOT_STRING, 0, 0f);

        // Kameranın ortasından ileriye doğru sonsuz bir çizgi
        if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(HitVfxPrefabs , hit.point ,quaternion.identity);
            EnemyHealth enemyhealth = hit.collider.GetComponent<EnemyHealth>();
            enemyhealth?.TakeDamage(damageAmount);
        }
        else
        {
            Debug.Log("Iska (Boşluk)");
        }
    }
}