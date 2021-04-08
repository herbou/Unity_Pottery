using UnityEngine ;

public class Coll : MonoBehaviour {
   public int index ;

   BoxCollider boxCollider ;

   private void Awake () {
      boxCollider = GetComponent<BoxCollider> () ;
      index = transform.GetSiblingIndex () ;
   }

   public void HitCollider (float damage) {
      // Resize the collider's height(Y) depends on "damage" 
      if (boxCollider.size.y - damage > 0.0f)
         boxCollider.size = new Vector3 (boxCollider.size.x, boxCollider.size.y - damage, boxCollider.size.z) ;
      else
         Destroy (this) ; // Remove Coll Component from this gameobject
   }
}
