using UnityEngine;
using System.Collections;

public class TowerAnimationScript : MonoBehaviour {
    private Animator animator;
    public bool amIFacingRight = true;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	public void IdleAnimation()
    {
		if(animator!=null)
        animator.SetBool("doIHaveTarget", false);
    }

    public void ShootingAnimation()
    {
		if(animator!=null)
        animator.SetBool("doIHaveTarget", true);
    }

    public void Flip()
    {
        amIFacingRight =! amIFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
