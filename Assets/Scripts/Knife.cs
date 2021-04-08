using UnityEngine ;

public class Knife : MonoBehaviour {
   [SerializeField] private float movementSpeed ;
   [SerializeField] private float hitDamage ;
   [SerializeField] private Wood wood ;

   [SerializeField] private ParticleSystem woodFx ;

   private ParticleSystem.EmissionModule woodFxEmission ;

   private Rigidbody knifeRb ;
   private Vector3 movementVector ;
   private bool isMoving = false ;

   private void Start () {
      knifeRb = GetComponent<Rigidbody> () ;

      woodFxEmission = woodFx.emission ;
   }

   private void Update () {
      isMoving = Input.GetMouseButton (0) ;

      if (isMoving)
         movementVector = new Vector3 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0f) * movementSpeed * Time.deltaTime ;
   }

   private void FixedUpdate () {
      if (isMoving)
         knifeRb.position += movementVector ;
   }

   private void OnCollisionExit (Collision collision) {
      woodFxEmission.enabled = false ;
   }

   private void OnCollisionStay (Collision collision) {
      Coll coll = collision.collider.GetComponent <Coll> () ;
      if (coll != null) {
         // hit Collider:
         woodFxEmission.enabled = true ;
         woodFx.transform.position = collision.contacts [ 0 ].point ;

         coll.HitCollider (hitDamage) ;
         wood.Hit (coll.index, hitDamage) ;
      }
   }
}
